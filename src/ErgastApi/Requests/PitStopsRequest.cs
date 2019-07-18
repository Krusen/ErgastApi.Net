using ErgastApi.Client.Attributes;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of pit stops matching the specified filters.
    /// </summary>
    public class PitStopsRequest : ErgastRequest<PitStopsResponse>
    {
        /// <summary>
        /// Limits the results to pit stops made on this lap.
        /// </summary>
        [UrlSegment("laps")]
        public int? Lap { get; set; }

        /// <summary>
        /// The pit stop number. Use to get pit stop info about the 1st/2nd/3rd pit stop etc.
        /// </summary>
        [UrlTerminator, UrlSegment("pitstops")]
        public int? PitStop { get; set; }
    }
}