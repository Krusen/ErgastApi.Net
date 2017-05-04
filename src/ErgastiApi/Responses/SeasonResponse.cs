using System.Collections.Generic;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;

namespace ErgastApi.Responses
{
    public class SeasonResponse : ErgastResponse
    {
        [JsonPathProperty("SeasonTable.Seasons")]
        public IList<Season> Seasons { get; set; }
    }
}
