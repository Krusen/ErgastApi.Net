using ErgastApi.Requests.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests.Standard
{
    public class RaceResultsRequest : StandardRequest<RaceResultsResponse>
    {
        [UrlTerminator]
        public override int? FinishingPosition { get; set; }
    }
}