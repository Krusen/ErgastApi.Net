namespace ErgastApi.Interfaces.Filters
{
    public interface IResultsFilter
    {
        IQuery Results();
        IQuery Results(int position);
    }
}