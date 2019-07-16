using System.Collections.Generic;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    public abstract class StandingsResponse<T> : ErgastResponse
    {
        [JsonPath("StandingsTable.StandingsLists")]
        public IList<T> StandingsLists { get; private set; }
    }
}
