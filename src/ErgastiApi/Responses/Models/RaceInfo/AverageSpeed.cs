using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class AverageSpeed
    {
        [JsonProperty("units")]
        public SpeedUnit Unit { get; private set; }

        [JsonProperty("speed")]
        public double Speed { get; private set; }
    }
}