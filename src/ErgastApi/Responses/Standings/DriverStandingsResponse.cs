using ErgastApi.Responses.Models.Standings;

namespace ErgastApi.Responses
{
    /// <summary>
    /// A response containing a list of driver standings (WDC) matching the request.
    /// </summary>
    public class DriverStandingsResponse : StandingsResponse<DriverStandingsList>
    {
    }
}