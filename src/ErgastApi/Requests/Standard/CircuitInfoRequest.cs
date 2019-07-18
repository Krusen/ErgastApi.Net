using ErgastApi.Client.Attributes;
using ErgastApi.Ids;
using ErgastApi.Responses;

namespace ErgastApi.Requests
{
    /// <summary>
    /// A request to get a list of circuits matching the specified filters.
    /// </summary>
    public class CircuitInfoRequest : StandardRequest<CircuitResponse>
    {
        /// <summary>
        /// The ID of the circuit.
        /// The static <see cref="Circuits"/> class contains the IDs for most recent and popular circuits.
        /// </summary>
        [UrlTerminator]
        public override string CircuitId { get; set; }
    }
}