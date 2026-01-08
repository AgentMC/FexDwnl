namespace FexDwnl
{
    partial class AddRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRule));
            folderBrowserDialog1 = new FolderBrowserDialog();
            label1 = new Label();
            resultRegex = new TextBox();
            label2 = new Label();
            resultPath = new TextBox();
            pickButton = new Button();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // resultRegex
            // 
            resources.ApplyResources(resultRegex, "resultRegex");
            resultRegex.Name = "resultRegex";
            resultRegex.TextChanged += TextBox_TextChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // resultPath
            // 
            resources.ApplyResources(resultPath, "resultPath");
            resultPath.Name = "resultPath";
            resultPath.ReadOnly = true;
            resultPath.TextChanged += TextBox_TextChanged;
            // 
            // pickButton
            // 
            resources.ApplyResources(pickButton, "pickButton");
            pickButton.Name = "pickButton";
            pickButton.UseVisualStyleBackColor = true;
            pickButton.Click += ButtonSelectPath_Click;
            // 
            // okButton
            // 
            resources.ApplyResources(okButton, "okButton");
            okButton.Name = "okButton";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += Submit_Click;
            // 
            // cancelButton
            // 
            resources.ApplyResources(cancelButton, "cancelButton");
            cancelButton.Name = "cancelButton";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += Cancel_Click;
            // 
            // AddRule
            // 
            AcceptButton = okButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(pickButton);
            Controls.Add(resultPath);
            Controls.Add(label2);
            Controls.Add(resultRegex);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddRule";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Label label1;
        private Label label2;
        private Button pickButton;
        private Button okButton;
        private Button cancelButton;
        internal TextBox resultRegex;
        internal TextBox resultPath;
    }
}