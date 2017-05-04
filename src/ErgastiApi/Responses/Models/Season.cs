﻿using Newtonsoft.Json;

namespace ErgastApi.Responses.Models
{
    public class Season
    {
        // TODO: Naming? int/string?
        [JsonProperty("season")]
        public int Year { get; private set; }

        [JsonProperty("url")]
        public string WikiUrl { get; private set; }
    }
}
