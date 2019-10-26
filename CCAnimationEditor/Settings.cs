using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Collections;


namespace CCAnimationEditor
{
    public static class Settings
    {
        private static readonly string SettingsFile = @"Settings.xml";

        private static string ccInstallDir = "";
        private static List<string> recentFiles = new List<string>();
        private static bool showDevWarning = true;
        private static bool accecptedLicense = false;
        private static bool createAnimBackup = true;
        private static bool checkForUpdates = true;

        public static string CCInstallDir { get => ccInstallDir; set => ccInstallDir = value; }
        public static List<string> RecentFiles { get => recentFiles; set => recentFiles = value; }
        public static bool ShowDevWarning { get => showDevWarning; set => showDevWarning = value; }
        public static bool AccecptedLicense { get => accecptedLicense; set => accecptedLicense = value; }
        public static bool CreateAnimBackup { get => createAnimBackup; set => createAnimBackup = value; }
        public static bool CheckForUpdates { get => checkForUpdates; set => checkForUpdates = value; }

        public static void SaveSettings()
        {
            XmlDocument doc = new XmlDocument();

            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", ""));
            XmlNode root = doc.CreateElement("Settings");
            doc.AppendChild(root);

            root.AppendChild(doc.CreateElement("CCInstallDir"));
            root["CCInstallDir"].InnerText = CCInstallDir;

            //root.AppendChild(doc.CreateElement("RecentFiles"));
            //foreach (string path in RecentFiles)
            //{
            //    XmlNode fileNode = doc.CreateElement("FilePath");
            //    fileNode.InnerText = path;

            //    root["RecentFiles"].AppendChild(fileNode);
            //}

            root.AppendChild(doc.CreateElement("ShowDevWarning"));
            root["ShowDevWarning"].InnerText = ShowDevWarning.ToString();

            root.AppendChild(doc.CreateElement("AccecptedLicense"));
            root["AccecptedLicense"].InnerText = AccecptedLicense.ToString();

            root.AppendChild(doc.CreateElement("CreateAnimBackup"));
            root["CreateAnimBackup"].InnerText = CreateAnimBackup.ToString();

            root.AppendChild(doc.CreateElement("CheckForUpdates"));
            root["CheckForUpdates"].InnerText = CheckForUpdates.ToString();

            doc.Save(SettingsFile);
        }

        public static void LoadSettings()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(SettingsFile);

                XmlNode root = doc["Settings"];

                CCInstallDir = root["CCInstallDir"].InnerText;
                //foreach (XmlNode fileNode in root["RecentFiles"].ChildNodes)
                //{
                //    RecentFiles.Add(fileNode.InnerText);
                //}

                ShowDevWarning = bool.Parse(root["ShowDevWarning"].InnerText);
                AccecptedLicense = bool.Parse(root["AccecptedLicense"].InnerText);
                CreateAnimBackup = bool.Parse(root["CreateAnimBackup"].InnerText);
                CheckForUpdates = bool.Parse(root["CheckForUpdates"].InnerText);
            }

            catch
            {
                // Generate a new save file anything is invalid
                SaveSettings();
            }
        }

        public static void ClearRecentFiles()
        {
            RecentFiles = new List<string>();
        }

        public static void DeleteSettings()
        {
            File.Delete(SettingsFile);
        }

        public static bool FindCCInstallDir()
        {
            // Check common locations
            List<string> commonLocations = new List<string>
            {
                @"C:\Program Files\Steam\steamapps\common\CrossCode\",
                @"C:\Program Files (x86)\Steam\steamapps\common\CrossCode\"
            };

            foreach (string location in commonLocations)
            {
                if (File.Exists(location + "CrossCode.exe"))
                {
                    CCInstallDir = location;
                    return true;
                }
            }

            // IDEA: Have it scan for CrossCode.exe if it is not in the common locations
            return false;
        }

        public static bool FindSettingsFile()
        {
            return File.Exists(SettingsFile);
        }
    }
}
