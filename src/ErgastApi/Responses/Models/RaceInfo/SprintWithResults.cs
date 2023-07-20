using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class SprintWithResults : Race
    {
        [JsonProperty("SprintResults")]
        public IList<RaceResult> SprintResults { get; private set; }
    }
}
