using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IResultsQuery : IPageableQuery, IDrivers, ICircuits, IConstructors, IGrid, IFastestLap,
        IFinishingStatus, IQualifyingFilter
    {
    }
}