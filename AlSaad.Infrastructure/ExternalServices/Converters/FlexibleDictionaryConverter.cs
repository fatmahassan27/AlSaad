using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AlSaad.Infrastructure.ExternalServices.Converters
{
    public class FlexibleDictionaryConverter: JsonConverter<Dictionary<string, decimal>>
    {
        public override Dictionary<string, decimal> Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var result = new Dictionary<string, decimal>();

            // null
            if (reader.TokenType == JsonTokenType.Null)
            {
                return result;
            }

            // Object:
            // "productAvailableQTY": {
            //     "1": 0,
            //     "2": 10
            // }
            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using var document = JsonDocument.ParseValue(ref reader);

                foreach (var property in document.RootElement.EnumerateObject())
                {
                    decimal value = 0;

                    if (property.Value.ValueKind == JsonValueKind.Number)
                    {
                        if (property.Value.TryGetDecimal(out var number))
                        {
                            value = number;
                        }
                    }
                    else if (property.Value.ValueKind == JsonValueKind.String)
                    {
                        decimal.TryParse(
                            property.Value.GetString(),
                            NumberStyles.Any,
                            CultureInfo.InvariantCulture,
                            out value);
                    }

                    result[property.Name] = value;
                }

                return result;
            }

            // Array:
            // "productAvailableQTY": []
            // Daftra sometimes returns an empty array
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                using var document = JsonDocument.ParseValue(ref reader);

                // Ignore the array and return empty dictionary
                return result;
            }

            throw new JsonException(
                $"Unexpected token {reader.TokenType} for Dictionary<string, decimal>."
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            Dictionary<string, decimal> value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (var item in value)
            {
                writer.WriteNumber(item.Key, item.Value);
            }

            writer.WriteEndObject();
        }
    }
}