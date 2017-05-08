using ErgastApi.Requests.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests.Other
{
    public class LapTimesRequest : ErgastRequest<LapTimesResponse>
    {
        [UrlTerminator, UrlSegment("laps")]
        public int? Lap { get; set; }

        [UrlSegment("pitstops")]
        public int? PitStop { get; set; }
    }
}