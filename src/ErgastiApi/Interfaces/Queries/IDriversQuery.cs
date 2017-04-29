using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IDriversQuery : IPageableQuery, ICircuits, IConstructors, IResultsFilter, IFastestLap,
        IFinishingStatus, IDriverStandings, ILapTimes, IPitStopsFilter, IQualifyingFilter
    {
    }
}