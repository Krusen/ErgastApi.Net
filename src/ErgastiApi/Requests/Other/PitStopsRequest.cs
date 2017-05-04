using ErgastApi.Requests.Attributes;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests.Other
{
    public class PitStopsRequest : ErgastRequest<RaceResponse<RaceWithPitStops>>
    {
        public PitStopsRequest()
        {
        }

        public PitStopsRequest(ErgastRequestSettings settings) : base(settings)
        {
        }

        [QueryMethod("laps")]
        public int? Lap { get; set; }

        [QueryTerminator, QueryMethod("pitstops")]
        public int? PitStop { get; set; }
    }
}