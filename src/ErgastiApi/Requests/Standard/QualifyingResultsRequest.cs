using ErgastApi.Requests.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests.Standard
{
    public class QualifyingResultsRequest : StandardRequest<QualifyingResultsResponse>
    {
        [UrlTerminator, UrlSegment("qualifying")]
        public override int? QualifyingPosition { get; set; }
    }
}