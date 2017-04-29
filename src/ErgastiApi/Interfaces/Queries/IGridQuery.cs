using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IGridQuery : IPageableQuery, ICircuits, IConstructors, IDrivers, IResults, IFastestLap, IFinishingStatus, IQualifyingFilter
    {
    }
}