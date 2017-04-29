using ErgastApi.Attributes;
using ErgastApi.Enums;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("circuits")]
    public interface ICircuits : IPageableQuery, ICircuitsFilter
    {
        ICircuitsQuery Circuits(string circuitId);
        ICircuitsQuery Circuits(Circuit circuit);
    }
}