using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    /// <summary>
    /// A response containing a list of seasons matching the request.
    /// </summary>
    public class SeasonResponse : ErgastResponse
    {
        [JsonPath("SeasonTable.Seasons")]
        public IList<Season> Seasons { get; private set; }
    }
}
