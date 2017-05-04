using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Constructor
    {
        public string ConstructorId { get; set; }

        [JsonProperty("url")]
        public string WikiUrl { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }
    }
}