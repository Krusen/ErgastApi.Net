using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Methods;

namespace ErgastApi.Interfaces.Queries
{
    public interface ICircuitsQuery : IQuery, IDrivers, IConstructors, IFinishingStatus, IResults
    {
    }
}