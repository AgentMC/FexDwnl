using System.Text.Json;

namespace FexDwnl
{
    internal static class Extensions
    {
        extension (string s)
        {
            public string Format(params object[] args) => string.Format(s, args);
        }
        extension (JsonElement parent)
        {
            public string GetStringValueSafe(string name) => parent.TryGetProperty(name, out var je2) ? je2.GetString() ?? string.Empty : string.Empty;
        }
    }
}
