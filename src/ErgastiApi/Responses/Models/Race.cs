using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace ErgastApi.Responses.Models
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

    public class RaceWithResults : Race
    {
        [JsonProperty("Results")]
        public IList<RaceResult> Results { get; private set; }
    }

    public class RaceWithPitStops : Race
    {
        [JsonProperty("PitStops")]
        public IList<PitStopInfo> PitStops { get; private set; }
    }

    public class RaceWithLapTimes : Race
    {
        [JsonProperty("Laps")]
        public IList<Lap> Laps { get; private set; }
    }

    public class RaceWithQualifyingResults : Race
    {
        [JsonProperty("QualifyingResults")]
        public IList<QualifyingResult> QualifyingResults { get; private set; }
    }
}
