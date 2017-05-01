using System.Collections.Generic;
using ErgastApi.Responses.Models;

namespace ErgastApi.Responses
{
    // TODO: Move classes/interfaces out
    public interface IStandingsResponse<T> : IErgastResponse where T : IStanding
    {
        IList<IStandingsList<T>> StandingsLists { get; set; }
    }


    public abstract class StandingsResponse<T> : ErgastResponse, IStandingsResponse<T> where T : IStanding
    {
        public IList<IStandingsList<T>> StandingsLists { get; set; }
    }

    public interface IStandingsList<T>
    {
        int Season { get; }

        int Round { get; }

        IList<T> Standings { get; }
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
}
