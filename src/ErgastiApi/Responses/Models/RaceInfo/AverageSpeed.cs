using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class AverageSpeed
    {
        // TODO: Units enum - kph/mph
        [JsonProperty("units")]
        public string Units { get; private set; }

        [JsonProperty("speed")]
        public double Speed { get; private set; }
    }
}