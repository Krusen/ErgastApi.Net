using System;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    // TODO: Use internal/private constructors for all response types?
    public abstract class ErgastResponse
    {
        public string Url { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }

        [JsonProperty("total")]
        public int TotalResults { get; set; }

        // TODO: Note that it can be inaccurate if limit/offset do not correlate
        // TODO: Test with 0 values
        public int Page => Offset / Limit + 1;

        // TODO: Test with 0 values
        public int TotalPages => (int) Math.Ceiling(TotalResults / (double)Limit);

        // TODO: Test
        public bool HasMorePages => TotalResults > Limit + Offset;
    }
}
