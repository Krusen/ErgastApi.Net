using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class RaceListQuery : StandardQuery
    {
        // Value not used
        [QueryTerminator, QueryMethod("races")]
        protected object Races { get; }
    }
}