using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Shared.Json.Converters;

public class SynchronizedDateTimeConverter : DateTimeConverterBase
{
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        return reader.TokenType switch
        {
            JsonToken.Null => null,
            
            JsonToken.Date => DateTime.SpecifyKind((DateTime) (reader.Value ?? DateTime.MinValue), DateTimeKind.Utc),
        
            _ => throw new JsonSerializationException($"Unexpected token type '{reader.TokenType}' when parsing DateTime.")
        };
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is DateTime dateTime)
        {
            var synchronizedDateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);
            writer.WriteValue(synchronizedDateTime);
        }
        else
        {
            throw new JsonSerializationException($"Unexpected value type '{value?.GetType()}' when serializing DateTime.");
        }
    }
}