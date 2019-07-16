using System.Collections.Generic;
using ErgastApi.Responses.Models;
using JsonExts.JsonPath;

namespace ErgastApi.Responses
{
    public class ConstructorResponse : ErgastResponse
    {
        [JsonPath("ConstructorTable.Constructors")]
        public IList<Constructor> Constructors { get; private set; }
    }
}
