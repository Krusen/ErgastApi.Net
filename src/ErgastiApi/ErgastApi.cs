using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ErgastApi.Interfaces.Responses;
using ErgastApi.Models;
using ErgastApi.Queries;
using ErgastApi.Responses;
using Query = ErgastApi.Models.Query;

namespace ErgastApi
{
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

        public ErgastApi()
            : this(new ResponseParser())
        {

        }

        public ErgastApi(IResponseParser responseParser)
        {
            ResponseParser = responseParser;
        }

        public ErgastApi(string apiRoot)
            : this(apiRoot, new ResponseParser())
        {

        }

        public ErgastApi(string apiRoot, IResponseParser responseParser)
            : this(responseParser)
        {
            ApiRoot = apiRoot;
        }

        public IEmptyQuery BeginQuery()
        {
            return new Query();
        }

        public RaceResponse Execute(IQuery query)
        {
            throw new NotImplementedException("Use async version for now");
        }

        // TODO: We need one for each type of response/query because of the return type
        public async Task<RaceResponse> ExecuteAsync(IQuery query)
        {
            var url = ApiRoot + query.BuildUrl();

            Console.WriteLine("Executing: " + url);

            var data = await HttpClient.GetStringAsync(url);

            var response = ResponseParser.Parse(data);

            return response;
        }
    }
}
