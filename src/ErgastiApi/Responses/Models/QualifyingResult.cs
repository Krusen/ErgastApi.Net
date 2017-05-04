using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class QualifyingResult : ResultBase
    {
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Q1 { get; set; }

        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Q2 { get; set; }

        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Q3 { get; set; }
    }
}