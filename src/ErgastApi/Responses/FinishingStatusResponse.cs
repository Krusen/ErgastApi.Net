using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    public class FinishingStatusResponse : ErgastResponse
    {
        [JsonPath("StatusTable.Status")]
        public IList<FinishingStatus> Statuses { get; private set; }
    }
}
