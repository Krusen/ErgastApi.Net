namespace ErgastApi.Queries
{
    public class SeasonListQuery : StandardQuery
    {
        // Value not used
        [QueryTerminator, QueryMethod("seasons")]
        protected object Seasons { get; }
    }
}