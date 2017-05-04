using ErgastApi.Enums;

namespace ErgastApi.Responses.Models
{
    public class FinishingStatus
    {
        public FinishingStatusId StatusId { get; set; }

        public int Count { get; set; }

        public string Status { get; set; }
    }
}
