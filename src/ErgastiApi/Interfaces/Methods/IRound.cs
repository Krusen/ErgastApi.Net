using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id(null)]
    public interface IRound : IQuery
    {
        IRoundQuery Round(int round);
        IRoundQuery LastRound { get; }
        IRoundQuery NextRound { get; }
    }
}