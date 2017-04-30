using ErgastApi.Enums;
using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class FinishingStatusQuery : StandardQuery
    {
        [QueryTerminator]
        public override FinishingStatus? FinishingStatus { get; set; }
    }
}