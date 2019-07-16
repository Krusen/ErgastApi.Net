using System;
using System.Threading.Tasks;
using ErgastApi.Abstractions;
using ErgastApi.Client.Caching;
using ErgastApi.Requests;
using ErgastApi.Responses;
using JsonExts.JsonPath;
using Newtonsoft.Json;

namespace ErgastApi.Client
{
    /// <inheritdoc cref="IErgastClient"/> />
    /// <summary>
    /// A client for querying the Ergast API.
    /// </summary>
    public class ErgastClient : IErgastClient, IDisposable
    {
        private string _apiBase = "https://ergast.com/api/f1";

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
        /// Gets or sets the <see cref="IErgastCache"/> used to cache the responses from the API.
        /// </summary>
        public IErgastCache Cache { get; set; } = new ErgastMemoryCache();

        /// <summary>
        /// Creates an <see cref="ErgastClient"/> using the default API base URL.
        /// </summary>
        public ErgastClient()
        {
        }

        /// <summary>
        /// Creates an <see cref="ErgastClient"/> using the specified API base URL.
        /// </summary>
        /// <param name="apiBase"></param>
        public ErgastClient(string apiBase)
        {
            ApiBase = apiBase;
        }

        /// <summary>
        /// Executes the request and returns a parsed response of type <typeparamref name="TResponse"/>.
        /// </summary>
        /// <typeparam name="TResponse">The type of the returned response.</typeparam>
        /// <param name="request">The request to execute.</param>
        /// <returns></returns>
        public async Task<TResponse> GetResponseAsync<TResponse>(ErgastRequest<TResponse> request) where TResponse : ErgastResponse
        {
            var url = ApiBase + UrlBuilder.Build(request);

            var response = Cache.Get<TResponse>(url);
            if (response != null)
                return response;

            EnsureValidRequest(request);

            var responseMessage = await HttpClient.GetAsync(url).ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();

            var content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var rootResponse = JsonConvert.DeserializeObject<ErgastRootResponse<TResponse>>(content, SerializerSettings);

            if (rootResponse == null)
                throw new Exception("Received an invalid response." + Environment.NewLine + "Response: " + content);

            response = rootResponse.Data;
            Cache.AddOrReplace(url, response);

            return response;
        }

        /// <summary>
        /// Ensures the request is valid and otherwise throws an exception.
        /// </summary>
        /// <exception cref="InvalidOperationException">The request is invalid</exception>
        protected void EnsureValidRequest(IErgastRequest request)
        {
            if (request?.Round != null && request?.Season == null)
                throw new InvalidOperationException("When specifying ErgastRequest.Round you also have to specify ErgastRequest.Season.");
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
            Cache?.Dispose();
        }

        private class ErgastRootResponse<T>
        {
            [JsonProperty("MRData")]
            public T Data { get; set; }
        }
    }
}
