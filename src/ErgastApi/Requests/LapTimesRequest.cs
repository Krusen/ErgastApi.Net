using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

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