using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests.Standard
{
    public abstract class StandardRequest<TResponse> : ErgastRequest<TResponse> where TResponse : ErgastResponse
    {
        [UrlSegment("constructors")]
        public virtual string ConstructorId { get; set; }

        [UrlSegment("circuits")]
        public virtual string CircuitId { get; set; }

        [UrlSegment("fastests")]
        public virtual int? FastestLapRank { get; set; }

        [UrlSegment("results")]
        public virtual int? FinishingPosition { get; set; }

        // Grid / starting position
        [UrlSegment("grid")]
        public virtual int? QualifyingPosition { get; set; }

        [UrlSegment("status")]
        public virtual FinishingStatusId? FinishingStatus { get; set; }
    }
}