using ErgastApi.Client.Attributes;
using ErgastApi.Responses.Standings;

namespace ErgastApi.Requests.Standings
{
    public class DriverStandingsRequest : StandingsRequest<DriverStandingsResponse>
    {
        [UrlTerminator, UrlSegment("driverStandings")]
        public int? DriverStanding { get; set; }
    }
}