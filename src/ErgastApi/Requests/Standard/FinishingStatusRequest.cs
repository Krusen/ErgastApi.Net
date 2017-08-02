using ErgastApi.Client.Attributes;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests
{
    public class FinishingStatusRequest : StandardRequest<FinishingStatusResponse>
    {
        [UrlTerminator]
        public override FinishingStatusId? FinishingStatus { get; set; }
    }
}