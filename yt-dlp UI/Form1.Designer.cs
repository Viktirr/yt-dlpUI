namespace yt_dlp_UI
{
    partial class ytdlpGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ytdlpGUI));
            this.OpenSelectYtDlp = new System.Windows.Forms.OpenFileDialog();
            this.btnSelYtdlpPath = new System.Windows.Forms.Button();
            this.YtdlpDirText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.OpenSelectffmpeg = new System.Windows.Forms.OpenFileDialog();
            this.ConOutput = new System.Windows.Forms.RichTextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.ffmpegDirText = new System.Windows.Forms.Label();
            this.ytdlpInfoText = new System.Windows.Forms.Label();
            this.ffmpegInfoText = new System.Windows.Forms.Label();
            this.linkText = new System.Windows.Forms.Label();
            this.LinkTextBox = new System.Windows.Forms.TextBox();
            this.selectMediaFormat = new System.Windows.Forms.ComboBox();
            this.savePathText = new System.Windows.Forms.Label();
            this.outputDirText = new System.Windows.Forms.Label();
            this.btnSelOutputLocation = new System.Windows.Forms.Button();
            this.FolderSelectSaveLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDownloadYtdlp = new System.Windows.Forms.Button();
            this.btnDownloadffmpeg = new System.Windows.Forms.Button();
            this.forceStopButton = new System.Windows.Forms.Button();
            this.advancedOptionsToggle = new System.Windows.Forms.CheckBox();
            this.horizontalDivider = new System.Windows.Forms.Label();
            this.highQualityCheckbox = new System.Windows.Forms.CheckBox();
            this.startFromTextBox = new System.Windows.Forms.TextBox();
            this.startFromCheckBox = new System.Windows.Forms.CheckBox();
            this.endAtCheckBox = new System.Windows.Forms.CheckBox();
            this.endAtTextBox = new System.Windows.Forms.TextBox();
            this.startFromSecondsLabel = new System.Windows.Forms.Label();
            this.endAtSecondsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelYtdlpPath
            // 
            this.btnSelYtdlpPath.Location = new System.Drawing.Point(8, 12);
            this.btnSelYtdlpPath.Name = "btnSelYtdlpPath";
            this.btnSelYtdlpPath.Size = new System.Drawing.Size(115, 23);
            this.btnSelYtdlpPath.TabIndex = 1;
            this.btnSelYtdlpPath.Text = "Open yt-dlp";
            this.btnSelYtdlpPath.UseVisualStyleBackColor = true;
            this.btnSelYtdlpPath.Click += new System.EventHandler(this.Button1_Click);
            // 
            // YtdlpDirText
            // 
            this.YtdlpDirText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.YtdlpDirText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YtdlpDirText.Location = new System.Drawing.Point(249, 41);
            this.YtdlpDirText.Name = "YtdlpDirText";
            this.YtdlpDirText.Size = new System.Drawing.Size(398, 26);
            this.YtdlpDirText.TabIndex = 2;
            this.YtdlpDirText.Text = "yt-dl or yt-dlp hasn\'t been found. Please open it.";
            this.YtdlpDirText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(129, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Open ffmpeg";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ConOutput
            // 
            this.ConOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConOutput.BackColor = System.Drawing.SystemColors.Control;
            this.ConOutput.Location = new System.Drawing.Point(8, 245);
            this.ConOutput.Name = "ConOutput";
            this.ConOutput.ReadOnly = true;
            this.ConOutput.Size = new System.Drawing.Size(764, 168);
            this.ConOutput.TabIndex = 6;
            this.ConOutput.Text = "";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(8, 214);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(137, 25);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ffmpegDirText
            // 
            this.ffmpegDirText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ffmpegDirText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ffmpegDirText.Location = new System.Drawing.Point(249, 67);
            this.ffmpegDirText.Name = "ffmpegDirText";
            this.ffmpegDirText.Size = new System.Drawing.Size(377, 26);
            this.ffmpegDirText.TabIndex = 8;
            this.ffmpegDirText.Text = "ffmpeg hasn\'t been found. Please open it.";
            this.ffmpegDirText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ytdlpInfoText
            // 
            this.ytdlpInfoText.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ytdlpInfoText.Location = new System.Drawing.Point(12, 41);
            this.ytdlpInfoText.Name = "ytdlpInfoText";
            this.ytdlpInfoText.Size = new System.Drawing.Size(231, 26);
            this.ytdlpInfoText.TabIndex = 9;
            this.ytdlpInfoText.Text = "yt-dlp path:";
            this.ytdlpInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ffmpegInfoText
            // 
            this.ffmpegInfoText.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ffmpegInfoText.Location = new System.Drawing.Point(12, 67);
            this.ffmpegInfoText.Name = "ffmpegInfoText";
            this.ffmpegInfoText.Size = new System.Drawing.Size(231, 26);
            this.ffmpegInfoText.TabIndex = 10;
            this.ffmpegInfoText.Text = "ffmpeg path:";
            this.ffmpegInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkText
            // 
            this.linkText.AutoSize = true;
            this.linkText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkText.Location = new System.Drawing.Point(12, 186);
            this.linkText.Name = "linkText";
            this.linkText.Size = new System.Drawing.Size(38, 20);
            this.linkText.TabIndex = 11;
            this.linkText.Text = "Link:";
            // 
            // LinkTextBox
            // 
            this.LinkTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LinkTextBox.Location = new System.Drawing.Point(56, 183);
            this.LinkTextBox.Name = "LinkTextBox";
            this.LinkTextBox.PlaceholderText = "Paste media link here";
            this.LinkTextBox.Size = new System.Drawing.Size(534, 27);
            this.LinkTextBox.TabIndex = 12;
            // 
            // selectMediaFormat
            // 
            this.selectMediaFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectMediaFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectMediaFormat.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectMediaFormat.FormattingEnabled = true;
            this.selectMediaFormat.Items.AddRange(new object[] {
            "Video (mp4)",
            "Video (webm)",
            "Audio (mp3)",
            "Audio (ogg)"});
            this.selectMediaFormat.Location = new System.Drawing.Point(596, 183);
            this.selectMediaFormat.Name = "selectMediaFormat";
            this.selectMediaFormat.Size = new System.Drawing.Size(176, 27);
            this.selectMediaFormat.TabIndex = 13;
            // 
            // savePathText
            // 
            this.savePathText.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.savePathText.Location = new System.Drawing.Point(12, 93);
            this.savePathText.Name = "savePathText";
            this.savePathText.Size = new System.Drawing.Size(231, 26);
            this.savePathText.TabIndex = 14;
            this.savePathText.Text = "Save location:";
            this.savePathText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outputDirText
            // 
            this.outputDirText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDirText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputDirText.Location = new System.Drawing.Point(249, 93);
            this.outputDirText.Name = "outputDirText";
            this.outputDirText.Size = new System.Drawing.Size(523, 26);
            this.outputDirText.TabIndex = 15;
            this.outputDirText.Text = "Download location hasn\'t been set.";
            this.outputDirText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelOutputLocation
            // 
            this.btnSelOutputLocation.Location = new System.Drawing.Point(250, 12);
            this.btnSelOutputLocation.Name = "btnSelOutputLocation";
            this.btnSelOutputLocation.Size = new System.Drawing.Size(142, 23);
            this.btnSelOutputLocation.TabIndex = 16;
            this.btnSelOutputLocation.Text = "Change save location";
            this.btnSelOutputLocation.UseVisualStyleBackColor = true;
            this.btnSelOutputLocation.Click += new System.EventHandler(this.btnSelOutputLocation_Click);
            // 
            // btnDownloadYtdlp
            // 
            this.btnDownloadYtdlp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadYtdlp.Location = new System.Drawing.Point(528, 12);
            this.btnDownloadYtdlp.Name = "btnDownloadYtdlp";
            this.btnDownloadYtdlp.Size = new System.Drawing.Size(119, 23);
            this.btnDownloadYtdlp.TabIndex = 17;
            this.btnDownloadYtdlp.Text = "Download yt-dlp";
            this.btnDownloadYtdlp.UseVisualStyleBackColor = true;
            this.btnDownloadYtdlp.Click += new System.EventHandler(this.btnDownloadYtdlp_Click);
            // 
            // btnDownloadffmpeg
            // 
            this.btnDownloadffmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadffmpeg.Location = new System.Drawing.Point(653, 12);
            this.btnDownloadffmpeg.Name = "btnDownloadffmpeg";
            this.btnDownloadffmpeg.Size = new System.Drawing.Size(119, 23);
            this.btnDownloadffmpeg.TabIndex = 18;
            this.btnDownloadffmpeg.Text = "Download ffmpeg";
            this.btnDownloadffmpeg.UseVisualStyleBackColor = true;
            this.btnDownloadffmpeg.Click += new System.EventHandler(this.btnDownloadffmpeg_Click);
            // 
            // forceStopButton
            // 
            this.forceStopButton.Enabled = false;
            this.forceStopButton.Location = new System.Drawing.Point(151, 214);
            this.forceStopButton.Name = "forceStopButton";
            this.forceStopButton.Size = new System.Drawing.Size(92, 25);
            this.forceStopButton.TabIndex = 19;
            this.forceStopButton.Text = "Force Stop";
            this.forceStopButton.UseVisualStyleBackColor = true;
            this.forceStopButton.Click += new System.EventHandler(this.forceStopButton_Click);
            // 
            // advancedOptionsToggle
            // 
            this.advancedOptionsToggle.AutoSize = true;
            this.advancedOptionsToggle.Location = new System.Drawing.Point(8, 419);
            this.advancedOptionsToggle.Name = "advancedOptionsToggle";
            this.advancedOptionsToggle.Size = new System.Drawing.Size(156, 19);
            this.advancedOptionsToggle.TabIndex = 20;
            this.advancedOptionsToggle.Text = "Show Advanced Options";
            this.advancedOptionsToggle.UseVisualStyleBackColor = true;
            this.advancedOptionsToggle.CheckedChanged += new System.EventHandler(this.advancedOptionsToggle_CheckedChanged);
            // 
            // horizontalDivider
            // 
            this.horizontalDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horizontalDivider.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.horizontalDivider.Location = new System.Drawing.Point(8, 441);
            this.horizontalDivider.Name = "horizontalDivider";
            this.horizontalDivider.Size = new System.Drawing.Size(764, 2);
            this.horizontalDivider.TabIndex = 21;
            // 
            // highQualityCheckbox
            // 
            this.highQualityCheckbox.AutoSize = true;
            this.highQualityCheckbox.Location = new System.Drawing.Point(8, 446);
            this.highQualityCheckbox.Name = "highQualityCheckbox";
            this.highQualityCheckbox.Size = new System.Drawing.Size(275, 19);
            this.highQualityCheckbox.TabIndex = 22;
            this.highQualityCheckbox.Text = "Download at the highest video quality available";
            this.highQualityCheckbox.UseVisualStyleBackColor = true;
            this.highQualityCheckbox.CheckedChanged += new System.EventHandler(this.highQualityCheckbox_CheckedChanged);
            // 
            // startFromTextBox
            // 
            this.startFromTextBox.Enabled = false;
            this.startFromTextBox.Location = new System.Drawing.Point(96, 467);
            this.startFromTextBox.MaxLength = 6;
            this.startFromTextBox.Name = "startFromTextBox";
            this.startFromTextBox.Size = new System.Drawing.Size(49, 23);
            this.startFromTextBox.TabIndex = 28;
            this.startFromTextBox.Text = "0";
            this.startFromTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startFromCheckBox
            // 
            this.startFromCheckBox.AutoSize = true;
            this.startFromCheckBox.Location = new System.Drawing.Point(8, 471);
            this.startFromCheckBox.Name = "startFromCheckBox";
            this.startFromCheckBox.Size = new System.Drawing.Size(82, 19);
            this.startFromCheckBox.TabIndex = 29;
            this.startFromCheckBox.Text = "Start from:";
            this.startFromCheckBox.UseVisualStyleBackColor = true;
            this.startFromCheckBox.CheckedChanged += new System.EventHandler(this.startFromCheckBox_CheckedChanged);
            // 
            // endAtCheckBox
            // 
            this.endAtCheckBox.AutoSize = true;
            this.endAtCheckBox.Location = new System.Drawing.Point(8, 492);
            this.endAtCheckBox.Name = "endAtCheckBox";
            this.endAtCheckBox.Size = new System.Drawing.Size(62, 19);
            this.endAtCheckBox.TabIndex = 30;
            this.endAtCheckBox.Text = "End at:";
            this.endAtCheckBox.UseVisualStyleBackColor = true;
            this.endAtCheckBox.CheckedChanged += new System.EventHandler(this.endAtCheckBox_CheckedChanged);
            // 
            // endAtTextBox
            // 
            this.endAtTextBox.Enabled = false;
            this.endAtTextBox.Location = new System.Drawing.Point(96, 492);
            this.endAtTextBox.MaxLength = 6;
            this.endAtTextBox.Name = "endAtTextBox";
            this.endAtTextBox.Size = new System.Drawing.Size(49, 23);
            this.endAtTextBox.TabIndex = 31;
            this.endAtTextBox.Text = "999";
            this.endAtTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // startFromSecondsLabel
            // 
            this.startFromSecondsLabel.AutoSize = true;
            this.startFromSecondsLabel.Location = new System.Drawing.Point(151, 471);
            this.startFromSecondsLabel.Name = "startFromSecondsLabel";
            this.startFromSecondsLabel.Size = new System.Drawing.Size(50, 15);
            this.startFromSecondsLabel.TabIndex = 32;
            this.startFromSecondsLabel.Text = "seconds";
            // 
            // endAtSecondsLabel
            // 
            this.endAtSecondsLabel.AutoSize = true;
            this.endAtSecondsLabel.Location = new System.Drawing.Point(151, 496);
            this.endAtSecondsLabel.Name = "endAtSecondsLabel";
            this.endAtSecondsLabel.Size = new System.Drawing.Size(50, 15);
            this.endAtSecondsLabel.TabIndex = 33;
            this.endAtSecondsLabel.Text = "seconds";
            // 
            // ytdlpGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.endAtSecondsLabel);
            this.Controls.Add(this.startFromSecondsLabel);
            this.Controls.Add(this.endAtTextBox);
            this.Controls.Add(this.endAtCheckBox);
            this.Controls.Add(this.startFromCheckBox);
            this.Controls.Add(this.startFromTextBox);
            this.Controls.Add(this.highQualityCheckbox);
            this.Controls.Add(this.horizontalDivider);
            this.Controls.Add(this.advancedOptionsToggle);
            this.Controls.Add(this.forceStopButton);
            this.Controls.Add(this.btnDownloadffmpeg);
            this.Controls.Add(this.btnDownloadYtdlp);
            this.Controls.Add(this.btnSelOutputLocation);
            this.Controls.Add(this.outputDirText);
            this.Controls.Add(this.savePathText);
            this.Controls.Add(this.selectMediaFormat);
            this.Controls.Add(this.LinkTextBox);
            this.Controls.Add(this.linkText);
            this.Controls.Add(this.ffmpegInfoText);
            this.Controls.Add(this.ytdlpInfoText);
            this.Controls.Add(this.ffmpegDirText);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ConOutput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.YtdlpDirText);
            this.Controls.Add(this.btnSelYtdlpPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "ytdlpGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "yt-dlp GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.ytdlpGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenFileDialog OpenSelectYtDlp;
        private Button btnSelYtdlpPath;
        private Label YtdlpDirText;
        private Button button1;
        private OpenFileDialog OpenSelectffmpeg;
        private RichTextBox ConOutput;
        private Button StartButton;
        private Label ffmpegDirText;
        private Label ytdlpInfoText;
        private Label ffmpegInfoText;
        private Label linkText;
        private TextBox LinkTextBox;
        private ComboBox selectMediaFormat;
        private Label savePathText;
        private Label outputDirText;
        private Button btnSelOutputLocation;
        private FolderBrowserDialog FolderSelectSaveLocation;
        private Button btnDownloadYtdlp;
        private Button btnDownloadffmpeg;
        private Button forceStopButton;
        private CheckBox advancedOptionsToggle;
        private Label horizontalDivider;
        private CheckBox highQualityCheckbox;
        private TextBox startFromTextBox;
        private CheckBox startFromCheckBox;
        private CheckBox endAtCheckBox;
        private TextBox endAtTextBox;
        private Label startFromSecondsLabel;
        private Label endAtSecondsLabel;
    }
}