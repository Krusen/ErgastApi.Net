using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface ICircuitsQuery : IPageableQuery, IDrivers, IConstructors, IFinishingStatus, IResults, IQualifyingFilter
    {
    }
}