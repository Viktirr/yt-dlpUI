using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Threading;
using System.Web;

delegate void SafeCallDelegate(string text);

namespace yt_dlp_UI
{
    public partial class ytdlpGUI : Form
    {
        private StringBuilder m_output;

        public ytdlpGUI()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenSelectYtDlp = new OpenFileDialog();
            OpenSelectYtDlp.InitialDirectory = @"C:\";
            OpenSelectYtDlp.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            OpenSelectYtDlp.Title = "Select yt-dlp.exe";
            if (OpenSelectYtDlp.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (OpenSelectYtDlp.FileName != null)
                    {
                        YtdlpDirText.Text = OpenSelectYtDlp.FileName;
                        Program.ytdlpFilePath = OpenSelectYtDlp.FileName;
                        Program.ytdlpFileName = OpenSelectYtDlp.SafeFileName;
                        if (Program.hasCustomSaveLocation == false)
                        {
                            Program.saveLocation = System.IO.Path.GetDirectoryName(Program.ytdlpFilePath);
                            outputDirText.Text = System.IO.Path.GetDirectoryName(Program.ytdlpFilePath) + " (Automatically assigned)";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong while selecting this file. " + ex.Message);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenSelectffmpeg = new OpenFileDialog();
            OpenSelectffmpeg.InitialDirectory = @"C:\";
            OpenSelectffmpeg.Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*";
            OpenSelectffmpeg.Title = "Select an ffmpeg binary";
            if (OpenSelectffmpeg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (OpenSelectffmpeg.FileName != null)
                    {
                        ffmpegDirText.Text = OpenSelectffmpeg.FileName;
                        Program.ffmpegFilePath = OpenSelectffmpeg.FileName;
                        Program.ffmpegFileName = OpenSelectffmpeg.SafeFileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong while selecting this file. " + ex.Message);
                }
            }
        }

        private void btnSelOutputLocation_Click(object sender, EventArgs e)
        {
            FolderSelectSaveLocation = new FolderBrowserDialog();
            FolderSelectSaveLocation.InitialDirectory = @"C:\";
            if (FolderSelectSaveLocation.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (FolderSelectSaveLocation.SelectedPath != null)
                    {
                        Program.hasCustomSaveLocation = true;
                        outputDirText.Text = FolderSelectSaveLocation.SelectedPath;
                        Program.saveLocation = FolderSelectSaveLocation.SelectedPath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong while selecting this folder. " + ex.Message);
                }
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Program.ytdlpFilePath))
            {
                ConOutput.Text = "Please open yt-dl/yt-dlp, then try again.";
            }
            else if (string.IsNullOrEmpty(Program.ffmpegFilePath))
            {
                ConOutput.Text = "Please open ffmpeg, then try again.";
            }
            else if (string.IsNullOrEmpty(LinkTextBox.Text))
            {
                ConOutput.Text = "Insert a link/URL to download.";
            }
            else
            {
                ConOutput.Text = "Starting...";
                StartButton.Enabled = false;
                if (selectMediaFormat.Text == "Video (mp4)")
                {
                    Program.mediaFormat = "--format mp4";
                }
                else if (selectMediaFormat.Text == "Audio (mp3)")
                {
                    Program.mediaFormat = "--extract-audio --audio-format mp3";
                }
                else
                {
                    MessageBox.Show("Couldn't retrieve media format. Downloading as video...");
                    Program.mediaFormat = "--format mp4";
                }
                Thread t = new Thread(CmdThread);
                t.Start();
            }
        }

        private void CmdThread()
        {
            string mediaFormat = Program.mediaFormat;
            m_output = new StringBuilder();
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
            cmdStartInfo.Arguments = "/c " + Program.ytdlpFilePath + " --ffmpeg-location " + Program.ffmpegFilePath + " -o \"" + Program.saveLocation + "\\%(title)s [%(id)s].%(ext)s\"" + " " + mediaFormat + " " + LinkTextBox.Text;
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = true;

            Process cmdProcess = new Process();
            cmdProcess.StartInfo = cmdStartInfo;
            cmdProcess.OutputDataReceived += cmd_DataReceived;
            cmdProcess.ErrorDataReceived += cmd_DataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Start();
            cmdProcess.BeginOutputReadLine();
            cmdProcess.BeginErrorReadLine();
            Program.cmdThread = cmdProcess;

            //cmdProcess.StandardInput.WriteLine(ConOutput.Text);
            //cmdProcess.StandardInput.WriteLine("exit");s

            cmdProcess.WaitForExit();

            if (StartButton.InvokeRequired)
            {
                Action enableStart = delegate { EnableStartButton(); };
                StartButton.Invoke(enableStart);
            }
            else
            {
                StartButton.Enabled = true;
            }

            // And now that everything's done, just set the text
            // to whatever's in the stringbuilder
            // ConOutput.Text = m_output.ToString();

            // We're done with the stringbuilder, let the garbage
            // collector free it
            m_output = null;
            Thread.CurrentThread.Interrupt();
        }

        void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("Output from other process");
            Debug.WriteLine(e.Data);


            string TextToWrite = e.Data;

            //ConOutput.Text = "";
            if (ConOutput.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateConsoleOutput(TextToWrite); };
                ConOutput.Invoke(safeWrite);
            }
            else
            {
                ConOutput.Text = e.Data;
            }

            // Add the data, one line at a time, to the string builder
            m_output.AppendLine(e.Data);
        }

        private void UpdateConsoleOutput(string ConsoleOutputText)
        {
            if (ConOutput.Text == "Starting...")
            {
                ConOutput.Text = "";
            }
            if (ConOutput.TextLength != 0)
            {
                ConOutput.Text += "\n";
            }
            ConOutput.Text += ConsoleOutputText;
            ConOutput.SelectionStart = ConOutput.TextLength;
            ConOutput.ScrollToCaret();
        }

        private void EnableStartButton()
        {
            StartButton.Enabled = true;
        }

        private void btnDownloadYtdlp_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        private void btnDownloadffmpeg_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("https://www.gyan.dev/ffmpeg/builds/ffmpeg-git-essentials.7z")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        private void forceStopButton_Click(object sender, EventArgs e)
        { 
            System.Diagnostics.Process t = Program.cmdThread;
            try
            {
                t.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong... \n" + ex.ToString());
            }
        }
        private void Form1_FormClosed(object sender, FormClosingEventArgs e)
        {
            FileStream _userData = new FileStream(Application.UserAppDataPath + "\\userdata.txt", FileMode.OpenOrCreate);
            if (_userData.Length > 0)
            {
                _userData.SetLength(0);
            }
            using (_userData)
            {
                if (Program.ytdlpFilePath != null && Program.ytdlpFilePath != "")
                {
                    try
                    {
                        AddText(_userData, Program.ytdlpFilePath.ToString());
                        AddText(_userData, "\n" + Program.ytdlpFileName.ToString());
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Something went wrong while saving yt-dlp shortcut to file", ex.ToString());
                    }
                }
                if (Program.ffmpegFilePath != null && Program.ffmpegFilePath != "")
                {
                    try
                    {
                        AddText(_userData, "\n" + Program.ffmpegFilePath.ToString());
                        AddText(_userData, "\n" + Program.ffmpegFileName.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong while saving ffmpeg shortcut to file", ex.ToString());
                    }
                }
                if (Program.saveLocation != null && Program.saveLocation != "")
                {
                    try
                    {
                        AddText(_userData, "\n" + Program.saveLocation.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong while saving save location information to file", ex.ToString());
                    }
                }
            }
            _userData.Dispose();
        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void ytdlpGUI_Load(object sender, EventArgs e)
        {
            try
            {
                var lineCount = File.ReadAllLines(Application.UserAppDataPath + "\\userdata.txt").Length;
                if (lineCount == 5)
                {
                    StreamReader _userData = new StreamReader(Application.UserAppDataPath + "\\userdata.txt");

                    Program.ytdlpFilePath = _userData.ReadLine();
                    Program.ytdlpFileName = _userData.ReadLine();
                    Program.ffmpegFilePath = _userData.ReadLine();
                    Program.ffmpegFileName = _userData.ReadLine();
                    Program.saveLocation = _userData.ReadLine();
                    if (Program.saveLocation != null) { Program.hasCustomSaveLocation = true; }
                    _userData.Dispose();

                    YtdlpDirText.Text = Program.ytdlpFilePath;
                    ffmpegDirText.Text = Program.ffmpegFilePath;
                    outputDirText.Text = Program.saveLocation + " (Automatically assigned)";
                }
                else
                {
                    ConOutput.Text = "Couldn't load file";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Couldn't find userdata.txt...\n",ex.ToString());
            }
        }
    }
}