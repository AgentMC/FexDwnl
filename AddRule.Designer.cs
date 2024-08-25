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
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 0;
            label1.Text = "File Name Regex";
            // 
            // resultRegex
            // 
            resultRegex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            resultRegex.Location = new Point(12, 27);
            resultRegex.Name = "resultRegex";
            resultRegex.Size = new Size(379, 23);
            resultRegex.TabIndex = 1;
            resultRegex.TextChanged += TextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 53);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Destination";
            // 
            // resultPath
            // 
            resultPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            resultPath.Location = new Point(13, 71);
            resultPath.Name = "resultPath";
            resultPath.ReadOnly = true;
            resultPath.Size = new Size(297, 23);
            resultPath.TabIndex = 3;
            resultPath.TextChanged += TextBox_TextChanged;
            // 
            // pickButton
            // 
            pickButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pickButton.Location = new Point(316, 70);
            pickButton.Name = "pickButton";
            pickButton.Size = new Size(75, 23);
            pickButton.TabIndex = 4;
            pickButton.Text = "Pick";
            pickButton.UseVisualStyleBackColor = true;
            pickButton.Click += ButtonSelectPath_Click;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            okButton.Location = new Point(235, 106);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 5;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += Submit_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cancelButton.Location = new Point(316, 106);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += Cancel_Click;
            // 
            // AddRule
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(403, 141);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(pickButton);
            Controls.Add(resultPath);
            Controls.Add(label2);
            Controls.Add(resultRegex);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(2048, 180);
            MinimizeBox = false;
            MinimumSize = new Size(419, 180);
            Name = "AddRule";
            Text = "Add a Download Rule";
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