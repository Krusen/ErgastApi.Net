using ErgastApi.Attributes;

namespace ErgastApi.Interfaces.Filters
{
    [Id("seasons")]
    public interface ISeasonsFilter
    {
        IQuery Seasons();
    }
}