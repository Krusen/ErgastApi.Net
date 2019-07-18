using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    /// <summary>
    /// A response containing a list of drivers matching the request.
    /// </summary>
    public class DriverResponse : ErgastResponse
    {
        [JsonPath("DriverTable.Drivers")]
        public IList<Driver> Drivers { get; private set; }
    }
}
