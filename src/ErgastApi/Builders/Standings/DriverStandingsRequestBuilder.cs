using ErgastApi.Requests;

namespace ErgastApi.Builders
{
    public class DriverStandingsRequestBuilder : AbstractRequestBuilder<DriverStandingsRequestBuilder, DriverStandingsRequest>
    {
        public DriverStandingsRequestBuilder Driver(string driverId)
        {
            Request.DriverId = driverId;
            return this;
        }

        public DriverStandingsRequestBuilder DriverStanding(int? position)
        {
            Request.DriverStanding = position;
            return this;
        }
    }
}