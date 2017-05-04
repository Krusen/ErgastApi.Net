using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Season
    {
        // TODO: Naming? int/string?
        [JsonProperty("season")]
        public int Year { get; set; }

        [JsonProperty("url")]
        public string WikiUrl { get; set; }
    }
}
