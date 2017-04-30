namespace ErgastApi.Queries
{
    public class LapTimesQuery : Query
    {
        [QueryTerminator, QueryMethod("laps")]
        public int? Lap { get; set; }

        [QueryMethod("pitstops")]
        public int? PitStop { get; set; }
    }
}