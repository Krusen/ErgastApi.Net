using System;
using Newtonsoft.Json;

namespace ErgastApi.Responses
{
    // TODO: Use internal/private constructors for all response types?
    public abstract class ErgastResponse
    {
        [JsonProperty("url")]
        public string RequestUrl { get; protected set; }

        [JsonProperty("limit")]
        public int Limit { get; protected set; }

        [JsonProperty("offset")]
        public int Offset { get; protected set; }

        [JsonProperty("total")]
        public int TotalResults { get; protected set; }

        // TODO: Note that it can be inaccurate if limit/offset do not divide evenly
        public int Page
        {
            get
            {
                if (Limit <= 0)
                    return 1;

                return (int) Math.Ceiling((double) Offset / Limit) + 1;
            }
        }

        // TODO: Test with 0 values
        public int TotalPages => (int) Math.Ceiling(TotalResults / (double) Limit);

        // TODO: Test
        public bool HasMorePages => TotalResults > Limit + Offset;
    }
}
