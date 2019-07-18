using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of driver standings (WDC) matching the specified filters.
    /// </summary>
    public class DriverStandingsRequest : ErgastRequest<DriverStandingsResponse>
    {
        /// <summary>
        /// Limits the results to the specified driver.
        /// The static <see cref="Drivers"/> class contains the IDs for most recent and popular drivers.
        /// </summary>
        [UrlSegment("drivers")]
        public string DriverId { get; set; }

        /// <summary>
        /// Position in the driver standings (WDC).
        /// </summary>
        [UrlTerminator, UrlSegment("driverStandings")]
        public int? DriverStanding { get; set; }
    }
}