using ErgastApi.Attributes;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id("grid")]
    public interface IGrid : IPageableQuery
    {
        IGridQuery Grid(int startingPosition);
    }
}