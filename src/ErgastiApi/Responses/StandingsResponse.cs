using System.Collections.Generic;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    public abstract class StandingsResponse<T> : ErgastResponse
    {
        // TODO: Handle creating generic types in InterfaceJsonConverter
        [JsonPathProperty("StandingsTable.StandingsLists")]
        public IList<T> StandingsLists { get; set; }
    }

    public abstract class StandingsList<T> where T : Standing
    {
        public int Season { get; set; }

        public int Round { get; set; }

        public abstract IList<T> Standings { get; set; }
    }

    public class DriverStandingsList : StandingsList<DriverStanding>
    {
        [JsonProperty("DriverStandings")]
        public override IList<DriverStanding> Standings { get; set; }
    }

    public class ConstructorStandingsList : StandingsList<ConstructorStanding>
    {
        [JsonProperty("ConstructorStandings")]
        public override IList<ConstructorStanding> Standings { get; set; }
    }

    public class DriverStandingsResponse : StandingsResponse<DriverStandingsList>
    {
    }

    public abstract class Standing
    {
        public int Position { get; set; }

        // TODO: Some of these values are not relevant for standings (if any)
        // TODO: Docu: equals Position or "R" retired, "D" disqualified, "E" excluded, "W" withdrawn, "F" failed to qualify, "N" not classified. See Status for more info
        public string PositionText { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }
    }

    public class DriverStanding : Standing
    {
        public Driver Driver { get; set; }
    }

    public class ConstructorStandingsResponse : StandingsResponse<ConstructorStandingsList>
    {

    }

    public class ConstructorStanding : Standing
    {
        public Constructor Constructor { get; set; }
    }
}
