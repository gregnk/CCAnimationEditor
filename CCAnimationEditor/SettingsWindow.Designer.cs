namespace CCAnimationEditor
{
    partial class SettingsWindow
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
            this.saveBtn = new MetroFramework.Controls.MetroButton();
            this.discardBtn = new MetroFramework.Controls.MetroButton();
            this.ccInstDirLbl = new MetroFramework.Controls.MetroLabel();
            this.ccInstDirTb = new MetroFramework.Controls.MetroTextBox();
            this.ccInstDirBrowseBtn = new MetroFramework.Controls.MetroButton();
            this.revertChangesBtn = new MetroFramework.Controls.MetroButton();
            this.createBackupLbl = new MetroFramework.Controls.MetroLabel();
            this.createBackupChk = new MetroFramework.Controls.MetroCheckBox();
            this.checkUpdateChk = new MetroFramework.Controls.MetroCheckBox();
            this.checkUpdatesLbl = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(475, 346);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(105, 25);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseSelectable = true;
            this.saveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // discardBtn
            // 
            this.discardBtn.Location = new System.Drawing.Point(364, 346);
            this.discardBtn.Name = "discardBtn";
            this.discardBtn.Size = new System.Drawing.Size(105, 25);
            this.discardBtn.TabIndex = 1;
            this.discardBtn.Text = "Discard";
            this.discardBtn.UseSelectable = true;
            this.discardBtn.Click += new System.EventHandler(this.DiscardBtn_Click);
            // 
            // ccInstDirLbl
            // 
            this.ccInstDirLbl.AutoSize = true;
            this.ccInstDirLbl.Location = new System.Drawing.Point(23, 64);
            this.ccInstDirLbl.Name = "ccInstDirLbl";
            this.ccInstDirLbl.Size = new System.Drawing.Size(92, 19);
            this.ccInstDirLbl.TabIndex = 2;
            this.ccInstDirLbl.Text = "CC install path";
            // 
            // ccInstDirTb
            // 
            // 
            // 
            // 
            this.ccInstDirTb.CustomButton.Image = null;
            this.ccInstDirTb.CustomButton.Location = new System.Drawing.Point(353, 1);
            this.ccInstDirTb.CustomButton.Name = "";
            this.ccInstDirTb.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ccInstDirTb.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ccInstDirTb.CustomButton.TabIndex = 1;
            this.ccInstDirTb.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ccInstDirTb.CustomButton.UseSelectable = true;
            this.ccInstDirTb.CustomButton.Visible = false;
            this.ccInstDirTb.Lines = new string[0];
            this.ccInstDirTb.Location = new System.Drawing.Point(122, 64);
            this.ccInstDirTb.MaxLength = 32767;
            this.ccInstDirTb.Name = "ccInstDirTb";
            this.ccInstDirTb.PasswordChar = '\0';
            this.ccInstDirTb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ccInstDirTb.SelectedText = "";
            this.ccInstDirTb.SelectionLength = 0;
            this.ccInstDirTb.SelectionStart = 0;
            this.ccInstDirTb.ShortcutsEnabled = true;
            this.ccInstDirTb.Size = new System.Drawing.Size(375, 23);
            this.ccInstDirTb.TabIndex = 3;
            this.ccInstDirTb.UseSelectable = true;
            this.ccInstDirTb.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ccInstDirTb.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ccInstDirBrowseBtn
            // 
            this.ccInstDirBrowseBtn.Location = new System.Drawing.Point(503, 64);
            this.ccInstDirBrowseBtn.Name = "ccInstDirBrowseBtn";
            this.ccInstDirBrowseBtn.Size = new System.Drawing.Size(79, 23);
            this.ccInstDirBrowseBtn.TabIndex = 4;
            this.ccInstDirBrowseBtn.Text = "Browse";
            this.ccInstDirBrowseBtn.UseSelectable = true;
            this.ccInstDirBrowseBtn.Click += new System.EventHandler(this.CCInstDirBrowseBtn_Click);
            // 
            // revertChangesBtn
            // 
            this.revertChangesBtn.Location = new System.Drawing.Point(253, 346);
            this.revertChangesBtn.Name = "revertChangesBtn";
            this.revertChangesBtn.Size = new System.Drawing.Size(105, 25);
            this.revertChangesBtn.TabIndex = 5;
            this.revertChangesBtn.Text = "Revert Changes";
            this.revertChangesBtn.UseSelectable = true;
            this.revertChangesBtn.Click += new System.EventHandler(this.RevertChangesBtn_Click);
            // 
            // createBackupLbl
            // 
            this.createBackupLbl.AutoSize = true;
            this.createBackupLbl.Location = new System.Drawing.Point(23, 102);
            this.createBackupLbl.Name = "createBackupLbl";
            this.createBackupLbl.Size = new System.Drawing.Size(201, 19);
            this.createBackupLbl.TabIndex = 6;
            this.createBackupLbl.Text = "Create backup upon opening file";
            // 
            // createBackupChk
            // 
            this.createBackupChk.AutoSize = true;
            this.createBackupChk.Location = new System.Drawing.Point(231, 105);
            this.createBackupChk.Name = "createBackupChk";
            this.createBackupChk.Size = new System.Drawing.Size(26, 15);
            this.createBackupChk.TabIndex = 7;
            this.createBackupChk.Text = " ";
            this.createBackupChk.UseSelectable = true;
            // 
            // checkUpdateChk
            // 
            this.checkUpdateChk.AutoSize = true;
            this.checkUpdateChk.Location = new System.Drawing.Point(231, 135);
            this.checkUpdateChk.Name = "checkUpdateChk";
            this.checkUpdateChk.Size = new System.Drawing.Size(26, 15);
            this.checkUpdateChk.TabIndex = 9;
            this.checkUpdateChk.Text = " ";
            this.checkUpdateChk.UseSelectable = true;
            // 
            // checkUpdatesLbl
            // 
            this.checkUpdatesLbl.AutoSize = true;
            this.checkUpdatesLbl.Location = new System.Drawing.Point(23, 132);
            this.checkUpdatesLbl.Name = "checkUpdatesLbl";
            this.checkUpdatesLbl.Size = new System.Drawing.Size(179, 19);
            this.checkUpdatesLbl.TabIndex = 8;
            this.checkUpdatesLbl.Text = "Check for updates on startup";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 392);
            this.Controls.Add(this.checkUpdateChk);
            this.Controls.Add(this.checkUpdatesLbl);
            this.Controls.Add(this.createBackupChk);
            this.Controls.Add(this.createBackupLbl);
            this.Controls.Add(this.revertChangesBtn);
            this.Controls.Add(this.ccInstDirBrowseBtn);
            this.Controls.Add(this.ccInstDirTb);
            this.Controls.Add(this.ccInstDirLbl);
            this.Controls.Add(this.discardBtn);
            this.Controls.Add(this.saveBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.Resizable = false;
            this.Text = "Settings";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroButton discardBtn;
        private MetroFramework.Controls.MetroButton saveBtn;
        private MetroFramework.Controls.MetroButton ccInstDirBrowseBtn;
        private MetroFramework.Controls.MetroTextBox ccInstDirTb;
        private MetroFramework.Controls.MetroLabel ccInstDirLbl;
        private MetroFramework.Controls.MetroButton revertChangesBtn;
        private MetroFramework.Controls.MetroCheckBox createBackupChk;
        private MetroFramework.Controls.MetroLabel createBackupLbl;
        private MetroFramework.Controls.MetroCheckBox checkUpdateChk;
        private MetroFramework.Controls.MetroLabel checkUpdatesLbl;
    }
}