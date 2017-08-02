using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public abstract class StandingsRequest<TResponse> : ErgastRequest<TResponse> where TResponse : ErgastResponse
    {
        [UrlSegment("constructors")]
        public virtual string ConstructorId { get; set; }
    }
}