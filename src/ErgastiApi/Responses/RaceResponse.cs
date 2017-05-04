using System;
using System.Collections.Generic;
using System.Globalization;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    public class RaceResponse<T> : ErgastResponse where T : Race
    {
        [JsonPathProperty("RaceTable.Races")]
        public IList<T> Races { get; set; }
    }
}
