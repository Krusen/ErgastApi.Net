using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of constructor standings (WCC) matching the specified filters.
    /// </summary>
    public class ConstructorStandingsRequest : ErgastRequest<ConstructorStandingsResponse>
    {
        /// <summary>
        /// Limits the results to the specified constructor.
        /// The static <see cref="Constructors"/> class contains the IDs for most recent and popular constructors.
        /// </summary>
        [UrlSegment("constructors")]
        public string ConstructorId { get; set; }

        /// <summary>
        /// Position in the constructor standings (WCC).
        /// </summary>
        [UrlTerminator, UrlSegment("constructorStandings")]
        public int? ConstructorStanding { get; set; }
    }
}