using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    [Id("circuits")]
    public interface ICircuitsFilter
    {
        IPageableQuery Circuits();
    }
}