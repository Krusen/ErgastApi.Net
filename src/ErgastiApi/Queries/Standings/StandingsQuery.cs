using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standings
{
    public abstract class StandingsQuery : Query
    {
        [QueryMethod("constructors")]
        public virtual string ConstructorId { get; set; }
    }
}