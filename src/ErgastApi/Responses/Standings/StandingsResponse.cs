using System.Collections.Generic;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    /// <summary>
    /// Base response for standings requests.
    /// </summary>
    public abstract class StandingsResponse<T> : ErgastResponse
    {
        [JsonPath("StandingsTable.StandingsLists")]
        public IList<T> StandingsLists { get; private set; }
    }
}
