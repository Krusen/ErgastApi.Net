using ErgastApi.Attributes;
using ErgastApi.Enums;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("constructors")]
    public interface IConstructors : IPageableQuery, IConstructorsFilter
    {
        IConstructorsQuery Constructors(string constructorId);

        IConstructorsQuery Constructors(Constructor constructor);
    }
}