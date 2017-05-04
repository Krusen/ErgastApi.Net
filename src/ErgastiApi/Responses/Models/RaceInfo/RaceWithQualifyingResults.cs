using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class RaceWithQualifyingResults : Race
    {
        [JsonProperty("QualifyingResults")]
        public IList<QualifyingResult> QualifyingResults { get; private set; }
    }
}