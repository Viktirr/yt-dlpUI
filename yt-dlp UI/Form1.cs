using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO; // Needed for reading and saving user data
using System.Threading; // Needed to avoid freezes while it downloads
using System.Web;
using System.Numerics;
using System.Collections;

namespace yt_dlp_UI
{
    public partial class ytdlpGUI : Form
    {
        private StringBuilder m_output;
        bool downloadProcessStopped = true;

        public ytdlpGUI()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) // Find & Select yt-dlp / yt-dl
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
                            Program.saveLocation = Path.GetDirectoryName(Program.ytdlpFilePath);
                            outputDirText.Text = Path.GetDirectoryName(Program.ytdlpFilePath) + " (Automatically assigned)";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong while selecting this file. " + ex.Message);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e) // Find & Select ffmpeg
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

        private void btnSelOutputLocation_Click(object sender, EventArgs e) // Select the download directory
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
        private void StartButton_Click(object sender, EventArgs e) // When you click the start button, check for any missing steps and tell the user to fix them.
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
                forceStopButton.Enabled = true;
                downloadProcessStopped = false;
                switch (selectMediaFormat.Text) // Find which format should download
                {
                    case "Video (mp4)":
                        Program.mediaFormat = " --format mp4";
                        break;
                    case "Video (webm)":
                        Program.mediaFormat = "";
                        break;
                    case "Audio (mp3)":
                        Program.mediaFormat = " -x --audio-format mp3";
                        break;
                    case "Audio (ogg)":
                        Program.mediaFormat = " -x --audio-format vorbis";
                        break;
                    case "None":
                        Program.mediaFormat = "";
                        break;
                    default:
                        MessageBox.Show("Couldn't retrieve media format. Downloading as video (mp4)...");
                        Program.mediaFormat = " --format mp4";
                        selectMediaFormat.Text = "Video (mp4)";
                        break;
                }

                switch (Program.downloadHighQuality) // Check if "download at the highest quality available" is enabled
                {
                    case true:
                        Program.highQualityStringArg = " -f bestvideo+bestaudio";
                        break;
                    case false:
                        Program.highQualityStringArg = "";
                        break;
                }

                switch (startFromCheckBox.Checked) // Check if Start From or End At checkboxes are enabled.
                {
                    case true:
                        switch (endAtCheckBox.Checked)
                        {
                            case true:
                                Program.sectionDownloadStringArg = " --download-sections \"*" + startFromTextBox.Text + "-" + endAtTextBox.Text + "\"";
                                break;
                            case false:
                                Program.sectionDownloadStringArg = " --download-sections \"*" + startFromTextBox.Text + "-inf\"";
                                break;
                        }
                        break;
                    case false:
                        switch (endAtCheckBox.Checked)
                        {
                            case true:
                                Program.sectionDownloadStringArg = " --download-sections \"*0-" + endAtTextBox.Text + "\"";
                                break;
                            case false:
                                Program.sectionDownloadStringArg = "";
                                break;
                        }
                        break;
                }

                if (advancedArgsCheckBox.Checked == true) { Program.additionalArgs = advancedArgsTextBox.Text; } // Check if additional arguments are enabled, if so, put them in a string (probably more efficient to just grab the value from the TextBox)
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
            cmdStartInfo.Arguments = "/c " + Program.ytdlpFilePath + " --ffmpeg-location " + Program.ffmpegFilePath + " -o \"" + Program.saveLocation + "\\%(title)s [%(id)s].%(ext)s\"" + " " + Program.highQualityStringArg + Program.sectionDownloadStringArg + " " + Program.additionalArgs + " " + mediaFormat + " " + LinkTextBox.Text;
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
            m_output = null;
            Thread.CurrentThread.Interrupt();
        }

        void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (ConOutput.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateConsoleOutput(e.Data); };
                ConOutput.Invoke(safeWrite);
            }
            else
            {
                ConOutput.Text = e.Data;
            }

            // Add the data, one line at a time, to the string builder
            m_output.AppendLine(e.Data);
        }

        private void UpdateConsoleOutput(string ConsoleOutputText) // Update the console with new text
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
            ConOutput.Text = ConOutput.Text + "\nFinished downloading.";
        }

        private void btnDownloadYtdlp_Click(object sender, EventArgs e) // Download yt-dlp
        {
            var ps = new ProcessStartInfo("https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe")
            {
                UseShellExecute = true
            };
            Process.Start(ps);
        }

        private void btnDownloadffmpeg_Click(object sender, EventArgs e) // Download ffmpeg
        {
            var ps = new ProcessStartInfo("https://www.gyan.dev/ffmpeg/builds/ffmpeg-git-essentials.7z")
            {
                UseShellExecute = true
            };
            Process.Start(ps);
        }

        private void forceStopButton_Click(object sender, EventArgs e) // Stops the downloading process
        { 
            System.Diagnostics.Process t = Program.cmdThread;
            if (downloadProcessStopped == false)
            {
                try
                {
                    Debug.Print(t.ToString());
                    t.Close();
                    t = null;
                }
                catch
                {
                    MessageBox.Show("Something went wrong while cancelling the download.\nIs the download even running?");
                    return;
                }
                if (downloadProcessStopped == false)
                {
                    ConOutput.Text = ConOutput.Text + "\nStopped.";
                    downloadProcessStopped = true;
                }
            }
        }
        private void Form1_FormClosed(object sender, FormClosingEventArgs e) // When the program is closed...
        {
            // Open or create userdata
            FileStream _userData = new FileStream(Application.UserAppDataPath + "\\userdata.txt", FileMode.OpenOrCreate);
            if (_userData.Length > 0) // If there is any data, erase it
            {
                _userData.SetLength(0);
            }
            using (_userData)
            {
                // Store the location of yt-dlp, ffmpeg and save location variables
                // This doesn't seem to be the best way to do it, since most games and programs use some kind of variable name before the variable content. (i.e. bResolutionScale = 0.5)
                // This method just stores the content and on opening the application takes the line in which the content might be and applies it to a variable.
                if (Program.ytdlpFilePath != null && Program.ytdlpFilePath != "")
                {
                    try
                    {
                        AddText(_userData, Program.ytdlpFilePath.ToString());
                        AddText(_userData, "\n" + Program.ytdlpFileName.ToString());
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Something went wrong while saving yt-dlp shortcut to user settings file", ex.ToString());
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
                        MessageBox.Show("Something went wrong while saving ffmpeg shortcut to user settings file", ex.ToString());
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
                        MessageBox.Show("Something went wrong while saving save location information to user settings file", ex.ToString());
                    }
                }
                if (Program.additionalArgs == "" || Program.additionalArgs == null)
                {
                    try
                    {
                        AddText(_userData, "\n" + "-");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong while saving additional arguments to user settings file", ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        AddText(_userData, "\n" + Program.additionalArgs.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Something went wrong while saving additional arguments to user settings file", ex.ToString());
                    }
                }
            }
            _userData.Dispose();
        }
        private static void AddText(FileStream fs, string value) // Gets a string, converts them into bytes, then stores it in UTF-8 encoded letters, basically a string again.
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private void ytdlpGUI_Load(object sender, EventArgs e) // While the program is loading...
        {
            selectMediaFormat.SelectedIndex = 3; // Select Audio (mp3)
            
            //Anchor things as they should be, they're not done in the Designer to make further development easier
            ConOutput.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            advancedOptionsToggle.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            horizontalDivider.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            highQualityCheckbox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            startFromCheckBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            startFromTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            endAtCheckBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            endAtTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            startFromSecondsLabel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            endAtSecondsLabel.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            advancedArgsCheckBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            advancedArgsTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
            try // Check for the userdata file and it's contents.
            {
                var lineCount = File.ReadAllLines(Application.UserAppDataPath + "\\userdata.txt").Length;
                if (lineCount == 6)
                {
                    StreamReader _userData = new StreamReader(Application.UserAppDataPath + "\\userdata.txt");

                    Program.ytdlpFilePath = _userData.ReadLine();
                    Program.ytdlpFileName = _userData.ReadLine();
                    Program.ffmpegFilePath = _userData.ReadLine();
                    Program.ffmpegFileName = _userData.ReadLine();
                    Program.saveLocation = _userData.ReadLine();
                    Program.additionalArgs = _userData.ReadLine();
                    if (Program.saveLocation != null) { Program.hasCustomSaveLocation = true; }
                    _userData.Dispose();

                    YtdlpDirText.Text = Program.ytdlpFilePath;
                    ffmpegDirText.Text = Program.ffmpegFilePath;
                    outputDirText.Text = Program.saveLocation + " (Automatically assigned)";
                    if (Program.additionalArgs == "-") { Program.additionalArgs = null; }
                    advancedArgsTextBox.Text = Program.additionalArgs;
                }
                else
                {
                    ConOutput.Text = "User settings file is corrupted/incomplete. Reverting to default settings.";
                }
            }
            catch
            {
                Debug.WriteLine("Couldn't find userdata.txt");
            }
        }

        private void advancedOptionsToggle_CheckedChanged(object sender, EventArgs e) // Upon enabling advanced options, change the size of the form while keeping everything in place.
        {
            float monitorScalingFactor = (float)this.DeviceDpi / 96f;
            Form thisForm = ytdlpGUI.ActiveForm;
            int sizeAdjust = 136;
            int dpiSizeAdjust = (int)Math.Floor((float)sizeAdjust * (float)monitorScalingFactor);
            Control[] anchors = { advancedOptionsToggle, highQualityCheckbox, startFromCheckBox, startFromTextBox, endAtCheckBox, endAtTextBox, startFromSecondsLabel, endAtSecondsLabel, advancedArgsCheckBox }; // I believe this could be optimised further by putting it as a starting variable
            Control[] anchorsSide = { horizontalDivider, advancedArgsTextBox };
            switch (advancedOptionsToggle.Checked) {
                case true:
                    // Adjust the size of the form while making sure that nothing comes out of the application
                    // Anchor to top left so the bottom options show up
                    ConOutput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    for (int i = 0; i < anchors.Length; i++) { anchors[i].Anchor = AnchorStyles.Left | AnchorStyles.Top; }
                    for (int i = 0; i < anchorsSide.Length; i++) { anchorsSide[i].Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right; }
                    thisForm.Size = new Size(Width, Height + dpiSizeAdjust); // Adjust form size
                    thisForm.MinimumSize = new Size(thisForm.MinimumSize.Width, thisForm.MinimumSize.Height + dpiSizeAdjust); // Adjust minimum form size

                    // Anchor back to their original places
                    ConOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    for (int i = 0; i < anchors.Length; i++) { anchors[i].Anchor = AnchorStyles.Left | AnchorStyles.Bottom; }
                    for (int i = 0; i < anchorsSide.Length; i++) { anchorsSide[i].Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right; }

                    break;
                case false:
                    // Adjust the size of the form while making sure that nothing comes out of the application
                    // Anchor to the top left so the bottom options hide
                    ConOutput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    for (int i = 0; i < anchors.Length; i++) { anchors[i].Anchor = AnchorStyles.Left | AnchorStyles.Top; }
                    for (int i = 0; i < anchorsSide.Length; i++) { anchorsSide[i].Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right; }
                    thisForm.MinimumSize = new Size(thisForm.MinimumSize.Width, thisForm.MinimumSize.Height - dpiSizeAdjust); // Adjust minimum form size
                    thisForm.Size = new Size(Width, Height - dpiSizeAdjust); // Adjust form size

                    //Anchor back to their original places
                    ConOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    for (int i = 0; i < anchors.Length; i++) { anchors[i].Anchor = AnchorStyles.Left | AnchorStyles.Bottom; }
                    for (int i = 0; i < anchorsSide.Length; i++) { anchorsSide[i].Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right; }

                    break;
            }
        }

        private void highQualityCheckbox_CheckedChanged(object sender, EventArgs e) // Check if "Use highest quality available is enabled, if so, use -f bestaudio+bestvideo and change the media format to webm.
        {
            switch (highQualityCheckbox.Checked)
            {
                case true:
                    selectMediaFormat.Text = "Video (webm)";
                    selectMediaFormat.Enabled = false;
                    Program.downloadHighQuality = true;
                    break;
                case false:
                    selectMediaFormat.Enabled = true;
                    Program.downloadHighQuality = false;
                    break;
            }
        }

        private void startFromCheckBox_CheckedChanged(object sender, EventArgs e) // If start from check box is enabled, enable the TextBox beside it.
        {
            switch (startFromCheckBox.Checked)
            {
                case true:
                    startFromTextBox.Enabled = true;
                    break;
                case false:
                    startFromTextBox.Enabled = false;
                    break;
            }
        }

        private void endAtCheckBox_CheckedChanged(object sender, EventArgs e) // If end at check box is enabled, enable the TextBox beside it.
        {
            switch (endAtCheckBox.Checked)
            {
                case true:
                    endAtTextBox.Enabled = true;
                    break;
                case false:
                    endAtTextBox.Enabled = false;
                    break;
            }
        }

        private void advancedArgsCheckBox_CheckedChanged(object sender, EventArgs e) // Upon enabling additional arguments, disable all extra functionality.
        {
            switch (advancedArgsCheckBox.Checked)
            {
                case true:
                    advancedArgsTextBox.Enabled = true;
                    highQualityCheckbox.Enabled = false;
                    highQualityCheckbox.Checked = false;
                    startFromCheckBox.Enabled = false;
                    startFromCheckBox.Checked = false;
                    endAtCheckBox.Enabled = false;
                    endAtCheckBox.Checked = false;
                    selectMediaFormat.Enabled = false;
                    selectMediaFormat.SelectedIndex = 0;
                    break;

                case false:
                    advancedArgsTextBox.Enabled = false;
                    selectMediaFormat.Enabled = true;
                    highQualityCheckbox.Enabled = true;
                    startFromCheckBox.Enabled = true;
                    endAtCheckBox.Enabled = true;
                    selectMediaFormat.SelectedIndex = 3;
                    break;
            }
        }
    }
}