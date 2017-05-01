using ErgastApi.Enums;
using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class FinishingStatusRequest : StandardRequest<IFinishingStatusResponse>
    {
        public FinishingStatusRequest()
        {
        }

        public FinishingStatusRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator]
        public override FinishingStatus? FinishingStatus { get; set; }
    }
}