using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    public interface IDriverStandings : IQuery
    {
        IQuery DriverStandings();
        IDriverStandingsQuery DriverStandings(int position);
    }
}