using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IConstructorsQuery : IPageableQuery, ICircuits, IDrivers, IGrid, IResults, IFastestLap,
        IFinishingStatus, IConstructorStandings, IQualifyingFilter
    {
    }
}