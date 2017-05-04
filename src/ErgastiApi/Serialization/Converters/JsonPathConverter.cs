using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization.Converters
{
    public class JsonPathConverter : JsonConverter
    {
        private JsonObjectContract ObjectContract { get; }

        public JsonPathConverter(JsonObjectContract contract)
        {
            // TODO: Remove, not used
            ObjectContract = contract;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contract = serializer.ContractResolver.ResolveContract(objectType) as JsonObjectContract;


            var token = JObject.Load(reader);

            // contract.DefaultCreator() + serializer.Populate used to avoid infinite loop by calling this same converter for the root object
            var value = contract.DefaultCreator();
            serializer.Populate(token.CreateReader(), value);

            // TODO: Move to contract resolver, include in this constructor?
            var props = contract.Properties.Where(x => x.AttributeProvider.GetAttributes(typeof(JsonPathPropertyAttribute), true).Any());

            // TODO: Refactor this shit
            foreach (var prop in props)
            {
                // TODO: Extend JsonProperty and add the path from JsonPathPropertyAttribute, save this with above TODO (contract resolver)
                var attr = prop.AttributeProvider.GetAttributes(typeof(JsonPathPropertyAttribute), true).First() as JsonPathPropertyAttribute;

                // TODO: Case-insensitive JsonPath instead of SelectToken
                var pathToken = token.SelectToken(attr.Path);
                if (pathToken != null)
                {
                    object propObj = null;
                    if (prop.Converter != null)
                    {
                        var propReader = pathToken.CreateReader();
                        propReader.Read();
                        propObj = prop.Converter.ReadJson(propReader, prop.PropertyType, null, serializer);
                    }
                    else
                    {
                        propObj = pathToken.ToObject(prop.PropertyType, serializer);
                    }
                    prop.ValueProvider.SetValue(value, propObj);
                }
            }

            return value;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
