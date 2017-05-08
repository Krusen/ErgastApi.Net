using System;
using System.Net.Http;
using System.Threading.Tasks;
using ErgastApi.Requests;
using ErgastApi.Responses;
using ErgastApi.Serialization;
using Newtonsoft.Json;

namespace ErgastApi
{
    public class ErgastClient
    {
        private string _apiRoot = "http://ergast.com/api/f1";

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

        // TODO: Interface?
        public HttpClient HttpClient { get; set; } = new HttpClient();

        public IUrlBuilder UrlBuilder { get; set; } = new UrlBuilder();

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

            Console.WriteLine(url);

            // TODO: Don't use GetStringAsync, instead use GetAsync - then we can handle errors better
            // TODO: Should probably be moved to its own wrapper with specific methods instead of using HttpClient directly
            var data = await HttpClient.GetStringAsync(url).ConfigureAwait(false);

            // TODO: Reuse/add to constructor?
            var settings = new JsonSerializerSettings { ContractResolver = new JsonPathContractResolver() };

            // TODO: Make all property setters private for all models/responses

            var obj = JsonConvert.DeserializeObject<ErgastRootResponse<T>>(data, settings);

            return obj.Data;
        }

        // TODO: Move and rename?
        private class ErgastRootResponse<T>
        {
            [JsonProperty("MRData")]
            public T Data { get; set; }
        }
    }
}
