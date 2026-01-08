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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prefetch));
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
            resources.ApplyResources(listBox1, "listBox1");
            listBox1.FormattingEnabled = true;
            listBox1.Name = "listBox1";
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // matchingRuleResult
            // 
            resources.ApplyResources(matchingRuleResult, "matchingRuleResult");
            matchingRuleResult.Name = "matchingRuleResult";
            matchingRuleResult.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // regexTextbox
            // 
            resources.ApplyResources(regexTextbox, "regexTextbox");
            regexTextbox.Name = "regexTextbox";
            regexTextbox.TextChanged += Regex_TextChanged;
            // 
            // regexResultTextbox
            // 
            resources.ApplyResources(regexResultTextbox, "regexResultTextbox");
            regexResultTextbox.Name = "regexResultTextbox";
            regexResultTextbox.ReadOnly = true;
            // 
            // addRegexButton
            // 
            resources.ApplyResources(addRegexButton, "addRegexButton");
            addRegexButton.Name = "addRegexButton";
            addRegexButton.UseVisualStyleBackColor = true;
            addRegexButton.Click += ButtonAddRule_Click;
            // 
            // refreshButton
            // 
            resources.ApplyResources(refreshButton, "refreshButton");
            refreshButton.Name = "refreshButton";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshHandler;
            // 
            // Prefetch
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
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