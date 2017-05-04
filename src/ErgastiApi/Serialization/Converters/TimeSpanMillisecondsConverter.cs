using System;
using Newtonsoft.Json;

namespace ErgastApi.Serialization.Converters
{
    public class TimeSpanMillisecondsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var timespan = (TimeSpan)value;
            writer.WriteValue(timespan.TotalMilliseconds);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                var milliseconds = (long) reader.Value;
                return TimeSpan.FromMilliseconds(milliseconds);
            }

            if (reader.TokenType == JsonToken.String)
            {
                var milliseconds = long.Parse((string)reader.Value);
                return TimeSpan.FromMilliseconds(milliseconds);
            }

            throw new JsonException($"Wrong token type '{reader.TokenType}' for reading TimeStamp as milliseconds.");
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
