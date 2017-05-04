using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class PitStop
    {
        public string DriverId { get; set; }

        public int Lap { get; set; }

        public int Stop { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan TimeOfDay { get; set; }

        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan Duration { get; set; }
    }
}