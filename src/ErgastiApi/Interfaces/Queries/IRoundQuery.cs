using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IRoundQuery : IPageableQuery, ICircuits, IDrivers, IConstructors, IGrid, IResults, IFastestLap,
        Methods.IFinishingStatus, IConstructorStandings, IDriverStandings
    {
    }
}