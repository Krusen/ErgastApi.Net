using System;
using System.Globalization;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class Race
    {
        // TODO: Make season (year) an int as well?
        [JsonProperty("season")]
        public int Season { get; private set; }

        [JsonProperty("round")]
        public int Round { get; private set; }

        [JsonProperty("raceName")]
        public string RaceName { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        [JsonProperty("circuit")]
        public Circuit Circuit { get; private set; }

        public DateTime StartTime => DateTime.Parse(DateRaw + " " + TimeRaw, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

        [JsonProperty("date")]
        internal string DateRaw { get; private set; }

        [JsonProperty("time")]
        internal string TimeRaw { get; private set; }
    }
}
