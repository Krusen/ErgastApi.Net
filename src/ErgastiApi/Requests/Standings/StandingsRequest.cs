using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standings
{
    public abstract class StandingsRequest<TResponse> : ErgastRequest<TResponse> where TResponse : ErgastResponse
    {
        protected StandingsRequest()
        {
        }

        protected StandingsRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryMethod("constructors")]
        public virtual string ConstructorId { get; set; }
    }
}