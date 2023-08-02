using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication2.Models;

namespace WebApplication2.JsonConverters.Converters;

public class ProductJsonConverter : JsonConverter<Product>
{
//    public override bool CanConvert(Type typeToConvert) => typeof(Product).IsAssignableFrom(typeToConvert);

    public override Product? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var modelTypeReader = reader;

        if (modelTypeReader.TokenType != JsonTokenType.StartObject) {
            throw new JsonException();
        }

        ProductType? productType = null;
        while (modelTypeReader.Read()) {
            if (modelTypeReader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = modelTypeReader.GetString();
                if (propertyName?.ToLower() == "product_type") 
                {
                    modelTypeReader.Read();
                    var modelType = modelTypeReader.GetString();
                    if (!string.IsNullOrWhiteSpace(modelType))
                    {
                        Enum.TryParse(modelType!, true, out ProductType parsedType);
                        productType = parsedType;
                    }
                    break;
                }
            }
        }

        Product? product = productType switch {
            ProductType.Accessories => JsonSerializer.Deserialize<Accessories?>(ref reader, options),
            ProductType.Book => JsonSerializer.Deserialize<Book?>(ref reader, options),
            ProductType.Movie => JsonSerializer.Deserialize<Movie?>(ref reader, options),
            ProductType.Undefined => JsonSerializer.Deserialize<Undefined?>(ref reader,options),
            _ => throw new JsonException($"Can't find model discriminator {productType}")
        };

        if (product == null) {
            throw new JsonException($"Parsing exception {productType}");
        }

        return product;
    }

    public override void Write(Utf8JsonWriter writer, Product value, JsonSerializerOptions options) {
        switch (value) {
            case Accessories accessories:
                JsonSerializer.Serialize(writer, accessories, options);
                break;
            case Book book:
                JsonSerializer.Serialize(writer, book, options);
                break;
            case Movie movie:
                JsonSerializer.Serialize(writer, movie, options);
                break;
            case Undefined undefined:
                JsonSerializer.Serialize(writer, undefined, options);
                break;
        }
    }
}
