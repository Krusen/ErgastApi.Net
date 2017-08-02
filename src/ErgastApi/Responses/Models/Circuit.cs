using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Circuit
    {
        [JsonProperty("circuitId")]
        public string CircuitId { get; private set; }

        [JsonProperty("circuitName")]
        public string CircuitName { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        [JsonProperty("location")]
        public Location Location { get; private set; }
    }
}