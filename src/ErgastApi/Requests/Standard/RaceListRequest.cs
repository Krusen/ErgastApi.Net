using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of races matching the specified filters.
    /// </summary>
    public class RaceListRequest : StandardRequest<RaceListResponse>
    {
        /// <summary>
        /// Not used.
        /// Only here for the <see cref="UrlTerminatorAttribute"/> and <see cref="UrlSegmentAttribute"/>.
        /// </summary>
        [UrlTerminator, UrlSegment("races")]
        // ReSharper disable once UnassignedGetOnlyAutoProperty
        protected object Races { get; }
    }
}