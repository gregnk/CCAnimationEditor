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
    public partial class LicenseWindow : MetroForm
    {
        public LicenseWindow(bool accecptLicense = false)
        {
            InitializeComponent();

            if (accecptLicense)
            {
                declineBtn.Visible = true;
                okBtn.Text = "Accept";
            }

            else
                okBtn.Text = "OK";
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            Settings.AccecptedLicense = true;
            Settings.SaveSettings();
            Close();
        }

        private void DeclineBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ThirdPartyLicensesBtn_Click(object sender, EventArgs e)
        {
            Process.Start("file:///" + Path.GetFullPath("LICENSES_3RDPARTY.html"));
        }
    }
}
