using FexDwnl.Properties;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;
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
        private int _lengthMB = 0;
        private long _contentLength = 0;
        private bool _timerStop = false;
        private bool _timerReload = false;


        private async void Form_Load(object sender, EventArgs e)
        {
            Text = Resources.AppName;
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



        private async Task<List<FexChild>> FetchFex(string key, ulong? childId = null)
        {
            List<FexChild> result;
            var fexApi = $"https://api.fex.net/api/v2/file/share/children/{key}{(childId == null ? string.Empty : "/" + childId)}?page=1&sort_by=name&per_page=500&is_desc=1";
            try
            {
                var jFex = await client.GetFromJsonAsync<FexRoot>(fexApi, SO);
                result = jFex?.Children ?? [];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.AppName} - {Resources.ErrUnableToFetchFex} - {ex}", Resources.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
            for (int i = result.Count - 1; i >= 0; i--)
            {
                var r = result[i];
                if (r.IsDir)
                {
                    result.RemoveAt(i);
                    if(r.HasChildren)
                    {
                        var childItems = await FetchFex(key, r.Id);
                        for (int cidx = 0; cidx < childItems.Count; cidx++)
                        {
                            var child = childItems[cidx];
                            child.PathName = Path.Combine(r.Name, child.PathName);
                            result.Add(child);
                        }
                    }
                }
            }
            return result;
        }
        public async Task<List<FexChild>> FetchFex() => await FetchFex(fexId.Text);

        private async void ButtonDownload_Click(object sender, EventArgs e)
        {
            downloadButton.Enabled = false;
            label4.Text = Resources.LStateFetching;
            var children = await FetchFex();

            var targetPaths = children.ToDictionary(c => c.PathName, c => GetFolderForFileByRule(c.PathName));
            bool allowDownloads = targetPaths.Values.All(v => v == null);

            int i = 0;
            foreach (var webFile in children)
            {
                var flowControl = DialogResult.Retry;
                while (flowControl == DialogResult.Retry)
                {
                    try
                    {
                        var selector = $"{++i}/{children.Count}";
                        var fileName = webFile.PathName;
                        var dwnlLoc = targetPaths[fileName] ?? (allowDownloads ? DownloadsFolder : null);
                        if (dwnlLoc != null)
                        {
                            var filePath = Path.Combine(dwnlLoc, fileName);

                            var fileTargetLoc = Path.GetDirectoryName(filePath)!;
                            if(!Directory.Exists(fileTargetLoc)) Directory.CreateDirectory(fileTargetLoc);

                            var peek = new FileInfo(filePath);
                            if (!peek.Exists || peek.Length != webFile.Size)
                            {
                                using var writer = new StreamWriter(filePath);

                                _writer = writer.BaseStream;
                                _contentLength = webFile.Size;
                                _lengthMB = AsIntMB(_contentLength);
                                _timerReload = true;
                                timer1.Start();
                                label4.Text = $"{selector} ({_lengthMB}MB): {filePath}";
                
                                using var webFileStream = await client.GetStreamAsync(webFile.DownloadUrl);
                                await webFileStream.CopyToAsync(_writer);
                
                                _writer = null;
                            }
                            else
                            {
                                await ShowMsgDelay(Color.Green, Resources.LStateSkipSelectorFmt.Format(selector!), 1000);
                            }
                        }
                        else
                        {
                            await ShowMsgDelay(Color.Red, Resources.LStateSkipSelectorNoMatchFmt.Format(selector!), 3000);
                        }

                        flowControl = DialogResult.Ignore;
                    }
                    catch (Exception ex)
                    {
                        i--;
                        flowControl = MessageBox.Show(this,
                                                      ex.ToString(),
                                                      Text,
                                                      MessageBoxButtons.AbortRetryIgnore,
                                                      MessageBoxIcon.Error);
                    }
                }
                if(flowControl == DialogResult.Abort)
                {
                    break;
                }
            }
            _timerStop = true;
            label4.Text = string.Empty;
            downloadButton.Enabled = true;
            MessageBox.Show(this, Resources.LStateDwnlComplete, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task ShowMsgDelay(Color color, string msg, int delayMs)
        {
            var clr = label4.ForeColor;
            label4.ForeColor = color;
            label4.Text = msg;
            await Task.Delay(delayMs);
            label4.ForeColor = clr;
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

#pragma warning disable CS8618 
        private static Marker Start;
#pragma warning restore CS8618 
        private readonly List<Marker> _speedTracker = [];
        private DateTime _downloadStartStamp;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_writer != null && _writer.CanWrite)
            {
                var now = DateTime.Now;
                if (_timerReload)
                {
                    _timerReload = false;
                    progressBar1.Value = 0;
                    progressBar1.Maximum = _lengthMB;
                    _downloadStartStamp = now.AddMilliseconds(-timer1.Interval);
                    Start = new(_downloadStartStamp, 0);
                    _speedTracker.Clear();
                    _speedTracker.Add(Start);
                }
                var pos = _writer.Position;
                progressBar1.Value = AsIntMB(pos);

                _speedTracker.Add(new(now, pos));
                bool doCleanup = false;
                Marker marker = Start; //csc does not understand it's always initialized below
                for (int i = _speedTracker.Count - 1; i >= 0; i--)
                {
                    if (doCleanup)
                    {
                        _speedTracker.RemoveAt(i);
                    }
                    else if ((now - _speedTracker[i].Time).TotalSeconds >= 5 || i == 0)
                    {
                        marker = _speedTracker[i];
                        doCleanup = true;
                    }
                }
                var speedLast5 = AsSizePerSec(now, pos, marker, out var speedBps);
                var speedAvg = AsSizePerSec(now, pos, Start, out var _);
                var eta = speedBps > 0
                          ? TimeSpan.FromSeconds(1 + (_contentLength - pos) / speedBps).ToString("hh':'mm':'ss") 
                          : Resources.LSpeedCalculating;
                label5.Text = $"{speedLast5} ({Resources.LSpeedAvg}: {speedAvg}) ETA: {eta}";
            }
            else
            {
                if (_timerStop)
                {
                    _timerStop = false;
                    timer1.Stop();
                }
                if (progressBar1.Value != 0) {
                    progressBar1.Value = 0;
                    label5.Text = string.Empty;
                    _speedTracker.Clear();
                }
            }
        }



        private static int AsIntMB(long l) => (int)(l / (1024 * 1024));

        private static readonly string[] Modifiers = [string.Empty, "K", "M", "G", "P"];
        private static string AsSizePerSec(DateTime now, long currentPosition, Marker previousMarker, out double speedBps)
        {
            var sec = (now - previousMarker.Time).TotalSeconds;
            var size = currentPosition - previousMarker.Position;
            var speed = size / sec;
            speedBps = speed;
            int level = 0;
            while(speed > 1024)
            {
                speed /= 1024;
                level++;
            }
            return $"{speed:f2} {Modifiers[level]}B/s";
        }

        private static readonly Guid FolderDownloads = new("374DE290-123F-4565-9164-39C4925E467B");
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        private static extern string SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid id, int flags = 0, nint token = 0);
        private static string DownloadsFolder { get; } = SHGetKnownFolderPath(FolderDownloads);

        public record FexChild(string Name, string DownloadUrl, long Size, bool HasChildren, bool IsDir, ulong Id)
        {
            public string PathName { get { return field ?? Name; } set; }
        }

        public record FexRoot(List<FexChild> Children);

        private record Marker(DateTime Time, long Position);
    }
}
