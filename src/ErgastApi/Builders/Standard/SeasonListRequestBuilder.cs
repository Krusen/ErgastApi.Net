using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Builders
{
    public class SeasonListRequestBuilder
        : StandardRequestBuilder<SeasonListRequestBuilder, SeasonListRequest, SeasonResponse>
    {
        // Cannot be combined with circuit, grid, result or status qualifiers
        public SeasonListRequestBuilder DriverStanding(int? position)
        {
            Request.DriverStanding = position;
            return this;
        }

        // Cannot be combined with circuit, grid, result or status qualifiers
        public SeasonListRequestBuilder ConstructorStanding(int? position)
        {
            Request.ConstructorStanding = position;
            return this;
        }
    }
}