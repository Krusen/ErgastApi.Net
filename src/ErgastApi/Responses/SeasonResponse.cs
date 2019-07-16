using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    public class SeasonResponse : ErgastResponse
    {
        [JsonPath("SeasonTable.Seasons")]
        public IList<Season> Seasons { get; private set; }
    }
}
