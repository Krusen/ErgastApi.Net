using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.Standings
{
    public class DriverStandingsList : StandingsList<DriverStanding>
    {
        [JsonProperty("DriverStandings")]
        public override IList<DriverStanding> Standings { get; set; }
    }
}