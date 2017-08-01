using System;
using System.Net.Http;
using System.Threading.Tasks;
using ErgastApi.Client.Caching;
using ErgastApi.Requests;
using ErgastApi.Responses;
using ErgastApi.Serialization;
using Newtonsoft.Json;

namespace ErgastApi.Client
{
    public class ErgastClient : IDisposable, IErgastClient
    {
        private string _apiRoot = "https://ergast.com/api/f1";

        private JsonSerializerSettings SerializerSettings { get; } = new JsonSerializerSettings { ContractResolver = new JsonPathContractResolver() };

        public string ApiRoot
        {
            get => _apiRoot;
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                    throw new ArgumentException("Value is not a valid absolute URL");

                if (!value.StartsWith("http://") && !value.StartsWith("https://"))
                    throw new ArgumentException("Value is not a valid absolute URL");

                _apiRoot = value.TrimEnd('/');
            }
        }

        // TODO: Interface for unit tests?
        public HttpClient HttpClient { get; set; } = new HttpClient();

        public IUrlBuilder UrlBuilder { get; set; } = new UrlBuilder();

        public IErgastCache Cache { get; set; } = new ErgastMemoryCache();

        public ErgastClient()
        {
        }

        public ErgastClient(string apiRoot)
        {
            ApiRoot = apiRoot;
        }

        public ErgastClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public ErgastClient(string apiRoot, HttpClient httpClient)
        {
            ApiRoot = apiRoot;
            HttpClient = httpClient;
        }

        public ErgastClient(HttpClient httpClient, IUrlBuilder urlBuilder)
        {
            HttpClient = httpClient;
            UrlBuilder = urlBuilder;
        }

        public async Task<T> ExecuteAsync<T>(ErgastRequest<T> request) where T : ErgastResponse
        {
            var url = ApiRoot + UrlBuilder.Build(request);

            // TODO: Remove this
            Console.WriteLine(url);

            var response = Cache.Get<T>(url);
            if (response != null)
                return response;

            EnsureValidRequest(request);

            var responseMessage = await HttpClient.GetAsync(url).ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();

            var content = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var rootResponse = JsonConvert.DeserializeObject<ErgastRootResponse<T>>(content, SerializerSettings);

            response = rootResponse.Data;
            Cache.AddOrReplace(url, response);

            return response;
        }

        protected void EnsureValidRequest(IErgastRequest request)
        {
            if (request.Round != null && request.Season == null)
                throw new Exception("You cannot specify a round without also specifying a season.");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
