using ErgastApi.Attributes;

namespace ErgastApi.Interfaces.Filters
{
    [Id("circuits")]
    public interface ICircuitsFilter
    {
        IQuery Circuits();
    }
}