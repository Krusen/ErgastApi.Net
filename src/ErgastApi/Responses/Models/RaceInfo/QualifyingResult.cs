using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class QualifyingResult : ResultBase
    {
        [JsonProperty("Q1")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? Q1 { get; private set; }

        [JsonProperty("Q2")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? Q2 { get; private set; }

        [JsonProperty("Q3")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? Q3 { get; private set; }
    }
}