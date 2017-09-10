namespace ErgastApi.Responses.Models.Standings
{
    public abstract class Standing
    {
        public int Position { get; set; }

        /// <summary>
        /// Finishing position.
        /// R = Retired, D = Disqualified, E = Excluded, W = Withdrawn, F = Failed to qualify, N = Not classified.
        /// </summary>
        public string PositionText { get; set; }

        public double Points { get; set; }

        public int Wins { get; set; }
    }
}