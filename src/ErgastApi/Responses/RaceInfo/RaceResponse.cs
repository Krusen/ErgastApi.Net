using System.Collections.Generic;
using ErgastApi.Responses.Models.RaceInfo;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    public abstract class RaceResponse<T> : ErgastResponse where T : Race
    {
        [JsonPath("RaceTable.Races")]
        public IList<T> Races { get; private set; }
    }
}
