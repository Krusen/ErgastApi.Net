using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;
using ErgastApi.Responses.Standings;

namespace ErgastApi.Requests.Standings
{
    public class ConstructorStandingsRequest : StandingsRequest<ConstructorStandingsResponse>
    {
        public ConstructorStandingsRequest()
        {
        }

        public ConstructorStandingsRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator, QueryMethod("constructorStandings")]
        public int? ConstructorStanding { get; set; }
    }
}