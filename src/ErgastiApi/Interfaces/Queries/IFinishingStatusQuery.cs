using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    // TODO: Maybe needs more applicable interfaces
    public interface IFinishingStatusQuery : IPageableQuery, IDrivers, IConstructors, ICircuits, IQualifyingFilter
    {
    }
}