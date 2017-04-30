namespace ErgastApi.Queries.Default.Info
{
    public class CircuitInfoQuery : InfoQuery, ICircuitInfoQuery
    {
        [QueryTerminator]
        public override string CircuitId { get; set; }
    }
}