namespace ErgastApi.Queries
{
    public class QualifyingResultsQuery : StandardQuery
    {
        [QueryTerminator, QueryMethod("qualifying")]
        protected object Qualifying { get; }
    }
}