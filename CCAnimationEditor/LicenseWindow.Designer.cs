namespace CCAnimationEditor
{
    partial class LicenseWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseWindow));
            this.styleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.okBtn = new MetroFramework.Controls.MetroButton();
            this.licenseLbl = new MetroFramework.Controls.MetroLabel();
            this.declineBtn = new MetroFramework.Controls.MetroButton();
            this.thirdPartyLicensesBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(481, 346);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(101, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "Accecpt/OK";
            this.okBtn.UseSelectable = true;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // licenseLbl
            // 
            this.licenseLbl.Location = new System.Drawing.Point(24, 64);
            this.licenseLbl.Name = "licenseLbl";
            this.licenseLbl.Size = new System.Drawing.Size(558, 264);
            this.licenseLbl.TabIndex = 6;
            this.licenseLbl.Text = resources.GetString("licenseLbl.Text");
            // 
            // declineBtn
            // 
            this.declineBtn.Location = new System.Drawing.Point(374, 346);
            this.declineBtn.Name = "declineBtn";
            this.declineBtn.Size = new System.Drawing.Size(101, 23);
            this.declineBtn.TabIndex = 7;
            this.declineBtn.Text = "Decline";
            this.declineBtn.UseSelectable = true;
            this.declineBtn.Visible = false;
            this.declineBtn.Click += new System.EventHandler(this.DeclineBtn_Click);
            // 
            // thirdPartyLicensesBtn
            // 
            this.thirdPartyLicensesBtn.Location = new System.Drawing.Point(23, 346);
            this.thirdPartyLicensesBtn.Name = "thirdPartyLicensesBtn";
            this.thirdPartyLicensesBtn.Size = new System.Drawing.Size(101, 23);
            this.thirdPartyLicensesBtn.TabIndex = 8;
            this.thirdPartyLicensesBtn.Text = "3rd Party Licenses";
            this.thirdPartyLicensesBtn.UseSelectable = true;
            this.thirdPartyLicensesBtn.Click += new System.EventHandler(this.ThirdPartyLicensesBtn_Click);
            // 
            // LicenseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 392);
            this.Controls.Add(this.thirdPartyLicensesBtn);
            this.Controls.Add(this.declineBtn);
            this.Controls.Add(this.licenseLbl);
            this.Controls.Add(this.okBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseWindow";
            this.Resizable = false;
            this.Text = "License";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroButton okBtn;
        private MetroFramework.Controls.MetroLabel licenseLbl;
        private MetroFramework.Controls.MetroButton declineBtn;
        private MetroFramework.Controls.MetroButton thirdPartyLicensesBtn;
    }
}