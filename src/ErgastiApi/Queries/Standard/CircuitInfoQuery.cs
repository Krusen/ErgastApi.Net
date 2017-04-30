using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class CircuitInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string CircuitId { get; set; }
    }
}