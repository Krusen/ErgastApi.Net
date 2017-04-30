namespace ErgastApi.Queries.Default.Info
{
    public class DriverInfoQuery : InfoQuery, IDriverInfoQuery
    {
        [QueryTerminator]
        public override string DriverId { get; set; }
    }
}