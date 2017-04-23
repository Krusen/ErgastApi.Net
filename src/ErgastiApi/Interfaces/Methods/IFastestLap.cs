using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("fastest")]
    public interface IFastestLap : IQuery
    {
        IFastestLapQuery FastestLap(int rank);
    }
}