using ErgastApi.Requests;
using ErgastApi.Responses;

namespace ErgastApi.Builders
{
    public class DriverInfoRequestBuilder
        : StandardRequestBuilder<DriverInfoRequestBuilder, DriverInfoRequest, DriverResponse>
    {
        public DriverInfoRequestBuilder DriverStanding(int? position)
        {
            Request.DriverStanding = position;
            return this;
        }
    }
}