using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication2.Models;

namespace WebApplication2.JsonConverters.Converters;

public class EnumProductTypeConverter : JsonConverter<ProductType>
{
    public override ProductType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();

        if (value=="Book")
        {
            return ProductType.Book;
        }
        if (value=="Accessories")
        {
            return ProductType.Accessories;
        }
        if (value=="Movie")
        {
            return ProductType.Movie;
        }

        else
        {
            return ProductType.Undefined;
        }

    }

    public override void Write(Utf8JsonWriter writer, ProductType value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case ProductType.Book:
                writer.WriteStringValue("Книга");
                break;
            case ProductType.Accessories:
                writer.WriteStringValue("Аксессуар");
                break;
            case ProductType.Movie:
                writer.WriteStringValue("Кино");
                break;
            case ProductType.Undefined:
                writer.WriteStringValue("Неопределенно");
                break;

        }
        
    }
}

