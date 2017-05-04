using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class PitStopInfo
    {
        [JsonProperty("driverId")]
        public string DriverId { get; private set; }

        [JsonProperty("lap")]
        public int Lap { get; private set; }

        [JsonProperty("stop")]
        public int Stop { get; private set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan TimeOfDay { get; private set; }

        [JsonProperty("duration")]
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan Duration { get; private set; }
    }
}