using ErgastApi.Enums;
using ErgastApi.Interfaces.Queries;
using ErgastApi.Models;

namespace ErgastApi
{
    public class Test
    {
        public void Testing()
        {
            var query = new Query() as IEmptyQuery;

            query.Season(2017).LastRound.Drivers(Driver.ALO).DriverStandings(1).Limit(10).Offset(10);
            query.Drivers("alonso").DriverStandings(1);
        }
    }
}
