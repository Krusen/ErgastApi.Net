using ErgastApi.Client.Attributes;
using ErgastApi.Responses.RaceInfo;

namespace ErgastApi.Requests
{
    public class LapTimesRequest : ErgastRequest<LapTimesResponse>
    {
        [UrlTerminator, UrlSegment("laps")]
        public int? Lap { get; set; }

        [UrlSegment("pitstops")]
        public int? PitStop { get; set; }
    }
}