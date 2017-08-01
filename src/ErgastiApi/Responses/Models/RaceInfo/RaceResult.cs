using System;
using ErgastApi.Ids;
using ErgastApi.Serialization;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    public class RaceResult : ResultBase
    {
        // TODO: Docu: equals Position or "R" retired, "D" disqualified, "E" excluded, "W" withdrawn, "F" failed to qualify, "N" not classified. See Status for more info
        [JsonProperty("positionText")]
        public string PositionText { get; private set; }

        [JsonProperty("points")]
        public int Points { get; private set; }

        // TODO: Docu: 0 means starting from pit lane
        [JsonProperty("grid")]
        public int Grid { get; private set; }

        public bool StartedFromPitLane => Grid == 0;

        [JsonProperty("laps")]
        public int Laps { get; private set; }

        // TODO: Enum? (FinishingStatusId) Value contains stuff like "+1 Lap". Probably needs to be mapped on enum and then custom converter
        [JsonProperty("status")]
        public string StatusText { get; private set; }

        [JsonIgnore]
        public FinishingStatusId Status => FinishingStatusIdParser.Parse(StatusText);

        [JsonProperty("FastestLap")]
        public FastestLap FastestLap { get; private set; }

        // TODO: Docu: Null for lapped cars
        [JsonPathProperty("Time.millis")]
        [JsonConverter(typeof(MillisecondsTimeSpanConverter))]
        public TimeSpan? TotalRaceTime { get; private set; }

        // TODO: Docu: Null for winner and lapped cars
        [JsonPathProperty("Time.time")]
        [JsonConverter(typeof(StringGapTimeSpanConverter))]
        public TimeSpan? GapToWinner { get; private set; }
    }
}