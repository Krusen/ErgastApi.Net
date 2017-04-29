using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    [Id("pitstops")]
    public interface IPitStopsFilter
    {
        IPageableQuery PitStops();

        IPageableQuery PitStops(int stopNumber);
    }
}