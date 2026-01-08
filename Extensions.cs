namespace FexDwnl
{
    internal static class Extensions
    {
        extension (string s)
        {
            public string Format(params object[] args) => string.Format(s, args);
        }
    }
}
