using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCAnimationEditor
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            // Generate a new settings file if it does not exist
            if (Settings.FindSettingsFile())
                Settings.LoadSettings();
            else
                Settings.SaveSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if the user has accepted the license
            if (!Settings.AccecptedLicense)
                Application.Run(new LicenseWindow(true));

            if (Settings.AccecptedLicense)
                Application.Run(new MainWindow());
        }

        public static string GetVersionString()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("v{0}.{1}.{2}", version.Major, version.Minor, version.Revision);
        }

        public static string GetBuildDateString()
        {
            // Returns date modified
            DateTime buildDate = File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location);
            return buildDate.ToString("yyyy-MM-dd HH:mm");
        }

        public static string GetLatestVersionString()
        {
            string latestVerString = null;

            try
            {
                latestVerString = new WebClient().DownloadString("http://gregnk.com/update/CCAnimationEditor.txt");
            }

            catch
            {
                return null;
            }

            return latestVerString;
        }

        public static bool CheckForUpdates()
        {
            // Check for the latest version
            string latestVerString = GetLatestVersionString();

            if (latestVerString != GetVersionString() && latestVerString != null)
                return true;
            else
                return false;
        }

        // TODO: Change this to download the program automatically
        public static void DownloadLatestVersion()
        {
            Process.Start(string.Format("https://github.com/gregnk/CCAnimationEditor/releases/download/{0}/CCAnimationEditor-{0}.zip", GetLatestVersionString()));
        }

        public static void WriteExecptionOutputToConsole(Exception e)
        {
            Console.WriteLine("===========");
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            Console.WriteLine("===========");
        }
    }
}
