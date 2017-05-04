using ErgastApi.Requests.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests.Standard
{
    public class RaceResultsRequest : StandardRequest<RaceResultsResponse>
    {
        public RaceResultsRequest()
        {
        }

        public RaceResultsRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator]
        public override int? FinishingPosition { get; set; }
    }
}