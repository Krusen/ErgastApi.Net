using System;
using ErgastApi.Serialization;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class FastestLap
    {
        public int Rank { get; set; }

        [JsonProperty("lap")]
        public int LapNumber { get; set; }

        // TODO: Does not have "time"/BehindWinner prop
        [JsonPathProperty("Time.time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan LapTime { get; set; }

        public AverageSpeed AverageSpeed { get; set; }
    }
}