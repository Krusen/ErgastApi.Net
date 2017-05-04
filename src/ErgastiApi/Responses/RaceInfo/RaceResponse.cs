using System.Collections.Generic;
using ErgastApi.Responses.Models.RaceInfo;
using ErgastApi.Serialization;

namespace ErgastApi.Responses.RaceInfo
{
    public abstract class RaceResponse<T> : ErgastResponse where T : Race
    {
        [JsonPathProperty("RaceTable.Races")]
        public IList<T> Races { get; private set; }
    }
}
