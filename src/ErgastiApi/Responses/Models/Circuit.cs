using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Circuit
    {
        public string CircuitId { get; set; }

        public string CircuitName { get; set; }

        [JsonProperty("url")]
        public string WikiUrl { get; set; }

        public Location Location { get; set; }
    }
}