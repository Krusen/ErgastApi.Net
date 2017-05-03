using System;
using System.Threading.Tasks;
using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;
using ErgastApi.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Requests
{
    public abstract class ErgastRequest<TResponse> : IErgastRequest where TResponse : IErgastResponse
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
            return Settings.ApiRoot + Settings.QueryBuilder.BuildUrl(this);
        }

        public virtual async Task<TResponse> ExecuteAsync()
        {
            var url = BuildUrl();

            Console.WriteLine(url);

            var traceWriter = new MemoryTraceWriter();

            // TODO: Don't use GetStringAsync, instead use GetAsync - then we can handle errors better
            // TODO: Should probably be moved to its own wrapper with specific methods instead of using HttpClient directly
            var data = await Settings.HttpClient.GetStringAsync(url).ConfigureAwait(false);

            // TODO: Reuse/add to constructor?
            var settings = new JsonSerializerSettings
            {
                TraceWriter = traceWriter,
                //ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new InterfaceContractResolver()
            };


            var obj = JsonConvert.DeserializeObject<ErgastRootResponse<TResponse>>(data, settings);

            Console.WriteLine(traceWriter.ToString());

            return obj.Data;
        }

        // TODO: Move and rename
        private class ErgastRootResponse<T>
        {
            [JsonProperty("MRData")]
            public T Data { get; set; }
        }
    }
}
