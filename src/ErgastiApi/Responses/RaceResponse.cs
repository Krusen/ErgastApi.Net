using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    public class RaceResponse : ErgastResponse
    {
        public IList<Race> Races { get; }
    }

    // TODO: Make setters private and add JsonProperty attribute
    public class Race : IRace, IRaceWithPitStops, IRaceWithLapTimes
    {
        // TODO: Make season (year) an int as well?
        public string Season { get; set; }

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

        public IList<RaceResult> Results { get; set; }

        public IList<QualifyingResult> QualifyingResults { get; set; }

        public IList<PitStop> PitStops { get; set; }

        [JsonProperty("laps")]
        public IList<LapTime> LapTimes { get; set; }
    }

    public interface IRace
    {
        string Season { get; set; }

        int Round { get; set; }

        string RaceName { get; set; }

        string WikiUrl { get; set; }

        Circuit Circuit { get; set; }

        DateTime StartTime { get; }
    }

    public interface IRaceWithResults : IRace
    {
        IList<RaceResult> Results { get; }
    }

    public interface IRaceWithQualifyingResults : IRace
    {
        IList<QualifyingResult> QualifyingResults { get; }
    }

    public interface IRaceWithPitStops : IRace
    {
        IList<PitStop> PitStops { get; }
    }

    public interface IRaceWithLapTimes : IRace
    {
        IList<LapTime> LapTimes { get; }
    }

    public class Circuit
    {
        public string CircuitId { get; }

        public string CircuitName { get; }

        [JsonProperty("url")]
        public string WikiUrl { get; }

        public Location Location { get; }
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

        // TODO: Enum? (FinishingStatus) Value contains stuff like "+1 Lap". Probably needs to be mapped on enum and then custom converter
        public string Status { get; set; }

        public FastestLap FastestLap { get; set; }

        // TODO: Docu: Might be null (lapped cars?)
        public Time Time { get; set; }
    }

    public class QualifyingResult : ResultBase
    {
        public TimeSpan Q1 { get; set; }

        public TimeSpan Q2 { get; set; }

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
        public Time Time { get; set; }

        public AverageSpeed AverageSpeed { get; set; }
    }

    // TODO: Rename?
    public class Time
    {
        [JsonProperty("millis")]
        public TimeSpan RaceTime { get; set; }

        // TODO: Custom converter for "+67.7" format
        [JsonProperty("time")]
        public TimeSpan BehindWinner { get; set; }
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
        public TimeSpan TimeOfDay { get; set; }

        // TODO: Custom TimeSpan converter from seconds (double)
        public TimeSpan Duration { get; set; }
    }

    public class LapTime
    {
        public string DriverId { get; set; }

        public int Position { get; set; }

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
