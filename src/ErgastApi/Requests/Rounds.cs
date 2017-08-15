namespace ErgastApi.Requests
{
    // TODO: Move to Ids namespace together with Drivers, Circuits etc.? Or the other way around?
    /// <summary>
    /// Constants for querying relative rounds, e.g. last round.
    /// </summary>
    public static class Rounds
    {
        /// <summary>
        /// This is the same as not specifying a round.
        /// </summary>
        public const string All = null;

        /// <summary>
        /// The last round.
        /// </summary>
        public const string Last = "last";

        /// <summary>
        /// The next round.
        /// </summary>
        public const string Next = "next";
    }
}