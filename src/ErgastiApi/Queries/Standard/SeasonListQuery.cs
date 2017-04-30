using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class SeasonListQuery : StandardQuery
    {
        // Value not used
        [QueryTerminator, QueryMethod("seasons")]
        protected object Seasons { get; }
    }
}