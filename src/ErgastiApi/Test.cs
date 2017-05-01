using System.Linq;
using ErgastApi.Queries;
using ErgastApi.Requests;
using ErgastApi.Requests.Standard;
using ErgastApi.Requests.Standings;
using ErgastApi.Responses;
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

            //var query = new DriverInfoQuery()
            //{
            //    Season = 2017,
            //    Round = 2,
            //    DriverId = "alonso"
            //};

            //var request = new DriverInfoRequest
            //{

            //};

            //var response = new DriverStandingsResponse();
            //response.StandingsLists.FirstOrDefault().Standings.FirstOrDefault().Wins

            var req = new DriverStandingsRequest();

        }
    }
}
