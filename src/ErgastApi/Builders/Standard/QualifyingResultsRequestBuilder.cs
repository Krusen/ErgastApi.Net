using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Builders
{
    public class QualifyingResultsRequestBuilder
        : StandardRequestBuilder<QualifyingResultsRequestBuilder, QualifyingResultsRequest, QualifyingResultsResponse>
    {
        public QualifyingResultsRequestBuilder QualifyingPosition(int? position)
        {
            Request.QualifyingPosition = position;
            return this;
        }
    }
}