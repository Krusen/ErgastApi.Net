using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class LapTiming
    {
        [JsonProperty("driverId")]
        public string DriverId { get; private set; }

        [JsonProperty("position")]
        public int Position { get; private set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan Time { get; private set; }
    }
}