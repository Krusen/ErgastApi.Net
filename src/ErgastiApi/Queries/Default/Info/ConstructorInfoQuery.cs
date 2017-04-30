namespace ErgastApi.Queries.Default.Info
{
    public class ConstructorInfoQuery : InfoQuery, IConstructorInfoQuery
    {
        [QueryTerminator]
        public override string ConstructorId { get; set; }
    }
}