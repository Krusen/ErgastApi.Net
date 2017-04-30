namespace ErgastApi.Queries
{
    public class ConstructorStandingsQuery : StandingsQuery
    {
        [QueryMethod("constructorStandings")]
        public int? ConstructorStanding { get; set; }
    }
}