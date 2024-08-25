using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FexDwnl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static readonly string Store = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FexDwnlSetup.json");
        private static readonly JsonSerializerOptions SO = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
        private readonly HttpClient client = new();        


        private Stream? _writer = null;
        private int _length = 0;
        private bool _timerStop = false;


        private async void Form_Load(object sender, EventArgs e)
        {
            if (File.Exists(Store))
            {
                using StreamReader sr = new(Store, System.Text.Encoding.UTF8);
                var json = JsonDocument.Parse(sr.ReadToEnd());
                foreach (var item in json.RootElement.GetProperty("rules").EnumerateArray())
                {
                    rules.Items.Add(new ListViewItem([
                            item.GetProperty("regex").GetString()!,
                            item.GetProperty("path").GetString()!
                        ]));
                }
            }
            await client.GetAsync("https://api.fex.net/api/v1/config/anonymous"); //get fex UUID
            await client.GetAsync("https://api.fex.net/api/v1/anonymous/upload-token"); //get token
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            var json = new JsonObject
            {
                {
                    "rules",
                    new JsonArray(rules.Items.Cast<ListViewItem>()
                                             .Select(lvi => new JsonObject
                                             {
                                                { "regex", lvi.SubItems[0].Text},
                                                { "path", lvi.SubItems[1].Text},
                                             })
                                             .ToArray())
                }
            };
            using StreamWriter sw = new(Store, false, System.Text.Encoding.UTF8);
            sw.Write(json);
        }




        private void Rules_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeRulesButton.Enabled = rules.SelectedItems.Count > 0;
            editRuleButton.Enabled = rules.SelectedItems.Count == 1;
        }

        public void ButtonAddRule_Click(object sender, EventArgs e)
        {
            AddRule addPair;
            if(e is Prefetch.RegexEventArgs param) //from Prefetch
            {
                addPair = new AddRule(param.Regex);
            }
            else if (sender == editRuleButton) //Edit
            {
                var selection = rules.SelectedItems[0];
                addPair = new AddRule(selection.SubItems[0].Text, selection.SubItems[1].Text);
            }
            else //Add
            {
                addPair = new AddRule();
            }

            if (addPair.ShowDialog(this) == DialogResult.OK)
            {
                var lvi = new ListViewItem([addPair.resultRegex.Text, addPair.resultPath.Text]);
                if(sender != editRuleButton)
                {
                    rules.Items.Add(lvi);
                }
                else
                {
                    var idx = rules.SelectedIndices[0];
                    rules.Items.RemoveAt(idx);
                    rules.Items.Insert(idx, lvi);
                }
            }
        }

        private void ButtonRemoveRules_Click(object sender, EventArgs e)
        {
            rules.SelectedItems.Cast<ListViewItem>().ToList().ForEach(rules.Items.Remove);
        }

        public string? GetFolderForFileByRule(string fileName)
        {
            return rules.Items
                        .Cast<ListViewItem>()
                        .FirstOrDefault(i => Regex.IsMatch(fileName, i.SubItems[0].Text))
                        ?.SubItems
                        ?[1]
                        ?.Text;
        }



        private void ButtonFetch_Click(object sender, EventArgs e)
        {
            new Prefetch(this).Show();
        }



        private async Task<List<FexChild>> FetchFex(string key)
        {
            var fexApi = $"https://api.fex.net/api/v2/file/share/children/{key}?page=1&sort_by=name&per_page=500&is_desc=1";
            var json = await client.GetFromJsonAsync<Dictionary<string, object>>(fexApi);
            var result = ((JsonElement)json["children"]).Deserialize<List<FexChild>>(SO)!;
            return result;
        }
        public async Task<List<FexChild>> FetchFex() => await FetchFex(fexId.Text);

        private async void ButtonDownload_Click(object sender, EventArgs e)
        {
            downloadButton.Enabled = false;
            var children = await FetchFex();
            int i = 0;
            foreach (var webFile in children)
            {
                var fileName = webFile.Name;
                var dwnlLoc = GetFolderForFileByRule(fileName) ?? GetDownloadsFolder();
                var filePath = Path.Combine(dwnlLoc, fileName);
                using var writer = new StreamWriter(filePath);

                _writer = writer.BaseStream;
                _length = AsIntMB(webFile.Size);
                timer1.Start();
                label4.Text = $"{++i}/{children.Count} ({_length}MB): {filePath}";
                
                using var webFileStream = await client.GetStreamAsync(webFile.DownloadUrl);
                await webFileStream.CopyToAsync(_writer);
                
                _writer = null;
            }
            _timerStop = true;
            label4.Text = string.Empty;
            downloadButton.Enabled = true;
        }

        private void TextBoxFexId_TextChanged(object sender, EventArgs e)
        {
            downloadButton.Enabled = fexId.Text != string.Empty;
            fetchButton.Enabled = downloadButton.Enabled;
            if (fexId.Text.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                fexId.Text = fexId.Text.Split("/")[^1];
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_writer != null && _writer.CanWrite)
            {
                if (progressBar1.Maximum != _length)
                {
                    progressBar1.Value = 0;
                    progressBar1.Maximum = _length;
                }
                progressBar1.Value = AsIntMB(_writer.Position);
            }
            else
            {
                if (_timerStop)
                {
                    _timerStop = false;
                    timer1.Stop();
                }
                progressBar1.Value = 0;
            }
        }



        private static int AsIntMB(long l) => (int)(l / (1024 * 1024));


        private static readonly Guid FolderDownloads = new("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        [SuppressMessage("Interoperability", "SYSLIB1054:Use 'LibraryImportAttribute' instead of 'DllImportAttribute' to generate P/Invoke marshalling code at compile time", Justification = "Ugly signature")]
        private static extern string SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid id, int flags = 0, nint token = 0);
        private static string GetDownloadsFolder() => SHGetKnownFolderPath(FolderDownloads);

        public record FexChild(string Name, string DownloadUrl, long Size);
    }
}
