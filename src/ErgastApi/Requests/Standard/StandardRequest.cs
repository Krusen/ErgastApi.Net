using System.Linq;
using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;
using ErgastApi.Responses.Models;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A base request containing filters used for most standard requests.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class StandardRequest<TResponse> : ErgastRequest<TResponse> where TResponse : ErgastResponse
    {
        /// <summary>
        /// Limits the results to the specified driver.
        /// The static <see cref="Drivers"/> class contains the IDs for most recent and popular drivers.
        /// </summary>
        [UrlSegment("drivers")]
        public virtual string DriverId { get; set; }

        /// <summary>
        /// Limits the results to the specified constructor.
        /// The static <see cref="Constructors"/> class contains the IDs for most recent and popular constructors.
        /// </summary>
        [UrlSegment("constructors")]
        public virtual string ConstructorId { get; set; }

        /// <summary>
        /// Limits the results to the specified circuit.
        /// The static <see cref="Circuits"/> class contains the IDs for most recent and popular circuits.
        /// </summary>
        [UrlSegment("circuits")]
        public virtual string CircuitId { get; set; }

        /// <summary>
        /// The fastest lap rank of a driver, i.e. a value of 1 means the fastest lap of the race.
        /// </summary>
        [UrlSegment("fastest")]
        public virtual int? FastestLapRank { get; set; }

        /// <summary>
        /// The finishing position of a driver.
        /// </summary>
        [UrlSegment("results")]
        public virtual int? FinishingPosition { get; set; }

        /// <summary>
        /// The starting grid position of a driver. A value of 0 means the driver started from the pits.
        /// </summary>
        [UrlSegment("grid")]
        public virtual int? StartingPosition { get; set; }

        /// <summary>
        /// The finishing status of a driver, e.g. did they finish or why did they not finish.
        /// </summary>
        [UrlSegment("status")]
        public virtual FinishingStatusId? FinishingStatus { get; set; }

        /// <summary>
        /// Returns true if any of the circuit, grid, result or status qualifiers has been set.
        /// These qualifiers cannot be combined with standings modifiers.
        /// </summary>
        protected bool HasCircuitGridResultOrStatusQualifier
        {
            get
            {
                var values = new object[]
                {
                    CircuitId,
                    FinishingPosition,
                    FinishingStatus,
                    FastestLapRank,
                    StartingPosition
                };
                return values.Any(x => x != null);
            }
        }
    }
}