using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IConstructorsQuery : IQuery, ICircuits, IDrivers, IGrid, IResults, IFastestLap,
        Methods.IFinishingStatus, IConstructorStandings
    {
    }
}