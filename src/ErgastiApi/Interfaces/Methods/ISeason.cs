using ErgastApi.Attributes;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    [Id(null)]
    public interface ISeason : ISeasonsFilter, IPageableQuery
    {
        // TODO: Docu: season = year (4 digit integer)
        ISeasonQuery Season(int season);
        ISeasonQuery CurrentSeason { get; }
    }
}