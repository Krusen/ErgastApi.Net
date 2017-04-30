using System.Collections.Generic;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class DriverResponse : ErgastResponse, IDriverResponse
    {
        [JsonProperty("DriverTable.Drivers")]
        public IList<Driver> Drivers { get; set; }
    }
}
