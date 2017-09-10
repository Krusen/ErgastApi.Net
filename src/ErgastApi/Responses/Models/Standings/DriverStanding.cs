using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.Standings
{
    public class DriverStanding : Standing
    {
        public Driver Driver { get; set; }

        /// <summary>
        /// The latest constructor which the driver has driven for.
        /// </summary>
        public Constructor Constructor => AllConstructors.LastOrDefault();

        /// <summary>
        /// A list of all the constructors the driver has driven for up to this point in the season.
        /// </summary>
        [JsonProperty("Constructors")]
        public IList<Constructor> AllConstructors { get; set; }
    }
}