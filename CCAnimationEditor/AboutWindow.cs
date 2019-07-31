using MetroFramework.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CCAnimationEditor
{
    public partial class AboutWindow : MetroForm
    {
        public AboutWindow()
        {
            InitializeComponent();
            versionLbl.Text = Program.GetVersionString() + " - " + Program.GetBuildDateString();
        }

        private void LicenseBtn_Click(object sender, EventArgs e)
        {
            LicenseWindow licenseWindow = new LicenseWindow();
            licenseWindow.ShowDialog();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GithubRepoBtn_Click(object sender, EventArgs e)
        {
            Process.Start("http://github.com/gregnk/CCAnimationEditor");
        }

        private void ProjPageLnk_Click(object sender, EventArgs e)
        {
            Process.Start("http://gregnk.com/projects/CCAnimationEditor.html");
        }
    }
}
