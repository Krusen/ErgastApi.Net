using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests.Standard
{
    public class FinishingStatusRequest : StandardRequest<FinishingStatusResponse>
    {
        [UrlTerminator]
        public override FinishingStatusId? FinishingStatus { get; set; }
    }
}