using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of lap times matching the specified filters.
    /// </summary>
    public class LapTimesRequest : ErgastRequest<LapTimesResponse>
    {
        /// <summary>
        /// Limits the results to the specified driver.
        /// The static <see cref="Drivers"/> class contains the IDs for most recent and popular drivers.
        /// </summary>
        [UrlSegment("drivers")]
        public string DriverId { get; set; }

        /// <summary>
        /// Limits the results to the specified lap.
        /// </summary>
        [UrlTerminator, UrlSegment("laps")]
        public int? Lap { get; set; }
    }
}