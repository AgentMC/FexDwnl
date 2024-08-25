using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FexDwnl
{
    public partial class AddRule : Form
    {
        public AddRule()
        {
            InitializeComponent();
        }

        public AddRule(string regex):this()
        {
            resultRegex.Text = regex;
        }
        
        public AddRule(string regex, string path) : this(regex)
        {
            resultPath.Text = path;
        }

        private void ButtonSelectPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
            {
                resultPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = resultRegex.Text != string.Empty && resultPath.Text != string.Empty;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
