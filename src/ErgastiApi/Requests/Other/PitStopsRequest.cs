using ErgastApi.Requests.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests.Other
{
    public class PitStopsRequest : ErgastRequest<PitStopsResponse>
    {
        [UrlSegment("laps")]
        public int? Lap { get; set; }

        [UrlTerminator, UrlSegment("pitstops")]
        public int? PitStop { get; set; }
    }
}