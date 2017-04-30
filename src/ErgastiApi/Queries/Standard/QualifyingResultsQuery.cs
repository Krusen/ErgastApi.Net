namespace ErgastApi.Queries
{
    public class QualifyingResultsQuery : StandardQuery
    {
        [QueryTerminator, QueryMethod("qualifying")]
        public virtual int? QualifyingPosition { get; set; }
    }
}