using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class Lap
    {
        [JsonProperty("number")]
        public int Number { get; private set; }

        [JsonProperty("Timings")]
        public IList<LapTiming> Timings { get; private set; }
    }
}