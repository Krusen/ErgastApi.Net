using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    public interface IResultsFilter
    {
        IPageableQuery Results();
        IPageableQuery Results(int position);
    }
}