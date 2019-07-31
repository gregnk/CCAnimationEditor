using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Components;
namespace CCAnimationEditor
{
    public partial class SettingsWindow : MetroForm
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void CCInstDirBrowseBtn_Click(object sender, EventArgs e)
        {
            // Ask the user 
            OpenFileDialog selectCCInstDir = new OpenFileDialog
            {
                Filter = "CrossCode Executable|CrossCode.exe",
                Title = "Open CrossCode executable"
            };

            if (selectCCInstDir.ShowDialog() == DialogResult.OK)
            {
                ccInstDirTb.Text = Path.GetDirectoryName(selectCCInstDir.FileName) + @"\";
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Settings.CCInstallDir = ccInstDirTb.Text;
            Settings.CreateAnimBackup = createBackupChk.Checked;

            Settings.SaveSettings();
            Close();
        }

        private void DiscardBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RevertChangesBtn_Click(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void UpdateControls()
        {
            ccInstDirTb.Text = Settings.CCInstallDir;
            createBackupChk.Checked = Settings.CreateAnimBackup;
        }
    }
}
