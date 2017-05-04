using ErgastApi.Enums;
using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public abstract class StandardRequest<TResponse> : ErgastRequest<TResponse> where TResponse : ErgastResponse
    {
        protected StandardRequest()
        {
        }

        protected StandardRequest(ErgastRequestSettings settings)
            : base(settings)
        {
        }

        [QueryMethod("constructors")]
        public virtual string ConstructorId { get; set; }

        [QueryMethod("circuits")]
        public virtual string CircuitId { get; set; }

        [QueryMethod("fastests")]
        public virtual int? FastestLapRank { get; set; }

        [QueryMethod("results")]
        public virtual int? FinishingPosition { get; set; }

        // Grid / starting position
        [QueryMethod("grid")]
        public virtual int? QualifyingPosition { get; set; }

        [QueryMethod("status")]
        public virtual FinishingStatusId? FinishingStatus { get; set; }
    }
}