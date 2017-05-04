namespace ErgastApi.Responses.Models.Standings
{
    public abstract class Standing
    {
        public int Position { get; set; }

        // TODO: Some of these values are not relevant for standings (if any)
        // TODO: Docu: equals Position or "R" retired, "D" disqualified, "E" excluded, "W" withdrawn, "F" failed to qualify, "N" not classified. See Status for more info
        public string PositionText { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }
    }
}