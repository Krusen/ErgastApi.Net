using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standings
{
    public class DriverStandingsQuery : StandingsQuery
    {
        [QueryMethod("driverStandings")]
        public int? DriverStanding { get; set; }
    }
}