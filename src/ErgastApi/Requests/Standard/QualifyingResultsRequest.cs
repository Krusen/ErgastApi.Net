using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class QualifyingResultsRequest : StandardRequest<QualifyingResultsResponse>
    {
        [UrlTerminator, UrlSegment("qualifying")]
        public override int? QualifyingPosition { get; set; }
    }
}