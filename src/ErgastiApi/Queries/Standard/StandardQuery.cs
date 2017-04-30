using ErgastApi.Enums;

namespace ErgastApi.Queries
{
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
        public virtual FinishingStatus? FinishingStatus { get; set; }
    }
}