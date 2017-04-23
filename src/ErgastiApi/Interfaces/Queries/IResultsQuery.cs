using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IResultsQuery : IQuery, IDrivers, ICircuits, IConstructors, IGrid, IFastestLap,
        Methods.IFinishingStatus
    {
    }
}