using System.Text.Json.Serialization;
using System.Text.Json;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var dateString = reader.GetString();
            if (DateTime.TryParseExact(dateString, "yyyy-MM-ddTHH:mm+00Z", null, System.Globalization.DateTimeStyles.AssumeUniversal, out var date))
            {
                return date;
            }
        }

        throw new JsonException("Invalid date format");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm+00Z"));
    }
}
