using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization
{
    public class JsonPathPropertyInfo
    {
        public JsonProperty JsonProperty { get; set; }

        public string Path { get; set; }
    }
}
