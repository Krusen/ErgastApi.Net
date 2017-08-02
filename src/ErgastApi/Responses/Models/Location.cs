using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public string Latitude { get; private set; }

        [JsonProperty("long")]
        public string Longitude { get; private set; }

        [JsonProperty("locality")]
        public string Locality { get; private set; }

        [JsonProperty("country")]
        public string Country { get; private set; }
    }
}