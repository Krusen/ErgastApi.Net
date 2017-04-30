namespace ErgastApi.Queries
{
    public class RaceResultsQuery : StandardQuery
    {
        [QueryTerminator]
        public override int? FinishingPosition { get; set; }
    }
}