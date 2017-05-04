using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests.Standard
{
    public class RaceResultsRequest : StandardRequest<RaceResponse<RaceWithResults>>
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