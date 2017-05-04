using System.Collections.Generic;
using ErgastApi.Serialization;

namespace ErgastApi.Responses
{
    public class ConstructorResponse : ErgastResponse
    {
        [JsonPathProperty("ConstructorTable.Constructors")]
        public IList<Constructor> Constructors { get; set; }
    }
}
