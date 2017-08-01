using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization.Converters
{
    public class JsonPathConverter : JsonConverter
    {
        private IEnumerable<JsonPathPropertyInfo> PathProperties { get; }

        public JsonPathConverter(IEnumerable<JsonPathPropertyInfo> pathProperties)
        {
            PathProperties = pathProperties;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JObject.Load(reader);
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;

            if (contract == null)
                throw new InvalidOperationException("JsonPathConverter cannot be used with value types or arrays.");

            // This is done to avoid an infinite loop by calling this same converter for the root object
            var value = CreateRootObject(token, contract, serializer);

            foreach (var pathPropertyInfo in PathProperties)
            {
                var jsonProperty = pathPropertyInfo.JsonProperty;

                // TODO: Case-insensitive JsonPath instead of SelectToken
                var pathToken = token.SelectToken(pathPropertyInfo.Path);
                if (pathToken == null)
                    continue;

                object propObj;
                if (jsonProperty.Converter != null)
                {
                    var propReader = pathToken.CreateReader();
                    propReader.Read();
                    propObj = jsonProperty.Converter.ReadJson(propReader, jsonProperty.PropertyType, null, serializer);
                }
                else
                {
                    propObj = pathToken.ToObject(jsonProperty.PropertyType, serializer);
                }
                jsonProperty.ValueProvider.SetValue(value, propObj);
            }

            return value;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates and populates the root object using the default settings.
        /// </summary>
        private static object CreateRootObject(JToken token, JsonContract contract, JsonSerializer serializer)
        {
            var value = contract.DefaultCreator();
            serializer.Populate(token.CreateReader(), value);
            return value;
        }
    }
}
