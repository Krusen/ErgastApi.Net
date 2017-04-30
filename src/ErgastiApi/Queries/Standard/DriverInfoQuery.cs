namespace ErgastApi.Queries
{
    public class DriverInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string DriverId { get; set; }
    }
}