using System;
using System.Threading;
using System.Threading.Tasks;
using ErgastApi.Abstractions;
using ErgastApi.Requests;
using ErgastApi.Responses;
using JsonExts.JsonPath;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Polly;
using Polly.Caching.Memory;

namespace ErgastApi.Client
{
    /// <inheritdoc cref="IErgastClient"/> />
    /// <summary>
    /// A client for querying the Ergast API.
    /// </summary>
    public class ErgastClient : IErgastClient, IDisposable
    {
        private string _apiBase = "https://ergast.com/api/f1";
        private IAsyncPolicy _pollyPolicy;

        private JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings {Converters = {new JsonPathObjectConverter()}};

        /// <summary>
        /// The Ergast API base URL. The default value is 'https://ergast.com/api/f1'.
        /// </summary>
        public string ApiBase
        {
            get => _apiBase;
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                    throw new ArgumentException("Value is not a valid absolute URL");

                if (!value.StartsWith("http://") && !value.StartsWith("https://"))
                    throw new ArgumentException("Value is not a valid absolute URL");

                _apiBase = value.TrimEnd('/');
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="IHttpClient"/> used to make HTTP requests.
        /// </summary>
        public IHttpClient HttpClient { get; set; } = new DefaultHttpClient();

        /// <summary>
        ///  Gets or sets the <see cref="IUrlBuilder"/> used to build the request URLs.
        /// </summary>
        public IUrlBuilder UrlBuilder { get; set; } = new UrlBuilder();

        /// <summary>
        /// The async Polly policy used to handle HTTP requests.
        /// The default policy caches responses for 1 hour.
        /// Change this to use a different strategy for retries, caching etc.
        /// See https://github.com/App-vNext/Polly for more information.
        /// </summary>
        public IAsyncPolicy PollyPolicy
        {
            get => _pollyPolicy;
            set => _pollyPolicy = value ?? Policy.NoOpAsync();
        }

        /// <summary>
        /// Creates an <see cref="ErgastClient"/> using the default API base URL.
        /// </summary>
        public ErgastClient()
        {
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var memoryCacheProvider = new MemoryCacheProvider(memoryCache);
            PollyPolicy = Policy.CacheAsync(memoryCacheProvider, TimeSpan.FromHours(1));
        }

        /// <summary>
        /// Executes the request and returns a parsed response of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the returned response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <param name="cancellationToken"></param>
        public virtual Task<TResponse> GetResponseAsync<TResponse>(ErgastRequest<TResponse> request, CancellationToken cancellationToken)
            where TResponse : ErgastResponse
        {
            var url = ApiBase + UrlBuilder.Build(request);

            request.Verify();

            var executionContext = new Context(url);
            return PollyPolicy.ExecuteAsync((context, token) => GetResponseAsync<TResponse>(url, token), executionContext, cancellationToken);
        }

        /// <summary>
        /// Executes the HTTP request to the specified URL and deserializes the response.
        /// </summary>
        /// <typeparam name="TResponse">The type the response should be deserialized to.</typeparam>
        /// <param name="url">The url being requested.</param>
        /// <param name="cancellationToken"></param>
        protected virtual async Task<TResponse> GetResponseAsync<TResponse>(string url, CancellationToken cancellationToken)
            where TResponse : ErgastResponse
        {
            using (var responseMessage = await HttpClient.GetAsync(url, cancellationToken).ConfigureAwait(false))
            {
                responseMessage.EnsureSuccessStatusCode();

                var content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                var rootResponse = JsonConvert.DeserializeObject<ErgastRootResponse<TResponse>>(content, SerializerSettings);

                if (rootResponse == null)
                    throw new Exception($"Received an invalid response.{Environment.NewLine}Response: {content}");

                var response = rootResponse.Data;

                return response;
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the <see cref="HttpClient"/> and <see cref="Cache"/>.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            HttpClient?.Dispose();
        }

        private class ErgastRootResponse<T>
        {
            [JsonProperty("MRData")]
            public T Data { get; set; }
        }
    }
}
