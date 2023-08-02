using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication2.JsonConverters.Converters;

public class InfinityConverter :JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
     
            string value = reader.GetString();

            if (value=="-∞")
            {
                return double.NegativeInfinity;
            }
            if (value=="+∞")
            {
                return double.PositiveInfinity;
            }
            if (value=="�")
            {
                return double.NaN;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return double.NaN;
            }

            return Convert.ToDouble(value.Replace(".",","));
    }
       

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
    {
        if (double.IsNegativeInfinity(value))
        {
            writer.WriteStringValue("-∞");
        }
        else if (double.IsPositiveInfinity(value))
        {
            writer.WriteStringValue("+∞");
        }
        else if (double.IsNaN(value))
        {
            writer.WriteStringValue("�");
        }
        else
        {
            writer.WriteNumberValue(value);
        }
    }
}