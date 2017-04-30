namespace ErgastApi.Queries
{
    public class RaceListQuery : StandardQuery
    {
        // Value not used
        [QueryTerminator, QueryMethod("races")]
        protected object Races { get; }
    }
}