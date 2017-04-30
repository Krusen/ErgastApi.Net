using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization
{
    public class PrivatePropertyResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            if (prop.Writable)
                return prop;

            var property = member as PropertyInfo;
            if (property != null)
            {
                prop.Writable = property.GetSetMethod(true) != null;
            }

            return prop;
        }
    }
}
