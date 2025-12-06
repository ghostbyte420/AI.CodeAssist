using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScintillaNET;

namespace AI.CodeAssist
{
    public partial class codeAssistant : Form
    {
        private Scintilla scintilla;

        public codeAssistant()
        {
            InitializeComponent();
            ReplaceRichTextBoxWithScintilla();
        }

        private void ReplaceRichTextBoxWithScintilla()
        {
            scintilla = new Scintilla
            {
                Location = codeAssistant_richTextBox_exportCodeBase_preview.Location,
                Size = codeAssistant_richTextBox_exportCodeBase_preview.Size,
                Dock = codeAssistant_richTextBox_exportCodeBase_preview.Dock,
                Anchor = codeAssistant_richTextBox_exportCodeBase_preview.Anchor
            };
            scintilla.LexerName = "cpp";
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.Green;
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.Green;
            scintilla.Styles[Style.Cpp.CommentDoc].ForeColor = Color.Green;
            scintilla.Styles[Style.Cpp.Number].ForeColor = Color.Purple;
            scintilla.Styles[Style.Cpp.String].ForeColor = Color.Red;
            scintilla.Styles[Style.Cpp.Character].ForeColor = Color.Red;
            scintilla.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.Brown;
            scintilla.SetKeywords(0, "abstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual void volatile while");
            scintilla.SetKeywords(1, "add alias ascending descending dynamic from get global group into join let orderby partial remove select set value var where yield");
            this.Controls.Remove(codeAssistant_richTextBox_exportCodeBase_preview);
            this.Controls.Add(scintilla);
        }

        private void codeAssistant_button_projectPathSearch_Click(object sender, EventArgs e)
        {
            if (codeAssistant__folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                codeAssistant_textBox_projectPathDirectory.Text = codeAssistant__folderBrowserDialog.SelectedPath;
            }
        }

        private void codeAssistant_openFileDirectory_Click(object sender, EventArgs e)
        {
            string projectFolder = codeAssistant_textBox_projectPathDirectory.Text;
            if (string.IsNullOrEmpty(projectFolder))
            {
                MessageBox.Show("Please select the project folder first.");
                return;
            }

            string outputDirectory = Path.Combine(projectFolder, "AI.CodeAssist");
            if (Directory.Exists(outputDirectory))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = outputDirectory,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("The output directory does not exist. Please export the code base first.");
            }
        }

        private void codeAssistant_button_exportCodeBase_Click(object sender, EventArgs e)
        {
            string projectFolder = codeAssistant_textBox_projectPathDirectory.Text;
            string outputFileBase = "CodeBase_";
            if (string.IsNullOrEmpty(projectFolder))
            {
                MessageBox.Show("Please select the project folder.");
                return;
            }

            try
            {
                string[] files = Directory.EnumerateFiles(projectFolder, "*.cs", SearchOption.AllDirectories).ToArray();
                if (files.Length == 0)
                {
                    MessageBox.Show("No .cs files found in the selected project folder.");
                    return;
                }

                codeAssistant_progressBar_exportCodeBase.Visible = true;
                codeAssistant_progressBar_exportCodeBase.Minimum = 0;
                codeAssistant_progressBar_exportCodeBase.Maximum = files.Length;
                codeAssistant_progressBar_exportCodeBase.Value = 0;

                MessageBox.Show($"Found {files.Length} .cs files to process.");

                int maxCharsPerFile = 140000;
                int currentFileIndex = 1;
                int currentCharCount = 0;
                StreamWriter outfile = null;
                string outputDirectory = Path.Combine(projectFolder, "AI.CodeAssist");
                Directory.CreateDirectory(outputDirectory);
                StringBuilder previewContent = new StringBuilder();
                string currentOutputFile = Path.Combine(outputDirectory, $"{outputFileBase}{currentFileIndex}.txt");
                outfile = new StreamWriter(currentOutputFile);
                int totalChars = 0;

                for (int i = 0; i < files.Length; i++)
                {
                    string file = files[i];
                    string fileContent = File.ReadAllText(file);
                    string[] lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    codeAssistant_progressBar_exportCodeBase.Value = i + 1;
                    Application.DoEvents();

                    if (currentCharCount + 2 > maxCharsPerFile)
                    {
                        outfile.Close();
                        currentFileIndex++;
                        currentOutputFile = Path.Combine(outputDirectory, $"{outputFileBase}{currentFileIndex}.txt");
                        outfile = new StreamWriter(currentOutputFile);
                        currentCharCount = 0;
                    }
                    outfile.WriteLine();
                    previewContent.AppendLine();
                    currentCharCount += 2;
                    totalChars += 2;

                    string fileMarker = $"=== File: {file} ===";
                    int fileMarkerLength = fileMarker.Length + 2;
                    if (currentCharCount + fileMarkerLength > maxCharsPerFile)
                    {
                        outfile.Close();
                        currentFileIndex++;
                        currentOutputFile = Path.Combine(outputDirectory, $"{outputFileBase}{currentFileIndex}.txt");
                        outfile = new StreamWriter(currentOutputFile);
                        currentCharCount = 0;
                    }
                    outfile.WriteLine(fileMarker);
                    previewContent.AppendLine(fileMarker);
                    currentCharCount += fileMarkerLength;
                    totalChars += fileMarkerLength;

                    if (currentCharCount + 2 > maxCharsPerFile)
                    {
                        outfile.Close();
                        currentFileIndex++;
                        currentOutputFile = Path.Combine(outputDirectory, $"{outputFileBase}{currentFileIndex}.txt");
                        outfile = new StreamWriter(currentOutputFile);
                        currentCharCount = 0;
                    }
                    outfile.WriteLine();
                    previewContent.AppendLine();
                    currentCharCount += 2;
                    totalChars += 2;

                    foreach (string line in lines)
                    {
                        int lineLength = line.Length + 2;
                        if (currentCharCount + lineLength > maxCharsPerFile)
                        {
                            outfile.Close();
                            currentFileIndex++;
                            currentOutputFile = Path.Combine(outputDirectory, $"{outputFileBase}{currentFileIndex}.txt");
                            outfile = new StreamWriter(currentOutputFile);
                            currentCharCount = 0;
                        }
                        outfile.WriteLine(line);
                        previewContent.AppendLine(line);
                        currentCharCount += lineLength;
                        totalChars += lineLength;
                    }

                    if (currentCharCount + 2 > maxCharsPerFile)
                    {
                        outfile.Close();
                        currentFileIndex++;
                        currentOutputFile = Path.Combine(outputDirectory, $"{outputFileBase}{currentFileIndex}.txt");
                        outfile = new StreamWriter(currentOutputFile);
                        currentCharCount = 0;
                    }
                    outfile.WriteLine();
                    previewContent.AppendLine();
                    currentCharCount += 2;
                    totalChars += 2;
                }

                outfile.Close();
                MessageBox.Show($"Combined code has been written to {currentFileIndex} files in the Output folder. Total characters: {totalChars}");
                scintilla.Text = previewContent.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
            finally
            {
                codeAssistant_progressBar_exportCodeBase.Visible = false;
            }
        }
    }
}
