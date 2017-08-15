using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class FinishingStatus
    {
        [JsonProperty("statusId")]
        public FinishingStatusId Status { get; private set; }

        [JsonProperty("count")]
        public int Count { get; private set; }

        [JsonProperty("status")]
        public string StatusText { get; private set; }
    }
}
