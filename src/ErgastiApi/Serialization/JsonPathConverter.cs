using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ErgastApi.Serialization
{
    public class JsonPathConverter : JsonConverter
    {
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
            object targetObj = Activator.CreateInstance(objectType);

            foreach (PropertyInfo prop in objectType.GetProperties()
                .Where(p => p.CanRead && p.CanWrite))
            {
                JsonPropertyAttribute att = prop.GetCustomAttribute<JsonPropertyAttribute>(true);

                string jsonPath = (att != null ? att.PropertyName : prop.Name);

                if (!jsonPath.Contains(".") && !jsonPath.Contains("["))
                {
                    var a = jo[jsonPath];
                }

                JToken token = jo.SelectToken(jsonPath);

                if (token != null && token.Type != JTokenType.Null)
                {
                    object value = token.ToObject(prop.PropertyType, serializer);
                    prop.SetValue(targetObj, value, null);
                }
            }

            return targetObj;
        }

        public override bool CanWrite => true;

        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when [JsonConverter] attribute is used
            return false;
        }
    }
}
