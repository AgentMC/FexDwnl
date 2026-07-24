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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            fexId = new TextBox();
            label1 = new Label();
            rules = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
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
            label5 = new Label();
            SuspendLayout();
            // 
            // fexId
            // 
            resources.ApplyResources(fexId, "fexId");
            fexId.Name = "fexId";
            fexId.TextChanged += TextBoxFexId_TextChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // rules
            // 
            resources.ApplyResources(rules, "rules");
            rules.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            rules.FullRowSelect = true;
            rules.Name = "rules";
            rules.UseCompatibleStateImageBehavior = false;
            rules.View = View.Details;
            rules.SelectedIndexChanged += Rules_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(columnHeader3, "columnHeader3");
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // downloadButton
            // 
            resources.ApplyResources(downloadButton, "downloadButton");
            downloadButton.Name = "downloadButton";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += ButtonDownload_Click;
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // addRuleButton
            // 
            resources.ApplyResources(addRuleButton, "addRuleButton");
            addRuleButton.Name = "addRuleButton";
            addRuleButton.UseVisualStyleBackColor = true;
            addRuleButton.Click += ButtonAddRule_Click;
            // 
            // removeRulesButton
            // 
            resources.ApplyResources(removeRulesButton, "removeRulesButton");
            removeRulesButton.Name = "removeRulesButton";
            removeRulesButton.UseVisualStyleBackColor = true;
            removeRulesButton.Click += ButtonRemoveRules_Click;
            // 
            // timer1
            // 
            timer1.Tick += Timer_Tick;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // fetchButton
            // 
            resources.ApplyResources(fetchButton, "fetchButton");
            fetchButton.Name = "fetchButton";
            fetchButton.UseVisualStyleBackColor = true;
            fetchButton.Click += ButtonFetch_Click;
            // 
            // editRuleButton
            // 
            resources.ApplyResources(editRuleButton, "editRuleButton");
            editRuleButton.Name = "editRuleButton";
            editRuleButton.UseVisualStyleBackColor = true;
            editRuleButton.Click += ButtonAddRule_Click;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = Color.Transparent;
            label5.Name = "label5";
            // 
            // MainForm
            // 
            AcceptButton = downloadButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
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
        private Label label5;
        private ColumnHeader columnHeader3;
    }
}
