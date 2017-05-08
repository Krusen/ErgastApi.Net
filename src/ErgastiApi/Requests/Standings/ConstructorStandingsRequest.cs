using ErgastApi.Requests.Attributes;
using ErgastApi.Responses.Standings;

namespace ErgastApi.Requests.Standings
{
    public class ConstructorStandingsRequest : StandingsRequest<ConstructorStandingsResponse>
    {
        [UrlTerminator, UrlSegment("constructorStandings")]
        public int? ConstructorStanding { get; set; }
    }
}