using ErgastApi.Requests;

namespace ErgastApi.Builders
{
    public class ConstructorStandingsRequestBuilder : AbstractRequestBuilder<ConstructorStandingsRequestBuilder, ConstructorStandingsRequest>
    {
        public ConstructorStandingsRequestBuilder Constructor(string constructorId)
        {
            Request.ConstructorId = constructorId;
            return this;
        }

        public ConstructorStandingsRequestBuilder ConstructorStanding(int? position)
        {
            Request.ConstructorStanding = position;
            return this;
        }
    }
}