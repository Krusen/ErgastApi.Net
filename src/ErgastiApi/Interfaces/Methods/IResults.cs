using ErgastApi.Attributes;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("results")]
    public interface IResults : IPageableQuery, IResultsFilter
    {
        new IResultsQuery Results();
        new IResultsQuery Results(int position);
    }
}