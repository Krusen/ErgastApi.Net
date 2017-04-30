using ErgastApi.Serialization;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    public interface IErgastResponse
    {
        string Url { get; set; }

        int Limit { get; set; }

        int Offset { get; set; }

        int Total { get; set; }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    public class ErgastResponse : IErgastResponse
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        public int Total { get; set; }
    }
}
