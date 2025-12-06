namespace AI.CodeAssist
{
    partial class codeAssistant
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
            codeAssistant_button_projectPathSearch = new Button();
            codeAssistant_button_exportCodeBase = new Button();
            codeAssistant_textBox_projectPathDirectory = new TextBox();
            codeAssistant_richTextBox_exportCodeBase_preview = new RichTextBox();
            codeAssistant_progressBar_exportCodeBase = new ProgressBar();
            codeAssistant_openFileDirectory = new Button();
            codeAssistant__folderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // codeAssistant_button_projectPathSearch
            // 
            codeAssistant_button_projectPathSearch.Font = new Font("Segoe UI", 10.5F);
            codeAssistant_button_projectPathSearch.Location = new Point(8, 11);
            codeAssistant_button_projectPathSearch.Name = "codeAssistant_button_projectPathSearch";
            codeAssistant_button_projectPathSearch.Size = new Size(124, 34);
            codeAssistant_button_projectPathSearch.TabIndex = 0;
            codeAssistant_button_projectPathSearch.Text = "Search for Project";
            codeAssistant_button_projectPathSearch.UseVisualStyleBackColor = true;
            codeAssistant_button_projectPathSearch.Click += codeAssistant_button_projectPathSearch_Click;
            // 
            // codeAssistant_button_exportCodeBase
            // 
            codeAssistant_button_exportCodeBase.Font = new Font("Segoe UI", 10.5F);
            codeAssistant_button_exportCodeBase.Location = new Point(9, 60);
            codeAssistant_button_exportCodeBase.Name = "codeAssistant_button_exportCodeBase";
            codeAssistant_button_exportCodeBase.Size = new Size(123, 30);
            codeAssistant_button_exportCodeBase.TabIndex = 1;
            codeAssistant_button_exportCodeBase.Text = "Export Codebase";
            codeAssistant_button_exportCodeBase.UseVisualStyleBackColor = true;
            codeAssistant_button_exportCodeBase.Click += codeAssistant_button_exportCodeBase_Click;
            // 
            // codeAssistant_textBox_projectPathDirectory
            // 
            codeAssistant_textBox_projectPathDirectory.Location = new Point(138, 16);
            codeAssistant_textBox_projectPathDirectory.Name = "codeAssistant_textBox_projectPathDirectory";
            codeAssistant_textBox_projectPathDirectory.Size = new Size(346, 23);
            codeAssistant_textBox_projectPathDirectory.TabIndex = 2;
            // 
            // codeAssistant_richTextBox_exportCodeBase_preview
            // 
            codeAssistant_richTextBox_exportCodeBase_preview.Location = new Point(138, 60);
            codeAssistant_richTextBox_exportCodeBase_preview.Name = "codeAssistant_richTextBox_exportCodeBase_preview";
            codeAssistant_richTextBox_exportCodeBase_preview.ShowSelectionMargin = true;
            codeAssistant_richTextBox_exportCodeBase_preview.Size = new Size(683, 147);
            codeAssistant_richTextBox_exportCodeBase_preview.TabIndex = 3;
            codeAssistant_richTextBox_exportCodeBase_preview.Text = "";
            // 
            // codeAssistant_progressBar_exportCodeBase
            // 
            codeAssistant_progressBar_exportCodeBase.Dock = DockStyle.Bottom;
            codeAssistant_progressBar_exportCodeBase.Location = new Point(0, 223);
            codeAssistant_progressBar_exportCodeBase.Name = "codeAssistant_progressBar_exportCodeBase";
            codeAssistant_progressBar_exportCodeBase.Size = new Size(830, 23);
            codeAssistant_progressBar_exportCodeBase.TabIndex = 4;
            // 
            // codeAssistant_openFileDirectory
            // 
            codeAssistant_openFileDirectory.Font = new Font("Segoe UI", 10.5F);
            codeAssistant_openFileDirectory.Location = new Point(694, 11);
            codeAssistant_openFileDirectory.Name = "codeAssistant_openFileDirectory";
            codeAssistant_openFileDirectory.Size = new Size(124, 34);
            codeAssistant_openFileDirectory.TabIndex = 5;
            codeAssistant_openFileDirectory.Text = "Open Directory";
            codeAssistant_openFileDirectory.UseVisualStyleBackColor = true;
            codeAssistant_openFileDirectory.Click += codeAssistant_openFileDirectory_Click;
            // 
            // codeAssistant
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 246);
            Controls.Add(codeAssistant_openFileDirectory);
            Controls.Add(codeAssistant_progressBar_exportCodeBase);
            Controls.Add(codeAssistant_richTextBox_exportCodeBase_preview);
            Controls.Add(codeAssistant_textBox_projectPathDirectory);
            Controls.Add(codeAssistant_button_exportCodeBase);
            Controls.Add(codeAssistant_button_projectPathSearch);
            Name = "codeAssistant";
            Text = "CodeAssistant";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button codeAssistant_button_projectPathSearch;
        private Button codeAssistant_button_exportCodeBase;
        private TextBox codeAssistant_textBox_projectPathDirectory;
        private RichTextBox codeAssistant_richTextBox_exportCodeBase_preview;
        private ProgressBar codeAssistant_progressBar_exportCodeBase;
        private Button codeAssistant_openFileDirectory;
        private FolderBrowserDialog codeAssistant__folderBrowserDialog;
    }
}