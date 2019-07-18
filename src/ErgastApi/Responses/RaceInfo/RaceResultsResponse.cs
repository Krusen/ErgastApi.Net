using ErgastApi.Responses.Models.RaceInfo;

namespace ErgastApi.Responses
{
    /// <summary>
    /// A response containing list of races (with race results) matching the request.
    /// </summary>
    public class RaceResultsResponse : RaceResponse<RaceWithResults>
    {
    }
}