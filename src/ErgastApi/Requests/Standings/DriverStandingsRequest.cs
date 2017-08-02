using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class DriverStandingsRequest : StandingsRequest<DriverStandingsResponse>
    {
        [UrlTerminator, UrlSegment("driverStandings")]
        public int? DriverStanding { get; set; }
    }
}