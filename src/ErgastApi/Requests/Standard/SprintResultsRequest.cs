using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class SprintResultsRequest : StandardRequest<SprintResultsResponse>
    {
        [UrlTerminator]
        public override int? FinishingPosition { get; set; }
    }
}
