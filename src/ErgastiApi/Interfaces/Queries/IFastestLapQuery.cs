using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface IFastestLapQuery : IResults, IFinishingStatus, IQualifyingFilter
    {
    }
}