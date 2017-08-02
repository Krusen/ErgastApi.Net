using System.Collections.Generic;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;

namespace ErgastApi.Responses
{
    public class FinishingStatusResponse : ErgastResponse
    {
        [JsonPathProperty("StatusTable.Status")]
        public IList<FinishingStatus> Statuses { get; private set; }
    }
}
