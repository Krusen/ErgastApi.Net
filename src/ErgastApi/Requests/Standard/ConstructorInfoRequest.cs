using ErgastApi.Client.Attributes;
using ErgastApi.Exceptions;
using ErgastApi.Ids;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of constructors matching the specified filters.
    /// </summary>
    public class ConstructorInfoRequest : StandardRequest<ConstructorResponse>
    {
        /// <summary>
        /// Position in the constructor standings (WCC).
        /// Cannot be used in combination with circuit, grid, result or status qualifiers.
        /// </summary>
        [UrlSegment("constructorStandings")]
        public int? ConstructorStanding { get; set; }

        /// <summary>
        /// Limits the results to the specified constructor.
        /// The static <see cref="Constructors"/> class contains the IDs for most recent and popular constructors.
        /// </summary>
        [UrlTerminator]
        public override string ConstructorId { get; set; }

        /// <summary>
        /// Verifies that the request is valid and otherwise throws an exception.
        /// This request cannot combine the <see cref="ConstructorStanding"/> filter with any of the circuit, grid, result or status qualifiers.
        /// </summary>
        public override void Verify()
        {
            base.Verify();

            if (ConstructorStanding != null && HasCircuitGridResultOrStatusQualifier)
                throw ErgastInvalidRequestException.InvalidStandingsRequest(nameof(ConstructorStanding));
        }
    }
}