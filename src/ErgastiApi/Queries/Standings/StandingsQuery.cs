namespace ErgastApi.Queries
{
    public abstract class StandingsQuery : Query
    {
        [QueryMethod("constructors")]
        public virtual string ConstructorId { get; set; }
    }
}