using System;
using ErgastApi.Serialization;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class FastestLap
    {
        public int Rank { get; set; }

        public int Lap { get; set; }

        // TODO: Does not have "time"/BehindWinner prop
        [JsonPathProperty("Time.time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Time { get; set; }

        public AverageSpeed AverageSpeed { get; set; }
    }
}