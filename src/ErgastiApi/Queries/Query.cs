using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries
{
    public abstract class Query : IQuery
    {
        public int Limit { get; set; } = 30;

        public int Offset { get; set; } = 0;

        [QueryMethod(Order = 1)]
        public virtual int? Season { get; set; }

        // TODO: Require season to be not null
        [QueryMethod(Order = 2)]
        [QueryDependency(nameof(Season))]
        public virtual int? Round { get; set; }

        [QueryMethod("drivers")]
        public virtual string DriverId { get; set; }
    }
}