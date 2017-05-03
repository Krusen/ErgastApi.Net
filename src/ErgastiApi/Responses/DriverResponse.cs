using System.Collections.Generic;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;

namespace ErgastApi.Responses
{
    public class DriverResponse : ErgastResponse, IDriverResponse
    {
        [JsonPathProperty("DriverTable.Drivers")]
        public IList<IDriver> Drivers { get; set; }
    }
}
