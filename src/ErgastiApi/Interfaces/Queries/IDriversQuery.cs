using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IDriversQuery : IQuery, ICircuits, IConstructors, IResultsFilter, IFastestLap,
        IFinishingStatus, IDriverStandings, ILapTimes, IPitStopsFilter
    {
    }
}