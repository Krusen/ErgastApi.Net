using ErgastApi.Requests.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests.Other
{
    public class LapTimesRequest : ErgastRequest<LapTimesResponse>
    {
        public LapTimesRequest()
        {
        }

        public LapTimesRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryTerminator, QueryMethod("laps")]
        public int? Lap { get; set; }

        [QueryMethod("pitstops")]
        public int? PitStop { get; set; }
    }
}