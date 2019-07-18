namespace ErgastApi.Requests
{
    /// <summary>
    /// Common interface for all requests, which contains properties for paging and limiting results to a season, round and/or driver.
    /// </summary>
    public interface IErgastRequest
    {
        /// <summary>
        /// The number of results to return. Must be between 1 and 1000.
        /// Default value if not specified is 30.
        /// The <see cref="Page"/> method can be used for easier paging.
        /// </summary>
        int? Limit { get; set; }

        /// <summary>
        /// The offset to start from, used for paging the results together with <see cref="Limit"/>.
        /// The <see cref="Page"/> method can be used for easier paging.
        /// </summary>
        int? Offset { get; set; }

        /// <summary>
        /// Convenience method used for paging. Sets the limit and offset values for you.
        /// </summary>
        /// <param name="page">The page to get. Use 1 for the first page.</param>
        /// <param name="pageSize">The results to return per page.</param>
        void Page(int page, int pageSize);

        /// <summary>
        /// Limits the results to the specified season (year).
        /// Use <see cref="Seasons.Current"/> for current season.
        /// </summary>
        string Season { get; set; }

        /// <summary>
        /// Limits the results to the specified round (number).
        /// Use <see cref="Rounds.Last"/> or <see cref="Rounds.Next"/> for the either last or next round.
        /// If this is specified <see cref="Season"/> must also be specified.
        /// </summary>
        string Round { get; set; }

        /// <summary>
        /// Verify the request is valid. Implementing classes should throw an exception if the request is invalid.
        /// </summary>
        void Verify();
    }
}