using System;
using System.Windows.Forms;

namespace yt_dlp_UI
{
    internal static class Program
    {
        public static string ytdlpFileName, ytdlpFilePath, ffmpegFileName, ffmpegFilePath, mediaFormat, saveLocation; // Initial variables that are needed for reading user data
        public static bool hasCustomSaveLocation = false; // Initial variables that are needed for reading user data

        public static bool downloadHighQuality = false; // Advanced options booleans
        public static string highQualityStringArg; // String for downloading at the highest quality available, used in StartButton_Click in Form1
        public static string sectionDownloadStringArg; // String for downloading only a section of a video, used in StartButton_Click in Form1

        public static string additionalArgs;

        public static System.Diagnostics.Process cmdThread; // Declaring a null thread before it is actually used, I don't remember why I put this here.

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ytdlpGUI());
        }
    }
}