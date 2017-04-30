using ErgastApi.Enums;

namespace ErgastApi.Queries
{
    public class FinishingStatusQuery : StandardQuery
    {
        [QueryTerminator]
        public override FinishingStatus? FinishingStatus { get; set; }
    }
}