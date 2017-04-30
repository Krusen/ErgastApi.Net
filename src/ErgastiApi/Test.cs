using ErgastApi.Enums;
using ErgastApi.Models;
using ErgastApi.Queries;
using ErgastApi.Queries.Default.Info;
using Newtonsoft.Json;

namespace ErgastApi
{
    public class Test
    {
        public void Testing()
        {
            //var query = new Query() as IEmptyQuery;

            //query.Season(2017).LastRound.Drivers(Driver.ALO).DriverStandings(1).Limit(10).Offset(10);
            //query.Drivers("alonso").DriverStandings();

            var api = (IErgastApi) null;

            var query = new DriverQueryBase
            {
                Season = 2017,
                Round = 2,
                DriverId = "alonso"
            };

            var response = api.Execute(query);
        }
    }
}
