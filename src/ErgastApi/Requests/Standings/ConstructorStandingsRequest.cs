using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class ConstructorStandingsRequest : StandingsRequest<ConstructorStandingsResponse>
    {
        [UrlTerminator, UrlSegment("constructorStandings")]
        public int? ConstructorStanding { get; set; }
    }
}