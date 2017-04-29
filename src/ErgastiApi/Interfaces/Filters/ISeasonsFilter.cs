using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    [Id("seasons")]
    public interface ISeasonsFilter
    {
        IPageableQuery Seasons();
    }
}