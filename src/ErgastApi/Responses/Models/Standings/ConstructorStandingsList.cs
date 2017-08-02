using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.Standings
{
    public class ConstructorStandingsList : StandingsList<ConstructorStanding>
    {
        [JsonProperty("ConstructorStandings")]
        public override IList<ConstructorStanding> Standings { get; set; }
    }
}