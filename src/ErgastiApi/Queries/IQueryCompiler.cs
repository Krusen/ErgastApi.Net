namespace ErgastApi.Queries
{
    public interface IQueryCompiler
    {
        string Compile(IQuery query);
    }
}