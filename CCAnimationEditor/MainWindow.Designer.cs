namespace CCAnimationEditor
{
    partial class MainWindow
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
            this.fileBtn = new MetroFramework.Controls.MetroButton();
            this.helpBtn = new MetroFramework.Controls.MetroButton();
            this.fileContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsBtn = new MetroFramework.Controls.MetroButton();
            this.helpContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animTimer = new System.Windows.Forms.Timer(this.components);
            this.animationsTab = new MetroFramework.Controls.MetroTabPage();
            this.copyAnimBtn = new MetroFramework.Controls.MetroButton();
            this.animClearBtn = new MetroFramework.Controls.MetroButton();
            this.animBackBtn = new MetroFramework.Controls.MetroButton();
            this.animSpeedTxt = new MetroFramework.Controls.MetroTextBox();
            this.animSpeedLbl = new MetroFramework.Controls.MetroLabel();
            this.toggleAnimBgBtn = new MetroFramework.Controls.MetroButton();
            this.dirTxt = new MetroFramework.Controls.MetroTextBox();
            this.dirLbl = new MetroFramework.Controls.MetroLabel();
            this.frameTxt = new MetroFramework.Controls.MetroTextBox();
            this.frameLbl = new MetroFramework.Controls.MetroLabel();
            this.playPauseBtn = new MetroFramework.Controls.MetroButton();
            this.animPropsPnl = new MetroFramework.Controls.MetroPanel();
            this.animPropEditBtn = new MetroFramework.Controls.MetroButton();
            this.animPropTxt = new MetroFramework.Controls.MetroTextBox();
            this.animPropLbl = new MetroFramework.Controls.MetroLabel();
            this.removeAnimBtn = new MetroFramework.Controls.MetroButton();
            this.addAnimBtn = new MetroFramework.Controls.MetroButton();
            this.animCmb = new MetroFramework.Controls.MetroComboBox();
            this.animLbl = new MetroFramework.Controls.MetroLabel();
            this.animImgPnl = new CCAnimationEditor.MetroPanelCustom();
            this.sheetsTab = new MetroFramework.Controls.MetroTabPage();
            this.sheetList = new MetroFramework.Controls.MetroListView();
            this.copySheetBtn = new MetroFramework.Controls.MetroButton();
            this.toggleSheetBgBtn = new MetroFramework.Controls.MetroButton();
            this.sheetImgPnl = new CCAnimationEditor.MetroPanelCustom();
            this.sheetPropTxt = new MetroFramework.Controls.MetroTextBox();
            this.sheetPropLbl = new MetroFramework.Controls.MetroLabel();
            this.removeSheetBtn = new MetroFramework.Controls.MetroButton();
            this.addSheetBtn = new MetroFramework.Controls.MetroButton();
            this.sheetLbl = new MetroFramework.Controls.MetroLabel();
            this.editorTabs = new MetroFramework.Controls.MetroTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).BeginInit();
            this.fileContextMenu.SuspendLayout();
            this.helpContextMenu.SuspendLayout();
            this.animationsTab.SuspendLayout();
            this.animPropsPnl.SuspendLayout();
            this.sheetsTab.SuspendLayout();
            this.editorTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager
            // 
            this.styleManager.Owner = this;
            this.styleManager.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // fileBtn
            // 
            this.fileBtn.Location = new System.Drawing.Point(23, 63);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(101, 23);
            this.fileBtn.TabIndex = 1;
            this.fileBtn.Text = "File";
            this.fileBtn.UseSelectable = true;
            this.fileBtn.Click += new System.EventHandler(this.FileBtn_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.Location = new System.Drawing.Point(237, 63);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(101, 23);
            this.helpBtn.TabIndex = 2;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseSelectable = true;
            this.helpBtn.Click += new System.EventHandler(this.HelpBtn_Click);
            // 
            // fileContextMenu
            // 
            this.fileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openRecentToolStripMenuItem});
            this.fileContextMenu.Name = "fileContextMenu";
            this.fileContextMenu.Size = new System.Drawing.Size(140, 114);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blankToolStripMenuItem});
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openRecentToolStripMenuItem.Text = "Open recent";
            this.openRecentToolStripMenuItem.Visible = false;
            // 
            // blankToolStripMenuItem
            // 
            this.blankToolStripMenuItem.Name = "blankToolStripMenuItem";
            this.blankToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.blankToolStripMenuItem.Text = "<Blank>";
            // 
            // settingsBtn
            // 
            this.settingsBtn.Location = new System.Drawing.Point(130, 63);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(101, 23);
            this.settingsBtn.TabIndex = 3;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseSelectable = true;
            this.settingsBtn.Click += new System.EventHandler(this.SettingsBtn_Click);
            // 
            // helpContextMenu
            // 
            this.helpContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpContextMenu.Name = "aboutContextMenu";
            this.helpContextMenu.Size = new System.Drawing.Size(158, 48);
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            this.documentationToolStripMenuItem.Visible = false;
            this.documentationToolStripMenuItem.Click += new System.EventHandler(this.DocumentationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // animTimer
            // 
            this.animTimer.Interval = 33;
            this.animTimer.Tick += new System.EventHandler(this.AnimTimer_Tick);
            // 
            // animationsTab
            // 
            this.animationsTab.Controls.Add(this.copyAnimBtn);
            this.animationsTab.Controls.Add(this.animClearBtn);
            this.animationsTab.Controls.Add(this.animBackBtn);
            this.animationsTab.Controls.Add(this.animSpeedTxt);
            this.animationsTab.Controls.Add(this.animSpeedLbl);
            this.animationsTab.Controls.Add(this.toggleAnimBgBtn);
            this.animationsTab.Controls.Add(this.dirTxt);
            this.animationsTab.Controls.Add(this.dirLbl);
            this.animationsTab.Controls.Add(this.frameTxt);
            this.animationsTab.Controls.Add(this.frameLbl);
            this.animationsTab.Controls.Add(this.playPauseBtn);
            this.animationsTab.Controls.Add(this.animPropsPnl);
            this.animationsTab.Controls.Add(this.removeAnimBtn);
            this.animationsTab.Controls.Add(this.addAnimBtn);
            this.animationsTab.Controls.Add(this.animCmb);
            this.animationsTab.Controls.Add(this.animLbl);
            this.animationsTab.Controls.Add(this.animImgPnl);
            this.animationsTab.HorizontalScrollbarBarColor = true;
            this.animationsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.animationsTab.HorizontalScrollbarSize = 10;
            this.animationsTab.Location = new System.Drawing.Point(4, 38);
            this.animationsTab.Name = "animationsTab";
            this.animationsTab.Size = new System.Drawing.Size(1407, 603);
            this.animationsTab.TabIndex = 1;
            this.animationsTab.Text = "Animations";
            this.animationsTab.VerticalScrollbarBarColor = true;
            this.animationsTab.VerticalScrollbarHighlightOnWheel = false;
            this.animationsTab.VerticalScrollbarSize = 10;
            // 
            // copyAnimBtn
            // 
            this.copyAnimBtn.Location = new System.Drawing.Point(373, 15);
            this.copyAnimBtn.Name = "copyAnimBtn";
            this.copyAnimBtn.Size = new System.Drawing.Size(31, 29);
            this.copyAnimBtn.TabIndex = 27;
            this.copyAnimBtn.Text = "++";
            this.copyAnimBtn.UseSelectable = true;
            this.copyAnimBtn.Click += new System.EventHandler(this.CopyAnimBtn_Click);
            this.copyAnimBtn.MouseHover += new System.EventHandler(this.CopyAnimBtn_MouseHover);
            // 
            // animClearBtn
            // 
            this.animClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.animClearBtn.Location = new System.Drawing.Point(195, 544);
            this.animClearBtn.Name = "animClearBtn";
            this.animClearBtn.Size = new System.Drawing.Size(83, 35);
            this.animClearBtn.TabIndex = 26;
            this.animClearBtn.Text = "Clear";
            this.animClearBtn.UseSelectable = true;
            this.animClearBtn.Visible = false;
            this.animClearBtn.Click += new System.EventHandler(this.AnimClearBtn_Click);
            // 
            // animBackBtn
            // 
            this.animBackBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.animBackBtn.Location = new System.Drawing.Point(195, 498);
            this.animBackBtn.Name = "animBackBtn";
            this.animBackBtn.Size = new System.Drawing.Size(83, 35);
            this.animBackBtn.TabIndex = 25;
            this.animBackBtn.Text = "Back";
            this.animBackBtn.UseSelectable = true;
            this.animBackBtn.Visible = false;
            this.animBackBtn.Click += new System.EventHandler(this.AnimBackBtn_Click);
            // 
            // animSpeedTxt
            // 
            this.animSpeedTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.animSpeedTxt.CustomButton.Image = null;
            this.animSpeedTxt.CustomButton.Location = new System.Drawing.Point(69, 1);
            this.animSpeedTxt.CustomButton.Name = "";
            this.animSpeedTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.animSpeedTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.animSpeedTxt.CustomButton.TabIndex = 1;
            this.animSpeedTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.animSpeedTxt.CustomButton.UseSelectable = true;
            this.animSpeedTxt.CustomButton.Visible = false;
            this.animSpeedTxt.Lines = new string[] {
        "1"};
            this.animSpeedTxt.Location = new System.Drawing.Point(59, 556);
            this.animSpeedTxt.MaxLength = 32767;
            this.animSpeedTxt.Name = "animSpeedTxt";
            this.animSpeedTxt.PasswordChar = '\0';
            this.animSpeedTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.animSpeedTxt.SelectedText = "";
            this.animSpeedTxt.SelectionLength = 0;
            this.animSpeedTxt.SelectionStart = 0;
            this.animSpeedTxt.ShortcutsEnabled = true;
            this.animSpeedTxt.Size = new System.Drawing.Size(91, 23);
            this.animSpeedTxt.TabIndex = 24;
            this.animSpeedTxt.Text = "1";
            this.animSpeedTxt.UseSelectable = true;
            this.animSpeedTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.animSpeedTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.animSpeedTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AnimSpeedTxt_KeyUp);
            // 
            // animSpeedLbl
            // 
            this.animSpeedLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.animSpeedLbl.AutoSize = true;
            this.animSpeedLbl.Location = new System.Drawing.Point(5, 557);
            this.animSpeedLbl.Name = "animSpeedLbl";
            this.animSpeedLbl.Size = new System.Drawing.Size(46, 19);
            this.animSpeedLbl.TabIndex = 23;
            this.animSpeedLbl.Text = "Speed";
            // 
            // toggleAnimBgBtn
            // 
            this.toggleAnimBgBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleAnimBgBtn.Location = new System.Drawing.Point(284, 498);
            this.toggleAnimBgBtn.Name = "toggleAnimBgBtn";
            this.toggleAnimBgBtn.Size = new System.Drawing.Size(83, 35);
            this.toggleAnimBgBtn.TabIndex = 22;
            this.toggleAnimBgBtn.Text = "Toggle BG";
            this.toggleAnimBgBtn.UseSelectable = true;
            this.toggleAnimBgBtn.Click += new System.EventHandler(this.ToggleBgBtn_Click);
            // 
            // dirTxt
            // 
            this.dirTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.dirTxt.CustomButton.Image = null;
            this.dirTxt.CustomButton.Location = new System.Drawing.Point(69, 1);
            this.dirTxt.CustomButton.Name = "";
            this.dirTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.dirTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.dirTxt.CustomButton.TabIndex = 1;
            this.dirTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dirTxt.CustomButton.UseSelectable = true;
            this.dirTxt.CustomButton.Visible = false;
            this.dirTxt.Lines = new string[] {
        "0"};
            this.dirTxt.Location = new System.Drawing.Point(59, 527);
            this.dirTxt.MaxLength = 32767;
            this.dirTxt.Name = "dirTxt";
            this.dirTxt.PasswordChar = '\0';
            this.dirTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dirTxt.SelectedText = "";
            this.dirTxt.SelectionLength = 0;
            this.dirTxt.SelectionStart = 0;
            this.dirTxt.ShortcutsEnabled = true;
            this.dirTxt.Size = new System.Drawing.Size(91, 23);
            this.dirTxt.TabIndex = 21;
            this.dirTxt.Text = "0";
            this.dirTxt.UseSelectable = true;
            this.dirTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.dirTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.dirTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DirTxt_KeyUp);
            // 
            // dirLbl
            // 
            this.dirLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dirLbl.AutoSize = true;
            this.dirLbl.Location = new System.Drawing.Point(4, 529);
            this.dirLbl.Name = "dirLbl";
            this.dirLbl.Size = new System.Drawing.Size(26, 19);
            this.dirLbl.TabIndex = 20;
            this.dirLbl.Text = "Dir";
            // 
            // frameTxt
            // 
            this.frameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.frameTxt.CustomButton.Image = null;
            this.frameTxt.CustomButton.Location = new System.Drawing.Point(69, 1);
            this.frameTxt.CustomButton.Name = "";
            this.frameTxt.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.frameTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.frameTxt.CustomButton.TabIndex = 1;
            this.frameTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.frameTxt.CustomButton.UseSelectable = true;
            this.frameTxt.CustomButton.Visible = false;
            this.frameTxt.Lines = new string[] {
        "0"};
            this.frameTxt.Location = new System.Drawing.Point(59, 498);
            this.frameTxt.MaxLength = 32767;
            this.frameTxt.Name = "frameTxt";
            this.frameTxt.PasswordChar = '\0';
            this.frameTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.frameTxt.SelectedText = "";
            this.frameTxt.SelectionLength = 0;
            this.frameTxt.SelectionStart = 0;
            this.frameTxt.ShortcutsEnabled = true;
            this.frameTxt.Size = new System.Drawing.Size(91, 23);
            this.frameTxt.TabIndex = 19;
            this.frameTxt.Text = "0";
            this.frameTxt.UseSelectable = true;
            this.frameTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.frameTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.frameTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrameTxt_KeyUp);
            // 
            // frameLbl
            // 
            this.frameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.frameLbl.AutoSize = true;
            this.frameLbl.Location = new System.Drawing.Point(4, 499);
            this.frameLbl.Name = "frameLbl";
            this.frameLbl.Size = new System.Drawing.Size(47, 19);
            this.frameLbl.TabIndex = 18;
            this.frameLbl.Text = "Frame";
            // 
            // playPauseBtn
            // 
            this.playPauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playPauseBtn.Location = new System.Drawing.Point(284, 544);
            this.playPauseBtn.Name = "playPauseBtn";
            this.playPauseBtn.Size = new System.Drawing.Size(83, 35);
            this.playPauseBtn.TabIndex = 17;
            this.playPauseBtn.Text = "Play";
            this.playPauseBtn.UseSelectable = true;
            this.playPauseBtn.Click += new System.EventHandler(this.PlayPauseBtn_Click);
            // 
            // animPropsPnl
            // 
            this.animPropsPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.animPropsPnl.AutoScroll = true;
            this.animPropsPnl.Controls.Add(this.animPropEditBtn);
            this.animPropsPnl.Controls.Add(this.animPropTxt);
            this.animPropsPnl.Controls.Add(this.animPropLbl);
            this.animPropsPnl.HorizontalScrollbar = true;
            this.animPropsPnl.HorizontalScrollbarBarColor = true;
            this.animPropsPnl.HorizontalScrollbarHighlightOnWheel = false;
            this.animPropsPnl.HorizontalScrollbarSize = 10;
            this.animPropsPnl.Location = new System.Drawing.Point(4, 50);
            this.animPropsPnl.Name = "animPropsPnl";
            this.animPropsPnl.Size = new System.Drawing.Size(363, 431);
            this.animPropsPnl.TabIndex = 16;
            this.animPropsPnl.VerticalScrollbar = true;
            this.animPropsPnl.VerticalScrollbarBarColor = false;
            this.animPropsPnl.VerticalScrollbarHighlightOnWheel = false;
            this.animPropsPnl.VerticalScrollbarSize = 10;
            // 
            // animPropEditBtn
            // 
            this.animPropEditBtn.Location = new System.Drawing.Point(100, 37);
            this.animPropEditBtn.Name = "animPropEditBtn";
            this.animPropEditBtn.Size = new System.Drawing.Size(188, 23);
            this.animPropEditBtn.TabIndex = 18;
            this.animPropEditBtn.Text = "Edit";
            this.animPropEditBtn.UseSelectable = true;
            this.animPropEditBtn.Visible = false;
            // 
            // animPropTxt
            // 
            // 
            // 
            // 
            this.animPropTxt.CustomButton.Image = null;
            this.animPropTxt.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.animPropTxt.CustomButton.Name = "";
            this.animPropTxt.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.animPropTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.animPropTxt.CustomButton.TabIndex = 1;
            this.animPropTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.animPropTxt.CustomButton.UseSelectable = true;
            this.animPropTxt.CustomButton.Visible = false;
            this.animPropTxt.Lines = new string[0];
            this.animPropTxt.Location = new System.Drawing.Point(100, 5);
            this.animPropTxt.MaxLength = 32767;
            this.animPropTxt.Name = "animPropTxt";
            this.animPropTxt.PasswordChar = '\0';
            this.animPropTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.animPropTxt.SelectedText = "";
            this.animPropTxt.SelectionLength = 0;
            this.animPropTxt.SelectionStart = 0;
            this.animPropTxt.ShortcutsEnabled = true;
            this.animPropTxt.Size = new System.Drawing.Size(188, 25);
            this.animPropTxt.TabIndex = 17;
            this.animPropTxt.UseSelectable = true;
            this.animPropTxt.Visible = false;
            this.animPropTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.animPropTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // animPropLbl
            // 
            this.animPropLbl.AutoSize = true;
            this.animPropLbl.Location = new System.Drawing.Point(1, 7);
            this.animPropLbl.Name = "animPropLbl";
            this.animPropLbl.Size = new System.Drawing.Size(38, 19);
            this.animPropLbl.TabIndex = 16;
            this.animPropLbl.Text = "Prop";
            this.animPropLbl.Visible = false;
            // 
            // removeAnimBtn
            // 
            this.removeAnimBtn.Location = new System.Drawing.Point(336, 15);
            this.removeAnimBtn.Name = "removeAnimBtn";
            this.removeAnimBtn.Size = new System.Drawing.Size(31, 29);
            this.removeAnimBtn.TabIndex = 13;
            this.removeAnimBtn.Text = "-";
            this.removeAnimBtn.UseSelectable = true;
            this.removeAnimBtn.Click += new System.EventHandler(this.RemoveAnimBtn_Click);
            // 
            // addAnimBtn
            // 
            this.addAnimBtn.Location = new System.Drawing.Point(299, 15);
            this.addAnimBtn.Name = "addAnimBtn";
            this.addAnimBtn.Size = new System.Drawing.Size(31, 29);
            this.addAnimBtn.TabIndex = 12;
            this.addAnimBtn.Text = "+";
            this.addAnimBtn.UseSelectable = true;
            this.addAnimBtn.Click += new System.EventHandler(this.AddAnimBtn_Click);
            // 
            // animCmb
            // 
            this.animCmb.FormattingEnabled = true;
            this.animCmb.ItemHeight = 23;
            this.animCmb.Location = new System.Drawing.Point(104, 15);
            this.animCmb.Name = "animCmb";
            this.animCmb.Size = new System.Drawing.Size(188, 29);
            this.animCmb.TabIndex = 11;
            this.animCmb.UseSelectable = true;
            this.animCmb.SelectedIndexChanged += new System.EventHandler(this.AnimCmb_SelectedIndexChanged);
            // 
            // animLbl
            // 
            this.animLbl.AutoSize = true;
            this.animLbl.Location = new System.Drawing.Point(4, 18);
            this.animLbl.Name = "animLbl";
            this.animLbl.Size = new System.Drawing.Size(69, 19);
            this.animLbl.TabIndex = 10;
            this.animLbl.Text = "Animation";
            // 
            // animImgPnl
            // 
            this.animImgPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.animImgPnl.BackColor = System.Drawing.Color.Black;
            this.animImgPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.animImgPnl.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.animImgPnl.HorizontalScrollbarBarColor = true;
            this.animImgPnl.HorizontalScrollbarHighlightOnWheel = false;
            this.animImgPnl.HorizontalScrollbarSize = 10;
            this.animImgPnl.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.animImgPnl.Location = new System.Drawing.Point(732, 15);
            this.animImgPnl.Name = "animImgPnl";
            this.animImgPnl.Size = new System.Drawing.Size(672, 588);
            this.animImgPnl.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.animImgPnl.TabIndex = 2;
            this.animImgPnl.UseCustomBackColor = true;
            this.animImgPnl.VerticalScrollbarBarColor = true;
            this.animImgPnl.VerticalScrollbarHighlightOnWheel = false;
            this.animImgPnl.VerticalScrollbarSize = 10;
            // 
            // sheetsTab
            // 
            this.sheetsTab.Controls.Add(this.sheetList);
            this.sheetsTab.Controls.Add(this.copySheetBtn);
            this.sheetsTab.Controls.Add(this.toggleSheetBgBtn);
            this.sheetsTab.Controls.Add(this.sheetImgPnl);
            this.sheetsTab.Controls.Add(this.sheetPropTxt);
            this.sheetsTab.Controls.Add(this.sheetPropLbl);
            this.sheetsTab.Controls.Add(this.removeSheetBtn);
            this.sheetsTab.Controls.Add(this.addSheetBtn);
            this.sheetsTab.Controls.Add(this.sheetLbl);
            this.sheetsTab.HorizontalScrollbarBarColor = true;
            this.sheetsTab.HorizontalScrollbarHighlightOnWheel = false;
            this.sheetsTab.HorizontalScrollbarSize = 10;
            this.sheetsTab.Location = new System.Drawing.Point(4, 38);
            this.sheetsTab.Name = "sheetsTab";
            this.sheetsTab.Size = new System.Drawing.Size(1407, 603);
            this.sheetsTab.TabIndex = 0;
            this.sheetsTab.Text = "Sheets";
            this.sheetsTab.VerticalScrollbarBarColor = true;
            this.sheetsTab.VerticalScrollbarHighlightOnWheel = false;
            this.sheetsTab.VerticalScrollbarSize = 10;
            // 
            // sheetList
            // 
            this.sheetList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.sheetList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.sheetList.FullRowSelect = true;
            this.sheetList.HideSelection = false;
            this.sheetList.Location = new System.Drawing.Point(103, 60);
            this.sheetList.Name = "sheetList";
            this.sheetList.OwnerDraw = true;
            this.sheetList.Size = new System.Drawing.Size(189, 417);
            this.sheetList.TabIndex = 25;
            this.sheetList.UseCompatibleStateImageBehavior = false;
            this.sheetList.UseSelectable = true;
            this.sheetList.View = System.Windows.Forms.View.List;
            this.sheetList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.SheetList_ItemSelectionChanged);
            this.sheetList.Click += new System.EventHandler(this.SheetList_Click);
            // 
            // copySheetBtn
            // 
            this.copySheetBtn.Location = new System.Drawing.Point(373, 15);
            this.copySheetBtn.Name = "copySheetBtn";
            this.copySheetBtn.Size = new System.Drawing.Size(31, 29);
            this.copySheetBtn.TabIndex = 24;
            this.copySheetBtn.Text = "++";
            this.copySheetBtn.UseSelectable = true;
            this.copySheetBtn.Click += new System.EventHandler(this.CopySheetBtn_Click);
            this.copySheetBtn.MouseHover += new System.EventHandler(this.CopySheetBtn_MouseHover);
            // 
            // toggleSheetBgBtn
            // 
            this.toggleSheetBgBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleSheetBgBtn.Location = new System.Drawing.Point(284, 498);
            this.toggleSheetBgBtn.Name = "toggleSheetBgBtn";
            this.toggleSheetBgBtn.Size = new System.Drawing.Size(83, 35);
            this.toggleSheetBgBtn.TabIndex = 23;
            this.toggleSheetBgBtn.Text = "Toggle BG";
            this.toggleSheetBgBtn.UseSelectable = true;
            this.toggleSheetBgBtn.Click += new System.EventHandler(this.ToggleBgBtn_Click);
            // 
            // sheetImgPnl
            // 
            this.sheetImgPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sheetImgPnl.BackColor = System.Drawing.Color.Black;
            this.sheetImgPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sheetImgPnl.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.sheetImgPnl.HorizontalScrollbarBarColor = true;
            this.sheetImgPnl.HorizontalScrollbarHighlightOnWheel = false;
            this.sheetImgPnl.HorizontalScrollbarSize = 10;
            this.sheetImgPnl.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.sheetImgPnl.Location = new System.Drawing.Point(732, 15);
            this.sheetImgPnl.Name = "sheetImgPnl";
            this.sheetImgPnl.Size = new System.Drawing.Size(672, 588);
            this.sheetImgPnl.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.sheetImgPnl.TabIndex = 10;
            this.sheetImgPnl.UseCustomBackColor = true;
            this.sheetImgPnl.VerticalScrollbarBarColor = true;
            this.sheetImgPnl.VerticalScrollbarHighlightOnWheel = false;
            this.sheetImgPnl.VerticalScrollbarSize = 10;
            // 
            // sheetPropTxt
            // 
            // 
            // 
            // 
            this.sheetPropTxt.CustomButton.Image = null;
            this.sheetPropTxt.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.sheetPropTxt.CustomButton.Name = "";
            this.sheetPropTxt.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.sheetPropTxt.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.sheetPropTxt.CustomButton.TabIndex = 1;
            this.sheetPropTxt.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.sheetPropTxt.CustomButton.UseSelectable = true;
            this.sheetPropTxt.CustomButton.Visible = false;
            this.sheetPropTxt.Lines = new string[0];
            this.sheetPropTxt.Location = new System.Drawing.Point(522, 15);
            this.sheetPropTxt.MaxLength = 32767;
            this.sheetPropTxt.Name = "sheetPropTxt";
            this.sheetPropTxt.PasswordChar = '\0';
            this.sheetPropTxt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.sheetPropTxt.SelectedText = "";
            this.sheetPropTxt.SelectionLength = 0;
            this.sheetPropTxt.SelectionStart = 0;
            this.sheetPropTxt.ShortcutsEnabled = true;
            this.sheetPropTxt.Size = new System.Drawing.Size(188, 25);
            this.sheetPropTxt.TabIndex = 9;
            this.sheetPropTxt.UseSelectable = true;
            this.sheetPropTxt.Visible = false;
            this.sheetPropTxt.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.sheetPropTxt.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sheetPropLbl
            // 
            this.sheetPropLbl.AutoSize = true;
            this.sheetPropLbl.Location = new System.Drawing.Point(423, 18);
            this.sheetPropLbl.Name = "sheetPropLbl";
            this.sheetPropLbl.Size = new System.Drawing.Size(38, 19);
            this.sheetPropLbl.TabIndex = 8;
            this.sheetPropLbl.Text = "Prop";
            this.sheetPropLbl.Visible = false;
            // 
            // removeSheetBtn
            // 
            this.removeSheetBtn.Location = new System.Drawing.Point(336, 15);
            this.removeSheetBtn.Name = "removeSheetBtn";
            this.removeSheetBtn.Size = new System.Drawing.Size(31, 29);
            this.removeSheetBtn.TabIndex = 6;
            this.removeSheetBtn.Text = "-";
            this.removeSheetBtn.UseSelectable = true;
            this.removeSheetBtn.Click += new System.EventHandler(this.RemoveSheetBtn_Click);
            // 
            // addSheetBtn
            // 
            this.addSheetBtn.Location = new System.Drawing.Point(299, 15);
            this.addSheetBtn.Name = "addSheetBtn";
            this.addSheetBtn.Size = new System.Drawing.Size(31, 29);
            this.addSheetBtn.TabIndex = 5;
            this.addSheetBtn.Text = "+";
            this.addSheetBtn.UseSelectable = true;
            this.addSheetBtn.Click += new System.EventHandler(this.AddSheetBtn_Click);
            // 
            // sheetLbl
            // 
            this.sheetLbl.AutoSize = true;
            this.sheetLbl.Location = new System.Drawing.Point(4, 18);
            this.sheetLbl.Name = "sheetLbl";
            this.sheetLbl.Size = new System.Drawing.Size(41, 19);
            this.sheetLbl.TabIndex = 3;
            this.sheetLbl.Text = "Sheet";
            // 
            // editorTabs
            // 
            this.editorTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorTabs.Controls.Add(this.sheetsTab);
            this.editorTabs.Controls.Add(this.animationsTab);
            this.editorTabs.Location = new System.Drawing.Point(23, 92);
            this.editorTabs.Name = "editorTabs";
            this.editorTabs.SelectedIndex = 0;
            this.editorTabs.Size = new System.Drawing.Size(1415, 645);
            this.editorTabs.TabIndex = 0;
            this.editorTabs.Tag = "";
            this.editorTabs.UseSelectable = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1461, 760);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.fileBtn);
            this.Controls.Add(this.editorTabs);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MinimumSize = new System.Drawing.Size(801, 467);
            this.Name = "MainWindow";
            this.Text = "CCAnimationEditor";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Closed += new System.EventHandler(this.MainWindow_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.styleManager)).EndInit();
            this.fileContextMenu.ResumeLayout(false);
            this.helpContextMenu.ResumeLayout(false);
            this.animationsTab.ResumeLayout(false);
            this.animationsTab.PerformLayout();
            this.animPropsPnl.ResumeLayout(false);
            this.animPropsPnl.PerformLayout();
            this.sheetsTab.ResumeLayout(false);
            this.sheetsTab.PerformLayout();
            this.editorTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Components.MetroStyleManager styleManager;
        private MetroFramework.Controls.MetroButton helpBtn;
        private MetroFramework.Controls.MetroButton fileBtn;
        private MetroFramework.Controls.MetroContextMenu fileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blankToolStripMenuItem;
        private MetroFramework.Controls.MetroButton settingsBtn;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu helpContextMenu;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer animTimer;
        private MetroFramework.Controls.MetroTabControl editorTabs;
        private MetroFramework.Controls.MetroTabPage sheetsTab;
        private MetroFramework.Controls.MetroButton toggleSheetBgBtn;
        private MetroPanelCustom sheetImgPnl;
        private MetroFramework.Controls.MetroTextBox sheetPropTxt;
        private MetroFramework.Controls.MetroLabel sheetPropLbl;
        private MetroFramework.Controls.MetroButton removeSheetBtn;
        private MetroFramework.Controls.MetroButton addSheetBtn;
        private MetroFramework.Controls.MetroLabel sheetLbl;
        private MetroFramework.Controls.MetroTabPage animationsTab;
        private MetroFramework.Controls.MetroButton animBackBtn;
        private MetroFramework.Controls.MetroTextBox animSpeedTxt;
        private MetroFramework.Controls.MetroLabel animSpeedLbl;
        private MetroFramework.Controls.MetroButton toggleAnimBgBtn;
        private MetroFramework.Controls.MetroTextBox dirTxt;
        private MetroFramework.Controls.MetroLabel dirLbl;
        private MetroFramework.Controls.MetroTextBox frameTxt;
        private MetroFramework.Controls.MetroLabel frameLbl;
        private MetroFramework.Controls.MetroButton playPauseBtn;
        private MetroFramework.Controls.MetroPanel animPropsPnl;
        private MetroFramework.Controls.MetroButton animPropEditBtn;
        private MetroFramework.Controls.MetroTextBox animPropTxt;
        private MetroFramework.Controls.MetroLabel animPropLbl;
        private MetroFramework.Controls.MetroButton removeAnimBtn;
        private MetroFramework.Controls.MetroButton addAnimBtn;
        private MetroFramework.Controls.MetroComboBox animCmb;
        private MetroFramework.Controls.MetroLabel animLbl;
        private MetroPanelCustom animImgPnl;
        private MetroFramework.Controls.MetroButton animClearBtn;
        private MetroFramework.Controls.MetroButton copySheetBtn;
        private MetroFramework.Controls.MetroButton copyAnimBtn;
        private MetroFramework.Controls.MetroListView sheetList;
    }
}

