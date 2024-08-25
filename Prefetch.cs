using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FexDwnl
{
    public partial class Prefetch : Form
    {
        public Prefetch(MainForm parent)
        {
            InitializeComponent();
            _mainForm = parent;
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
                matchingRuleResult.Text = "No item selected";
            }
            else
            {
                regexTextbox.Enabled = true;
                var folder = _mainForm.GetFolderForFileByRule(listBox1.SelectedItem as string);
                matchingRuleResult.Text = folder ?? "No rule matches, Downloads folder will be used instead.";
            }
        }

        private void Regex_TextChanged(object sender, EventArgs e)
        {
            if (regexTextbox.Text != string.Empty)
            {
                try
                {
                    if (Regex.IsMatch(listBox1.SelectedItem as string, regexTextbox.Text))
                    {
                        regexResultTextbox.Text = "MATCH!";
                        regexResultTextbox.BackColor = Color.Green;
                    }
                    else
                    {
                        regexResultTextbox.Text = "No match.";
                        regexResultTextbox.BackColor = Color.Orange;
                    }
                    addRegexButton.Enabled = true;
                }
                catch
                {
                    addRegexButton.Enabled = false;
                    regexResultTextbox.Text = "INVALID REGEX!";
                    regexResultTextbox.BackColor = Color.Red;
                }
            }
            else
            {
                addRegexButton.Enabled = false;
                regexResultTextbox.Text = "(empty)";
                regexResultTextbox.BackColor = SystemColors.Control;
            }
        }

        private async void RefreshHandler(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var entry in await _mainForm.FetchFex())
            {
                listBox1.Items.Add(entry.Name);
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
