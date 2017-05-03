using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ErgastApi.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ErgastApi.Serialization
{
    // TODO: Not used, but might want to implement as NuGet package or something
    // TODO: ReadJson contains case-insensitive version of SelectToken of some sort
    public class JsonPathConverter : InterfaceJsonConverter
    {
        // TODO: Not used by this project, maybe just delete it
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var properties = value.GetType().GetRuntimeProperties().Where(p => p.CanRead && p.CanWrite);
            JObject main = new JObject();
            foreach (PropertyInfo prop in properties)
            {
                var propertyValue = prop.GetValue(value);
                if (serializer.NullValueHandling == NullValueHandling.Ignore && propertyValue == null)
                    continue;

                JsonPropertyAttribute att = prop.GetCustomAttributes(true)
                    .OfType<JsonPropertyAttribute>()
                    .FirstOrDefault();

                string jsonPath = (att != null ? att.PropertyName : prop.Name);

                if (serializer.ContractResolver is DefaultContractResolver)
                {
                    var resolver = (DefaultContractResolver)serializer.ContractResolver;
                    jsonPath = resolver.GetResolvedPropertyName(jsonPath);
                }

                var nesting = jsonPath.Split(new[] { '.' });
                JToken lastLevel = main;
                var arrayIndex = -1;

                // Walk through all levels split by '.'
                for (int i = 0; i < nesting.Length; i++)
                {
                    // TODO: Cleanup
                    var arrayMatch = Regex.Match(nesting[i], @"\[(\d+)\]$");

                    // If array (i.e. property[#])
                    if (arrayMatch.Success)
                    {
                        // Remove indexing from current level/path and store array index
                        arrayIndex = int.Parse(arrayMatch.Groups[1].Value);
                        nesting[i] = nesting[i].Remove(arrayMatch.Index);

                        // Create array if it doesn't exist
                        if (lastLevel[nesting[i]] == null)
                        {
                            lastLevel[nesting[i]] = new JArray();
                        }
                    }

                    // If last level of path
                    if (i == nesting.Length - 1)
                    {
                        // TODO: Cleanup
                        // If current level is an array path
                        if (arrayMatch.Success)
                        {
                            // Get existing array or create new
                            var jarray = lastLevel[nesting[i]] as JArray ?? new JArray();

                            // Add null values up to the specified index
                            while (jarray.Count - 1 < arrayIndex)
                            {
                                jarray.Add(null);
                            }

                            // Replace value at index with property value
                            jarray[arrayIndex] = new JValue(propertyValue);
                        }
                        else
                        {
                            // It's not an array path

                            // If last level was an array
                            var jarray = lastLevel as JArray;
                            if (jarray != null)
                            {
                                // Make sure the array is filled up to the array index
                                while (jarray.Count - 1 < arrayIndex)
                                {
                                    jarray.Add(null);
                                }

                                // Get or create object at array index
                                jarray[arrayIndex] = jarray[arrayIndex] as JObject ?? new JObject();

                                // Set object property value
                                jarray[arrayIndex][nesting[i]] = new JValue(propertyValue);
                            }
                            else
                            {
                                // Set object property value
                                lastLevel[nesting[i]] = new JValue(propertyValue);
                            }
                        }
                    }
                    else
                    {
                        // If not last level

                        // Create object/array if it doesn't exist
                        if (lastLevel[nesting[i]] == null)
                        {
                            lastLevel[nesting[i]] = arrayMatch.Success
                                ? new JArray() as JToken
                                : new JObject() as JToken;
                        }

                        // Set last level to the one we just created
                        lastLevel = lastLevel[nesting[i]];
                    }
                }

            }
            serializer.Serialize(writer, main);
        }

        // TODO: Case insensitive property name match if possible
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            var targetObjType = base.CanConvert(objectType) ? GetMatchingType(objectType) : objectType;
            object targetObj = Activator.CreateInstance(targetObjType);

            //var properties2 = new[] { objectType }.Concat(objectType.GetInterfaces()).SelectMany(i => i.GetProperties()).Where(p => p.CanWrite && p.CanRead);

            //var properties = objectType.GetProperties().Where(p => p.CanRead && p.CanWrite);
            var properties = targetObjType.GetProperties().Where(p => p.CanRead && p.CanWrite);

            foreach (var prop in properties)
            {
                JsonPropertyAttribute att = prop.GetCustomAttribute<JsonPropertyAttribute>(true);

                string jsonPath = (att != null ? att.PropertyName : prop.Name);

                var contractResolver = serializer.ContractResolver as DefaultContractResolver;
                if (contractResolver != null)
                {
                    jsonPath = contractResolver.GetResolvedPropertyName(jsonPath);
                }

                // TODO: Handle array indexing (and cleanup)
                var parts = jsonPath.Split('.');
                JToken token = jo;
                foreach (var part in parts)
                {
                    var obj = token as JObject;

                    token = obj?.GetValue(part, StringComparison.OrdinalIgnoreCase);
                }


                if (token != null && token.Type != JTokenType.Null)
                {
                    var propertyTypeImplementation = prop.PropertyType;
                    if (base.CanConvert(propertyTypeImplementation))
                        propertyTypeImplementation = GetMatchingType(propertyTypeImplementation);

                    object value = token.ToObject(propertyTypeImplementation, serializer);
                    prop.SetValue(targetObj, value, null);
                }
            }

            return targetObj;
        }

        public override bool CanWrite => true;

        //public override bool CanConvert(Type objectType)
        //{
        //    return typeof(IErgastResponse).IsAssignableFrom(objectType);
        //}
    }
}
