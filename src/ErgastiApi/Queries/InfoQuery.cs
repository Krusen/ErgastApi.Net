using ErgastApi.Enums;

namespace ErgastApi.Queries
{
    public abstract class InfoQuery : IQuery, IInfoQuery
    {
        [QueryMethod(Order = 1)]
        public int Season { get; set; }

        [QueryMethod(Order = 2)]
        public int Round { get; set; }

        [QueryMethod("drivers")]
        public virtual string DriverId { get; set; }

        [QueryMethod("constructors")]
        public virtual string ConstructorId { get; set; }

        [QueryMethod("circuits")]
        public virtual string CircuitId { get; set; }

        [QueryMethod("fastests")]
        public int FastestLapRank { get; set; }

        [QueryMethod("results")]
        public virtual int FinishingPosition { get; set; }

        // Grid
        [QueryMethod("grid")]
        public int QualifyingPosition { get; set; }

        [QueryMethod("status")]
        public virtual FinishingStatus FinishingStatus { get; set; }
    }
}