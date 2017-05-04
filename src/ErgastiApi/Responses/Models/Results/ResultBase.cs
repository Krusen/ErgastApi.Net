using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.Results
{
    public abstract class ResultBase
    {
        [JsonProperty("number")]
        public int Number { get; private set; }

        [JsonProperty("position")]
        public int Position { get; private set; }

        [JsonProperty("Driver")]
        public Driver Driver { get; private set; }

        [JsonProperty("Constructor")]
        public Constructor Constructor { get; private set; }
    }
}