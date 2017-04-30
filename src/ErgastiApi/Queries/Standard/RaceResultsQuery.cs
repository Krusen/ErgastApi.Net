using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class RaceResultsQuery : StandardQuery
    {
        [QueryTerminator]
        public override int? FinishingPosition { get; set; }
    }
}