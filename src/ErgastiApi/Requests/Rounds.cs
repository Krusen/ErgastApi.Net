namespace ErgastApi.Requests
{
    /// <summary>
    /// Constants for querying relative rounds, e.g. last round.
    /// </summary>
    public static class Rounds
    {
        /// <summary>
        /// This is the same as not specifying a round.
        /// </summary>
        public const string All = null;
        public const string Last = "last";
        public const string Next = "next";
    }
}