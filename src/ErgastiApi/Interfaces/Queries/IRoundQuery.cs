using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IRoundQuery : IQuery, ICircuits, IDrivers, IConstructors, IGrid, IResults, IFastestLap,
        Methods.IFinishingStatus, IConstructorStandings, IDriverStandings
    {
    }
}