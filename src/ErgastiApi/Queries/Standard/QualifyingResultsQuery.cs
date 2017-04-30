namespace ErgastApi.Queries
{
    public class QualifyingResultsQuery : StandardQuery
    {
        [QueryTerminator, QueryMethod("qualifying")]
        public override int? QualifyingPosition { get; set; }
    }
}