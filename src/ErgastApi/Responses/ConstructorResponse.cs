using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    /// <summary>
    /// A response containing a list of constructors matching the request.
    /// </summary>
    public class ConstructorResponse : ErgastResponse
    {
        [JsonPath("ConstructorTable.Constructors")]
        public IList<Constructor> Constructors { get; private set; }
    }
}
