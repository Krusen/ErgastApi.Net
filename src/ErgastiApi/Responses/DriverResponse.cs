using System.Collections.Generic;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;

namespace ErgastApi.Responses
{
    public class DriverResponse : ErgastResponse
    {
        [JsonPathProperty("DriverTable.Drivers")]
        public IList<Driver> Drivers { get; set; }
    }
}
