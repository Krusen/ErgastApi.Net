using ErgastApi.Attributes;
using ErgastApi.Enums;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("drivers")]
    public interface IDrivers : IQuery, IDriversFilter
    {
        IDriversQuery Drivers(string driverId);
        IDriversQuery Drivers(Driver driver);
    }
}