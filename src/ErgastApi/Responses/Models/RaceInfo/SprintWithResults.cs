using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class SprintWithResults : Race
    {
        [JsonProperty("sprint")]
        public IList<RaceResult> Results { get; private set; }
    }
}
