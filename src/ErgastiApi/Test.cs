using ErgastApi.Queries;
using ErgastApi.Queries.Standard;

namespace ErgastApi
{
    public class Test
    {
        public void Testing()
        {
            //var query = new Query() as IEmptyQuery;

            //query.Season(2017).LastRound.Drivers(Driver.ALO).DriverStandings(1).Limit(10).Offset(10);
            //query.Drivers("alonso").DriverStandings();

            var api = (ErgastApi) null;

            var query = new DriverInfoQuery()
            {
                Season = 2017,
                Round = 2,
                DriverId = "alonso"
            };

            var response = api.Execute(query);
        }
    }
}
