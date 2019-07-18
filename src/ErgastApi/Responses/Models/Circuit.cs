using ErgastApi.Ids;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    /// <summary>
    /// Contains information about a circuit like its ID, name and location.
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// The ID of the circuit in the API. Used to make requests concerning a specific driver.
        /// The static <see cref="Circuits"/> class contains the IDs of most recent and popular circuits.
        /// </summary>
        [JsonProperty("circuitId")]
        public string CircuitId { get; private set; }

        [JsonProperty("circuitName")]
        public string CircuitName { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        [JsonProperty("location")]
        public Location Location { get; private set; }
    }
}