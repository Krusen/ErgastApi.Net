namespace ErgastApi.Requests
{
    // TODO: Move to Ids namespace together with Drivers, Circuits etc.? Or the other way around?
    /// <summary>
    /// Constants for querying relative seasons, e.g. current season.
    /// </summary>
    public static class Seasons
    {
        /// <summary>
        /// This is the same as not specifying a season.
        /// </summary>
        public const string All = null;

        /// <summary>
        /// The current season.
        /// </summary>
        public const string Current = "current";
    }
}