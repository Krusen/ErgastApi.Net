using System;
using ErgastApi.Serialization.Converters;
using JsonExts.JsonPath;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class FastestLap
    {
        [JsonProperty("rank")]
        public int Rank { get; private set; }

        [JsonProperty("lap")]
        public int LapNumber { get; private set; }

        [JsonPath("Time.time")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? LapTime { get; private set; }

        [JsonProperty("AverageSpeed")]
        public AverageSpeed AverageSpeed { get; private set; }
    }
}