namespace ErgastApi.Queries
{
    public class CircuitInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string CircuitId { get; set; }
    }
}