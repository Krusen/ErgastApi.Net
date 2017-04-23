using ErgastApi.Attributes;

namespace ErgastApi.Interfaces.Filters
{
    [Id("pitstops")]
    public interface IPitStopsFilter
    {
        IQuery PitStops();

        IQuery PitStops(int stopNumber);
    }
}