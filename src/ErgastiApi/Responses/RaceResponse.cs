using System;
using System.Collections.Generic;
using System.Globalization;
using ErgastApi.Responses.Models;
using ErgastApi.Serialization;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    public class RaceResponse<T> : ErgastResponse where T : Race
    {
        [JsonPathProperty("RaceTable.Races")]
        public IList<T> Races { get; set; }
    }

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

   public class Circuit
    {
        public string CircuitId { get; set; }

        public string CircuitName { get; set; }

        [JsonProperty("url")]
        public string WikiUrl { get; set; }

        public Location Location { get; set; }
    }

    public abstract class ResultBase
    {
        public int Number { get; set; }

        public int Position { get; set; }

        public Driver Driver { get; set; }

        public Constructor Constructor { get; set; }
    }

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

        public FastestLap FastestLap { get; set; }

        // TODO: Docu: Might be null (lapped cars?)
        public Time Time { get; set; }
    }

    public class QualifyingResult : ResultBase
    {
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Q1 { get; set; }

        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Q2 { get; set; }

        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Q3 { get; set; }
    }


    public class Constructor
    {
        public string ConstructorId { get; set; }

        [JsonProperty("url")]
        public string WikiUrl { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }
    }

    // TODO: Rename?
    public class FastestLap
    {
        public int Rank { get; set; }

        public int Lap { get; set; }

        // TODO: Does not have "time"/BehindWinner prop
        [JsonPathProperty("Time.time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Time { get; set; }

        public AverageSpeed AverageSpeed { get; set; }
    }

    // TODO: Rename?
    public class Time
    {
        [JsonProperty("millis")]
        [JsonConverter(typeof(TimeSpanMillisecondsConverter))]
        public TimeSpan RaceTime { get; set; }

        // TODO: Custom converter for "+67.7" format
        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanStringGapConverter))]
        public TimeSpan? BehindWinner { get; set; }
    }

    // TODO: Rename?
    public class AverageSpeed
    {
        // TODO: Units enum - kph/mph
        public string Units { get; set; }

        public double Speed { get; set; }
    }

    public class PitStop
    {
        public string DriverId { get; set; }

        public int Lap { get; set; }

        public int Stop { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan TimeOfDay { get; set; }

        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan Duration { get; set; }
    }

    public class Lap
    {
        public int Number { get; set; }

        public IList<LapInfo> Timings { get; set; }
    }

    public class LapInfo
    {
        public string DriverId { get; set; }

        public int Position { get; set; }

        [JsonConverter(typeof(TimeSpanStringConverter))]
        public TimeSpan Time { get; set; }
    }

    public class Location
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }

        [JsonProperty("long")]
        public string Longitude { get; set; }

        public string Locality { get; set; }

        public string Country { get; set; }
    }
}
