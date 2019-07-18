using ErgastApi.Client.Attributes;
using ErgastApi.Exceptions;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of constructors matching the specified filters.
    /// </summary>
    public class DriverInfoRequest : StandardRequest<DriverResponse>
    {
        /// <summary>
        /// Position in the driver standings (WDC).
        /// Cannot be used in combination with circuit, grid, result or status qualifiers.
        /// </summary>
        [UrlSegment("driverStandings")]
        public int? DriverStanding { get; set; }

        [UrlTerminator]
        public override string DriverId { get; set; }

        /// <summary>
        /// Verifies that the request is valid and otherwise throws an exception.
        /// This request cannot combine the <see cref="DriverStanding"/> filter with any of the circuit, grid, result or status qualifiers.
        /// </summary>
        public override void Verify()
        {
            base.Verify();

            if (DriverStanding != null && HasCircuitGridResultOrStatusQualifier)
                throw ErgastInvalidRequestException.InvalidStandingsRequest(nameof(DriverStanding));
        }
    }
}
