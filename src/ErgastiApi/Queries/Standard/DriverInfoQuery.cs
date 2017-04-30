using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class DriverInfoQuery : StandardQuery, IDriverInfoQuery
    {
        [QueryTerminator]
        public override string DriverId { get; set; }
    }
}