using System;
using System.Windows.Forms;

namespace yt_dlp_UI
{
    internal static class Program
    {
        public static string ytdlpFileName, ytdlpFilePath, ffmpegFileName, ffmpegFilePath, linktodl, mediaFormat, saveLocation;
        public static bool hasCustomSaveLocation = false;
        public static System.Diagnostics.Process cmdThread;
        public static string settingsFileLocation = "%USERPROFILE%\\AppData\\Roaming"; //\\Viktir\\ytdlpGUI1\\settings.txt";

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