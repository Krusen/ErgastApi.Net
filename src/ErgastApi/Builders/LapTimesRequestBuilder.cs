using ErgastApi.Requests;

namespace ErgastApi.Builders
{
    public class LapTimesRequestBuilder : AbstractRequestBuilder<LapTimesRequestBuilder, LapTimesRequest>
    {
        public LapTimesRequestBuilder Driver(string driverId)
        {
            Request.DriverId = driverId;
            return this;
        }
        public LapTimesRequestBuilder Lap(int? lap)
        {
            Request.Lap = lap;
            return this;
        }
    }
}
