using System;
using ErgastApi.Serialization;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class FastestLap
    {
        [JsonProperty("rank")]
        public int Rank { get; private set; }

        [JsonProperty("lap")]
        public int LapNumber { get; private set; }

        [JsonPathProperty("Time.time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan LapTime { get; private set; }

        [JsonProperty("AverageSpeed")]
        public AverageSpeed AverageSpeed { get; private set; }
    }
}