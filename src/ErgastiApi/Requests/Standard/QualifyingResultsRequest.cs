using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Standard
{
    public class QualifyingResultsRequest : StandardRequest<IRaceResponse<IRaceWithQualifyingResults>>
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