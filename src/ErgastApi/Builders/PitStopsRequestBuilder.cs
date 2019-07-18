using ErgastApi.Requests;

namespace ErgastApi.Builders
{
    public class PitStopsRequestBuilder : AbstractRequestBuilder<PitStopsRequestBuilder, PitStopsRequest>
    {
        public PitStopsRequestBuilder Lap(int? lap)
        {
            Request.Lap = lap;
            return this;
        }

        public PitStopsRequestBuilder PitStop(int? pitStop)
        {
            Request.PitStop = pitStop;
            return this;
        }
    }
}
