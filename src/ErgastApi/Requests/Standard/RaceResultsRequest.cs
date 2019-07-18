using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of race results matching the specified filters.
    /// </summary>
    public class RaceResultsRequest : StandardRequest<RaceResultsResponse>
    {
        /// <summary>
        /// The finishing position of a driver.
        /// </summary>
        [UrlTerminator]
        public override int? FinishingPosition { get; set; }
    }
}