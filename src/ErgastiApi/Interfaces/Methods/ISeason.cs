using ErgastApi.Attributes;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id(null)]
    public interface ISeason : ISeasonsFilter, IQuery
    {
        ISeasonQuery Season(int season);
        ISeasonQuery CurrentSeason { get; }
    }
}