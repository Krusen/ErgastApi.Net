using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standings
{
    public class DriverStandingsRequest : StandingsRequest<IDriverStandingsResponse>
    {
        public DriverStandingsRequest()
        {
        }

        public DriverStandingsRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator, QueryMethod("driverStandings")]
        public int? DriverStanding { get; set; }
    }
}