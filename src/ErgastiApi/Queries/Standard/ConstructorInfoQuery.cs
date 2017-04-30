namespace ErgastApi.Queries
{
    public class ConstructorInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string ConstructorId { get; set; }
    }
}