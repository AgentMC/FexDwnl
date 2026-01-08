using FexDwnl.Properties;
using System.Text.RegularExpressions;

namespace FexDwnl
{
    public partial class Prefetch : Form
    {
        public Prefetch(MainForm parent)
        {
            InitializeComponent();
            _mainForm = parent;
            regexResultTextbox.Text = Resources.LPfRgxEmpty;
        }

        private readonly MainForm _mainForm;

        public new void Show()
        {
            base.Show();
            RefreshHandler(this, EventArgs.Empty);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                regexTextbox.Enabled = false;
                matchingRuleResult.Text = Resources.LPfStateNoItemSelected;
            }
            else
            {
                regexTextbox.Enabled = true;
                var folder = _mainForm.GetFolderForFileByRule((string)listBox1.SelectedItem!);
                matchingRuleResult.Text = folder ?? Resources.LPfStateUUseDownloadsFolder;
            }
        }

        private void Regex_TextChanged(object sender, EventArgs e)
        {
            if (regexTextbox.Text != string.Empty)
            {
                try
                {
                    if (Regex.IsMatch(listBox1.SelectedItem as string ?? string.Empty, regexTextbox.Text))
                    {
                        regexResultTextbox.Text = Resources.LPfRgxMatch;
                        regexResultTextbox.BackColor = Color.Green;
                    }
                    else
                    {
                        regexResultTextbox.Text = Resources.LPfRgxNoMatch;
                        regexResultTextbox.BackColor = Color.Orange;
                    }
                    addRegexButton.Enabled = true;
                }
                catch
                {
                    addRegexButton.Enabled = false;
                    regexResultTextbox.Text = Resources.LPfRgxInvalid;
                    regexResultTextbox.BackColor = Color.Red;
                }
            }
            else
            {
                addRegexButton.Enabled = false;
                regexResultTextbox.Text = Resources.LPfRgxEmpty;
                regexResultTextbox.BackColor = SystemColors.Control;
            }
        }

        private async void RefreshHandler(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var entry in await _mainForm.FetchFex())
            {
                listBox1.Items.Add(entry.PathName);
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void ButtonAddRule_Click(object sender, EventArgs e)
        {
            _mainForm.ButtonAddRule_Click(this, new RegexEventArgs(regexTextbox.Text));
        }

        public class RegexEventArgs(string regex) : EventArgs
        {
            public readonly string Regex = regex;
        }
    }
}
