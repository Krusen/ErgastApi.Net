using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    public class CircuitResponse : ErgastResponse
    {
        [JsonPath("CircuitTable.Circuits")]
        public IList<Circuit> Circuits { get; private set; }
    }
}
