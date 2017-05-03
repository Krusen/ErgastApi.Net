using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization
{
    // TODO: Rename to indicate JsonPath support as well
    public class InterfaceJsonConverter : JsonConverter
    {
        private ConcurrentDictionary<Type, Type> TypeMap { get; } = new ConcurrentDictionary<Type, Type>();

        public override bool CanConvert(Type objectType)
        {
            // TODO: Should not be needed as the converter is applied by the contract resolver (or directly with attribute)
            return !typeof(IEnumerable).IsAssignableFrom(objectType);
        }

        public override bool CanWrite => false;

        // TODO: Maybe only read properties specified on interface and not all properties on implementing type
        // TODO: Maybe read JsonAttribute/contract stuff from interface as well/instead?
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JObject.Load(reader);

            var type = GetMatchingType(objectType);

            var value = token.ToObject(type, serializer);

            var resolver = new InterfaceContractResolver();

            // TODO: Null-check and/or other contract types?
            JsonObjectContract contract = (JsonObjectContract)resolver.ResolveContract(type);

            var props = contract.Properties.Where(x => x.AttributeProvider.GetAttributes(typeof(JsonPathPropertyAttribute), true).Any());

            // TODO: Refactor this shit
            foreach (var prop in props)
            {
                var attr = prop.AttributeProvider.GetAttributes(typeof(JsonPathPropertyAttribute), true).First() as JsonPathPropertyAttribute;

                // TODO: Case-insensitive JsonPath instead of SelectToken
                var pathToken = token.SelectToken(attr.Path);
                if (pathToken != null)
                {
                    var propType = InterfaceContractResolver.CanHandleType(prop.PropertyType) ? GetMatchingType(prop.PropertyType) : prop.PropertyType;
                    var propObj = pathToken.ToObject(propType, serializer);
                    prop.ValueProvider.SetValue(value, propObj);
                }
            }

            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException("Should only be used for deserializing to interfaces");
        }

        // TODO: Add property to specify the specific implementation to use (e.g. if more than one)
        // TODO: Maybe refactor as GetClassType - if type is class just return it, otherwise try to get class implementing interface
        protected Type GetMatchingType(Type objectType)
        {
            if (objectType.IsClass || objectType.IsValueType)
                return objectType;

            Type matchingType;
            if (TypeMap.TryGetValue(objectType, out matchingType))
                return matchingType;

            var implementingTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetExportedTypes())
                .Where(x => !x.IsInterface && !x.IsAbstract && x.GetInterfaces().Contains(objectType))
                .ToList();

            if (!implementingTypes.Any())
                throw new NotSupportedException("No types implementing the interface: " + objectType.Name);

            if (implementingTypes.Count > 1)
                throw new NotSupportedException("More than one type implements the interface: " + objectType.Name);

            matchingType = implementingTypes.First();

            TypeMap.TryAdd(objectType, matchingType);

            return matchingType;
        }
    }
}
