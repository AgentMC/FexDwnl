namespace FexDwnl
{
    partial class Prefetch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            matchingRuleResult = new TextBox();
            label3 = new Label();
            regexTextbox = new TextBox();
            regexResultTextbox = new TextBox();
            addRegexButton = new Button();
            refreshButton = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 27);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(680, 184);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Files";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(12, 217);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 2;
            label2.Text = "Existing rule:";
            // 
            // matchingRuleResult
            // 
            matchingRuleResult.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            matchingRuleResult.Location = new Point(12, 235);
            matchingRuleResult.Name = "matchingRuleResult";
            matchingRuleResult.ReadOnly = true;
            matchingRuleResult.Size = new Size(599, 23);
            matchingRuleResult.TabIndex = 3;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(12, 261);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 5;
            label3.Text = "Test regex";
            // 
            // regexTextbox
            // 
            regexTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            regexTextbox.Location = new Point(12, 279);
            regexTextbox.Name = "regexTextbox";
            regexTextbox.Size = new Size(493, 23);
            regexTextbox.TabIndex = 6;
            regexTextbox.TextChanged += Regex_TextChanged;
            // 
            // regexResultTextbox
            // 
            regexResultTextbox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            regexResultTextbox.Location = new Point(511, 280);
            regexResultTextbox.Name = "regexResultTextbox";
            regexResultTextbox.ReadOnly = true;
            regexResultTextbox.Size = new Size(100, 23);
            regexResultTextbox.TabIndex = 7;
            regexResultTextbox.Text = "(empty)";
            regexResultTextbox.TextAlign = HorizontalAlignment.Center;
            // 
            // addRegexButton
            // 
            addRegexButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            addRegexButton.Enabled = false;
            addRegexButton.Location = new Point(617, 279);
            addRegexButton.Name = "addRegexButton";
            addRegexButton.Size = new Size(75, 23);
            addRegexButton.TabIndex = 8;
            addRegexButton.Text = "Add";
            addRegexButton.UseVisualStyleBackColor = true;
            addRegexButton.Click += ButtonAddRule_Click;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            refreshButton.Location = new Point(617, 235);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 4;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshHandler;
            // 
            // Prefetch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 317);
            Controls.Add(refreshButton);
            Controls.Add(addRegexButton);
            Controls.Add(regexResultTextbox);
            Controls.Add(regexTextbox);
            Controls.Add(label3);
            Controls.Add(matchingRuleResult);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "Prefetch";
            Text = "Prefetch";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Label label2;
        private TextBox matchingRuleResult;
        private Label label3;
        private TextBox regexTextbox;
        private TextBox regexResultTextbox;
        private Button addRegexButton;
        private Button refreshButton;
    }
}