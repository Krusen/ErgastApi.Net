using System.Collections.Generic;

namespace ErgastApi.Responses.Models
{
    public class Lap
    {
        public int Number { get; set; }

        public IList<LapTiming> Timings { get; set; }
    }
}