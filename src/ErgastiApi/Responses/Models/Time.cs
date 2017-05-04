using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Time
    {
        [JsonProperty("millis")]
        [JsonConverter(typeof(TimeSpanMillisecondsConverter))]
        public TimeSpan RaceTime { get; set; }

        // TODO: Custom converter for "+67.7" format
        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanStringGapConverter))]
        public TimeSpan? BehindWinner { get; set; }
    }
}