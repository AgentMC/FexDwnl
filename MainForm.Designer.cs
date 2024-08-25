namespace FexDwnl
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            fexId = new TextBox();
            label1 = new Label();
            rules = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            label2 = new Label();
            downloadButton = new Button();
            progressBar1 = new ProgressBar();
            label3 = new Label();
            addRuleButton = new Button();
            removeRulesButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            fetchButton = new Button();
            editRuleButton = new Button();
            SuspendLayout();
            // 
            // fexId
            // 
            fexId.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            fexId.Location = new Point(12, 27);
            fexId.Name = "fexId";
            fexId.Size = new Size(385, 23);
            fexId.TabIndex = 0;
            fexId.TextChanged += TextBoxFexId_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 1;
            label1.Text = "FeX ID or link";
            // 
            // rules
            // 
            rules.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rules.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            rules.FullRowSelect = true;
            rules.Location = new Point(12, 71);
            rules.Name = "rules";
            rules.Size = new Size(547, 187);
            rules.TabIndex = 5;
            rules.UseCompatibleStateImageBehavior = false;
            rules.View = View.Details;
            rules.SelectedIndexChanged += Rules_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Regex";
            columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Path";
            columnHeader2.Width = 600;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 4;
            label2.Text = "Download rules";
            // 
            // downloadButton
            // 
            downloadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            downloadButton.Enabled = false;
            downloadButton.Location = new Point(403, 27);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(75, 23);
            downloadButton.TabIndex = 2;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += ButtonDownload_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(12, 309);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(547, 23);
            progressBar1.TabIndex = 9;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(12, 291);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 8;
            label3.Text = "File progress";
            // 
            // addRuleButton
            // 
            addRuleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addRuleButton.Location = new Point(12, 264);
            addRuleButton.Name = "addRuleButton";
            addRuleButton.Size = new Size(75, 23);
            addRuleButton.TabIndex = 6;
            addRuleButton.Text = "Add";
            addRuleButton.UseVisualStyleBackColor = true;
            addRuleButton.Click += ButtonAddRule_Click;
            // 
            // removeRulesButton
            // 
            removeRulesButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeRulesButton.Enabled = false;
            removeRulesButton.Location = new Point(93, 264);
            removeRulesButton.Name = "removeRulesButton";
            removeRulesButton.Size = new Size(75, 23);
            removeRulesButton.TabIndex = 7;
            removeRulesButton.Text = "Remove";
            removeRulesButton.UseVisualStyleBackColor = true;
            removeRulesButton.Click += ButtonRemoveRules_Click;
            // 
            // timer1
            // 
            timer1.Tick += Timer_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 291);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 10;
            // 
            // fetchButton
            // 
            fetchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fetchButton.Enabled = false;
            fetchButton.Location = new Point(484, 27);
            fetchButton.Name = "fetchButton";
            fetchButton.Size = new Size(75, 23);
            fetchButton.TabIndex = 3;
            fetchButton.Text = "Fetch";
            fetchButton.UseVisualStyleBackColor = true;
            fetchButton.Click += ButtonFetch_Click;
            // 
            // editRuleButton
            // 
            editRuleButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            editRuleButton.Enabled = false;
            editRuleButton.Location = new Point(174, 264);
            editRuleButton.Name = "editRuleButton";
            editRuleButton.Size = new Size(75, 23);
            editRuleButton.TabIndex = 11;
            editRuleButton.Text = "Edit";
            editRuleButton.UseVisualStyleBackColor = true;
            editRuleButton.Click += ButtonAddRule_Click;
            // 
            // MainForm
            // 
            AcceptButton = downloadButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 350);
            Controls.Add(editRuleButton);
            Controls.Add(fetchButton);
            Controls.Add(label4);
            Controls.Add(removeRulesButton);
            Controls.Add(addRuleButton);
            Controls.Add(label3);
            Controls.Add(progressBar1);
            Controls.Add(downloadButton);
            Controls.Add(label2);
            Controls.Add(rules);
            Controls.Add(label1);
            Controls.Add(fexId);
            Name = "MainForm";
            Text = "FeX downloader";
            FormClosed += Form_Closed;
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox fexId;
        private Label label1;
        private ListView rules;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label label2;
        private Button downloadButton;
        private ProgressBar progressBar1;
        private Label label3;
        private Button addRuleButton;
        private Button removeRulesButton;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private Button fetchButton;
        private Button editRuleButton;
    }
}
