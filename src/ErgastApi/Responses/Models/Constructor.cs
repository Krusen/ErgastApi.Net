using ErgastApi.Ids;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    /// <summary>
    /// Contains information about a constructor like its ID, name and nationality.
    /// </summary>
    public class Constructor
    {
        /// <summary>
        /// The ID of the constructor in the API. Used to make requests concerning a specific constructor.
        /// The static <see cref="Constructors"/> class contains the IDs of most recent and popular constructors.
        /// </summary>
        [JsonProperty("constructorId")]
        public string ConstructorId { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("nationality")]
        public string Nationality { get; private set; }
    }
}