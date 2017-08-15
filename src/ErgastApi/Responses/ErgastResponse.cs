using System;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    // TODO: Use internal/private constructors for all response types?
    /// <summary>
    /// Base class for responses returned from the Ergast API.
    /// It contains properties for the request URL, the limit and offset used, and the total number of results for the request.
    /// </summary>
    public abstract class ErgastResponse
    {
        /// <summary>
        /// The URL used for the request.
        /// </summary>
        [JsonProperty("url")]
        public string RequestUrl { get; protected set; }

        /// <summary>
        /// The limit used in the request.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit { get; protected set; }

        /// <summary>
        /// The offset used in the request.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset { get; protected set; }

        /// <summary>
        /// The total number of results.
        /// </summary>
        [JsonProperty("total")]
        public int TotalResults { get; protected set; }

        /// <summary>
        /// Calculates the current page number from the values of <see cref="Offset"/> and <see cref="Limit"/>.
        /// This will be inaccurate if offset and limit do not divide evenly.
        /// </summary>
        public int Page
        {
            get
            {
                if (Limit <= 0 || Offset <= 0)
                    return 1;

                return (int) Math.Ceiling((double) Offset / Limit) + 1;
            }
        }

        /// <summary>
        /// Calculates the number of total pages from the values of <see cref="TotalResults"/> and <see cref="Limit"/>.
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (Limit <= 0)
                    return 0;

                return (int) Math.Ceiling(TotalResults / (double) Limit);
            }
        }

        /// <summary>
        /// Calculates if there are more page left from the values of <see cref="TotalResults"/>, <see cref="Limit"/> and <see cref="Offset"/>.
        /// </summary>
        public bool HasMorePages => TotalResults > Limit + Offset;
    }
}
