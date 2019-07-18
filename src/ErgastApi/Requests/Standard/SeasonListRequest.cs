using ErgastApi.Client.Attributes;
using ErgastApi.Exceptions;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request for getting a list of seasons matching the specified filters.
    /// </summary>
    public class SeasonListRequest : StandardRequest<SeasonResponse>
    {
        /// <summary>
        /// Position in the constructor standings (WCC).
        /// Cannot be used in combination with circuit, grid, result or status qualifiers.
        /// </summary>
        [UrlSegment("constructorStandings")]
        public int? ConstructorStanding { get; set; }

        /// <summary>
        /// Position in the driver standings (WDC).
        /// Cannot be used in combination with circuit, grid, result or status qualifiers.
        /// </summary>
        [UrlSegment("driverStandings")]
        public int? DriverStanding { get; set; }

        /// <summary>
        /// Not used.
        /// Only here for the <see cref="UrlTerminatorAttribute"/> and <see cref="UrlSegmentAttribute"/>.
        /// </summary>
        [UrlTerminator, UrlSegment("seasons")]
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        protected object Seasons { get; }

        /// <summary>
        /// Verifies that the request is valid and otherwise throws an exception.
        /// This request cannot combine the <see cref="ConstructorStanding"/> nor the <see cref="DriverStanding"/> filters
        /// with any of the circuit, grid, result or status qualifiers.
        /// </summary>
        public override void Verify()
        {
            base.Verify();

            if (ConstructorStanding == null && DriverStanding == null)
                return;

            if (!HasCircuitGridResultOrStatusQualifier)
                return;

            throw ErgastInvalidRequestException.InvalidStandingsRequest($"{nameof(ConstructorStanding)} and {nameof(DriverStanding)}");
        }
    }
}