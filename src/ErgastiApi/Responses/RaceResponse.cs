using System.Collections.Generic;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;

namespace ErgastApi.Responses
{
    public class RaceResponse<T> : ErgastResponse where T : Race
    {
        [JsonPathProperty("RaceTable.Races")]
        public IList<T> Races { get; private set; }
    }
}
