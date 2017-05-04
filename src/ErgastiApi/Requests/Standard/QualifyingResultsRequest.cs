using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests.Standard
{
    public class QualifyingResultsRequest : StandardRequest<RaceResponse<RaceWithQualifyingResults>>
    {
        public QualifyingResultsRequest()
        {
        }

        public QualifyingResultsRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator, QueryMethod("qualifying")]
        public override int? QualifyingPosition { get; set; }
    }
}