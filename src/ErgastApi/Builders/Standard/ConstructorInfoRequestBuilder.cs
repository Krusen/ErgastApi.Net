using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Builders
{
    public class ConstructorInfoRequestBuilder
        : StandardRequestBuilder<ConstructorInfoRequestBuilder, ConstructorInfoRequest, ConstructorResponse>
    {
        public ConstructorInfoRequestBuilder ConstructorStanding(int? position)
        {
            Request.ConstructorStanding = position;
            return this;
        }
    }
}