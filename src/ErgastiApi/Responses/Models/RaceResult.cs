using System;
using ErgastApi.Enums;
using ErgastApi.Serialization;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class RaceResult : ResultBase
    {
        // TODO: Docu: equals Position or "R" retired, "D" disqualified, "E" excluded, "W" withdrawn, "F" failed to qualify, "N" not classified. See Status for more info
        public string PositionText { get; set; }

        public int Points { get; set; }

        // TODO: Docu: 0 means starting from pit lane
        public int Grid { get; set; }

        public int Laps { get; set; }

        // TODO: Enum? (FinishingStatusId) Value contains stuff like "+1 Lap". Probably needs to be mapped on enum and then custom converter
        public string Status { get; set; }

        public FinishingStatusId StatusId => FinishingStatusIdParser.Parse(Status);

        public FastestLap FastestLap { get; set; }

        // TODO: Docu: Null for lapped cars
        [JsonPathProperty("Time.millis")]
        [JsonConverter(typeof(TimeSpanMillisecondsConverter))]
        public TimeSpan TotalRaceTime { get; set; }

        // TODO: Docu: Null for winner and lapped cars
        [JsonPathProperty("Time.time")]
        [JsonConverter(typeof(TimeSpanStringGapConverter))]
        public TimeSpan? GapToWinner { get; set; }
    }
}