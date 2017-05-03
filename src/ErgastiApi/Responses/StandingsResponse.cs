using System.Collections.Generic;
using System.Linq;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    // TODO: Move classes/interfaces out
    public interface IStandingsResponse<T> : IErgastResponse where T : IStanding
    {
        IList<IStandingsList<T>> StandingsLists { get; set; }
    }

    public abstract class StandingsResponse<T> : ErgastResponse, IStandingsResponse<T> where T : IStanding
    {
        // TODO: Handle creating generic types in InterfaceJsonConverter
        [JsonPathProperty("StandingsTable.StandingsLists")]
        public IList<IStandingsList<T>> StandingsLists { get; set; }
    }

    public interface IStandingsList<T> where T : IStanding
    {
        int Season { get; }

        int Round { get; }

        IList<T> Standings { get; }
    }

    public class StandingsList<T> : IStandingsList<T> where T : IStanding
    {
        public int Season { get; set; }

        public int Round { get; set; }

        //public IList<T> Standings => DriverStandings?.Cast<T>().ToList() ?? ConstructorStandings?.Cast<T>().ToList();
        public IList<T> Standings => DriverStandings ?? ConstructorStandings;

        public IList<T> DriverStandings { get; set; }

        public IList<T> ConstructorStandings { get; set; }
    }

    public interface IStanding
    {
        int Position { get; }

        // TODO: Some of these values are not relevant for standings (if any)
        // TODO: Docu: equals Position or "R" retired, "D" disqualified, "E" excluded, "W" withdrawn, "F" failed to qualify, "N" not classified. See Status for more info
        string PositionText { get; }

        int Points { get; }

        int Wins { get; }
    }

    public interface IDriverStandingsResponse : IStandingsResponse<IDriverStanding>
    { }

    public class DriverStandingsResponse : StandingsResponse<IDriverStanding>, IDriverStandingsResponse
    {
    }

    public interface IDriverStanding : IStanding
    {
        // TODO: Interface
        Driver Driver { get; }

        // TODO: Interface
        IList<Constructor> Constructors { get; }
    }

    public class DriverStanding : IDriverStanding
    {
        public int Position { get; set; }

        public string PositionText { get; set; }

        public int Points { get; set; }

        public int Wins { get; set; }

        public Driver Driver { get; set; }

        public IList<Constructor> Constructors { get; set; }
    }

    public interface IConstructorStandingsResponse : IStandingsResponse<IConstructorStanding>
    {
    }

    public class ConstructorStandingsResponse : StandingsResponse<IConstructorStanding>, IConstructorStandingsResponse
    {

    }

    public interface IConstructorStanding : IStanding
    {
        Constructor Constructor { get; }
    }

    public class ConstructorStanding : IConstructorStanding
    {
        public int Position { get; set; }
        public string PositionText { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }
        public Constructor Constructor { get; set; }
    }
}
