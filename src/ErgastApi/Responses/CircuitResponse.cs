using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    /// <summary>
    /// A response containing a list of circuits matching the request.
    /// </summary>
    public class CircuitResponse : ErgastResponse
    {
        [JsonPath("CircuitTable.Circuits")]
        public IList<Circuit> Circuits { get; private set; }
    }
}
