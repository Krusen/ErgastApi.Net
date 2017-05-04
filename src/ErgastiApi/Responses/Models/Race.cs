using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    // TODO: Make setters private?
    public class Race
    {
        // TODO: Make season (year) an int as well?
        public int Season { get; set; }

        public int Round { get; set; }

        public string RaceName { get; set; }

        [JsonProperty("url")]
        public string WikiUrl { get; set; }

        public Circuit Circuit { get; set; }

        public DateTime StartTime => DateTime.Parse(DateRaw + " " + TimeRaw, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

        [JsonProperty("date")]
        internal string DateRaw { get; set; }

        [JsonProperty("time")]
        internal string TimeRaw { get; set; }
    }

    public class RaceWithResults : Race
    {
        public IList<RaceResult> Results { get; set; }
    }

    public class RaceWithPitStops : Race
    {
        public IList<PitStop> PitStops { get; set; }
    }

    public class RaceWithLapTimes : Race
    {
        [JsonProperty("Laps")]
        public IList<Lap> LapTimes { get; set; }
    }

    public class RaceWithQualifyingResults : Race
    {
        public IList<QualifyingResult> QualifyingResults { get; set; }
    }
}
