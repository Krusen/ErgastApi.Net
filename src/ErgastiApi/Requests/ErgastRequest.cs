using System;
using System.Diagnostics;
using System.Threading.Tasks;
using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;
using ErgastApi.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Requests
{
    public abstract class ErgastRequest<TResponse> : IErgastRequest where TResponse : ErgastResponse
    {
        public ErgastRequestSettings Settings { get; }

        protected ErgastRequest()
            : this(ErgastRequestSettings.Defaults())
        {
        }

        protected ErgastRequest(ErgastRequestSettings settings)
        {
            Settings = settings;
        }

        private int? _limit;
        private int? _offset;

        public int? Limit
        {
            get => _limit;
            set
            {
                if (value < 0 || value > 1000)
                    throw new ArgumentOutOfRangeException(nameof(Limit), "Limit cannot be less than 0 or greater than 1000. Actual value: " + value);

                _limit = value;
            }
        }

        public int? Offset
        {
            get => _offset;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(Offset), "Offset cannot be lower than 0");

                _offset = value;
            }
        }

        [QueryMethod(Order = 1)]
        public virtual int? Season { get; set; }

        // TODO: Require season to be not null
        [QueryMethod(Order = 2)]
        [QueryDependency(nameof(Season))]
        public virtual int? Round { get; set; }

        [QueryMethod("drivers")]
        public virtual string DriverId { get; set; }

        public void Page(int page, int pageSize)
        {
            if (page < 1)
                throw new ArgumentOutOfRangeException(nameof(page), "Page number cannot be lower than 1");

            if (pageSize < 0 || pageSize > 1000)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size cannot be less than 0 or greater than 1000. Actual value: " + pageSize);

            Limit = pageSize;
            Offset = (page - 1) * pageSize;
        }

        protected virtual string BuildUrl()
        {
            return Settings.ApiRoot + Settings.UrlBuilder.Build(this);
        }

        public virtual async Task<TResponse> ExecuteAsync()
        {
            var url = BuildUrl();

            Console.WriteLine(url);

            // TODO: Don't use GetStringAsync, instead use GetAsync - then we can handle errors better
            // TODO: Should probably be moved to its own wrapper with specific methods instead of using HttpClient directly
            var data = await Settings.HttpClient.GetStringAsync(url).ConfigureAwait(false);

            // TODO: Reuse/add to constructor?
            var settings = new JsonSerializerSettings
            {
                //TraceWriter = new TraceWriter(),
                //ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new JsonPathContractResolver()
            };

            // TODO: Make all property setters private for all models/responses


            var obj = JsonConvert.DeserializeObject<ErgastRootResponse<TResponse>>(data, settings);


            return obj.Data;
        }

        public class TraceWriter : ITraceWriter
        {
            public TraceLevel LevelFilter
            {
                get { return TraceLevel.Verbose; }
            }

            public void Trace(TraceLevel level, string message, Exception ex)
            {
                var color = "black";
                switch (level)
                {
                    case TraceLevel.Error: color = "red"; break;
                    case TraceLevel.Warning: color = "orange"; break;
                }

                Console.WriteLine(message);
                if (ex != null)
                    Console.WriteLine(ex.ToString());
            }
        }

        // TODO: Move and rename
        private class ErgastRootResponse<T>
        {
            [JsonProperty("MRData")]
            public T Data { get; set; }
        }
    }
}
