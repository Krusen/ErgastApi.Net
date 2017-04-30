using ErgastApi.Enums;

namespace ErgastApi.Queries
{
    public interface IInfoQuery
    {
        string CircuitId { get; set; }
        string ConstructorId { get; set; }
        string DriverId { get; set; }
        int FastestLapRank { get; set; }
        int FinishingPosition { get; set; }
        FinishingStatus FinishingStatus { get; set; }
        int QualifyingPosition { get; set; }
        int Round { get; set; }
        int Season { get; set; }
    }
}