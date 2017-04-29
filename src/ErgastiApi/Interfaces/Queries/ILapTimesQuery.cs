using ErgastApi.Attributes;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Responses;

namespace ErgastApi.Interfaces.Queries
{
    public interface ILapTimesQuery : IPageableQuery, IPitStopsFilter, IRaceResponseQuery
    {
    }
}