using System;
using System.Globalization;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// Information about a specific race/grand prix.
    /// </summary>
    public class Race
    {
        [JsonProperty("season")]
        public int Season { get; private set; }

        [JsonProperty("round")]
        public int Round { get; private set; }

        /// <summary>
        /// The name of the race, e.g. The British Grand Prix.
        /// </summary>
        [JsonProperty("raceName")]
        public string RaceName { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        [JsonProperty("circuit")]
        public Circuit Circuit { get; private set; }

        /// <summary>
        /// The time of race start.
        /// </summary>
        public DateTime StartTime => DateTime.Parse(DateRaw + " " + TimeRaw, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

        [JsonProperty("date")]
        internal string DateRaw { get; private set; }

        [JsonProperty("time")]
        internal string TimeRaw { get; private set; }
    }
}
