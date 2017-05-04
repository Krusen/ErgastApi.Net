using System;
using System.Globalization;
using Newtonsoft.Json;

namespace ErgastApi.Serialization.Converters
{
    public class TimeSpanSecondsConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var timespan = (TimeSpan)value;
            writer.WriteValue(timespan.TotalMilliseconds);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Float)
            {
                var milliseconds = (double)reader.Value;
                return TimeSpan.FromSeconds(milliseconds);
            }

            if (reader.TokenType == JsonToken.String)
            {
                var milliseconds = double.Parse((string)reader.Value, CultureInfo.InvariantCulture);
                return TimeSpan.FromSeconds(milliseconds);
            }

            throw new JsonException($"Wrong token type '{reader.TokenType}' for reading TimeStamp as seconds.");
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
