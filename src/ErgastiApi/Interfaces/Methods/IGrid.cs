using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("grid")]
    public interface IGrid : IQuery
    {
        IGridQuery Grid(int startingPosition);
    }
}