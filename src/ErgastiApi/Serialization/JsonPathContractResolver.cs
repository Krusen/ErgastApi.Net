using System;
using System.Linq;
using System.Reflection;
using ErgastApi.Serialization.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization
{
    public class JsonPathContractResolver : DefaultContractResolver
    {
        public JsonPathContractResolver()
        {
        }

        public JsonPathContractResolver(NamingStrategy namingStrategy)
        {
            NamingStrategy = namingStrategy;
        }

        private static bool HasPropertiesUsingJsonPath(JsonObjectContract contract)
        {
            return contract.Properties.Any(x => x.AttributeProvider
                .GetAttributes(typeof(JsonPathPropertyAttribute), true)
                .Any());
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);

            if (HasPropertiesUsingJsonPath(contract))
                contract.Converter = new JsonPathConverter(contract);

            return contract;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            prop.Writable = prop.Writable ? prop.Writable : HasPrivateSetter(member);

            // TODO: Clean up a bit. Ignores attributes with JsonPathProperty attribute in default serializer
            prop.Ignored = prop.Ignored || prop.AttributeProvider.GetAttributes(typeof(JsonPathPropertyAttribute), true).Any();

            return prop;
        }

        private static bool HasPrivateSetter(MemberInfo member)
        {
            var property = member as PropertyInfo;
            return property?.GetSetMethod(true) != null;
        }
    }
}
