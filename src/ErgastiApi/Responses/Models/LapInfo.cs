using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class LapInfo
    {
        public string DriverId { get; set; }

        public int Position { get; set; }

        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Time { get; set; }
    }
}