using System;
using ErgastApi.Serialization.Converters;
using JsonExts.JsonPath;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// Information about the fastest lap of a driver.
    /// </summary>
    public class FastestLap
    {
        /// <summary>
        /// The rank of this fastest lap of the race.
        /// A value of 1 means it was the fastest lap of the race.
        /// </summary>
        [JsonProperty("rank")]
        public int Rank { get; private set; }

        /// <summary>
        /// The lap number on which this fastest lap was set.
        /// </summary>
        [JsonProperty("lap")]
        public int LapNumber { get; private set; }

        /// <summary>
        /// The lap time of this fastest lap.
        /// </summary>
        [JsonPath("Time.time")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? LapTime { get; private set; }

        /// <summary>
        /// The average speed of this fastest lap.
        /// </summary>
        [JsonProperty("AverageSpeed")]
        public AverageSpeed AverageSpeed { get; private set; }
    }
}