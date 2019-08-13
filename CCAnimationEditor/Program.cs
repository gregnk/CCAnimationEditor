using System;
using System.Collections.Generic;
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

        public static bool CheckForUpdates()
        {
            // Check for the latest version
            string latestVerString = null;

            try
            {
                latestVerString = new WebClient().DownloadString("http://gregnk.com/update/CCAnimationEditor.txt");
            }

            catch
            {
                return false;
            }

            if (latestVerString != GetVersionString() && latestVerString != null)
                return true;
            else
                return false;
        }

    }
}
