using ErgastApi.Interfaces.Queries;

namespace ErgastApi.Interfaces.Methods
{
    public interface IDriverStandings : IPageableQuery
    {
        IPageableQuery DriverStandings();
        IDriverStandingsQuery DriverStandings(int position);
    }
}