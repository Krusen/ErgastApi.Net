using System.Collections.Generic;

namespace ErgastApi.Responses.Models.Standings
{
    public abstract class StandingsList<T> where T : Standing
    {
        public int Season { get; set; }

        public int Round { get; set; }

        public abstract IList<T> Standings { get; set; }
    }
}