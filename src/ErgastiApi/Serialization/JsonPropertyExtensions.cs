using System.Linq;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization
{
    public static class JsonPropertyExtensions
    {
        public static bool HasAttribute<T>(this JsonProperty property)
        {
            return property.AttributeProvider.GetAttributes(typeof(T), true).Any();
        }
    }
}
