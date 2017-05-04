using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class RaceWithPitStops : Race
    {
        [JsonProperty("PitStops")]
        public IList<PitStopInfo> PitStops { get; private set; }
    }
}