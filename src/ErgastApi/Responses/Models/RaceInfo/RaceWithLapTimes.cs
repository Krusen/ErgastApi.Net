using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class RaceWithLapTimes : Race
    {
        [JsonProperty("Laps")]
        public IList<Lap> Laps { get; private set; }
    }
}