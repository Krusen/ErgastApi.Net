using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// Qualifying result including times set in Q1, Q2 and Q3.
    /// </summary>
    public class QualifyingResult : ResultBase
    {
        /// <summary>
        /// Time set in Q1.
        /// </summary>
        [JsonProperty("Q1")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? Q1 { get; private set; }

        /// <summary>
        /// Time set in Q2.
        /// </summary>
        [JsonProperty("Q2")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? Q2 { get; private set; }

        /// <summary>
        /// Time set in Q3.
        /// </summary>
        [JsonProperty("Q3")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? Q3 { get; private set; }
    }
}