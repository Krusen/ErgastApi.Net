using ErgastApi.Enums;
using ErgastApi.Interfaces.Filters;
using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    public interface IFinishingStatus : IFinishingStatusFilter
    {
        IFinishingStatusQuery Status(int statusId);
        IFinishingStatusQuery Status(FinishingStatus status);
    }
}