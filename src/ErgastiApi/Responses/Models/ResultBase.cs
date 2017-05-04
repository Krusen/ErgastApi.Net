namespace ErgastApi.Responses.Models
{
    public abstract class ResultBase
    {
        public int Number { get; set; }

        public int Position { get; set; }

        public Driver Driver { get; set; }

        public Constructor Constructor { get; set; }
    }
}