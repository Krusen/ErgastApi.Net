using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// Lap time and position of a driver at the end of a lap.
    /// </summary>
    public class LapTiming
    {
        /// <summary>
        /// The driver who completed this lap.
        /// </summary>
        [JsonProperty("driverId")]
        public string DriverId { get; private set; }

        /// <summary>
        /// The driver's position at the end of this lap.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; private set; }

        /// <summary>
        /// The driver's lap time for this lap.
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan? Time { get; private set; }
    }
}