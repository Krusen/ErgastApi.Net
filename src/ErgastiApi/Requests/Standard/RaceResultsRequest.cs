using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    public class RaceResultsRequest : StandardRequest<RaceResultsResponse>
    {
        [UrlTerminator]
        public override int? FinishingPosition { get; set; }
    }
}