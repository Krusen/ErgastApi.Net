using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    [Id("constructors")]
    public interface IConstructorsFilter
    {
        IPageableQuery Constructors();
    }
}