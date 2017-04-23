using ErgastApi.Attributes;
using ErgastApi.Enums;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("circuits")]
    public interface ICircuits : IQuery, ICircuitsFilter
    {
        ICircuitsQuery Circuits(string circuitId);
        ICircuitsQuery Circuits(Circuit circuit);
    }
}