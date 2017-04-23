using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IGridQuery : IQuery, ICircuits, IConstructors, IDrivers, IResults, IFastestLap, IFinishingStatus
    {
    }
}