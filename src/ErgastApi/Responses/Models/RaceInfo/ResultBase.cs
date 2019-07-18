using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// Base class for results info.
    /// </summary>
    public abstract class ResultBase
    {
        /// <summary>
        /// The driver number.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; private set; }

        /// <summary>
        /// The final position of the driver.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; private set; }

        [JsonProperty("Driver")]
        public Driver Driver { get; private set; }

        [JsonProperty("Constructor")]
        public Constructor Constructor { get; private set; }
    }
}