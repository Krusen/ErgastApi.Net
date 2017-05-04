using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Constructor
    {
        [JsonProperty("constructorId")]
        public string ConstructorId { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("nationality")]
        public string Nationality { get; private set; }
    }
}