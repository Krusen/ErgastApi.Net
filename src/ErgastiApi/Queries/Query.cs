using System;
using ErgastApi.Enums;

namespace ErgastApi.Queries
{
    public abstract class Query
    {
        [QueryMethod(Order = 1)]
        public virtual int? Season { get; set; }

        // TODO: Require season to be not null
        [QueryMethod(Order = 2)]
        [QueryDependency(nameof(Season))]
        public virtual int? Round { get; set; }

        [QueryMethod("drivers")]
        public virtual string DriverId { get; set; }
    }

    public abstract class LapTimesAndPitStopsQuery : Query
    {
        [QueryMethod("laps")]
        public virtual int? Lap { get; set; }

        [QueryMethod("pitstops")]
        public virtual int? PitStop { get; set; }
    }

    public class LapTimesQuery : LapTimesAndPitStopsQuery
    {
        [QueryTerminator]
        public override int? Lap { get; set; }
    }

    public class PitStopsQuery : LapTimesAndPitStopsQuery
    {
        [QueryTerminator]
        public override int? PitStop { get; set; }
    }



    public abstract class StandardQuery : Query
    {
        [QueryMethod("constructors")]
        public virtual string ConstructorId { get; set; }

        [QueryMethod("circuits")]
        public virtual string CircuitId { get; set; }

        [QueryMethod("fastests")]
        public virtual int? FastestLapRank { get; set; }

        [QueryMethod("results")]
        public virtual int? FinishingPosition { get; set; }

        // Grid / starting position
        [QueryMethod("grid")]
        public virtual int? QualifyingPosition { get; set; }

        [QueryMethod("status")]
        public virtual FinishingStatus FinishingStatus { get; set; }
    }

    public class DriverInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string DriverId { get; set; }
    }

    public class ConstructorInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string ConstructorId { get; set; }
    }

    public class CircuitInfoQuery : StandardQuery
    {
        [QueryTerminator]
        public override string CircuitId { get; set; }
    }

    public class FinishingStatusQuery : StandardQuery
    {
        [QueryTerminator]
        public override FinishingStatus FinishingStatus { get; set; }
    }

    public class QualifyingResultsQuery : StandardQuery
    {
        [QueryTerminator, QueryMethod("qualifying")]
        protected object Qualifying { get; }
    }

    public class RaceResultsQuery : StandardQuery
    {
        [QueryTerminator]
        public override int? FinishingPosition { get; set; }
    }

    public class SeasonListQuery : StandardQuery
    {
        // Value not used
        [QueryTerminator, QueryMethod("seasons")]
        protected object Seasons { get; }
    }

    public class RaceListQuery : StandardQuery
    {
        // Value not used
        [QueryTerminator, QueryMethod("races")]
        protected object Races { get; }
    }



    public abstract class StandingsQuery : Query
    {
        [QueryMethod("constructors")]
        public virtual string ConstructorId { get; set; }
    }

    public class DriverStandingsQuery : StandingsQuery
    {
        [QueryMethod("driverStandings")]
        public int? DriverStanding { get; set; }
    }

    public class ConstructorStandingsQuery : StandingsQuery
    {
        [QueryMethod("constructorStandings")]
        public int? ConstructorStanding { get; set; }
    }
}