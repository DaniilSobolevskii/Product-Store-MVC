using System.Text;
using System.Text.Json;

namespace WebApplication2.JsonConverters.Policies;

public class SnakeCasePolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        StringBuilder snake_name = new StringBuilder();

        for (int i = 0; i < name.Length; i++)
        {
            char c = name[i];

            if (Char.IsUpper(c) && snake_name.Length > 0)
            {
                snake_name.Append('_').Append(char.ToLower(c));
            }
            else
            {
                snake_name.Append(char.ToLower(c));
            }
        }

        return snake_name.ToString();
    }
}