using System;
using System.Net.Http;
using System.Threading.Tasks;
using ErgastApi.Queries;
using ErgastApi.Responses;
using ErgastApi.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ErgastApi
{
    // TODO: Rename to something like ErgastApiClient to avoid ErgastApi.ErgastApi usage
    public class ErgastApi
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

        // TODO: Interface and put in constructor
        protected HttpClient HttpClient { get; set; } = new HttpClient();

        protected IResponseParser ResponseParser { get; set; }

        protected IQueryCompiler QueryCompiler { get; set; }

        public ErgastApi()
            : this(new ResponseParser(), new QueryCompiler())
        {

        }

        public ErgastApi(IResponseParser responseParser, IQueryCompiler queryCompiler)
        {
            ResponseParser = responseParser;
            QueryCompiler = queryCompiler;
        }

        public ErgastApi(string apiRoot)
            : this()
        {
            ApiRoot = apiRoot;
        }

        public ErgastApi(string apiRoot, IResponseParser responseParser, IQueryCompiler queryCompiler)
            : this(responseParser, queryCompiler)
        {
            ApiRoot = apiRoot;
        }

        public DriverResponse Execute(DriverInfoQuery query)
        {
            throw new NotImplementedException("Use async version for now");
        }

        public async Task<DriverResponse> ExecuteAsync(DriverInfoQuery query)
        {
            {
                var url = ApiRoot + QueryCompiler.Compile(query);

                Console.WriteLine("Executing: " + url);

                var data = await HttpClient.GetStringAsync(url).ConfigureAwait(false);

                // TODO: Reuse
                var settings = new JsonSerializerSettings
                {
                    //NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new PrivatePropertyResolver()
                };
                JsonConvert.DefaultSettings = () => settings;

                var json =  JsonConvert.DeserializeObject<JObject>(data);

                return json.SelectToken("MRData").ToObject<DriverResponse>();
            }
        }

        // TODO: We need one for each type of response/query because of the return type
        public async Task<RaceResponse> ExecuteAsync(IQuery query)
        {
            var url = ApiRoot + QueryCompiler.Compile(query);

            Console.WriteLine("Executing: " + url);

            var data = await HttpClient.GetStringAsync(url).ConfigureAwait(false);

            var response = ResponseParser.Parse(data);

            return response;
        }
    }
}
