using System.Collections.Generic;
using ErgastApi.Responses.Models.Results;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class RaceWithResults : Race
    {
        [JsonProperty("Results")]
        public IList<RaceResult> Results { get; private set; }
    }
}