using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class LapTiming
    {
        [JsonProperty("driverId")]
        public string DriverId { get; private set; }

        [JsonProperty("position")]
        public int Position { get; private set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Time { get; private set; }
    }
}