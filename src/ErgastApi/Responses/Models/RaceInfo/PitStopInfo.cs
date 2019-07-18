using System;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// Information about a pit stop during a race.
    /// </summary>
    public class PitStopInfo
    {
        /// <summary>
        /// The driver who made the pit stop.
        /// </summary>
        [JsonProperty("driverId")]
        public string DriverId { get; private set; }

        /// <summary>
        /// The lap on which the pit stop was made.
        /// </summary>
        [JsonProperty("lap")]
        public int Lap { get; private set; }

        /// <summary>
        /// The number of the pit stop in the race (for this driver).
        /// </summary>
        [JsonProperty("stop")]
        public int Stop { get; private set; }

        /// <summary>
        /// The time of day the pit stop was made.
        /// </summary>
        [JsonProperty("time")]
        [JsonConverter(typeof(StringTimeSpanConverter))]
        public TimeSpan TimeOfDay { get; private set; }

        /// <summary>
        /// The duration of the pit stop (time in pit lane).
        /// </summary>
        [JsonProperty("duration")]
        [JsonConverter(typeof(SecondsTimeSpanConverter))]
        public TimeSpan Duration { get; private set; }
    }
}