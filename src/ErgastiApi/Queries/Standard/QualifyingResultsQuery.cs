using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class QualifyingResultsQuery : StandardQuery
    {
        [QueryTerminator, QueryMethod("qualifying")]
        public override int? QualifyingPosition { get; set; }
    }
}