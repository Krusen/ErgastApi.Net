using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Filters
{
    public interface IFinishingStatusFilter
    {
        IPageableQuery Status();
    }
}