using ErgastApi.Queries;
using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests.Other
{
    public class PitStopsRequests : ErgastRequest<IRaceResponse<IRaceWithPitStops>>
    {
        public PitStopsRequests()
        {
        }

        public PitStopsRequests(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryMethod("laps")]
        public int? Lap { get; set; }

        [QueryTerminator, QueryMethod("pitstops")]
        public int? PitStop { get; set; }
    }
}