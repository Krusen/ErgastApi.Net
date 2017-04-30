namespace ErgastApi.Queries
{
    public class PitStopsQuery : Query
    {
        [QueryMethod("laps")]
        public int? Lap { get; set; }

        [QueryTerminator, QueryMethod("pitstops")]
        public int? PitStop { get; set; }
    }
}