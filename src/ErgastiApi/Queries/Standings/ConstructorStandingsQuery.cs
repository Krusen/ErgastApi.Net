using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standings
{
    public class ConstructorStandingsQuery : StandingsQuery
    {
        [QueryMethod("constructorStandings")]
        public int? ConstructorStanding { get; set; }
    }
}