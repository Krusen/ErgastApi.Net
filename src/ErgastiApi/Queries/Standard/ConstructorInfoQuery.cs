using ErgastApi.Queries.Attributes;

namespace ErgastApi.Queries.Standard
{
    public class ConstructorInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string ConstructorId { get; set; }
    }
}