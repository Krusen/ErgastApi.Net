using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Other
{
    public class PitStopsQuery : Query
    {
        [QueryMethod("laps")]
        public int? Lap { get; set; }

        [QueryTerminator, QueryMethod("pitstops")]
        public int? PitStop { get; set; }
    }
}