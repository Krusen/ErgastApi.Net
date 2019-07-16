using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    public class DriverResponse : ErgastResponse
    {
        [JsonPath("DriverTable.Drivers")]
        public IList<Driver> Drivers { get; private set; }
    }
}
