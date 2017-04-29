using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    // TODO: Allow this to be used on method level and be inherited or something
    [Id("drivers")]
    public interface IDriversFilter
    {
        IPageableQuery Drivers();
    }
}