using ErgastApi.Ids;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class FinishingStatus
    {
        [JsonProperty("statusId")]
        public FinishingStatusId StatusId { get; private set; }

        [JsonProperty("count")]
        public int Count { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }
    }
}
