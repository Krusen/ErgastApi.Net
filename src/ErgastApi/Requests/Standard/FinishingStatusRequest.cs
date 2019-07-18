using ErgastApi.Client.Attributes;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of finishing statuses (and their count) matching the specified filters.
    /// </summary>
    public class FinishingStatusRequest : StandardRequest<FinishingStatusResponse>
    {
        /// <summary>
        /// The finishing status of a driver, i.e. if they finished or the reason they didn't finish.
        /// </summary>
        [UrlTerminator]
        public override FinishingStatusId? FinishingStatus { get; set; }
    }
}