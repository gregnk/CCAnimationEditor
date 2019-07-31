namespace CCAnimationEditor
{
    partial class AboutWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.programNameLbl = new MetroFramework.Controls.MetroLabel();
            this.copyrightLbl = new MetroFramework.Controls.MetroLabel();
            this.versionLbl = new MetroFramework.Controls.MetroLabel();
            this.githubRepoBtn = new MetroFramework.Controls.MetroButton();
            this.licenseBtn = new MetroFramework.Controls.MetroButton();
            this.okBtn = new MetroFramework.Controls.MetroButton();
            this.projPageLnk = new MetroFramework.Controls.MetroLink();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // programNameLbl
            // 
            this.programNameLbl.AutoSize = true;
            this.programNameLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.programNameLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.programNameLbl.Location = new System.Drawing.Point(23, 72);
            this.programNameLbl.Name = "programNameLbl";
            this.programNameLbl.Size = new System.Drawing.Size(173, 25);
            this.programNameLbl.TabIndex = 0;
            this.programNameLbl.Text = "CCAnimationEditor";
            // 
            // copyrightLbl
            // 
            this.copyrightLbl.AutoSize = true;
            this.copyrightLbl.Location = new System.Drawing.Point(23, 164);
            this.copyrightLbl.MaximumSize = new System.Drawing.Size(750, 0);
            this.copyrightLbl.Name = "copyrightLbl";
            this.copyrightLbl.Size = new System.Drawing.Size(296, 57);
            this.copyrightLbl.TabIndex = 1;
            this.copyrightLbl.Text = "Developed by Gregory \"Gregarious\" Karastergios\r\n\r\nThis program is distributed und" +
    "er the ISC License";
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.versionLbl.Location = new System.Drawing.Point(23, 97);
            this.versionLbl.MaximumSize = new System.Drawing.Size(750, 0);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Size = new System.Drawing.Size(49, 19);
            this.versionLbl.TabIndex = 2;
            this.versionLbl.Text = "v0.0.0";
            // 
            // githubRepoBtn
            // 
            this.githubRepoBtn.Location = new System.Drawing.Point(23, 346);
            this.githubRepoBtn.Name = "githubRepoBtn";
            this.githubRepoBtn.Size = new System.Drawing.Size(101, 23);
            this.githubRepoBtn.TabIndex = 3;
            this.githubRepoBtn.Text = "Github Repo";
            this.githubRepoBtn.UseSelectable = true;
            this.githubRepoBtn.Click += new System.EventHandler(this.GithubRepoBtn_Click);
            // 
            // licenseBtn
            // 
            this.licenseBtn.Location = new System.Drawing.Point(130, 346);
            this.licenseBtn.Name = "licenseBtn";
            this.licenseBtn.Size = new System.Drawing.Size(101, 23);
            this.licenseBtn.TabIndex = 4;
            this.licenseBtn.Text = "License";
            this.licenseBtn.UseSelectable = true;
            this.licenseBtn.Click += new System.EventHandler(this.LicenseBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(481, 346);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(101, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "OK";
            this.okBtn.UseSelectable = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // projPageLnk
            // 
            this.projPageLnk.Location = new System.Drawing.Point(23, 128);
            this.projPageLnk.Name = "projPageLnk";
            this.projPageLnk.Size = new System.Drawing.Size(316, 23);
            this.projPageLnk.TabIndex = 6;
            this.projPageLnk.Text = "http://gregnk.com/projects/CCAnimationEditor.html";
            this.projPageLnk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.projPageLnk.UseSelectable = true;
            this.projPageLnk.Click += new System.EventHandler(this.ProjPageLnk_Click);
            // 
            // AboutWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 392);
            this.Controls.Add(this.projPageLnk);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.licenseBtn);
            this.Controls.Add(this.githubRepoBtn);
            this.Controls.Add(this.versionLbl);
            this.Controls.Add(this.copyrightLbl);
            this.Controls.Add(this.programNameLbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutWindow";
            this.Resizable = false;
            this.Text = "About";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroLabel programNameLbl;
        private MetroFramework.Controls.MetroLabel copyrightLbl;
        private MetroFramework.Controls.MetroLabel versionLbl;
        private MetroFramework.Controls.MetroButton githubRepoBtn;
        private MetroFramework.Controls.MetroButton licenseBtn;
        private MetroFramework.Controls.MetroButton okBtn;
        private MetroFramework.Controls.MetroLink projPageLnk;
    }
}