using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Location
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("long")]
        public string Longitude { get; set; }

        public string Locality { get; set; }

        public string Country { get; set; }
    }
}