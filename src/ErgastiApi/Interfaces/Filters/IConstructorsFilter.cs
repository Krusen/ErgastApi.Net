using ErgastApi.Attributes;

namespace ErgastApi.Interfaces.Filters
{
    [Id("constructors")]
    public interface IConstructorsFilter
    {
        IQuery Constructors();
    }
}