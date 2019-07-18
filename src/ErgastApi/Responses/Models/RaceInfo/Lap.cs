using System.Collections.Generic;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models.RaceInfo
{
    /// <summary>
    /// A lap with a list of lap times for each driver set on that lap.
    /// </summary>
    public class Lap
    {
        /// <summary>
        /// The lap number of this lap.
        /// </summary>
        [JsonProperty("number")]
        public int Number { get; private set; }

        /// <summary>
        /// The drivers and their lap times for this lap.
        /// </summary>
        [JsonProperty("Timings")]
        public IList<LapTiming> Timings { get; private set; }
    }
}