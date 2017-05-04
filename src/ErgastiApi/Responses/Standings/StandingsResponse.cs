using System.Collections.Generic;
using ErgastApi.Serialization;

namespace ErgastApi.Responses.Standings
{
    public abstract class StandingsResponse<T> : ErgastResponse
    {
        [JsonPathProperty("StandingsTable.StandingsLists")]
        public IList<T> StandingsLists { get; private set; }
    }
}
