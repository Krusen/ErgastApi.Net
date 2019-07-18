using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    /// <summary>
    /// A response containing a list of finishing statuses (and their count) matching the request.
    /// </summary>
    public class FinishingStatusResponse : ErgastResponse
    {
        [JsonPath("StatusTable.Status")]
        public IList<FinishingStatus> Statuses { get; private set; }
    }
}
