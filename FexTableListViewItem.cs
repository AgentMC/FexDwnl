namespace FexDwnl
{
    public class FexTableListViewItem(string regex, string path, string? lastKey) : ListViewItem([regex, path, lastKey ?? string.Empty])
    {
        public string Regex => SubItems[0].Text;
        public string Path => SubItems[1].Text;
        public string LastKey { get => SubItems[2].Text; set => SubItems[2].Text = value; }
    }
}
