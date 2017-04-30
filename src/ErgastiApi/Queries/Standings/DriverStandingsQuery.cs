namespace ErgastApi.Queries
{
    public class DriverStandingsQuery : StandingsQuery
    {
        [QueryMethod("driverStandings")]
        public int? DriverStanding { get; set; }
    }
}