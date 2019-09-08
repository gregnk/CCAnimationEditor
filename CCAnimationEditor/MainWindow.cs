using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

// TODO: Implement multi entity animations
// TODO: Clean this entire thing up and put it into different class files

// TODO: Add an "Export to GIF" function
// TODO: Add some documentation as to what each property does
// TODO: Make the UI setup more efficient
// TODO: Add the ability to edit multiple items at once

namespace CCAnimationEditor
{
    public partial class MainWindow : MetroForm
    {
        // Animation file class
        private AnimationFile animationFile = new AnimationFile();

        // Animation file path
        private string animationFilePath;

        // All of the controls are (mostly) auto generated from the class properties

        // Property labels and inputs - Sheets
        private List<MetroLabel> sheetPropLabels = new List<MetroLabel>();
        private List<MetroTextBox> sheetPropInputs = new List<MetroTextBox>();

        // Property labels and inputs - Animations
        private List<MetroLabel> animPropLabels = new List<MetroLabel>();
        private List<Control> animPropInputs = new List<Control>();

        // Editor settings
        private bool unsavedChanges = false;
        private bool playAnim = false;
        private int animDir = 0;
        private int animFrameIndex = 0;

        private bool editingArray = false;
        private string arrayName;

        // Spacing for auto-generated controls
        private const int ControlSpacing = 40;
        private ToolTip tt = new ToolTip();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            // Set the default tab to sheets
            editorTabs.SelectedIndex = 0;

            // Set the install dir if it is not set
            if (Settings.CCInstallDir == "")
            {
                // Try to locate the CC install dir
                if (Settings.FindCCInstallDir())
                    Settings.SaveSettings();

                else
                {
                    // If it cannot be found then ask the user to locate it
                    OpenFileDialog selectCCInstDir = new OpenFileDialog
                    {
                        Filter = "CrossCode Executable|CrossCode.exe",
                        Title = "Open CrossCode executable"
                    };

                    if (selectCCInstDir.ShowDialog() == DialogResult.OK)
                    {
                        Settings.CCInstallDir = Path.GetDirectoryName(selectCCInstDir.FileName) + @"\";
                        Settings.SaveSettings();
                    }

                    else
                    {
                        Close();
                    }
                }
            }

            // Show the dev warning on the first startup
            if (Settings.ShowDevWarning)
            {
                MetroMessageBox.Show(this,
                    "This program is still in beta and is not finished or guaranteed to be 100% functional. " + Environment.NewLine
                    + "Please submit any bugs reports, feature requests or feedback to http://github.com/gregnk/CCAnimationEditor/issues" + Environment.NewLine + Environment.NewLine
                    + "Thank You.",
                    "Notice", MessageBoxButtons.OK);

                Settings.ShowDevWarning = false;
                Settings.SaveSettings();
            }

#if !DEBUG
            if (Settings.CheckForUpdates)
            {
                if (Program.CheckForUpdates())
                {
                    DialogResult updateDlg = MetroMessageBox.Show(this, "An update is available! Would you like to download it?" + Environment.NewLine
                        + "(You can disable this check in settings)", "Notice", MessageBoxButtons.YesNo);

                    if (updateDlg == DialogResult.Yes)
                    {
                        Program.DownloadLatestVersion();
                    }
                }
            }
#endif
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            tt.Dispose();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask the user if they want to save any unsaved changes
            if (unsavedChanges)
            {
                DialogResult confirm = ConfirmUnsavedChanges();

                if (confirm == DialogResult.Yes || confirm == DialogResult.No)
                    e.Cancel = false;
                else if (confirm == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        // Menu bar
        private void FileBtn_Click(object sender, EventArgs e)
        {
            fileContextMenu.Show(fileBtn, 0, fileBtn.Height);
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            helpContextMenu.Show(helpBtn, 0, helpBtn.Height);
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.ShowDialog();
        }

        // Menu bar - File items
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (unsavedChanges)
            {
                DialogResult confirm = ConfirmUnsavedChanges();

                if (confirm == DialogResult.Cancel)
                    return;
                else
                    unsavedChanges = false;
            }

            // Reset the loaded file
            animationFile = new AnimationFile();

            ResetSheetControls();
            ResetAnimControls();
            UpdateSheetList();
            UpdateAnimList();

            // Set the window title
            Text = "CCAnimationEditor";
            Refresh();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ask the user what file they want to open
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON File|*.json",
                InitialDirectory = Settings.CCInstallDir + @"assets\data\animations\",
                Title = "Open file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (unsavedChanges)
                {
                    DialogResult confirm = ConfirmUnsavedChanges();

                    if (confirm == DialogResult.Cancel)
                        return;
                }

                // Set the animation file path var
                animationFilePath = openFileDialog.FileName;

                // Load that file
                animationFile = new AnimationFile();

                if (animationFile.LoadFile(animationFilePath) == true)
                {
                    if (sheetCmb.Items.Count == 0)
                        GenerateSheetControls();

                    if (animCmb.Items.Count == 0)
                        GenerateAnimControls();

                    // Update the arrays
                    UpdateSheetList();
                    UpdateAnimList();

                    // Display the first animation and sheet
                    sheetCmb.SelectedIndex = 0;
                    animCmb.SelectedIndex = 0;

                    // Reset the animation player
                    animFrameIndex = 0;
                    frameTxt.Text = "0";
                    animDir = 0;
                    dirTxt.Text = "0";
                    PauseAnim();

                    // Update the recent files array
                    Settings.RecentFiles.Add(Path.GetFileName(openFileDialog.FileName));
                    Settings.SaveSettings();

                    // Create backup if enabled
                    if (Settings.CreateAnimBackup)
                        animationFile.CreateBackup();

                    unsavedChanges = false;

                    // Set the window title
                    Text = "CCAnimationEditor - " + Path.GetFileName(openFileDialog.FileName);
                    Refresh();
                }

                // If we open a file type that is not supported
                else
                {
                    SystemSounds.Exclamation.Play();
                    MetroMessageBox.Show(this, "File type not supported", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (animationFilePath != null)
                SaveFile(animationFilePath);

            else
            {
                SaveFileAs();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void SaveFile(string animationFilePath)
        {
            animationFile.SaveFile(animationFilePath);

            if (unsavedChanges)
            {
                unsavedChanges = false;

                Text.Substring(Text.Length - 1);
            }
        }

        private void SaveFileAs()
        {
            SaveFileDialog saveAsDialog = new SaveFileDialog
            {
                Filter = "JSON File|*.json",
                InitialDirectory = Settings.CCInstallDir + @"assets\data\animations\",
                Title = "Save as"
            };

            if (saveAsDialog.ShowDialog() == DialogResult.OK)
            {
                // Update file path
                animationFile.FilePath = saveAsDialog.FileName;

                // Update the window title
                Text = "CCAnimationEditor - " + Path.GetFileName(saveAsDialog.FileName);
                Refresh();

                animationFilePath = animationFile.FilePath;

                // Save the file
                animationFile.SaveFile(animationFile.FilePath);

                unsavedChanges = false;
            }
        }

        // Unsaved changes functions
        private void SetUnsavedChanges()
        {
            if (unsavedChanges == false)
            {
                unsavedChanges = true;

                // Add an asterisk to the end of the file name
                Text += "*";
                Refresh();
            }
        }

        private DialogResult ConfirmUnsavedChanges()
        {
            DialogResult confirmDlg = MetroMessageBox.Show(this, "There are unsaved changes, would you like to save them?", "Warning", MessageBoxButtons.YesNoCancel);

            if (confirmDlg == DialogResult.Yes)
            {
                SaveFile(animationFilePath);
                return DialogResult.Yes;
            }

            else if (confirmDlg == DialogResult.No)
                return DialogResult.No;

            else if (confirmDlg == DialogResult.Cancel)
                return DialogResult.Cancel;

            return DialogResult.Cancel; // Dummy code
        }

        // Menu bar - Help items
        private void DocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }

        // List updating
        private void SheetCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySheet();
            UpdateSheetControlValues();
        }

        private void AnimCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editingArray)
            {
                editingArray = false;
                ResetAnimControls();
                GenerateAnimControls();
                animBackBtn.Visible = false;
                animClearBtn.Visible = false;
            }

            animFrameIndex = 0;
            DisplayAnim();
            UpdateAnimControlValues();
        }

        private void AnimSheetCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (animationFile.Animations.Count < 1) return;

            // Get the selected sheet from the combo box
            MetroComboBox animSheetCmb = (MetroComboBox)animPropInputs[1];
            animationFile.Animations[animCmb.SelectedIndex].Sheet = animSheetCmb.SelectedItem.ToString();

            SetUnsavedChanges();
            DisplayAnim();
        }

        private void AnimShapeTypeCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (animationFile.Animations.Count < 1) return;

            MetroComboBox animShapeTypeCmb = (MetroComboBox)animPropInputs[2];
            animationFile.Animations[animCmb.SelectedIndex].ShapeType = animShapeTypeCmb.SelectedItem.ToString();

            SetUnsavedChanges();
            DisplayAnim();
        }

        private void AnimDirsCmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (animationFile.Animations.Count < 1) return;

            MetroComboBox animDirsCmb = (MetroComboBox)animPropInputs[3];
            animationFile.Animations[animCmb.SelectedIndex].Dirs = int.Parse(animDirsCmb.SelectedItem.ToString());

            // Update the array sizes
            foreach (var prop in animationFile.Animations[animCmb.SelectedIndex].GetType().GetProperties())
            {
                if (prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]) is int[] array)
                {
                    if (prop.Name != "Frames" && prop.Name != "AlphaFrames")
                    {
                        Array.Resize(ref array, animationFile.Animations[animCmb.SelectedIndex].Dirs);
                        prop.SetValue(animationFile.Animations[animCmb.SelectedIndex], array);
                    }
                }
            }

            SetUnsavedChanges();
            DisplayAnim();
        }

        // Real-time updating - Sheets
        private void SheetTextBox_KeyUp(object sender, EventArgs e)
        {
            UpdateSheetValues();
        }

        private void UpdateSheetValues()
        {
            // Make sure the sheet is not null
            if (animationFile.Sheets.Count == 0 || sheetCmb.SelectedIndex < 0) return;

            // Update the class values
            Sheet sheet = animationFile.Sheets[sheetCmb.SelectedIndex];
            int pos = 0;
            foreach (var prop in sheet.GetType().GetProperties())
            {
                if (prop.GetValue(sheet) != null)
                {
                    // Strings
                    if (prop.GetValue(sheet) is string)
                        prop.SetValue(sheet, sheetPropInputs[pos++].Text);

                    // Ints
                    else if (prop.GetValue(sheet) is int)
                    {
                        int.TryParse(sheetPropInputs[pos++].Text, out int outInt);
                        prop.SetValue(sheet, outInt);
                    }
                }
            }

            // Update the property values
            int index = sheetCmb.SelectedIndex;
            UpdateSheetControlValues();
            UpdateSheetList();
            sheetCmb.SelectedIndex = index;
            DisplaySheet();

            SetUnsavedChanges();
        }

        // Real-time updating - Animations 
        private void AnimTextBox_KeyUp(object sender, EventArgs e)
        {
            UpdateAnimValues();
        }

        private void AnimCheckBox_Click(object sender, EventArgs e)
        {
            UpdateAnimValues();
        }

        private void UpdateAnimValues()
        {
            // Make sure the selected anim is not null
            if (animationFile.Animations.Count == 0 || animCmb.SelectedIndex < 0) return;

            PauseAnim();

            // Update the class values
            Animation anim = animationFile.Animations[animCmb.SelectedIndex];
            int pos = 0;

            foreach (var prop in anim.GetType().GetProperties())
            {
                if (prop.GetValue(anim, null) != null)
                {
                    Console.WriteLine(prop.Name);

                    // Strings
                    if (prop.GetValue(anim) is string)
                    {
                        Console.WriteLine("String " + pos);
                        prop.SetValue(anim, animPropInputs[pos].Text);
                    }

                    // Boolean (CheckBox)
                    else if (prop.GetValue(anim) is bool)
                    {
                        Console.WriteLine("Bool " + pos);
                        MetroCheckBox checkBox = (MetroCheckBox)animPropInputs[pos];

                        prop.SetValue(anim, checkBox.Checked);
                    }

                    // Ints
                    else if (prop.GetValue(anim) is int)
                    {
                        Console.WriteLine("Int " + pos);

                        int.TryParse(animPropInputs[pos].Text, out int outInt);
                        prop.SetValue(anim, outInt);
                    }

                    // Int arrays
                    else if (prop.GetValue(anim) is int[] intArray)
                    {
                        Console.WriteLine("Int Array " + pos);
                    }

                    // 2D int arrays
                    else if (prop.GetValue(anim) is int[][] intArray2)
                    {

                        Console.WriteLine("Int Array 2D " + pos);
                    }

                    // Floats
                    else if (prop.GetValue(anim) is float)
                    {
                        Console.WriteLine("Float " + pos);

                        float.TryParse(animPropInputs[pos].Text, out float outFloat);
                        prop.SetValue(anim, outFloat);
                    }
                }

                pos++;
            }

            // Update the property values
            int index = animCmb.SelectedIndex;
            UpdateAnimControlValues();
            UpdateAnimList();
            animCmb.SelectedIndex = index;
            DisplayAnim();

            SetUnsavedChanges();
        }

        private void AnimArrayTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            UpdateAnimArrayValues();
        }


        private void UpdateAnimArrayValues()
        {
            if (animationFile.Animations.Count == 0 || animCmb.SelectedIndex < 0) return;

            PauseAnim();

            // Update the class values
            Animation anim = animationFile.Animations[animCmb.SelectedIndex];
            int pos = 0;

            // Find the array in the object
            foreach (var prop in anim.GetType().GetProperties())
            {
                // 1D arrays
                if (prop.Name == arrayName && prop.GetValue(anim) is int[] array)
                {
                    // Size
                    int.TryParse(animPropInputs[pos++].Text, out int outLengthInt);

                    if (outLengthInt != array.Length)
                    {
                        // Resize the array
                        Array.Resize(ref array, outLengthInt);

                        // Get the array name
                        string arrayName = animPropLabels[0].Text;

                        // Set the array
                        prop.SetValue(anim, array);

                        // Regenerate the controls
                        ResetAnimControls();
                        GenerateAnimArrayControls(array, arrayName);
                    }

                    else
                    {
                        // Items
                        for (int i = 0; i < array.Length; i++)
                        {
                            int.TryParse(animPropInputs[pos++].Text, out int outInt);
                            array[i] = outInt;
                        }

                        prop.SetValue(anim, array);
                    }

                    break;
                }

                // 2D arrays
                else if (prop.Name == arrayName && prop.GetValue(anim) is int[][] array2)
                {
                    // Skip level 1 size (same as angle)
                    pos++;

                    // Go through each item
                    for (int i = 0; i < array2.Length; i++)
                    {

                        int.TryParse(animPropInputs[pos++].Text, out int outLengthInt);

                        if (outLengthInt != array2[i].Length)
                        {
                            // Resize the level 2 array
                            Array.Resize(ref array2[i], outLengthInt);

                            // Get the array name
                            string arrayName = animPropLabels[0].Text;

                            // Set the array
                            prop.SetValue(anim, array2);

                            // Regenerate the controls
                            ResetAnimControls();
                            GenerateAnim2dArrayControls(array2, arrayName);

                            break;
                        }

                        else
                        {
                            // Get the values
                            for (int i2 = 0; i2 < array2[i].Length; i2++)
                            {
                                int.TryParse(animPropInputs[pos++].Text, out int outInt);
                                array2[i][i2] = outInt;
                            }
                        }
                    }

                    prop.SetValue(anim, array2);
                }
            }

            SetUnsavedChanges();
        }

        // Add and remove buttons - Sheets
        // TODO: Add the ability to-rearrange items on the list

        private void AddSheetBtn_Click(object sender, EventArgs e)
        {
            // Add a new sheet
            animationFile.Sheets.Add(new Sheet());

            if (sheetCmb.Items.Count == 0)
                GenerateSheetControls();


            // Switch to the new sheet
            UpdateSheetList();
            sheetCmb.SelectedIndex = sheetCmb.Items.Count - 1;

            if (animationFile.Animations.Count > 0)
                UpdateAnimControlValues();
        }

        private void RemoveSheetBtn_Click(object sender, EventArgs e)
        {
            // Make sure that the list is populated
            if (animationFile == null || animationFile.Sheets.Count == 0) return;

            // Confirm before deleting the sheet
            if (MetroMessageBox.Show(this, "This will delete the sheet, confirm?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int oldSheetIndex = sheetCmb.SelectedIndex;

                // Remove the sheet from the array
                animationFile.Sheets.Remove(animationFile.Sheets[oldSheetIndex]);

                // Display the next available sheet
                UpdateSheetList();

                if (oldSheetIndex >= sheetCmb.Items.Count)
                    sheetCmb.SelectedIndex = sheetCmb.Items.Count - 1;
                else
                    sheetCmb.SelectedIndex = oldSheetIndex;
            }
        }

        private void CopySheetBtn_Click(object sender, EventArgs e)
        {
            // Make sure that there is at least one sheet
            if (animationFile == null || animationFile.Sheets.Count < 2) return;

            // Copy the current sheet
            animationFile.Sheets.Add(animationFile.Sheets[sheetCmb.SelectedIndex]);

            // Select the copied sheet
            UpdateSheetList();
            sheetCmb.SelectedIndex = sheetCmb.Items.Count - 1;
        }

        // Add and remove buttons - Animations
        private void AddAnimBtn_Click(object sender, EventArgs e)
        {
            // Check if there are any sheets defined
            if (animationFile.Sheets != null && animationFile.Sheets.Count != 0)
            {
                if (animCmb.Items.Count == 0)
                    GenerateAnimControls();

                animationFile.Animations.Add(new Animation { Dirs = 1, Time = 1 });
                animationFile.Animations[animationFile.Animations.Count - 1].Sheet = animationFile.Sheets[animationFile.Sheets.Count - 1].Name;

                UpdateAnimList();
                animCmb.SelectedIndex = animCmb.Items.Count - 1;

            }

            else
                MetroMessageBox.Show(this, "No sheets are currently defined", "Error", MessageBoxButtons.OK);
        }

        private void RemoveAnimBtn_Click(object sender, EventArgs e)
        {
            if (animationFile == null || animationFile.Animations.Count == 0) return;

            // Confirm before deleting the anim
            if (MetroMessageBox.Show(this, "This will delete the animation, confirm?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int oldAnimIndex = animCmb.SelectedIndex;

                // Remove the sheet from the array
                animationFile.Animations.Remove(animationFile.Animations[oldAnimIndex]);

                // Display the next available sheet
                UpdateAnimList();

                if (oldAnimIndex >= animCmb.Items.Count)
                    animCmb.SelectedIndex = animCmb.Items.Count - 1;
                else
                    animCmb.SelectedIndex = oldAnimIndex;
            }
        }

        private void CopyAnimBtn_Click(object sender, EventArgs e)
        {
            // Make sure that there is at least one anim
            if (animationFile == null || animationFile.Animations.Count < 2) return;

            // Copy the current anim
            animationFile.Animations.Add(animationFile.Animations[animCmb.SelectedIndex]);

            // Select the copied anim
            UpdateAnimList();
            animCmb.SelectedIndex = animCmb.Items.Count - 1;
        }

        // List update functions
        private void UpdateSheetList()
        {
            // Clear the combo box
            sheetCmb.Items.Clear();

            // Clear the image panel
            sheetImgPnl.BackgroundImage = null;

            // Add each sheet in the array
            foreach (Sheet sheet in animationFile.Sheets)
            {
                sheetCmb.Items.Add(sheet.Name);
            }
        }

        private void UpdateAnimList()
        {
            // Clear the combo box
            animCmb.Items.Clear();

            // Clear the image panel
            animImgPnl.BackgroundImage = null;

            // Add each animation in the array
            foreach (Animation anim in animationFile.Animations)
                animCmb.Items.Add(anim.Name);
        }

        // Display functions
        private void DisplaySheet()
        {
            // Get the current sheet
            Sheet sheet = animationFile.Sheets[sheetCmb.SelectedIndex];

            // Get the sheet relative to the game's install dir
            string sheetPath = GetSheetPath(sheet);

            // Check if the file exists
            if (File.Exists(sheetPath))
            {
                Image sheetImg = Image.FromFile(sheetPath);

                // Crop the image to the specified portion
                Bitmap sheetImgBmp = new Bitmap(sheetImg);
                try
                {
                    Bitmap sheetImgBmpCropped = sheetImgBmp.Clone(
                        new Rectangle(
                            sheet.OffX,
                            sheet.OffY,
                            sheet.XCount > 0 ? sheet.Width * sheet.XCount : sheetImg.Width - sheet.OffX,
                            sheetImg.Height - sheet.OffY),
                        sheetImgBmp.PixelFormat
                        );

                    // Apply the image to the panel
                    sheetImgPnl.BackgroundImage = sheetImgBmpCropped;
                    sheetImg.Dispose();
                }

                // Reset the panel and play an error if the user enters something invalid
                catch
                {
                    SystemSounds.Beep.Play();
                    sheetImgPnl.BackgroundImage = sheetImg;
                }

                // Dispose the bmp to avoid a memory leak
                sheetImgBmp.Dispose();
            }

            // Put a placeholder image if the sheet does not exist
            else
                sheetImgPnl.BackgroundImage = Properties.Resources.SrcNotFound;

            // TODO: Have it draw a grid showing the sprites
        }


        private void DrawSheetGrid()
        {
            // NOTE: This is unfinished
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            Rectangle rect1 = new Rectangle(10, 10, 100, 50);
            Rectangle rect2 = new Rectangle(10, 60, 100, 50);
            Rectangle[] rects = new Rectangle[] { rect1, rect2 };
            g.DrawRectangles(p, rects);
        }

        private void UpdateSheetControlValues()
        {
            // Go through each control and update the value
            int pos = 0;
            foreach (var prop in animationFile.Sheets[sheetCmb.SelectedIndex].GetType().GetProperties())
            {
                sheetPropInputs[pos].Text = prop.GetValue(animationFile.Sheets[sheetCmb.SelectedIndex]).ToString();
                pos++;
            }
        }

        // NOTE: I imagine this is where a lot of the bugs are going to end up
        private void DisplayAnim()
        {
            // Get the current anim
            Animation anim = animationFile.Animations[animCmb.SelectedIndex];
            Sheet animSheet = animationFile.FindSheet(anim.Sheet);

            // Get the sheet relative to the game's install dir
            string sheetPath = GetSheetPath(animSheet);

            // Check if the file exists
            if (File.Exists(sheetPath))
            {
                Image sheetImg = Image.FromFile(sheetPath);
                Bitmap animImgBmp = new Bitmap(sheetImg);

                // Calculate the sheet dimensions
                int animSheetWidth = animSheet.XCount > 0 ? animSheet.Width * animSheet.XCount : sheetImg.Width - animSheet.OffX;
                int animSheetHeight = sheetImg.Height - animSheet.OffY;

                // Calculate the frame offsets
                int xFrames = animSheet.XCount > 0 ? animSheet.XCount : animSheetWidth / animSheet.Width;
                int yFrames = animSheetHeight / animSheet.Height; // This is only used for debugging

                Console.WriteLine("{0} / {1}", animSheetHeight, animSheet.Height);

                int frameColOffset = 0;
                int frameRowOffset = 0;

                // Frames takes priority over DirFrames
                int frame = (anim.Frames != null) ? anim.Frames[animFrameIndex] :
                    (anim.DirFrames != null) ? anim.DirFrames[animDir][animFrameIndex] : 0;

                // Determine where the frame is on the sheet
                // Cycle through each frame on the sheet
                for (int f = 0; f < frame; f++)
                {
                    frameColOffset++;
                    Console.WriteLine("{0}, {1}", frame, xFrames);
                    Console.WriteLine("frameColOffset++");

                    // Go to the next row on the sheet once we hit the end
                    if (frameColOffset >= xFrames)
                    {
                        frameColOffset = 0;
                        frameRowOffset++;
                        Console.WriteLine("frameRowOffset++");
                    }

                }

                if (anim.Frames != null)
                {
                    // Apply the dir
                    frameRowOffset += animDir;
                }

                // Crop the image to the specified portion
                try
                {
                    if (anim.FlipX != null && anim.Frames != null)
                    {
                        // HACK: This is an assumption (When do the frames go back up?)
                        if (anim.Dirs == 16)
                        {
                            if (anim.FlipX[animDir] == 1 && animDir >= 9)
                                frameRowOffset -= animDir - 8;
                        }

                        else if (anim.Dirs == 8)
                        {
                            if (anim.FlipX[animDir] == 1 && animDir >= 5)
                                frameRowOffset -= animDir - 4;
                        }

                        else if (anim.Dirs == 6)
                        {
                            if (anim.FlipX[animDir] == 1 && animDir >= 4)
                                frameRowOffset -= animDir - 3;
                        }

                        else if (anim.Dirs == 4)
                        {
                            if (anim.FlipX[animDir] == 1 && animDir >= 3)
                                frameRowOffset -= animDir - 2;
                        }

                        else if (anim.Dirs == 2)
                        {
                            if (anim.FlipX[animDir] == 1 && animDir == 1)
                                frameRowOffset--;
                        }
                    }

                    Console.WriteLine("C {0}/{1}, R {2}/{3}", frameColOffset, xFrames, frameRowOffset, yFrames);

                    Bitmap animImgBmpCropped = animImgBmp.Clone(
                        new Rectangle(
                            animSheet.OffX + (animSheet.Width * frameColOffset),
                            animSheet.OffY + (animSheet.Height * frameRowOffset),
                            animSheet.Width,
                            animSheet.Height),
                        animImgBmp.PixelFormat
                        );

                    // Rotate if specified
                    if (anim.FlipX != null)
                    {
                        if (anim.FlipX[animDir] == 1)
                            animImgBmpCropped.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    }

                    // Apply the image to the panel
                    animImgPnl.BackgroundImage = animImgBmpCropped;
                    animImgBmp.Dispose();
                    sheetImg.Dispose();
                }

                // Reset the panel and play an error if the user enters something invalid
                catch (Exception e)
                {
                    Program.WriteExecptionOutputToConsole(e);

                    SystemSounds.Beep.Play();
                    animImgPnl.BackgroundImage = sheetImg;
                }

                // Dispose the bmp to avoid a memory leak
                animImgBmp.Dispose();
            }

            // Put a placeholder image if it does not exist
            else
                animImgPnl.BackgroundImage = Properties.Resources.SrcNotFound;
        }

        private void UpdateAnimControlValues()
        {
            int pos = 0;
            foreach (var prop in animationFile.Animations[animCmb.SelectedIndex].GetType().GetProperties())
            {

                // Arrays
                if (prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]) is int[] array)
                {
                    pos++;
                }

                // 2D Arrays
                else if (prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]) is int[][] array2)
                {
                    pos++;
                }

                // Booleans
                else if (prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]) is bool boolean)
                {
                    MetroCheckBox chkBox = (MetroCheckBox)animPropInputs[pos++];
                    chkBox.Checked = boolean;
                }

                else if (prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]) is null)
                {
                    pos++;
                }

                // Strings
                else
                {
                    if (prop.Name == "Sheet")
                    {
                        MetroComboBox comboBox = (MetroComboBox)animPropInputs[pos++];
                        comboBox.SelectionChangeCommitted += AnimSheetCmb_SelectionChangeCommitted;

                        comboBox.Items.Clear();

                        int index = 0;
                        foreach (Sheet sheet in animationFile.Sheets)
                        {
                            comboBox.Items.Add(sheet.Name);
                            if (sheet.Name == prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]).ToString())
                                comboBox.SelectedIndex = index;

                            index++;
                        }
                    }

                    else if (prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]) != null)
                        animPropInputs[pos++].Text = prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]).ToString();

                }

            }

            // Set anim speed
            animTimer.Interval = GetAnimTimerInterval();
        }

        private void UpdateAnimArrayControlValues()
        {
            Animation anim = animationFile.Animations[animCmb.SelectedIndex];
            int pos = 0;

            // Find the array
            foreach (var prop in anim.GetType().GetProperties())
            {
                // Once found, update the values

                // 1D Array
                if (prop.Name == arrayName && prop.GetValue(anim) is int[] array)
                {
                    // Size
                    animPropInputs[pos++].Text = array.Length.ToString();

                    // Values
                    foreach (int item in array)
                        animPropInputs[pos++].Text = item.ToString();

                    break;
                }

                // 2D Array
                else if (prop.Name == arrayName && prop.GetValue(anim) is int[][] array2)
                {
                    // Size
                    animPropInputs[pos++].Text = array2.Length.ToString();

                    foreach (int[] item in array2)
                    {
                        // Level 2 sizes
                        animPropInputs[pos++].Text = item.Length.ToString();

                        foreach (int item2 in item)
                        {
                            animPropInputs[pos++].Text = item2.ToString();
                        }
                    }

                    break;
                }
            }
        }

        private void AnimArrayEditBtn_Click(object sender, EventArgs e)
        {
            editingArray = true;
            if (animationFile.Animations.Count != 0)
            {
                // Determine what array the user selected
                MetroButton button = (MetroButton)sender;

                // Match the button to the control label
                int[] array = null;
                int propIndex = 0;

                while (propIndex < animPropInputs.Count)
                {
                    if (animPropInputs[propIndex] == button)
                    {
                        break;
                    }

                    propIndex++;
                }

                // Match the control label to a property in the animation class
                foreach (var prop in animationFile.Animations[animCmb.SelectedIndex].GetType().GetProperties())
                {
                    if (animPropLabels[propIndex].Text == prop.Name)
                    {
                        array = (int[])prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]);
                    }
                }

                arrayName = animPropLabels[propIndex].Text;

                if (array != null)
                {
                    SwitchToArrayEditor(array, propIndex);
                }

                // Generate the array if it is null
                else
                {
                    array = new int[1] { 0 };

                    // Implement array-specific sizing

                    // Based on angles
                    if (arrayName != "Frames" && arrayName != "AlphaFrames")
                    {
                        Array.Resize(ref array, animationFile.Animations[animCmb.SelectedIndex].Dirs);
                    }

                    // Based on frames
                    else if (arrayName == "AlphaFrames" && animationFile.Animations[animCmb.SelectedIndex].Frames != null)
                    {
                        Array.Resize(ref array, animationFile.Animations[animCmb.SelectedIndex].Frames.Length);
                    }

                    animationFile.Animations[animCmb.SelectedIndex].GetType().GetProperty(arrayName).SetValue(animationFile.Animations[animCmb.SelectedIndex], array);

                    // Switch to the array editor
                    SwitchToArrayEditor(array, propIndex);
                }
            }
        }

        private void Anim2dArrayEditBtn_Click(object sender, EventArgs e)
        {
            editingArray = true;
            if (animationFile.Animations.Count != 0)
            {
                // Determine what array the user selected
                MetroButton button = (MetroButton)sender;

                // Match the button to the control label
                int[][] array = null;
                int propIndex = 0;

                while (propIndex < animPropInputs.Count)
                {
                    if (animPropInputs[propIndex] == button)
                    {
                        break;
                    }

                    propIndex++;
                }

                // Match the control label to a property in the animation class
                foreach (var prop in animationFile.Animations[animCmb.SelectedIndex].GetType().GetProperties())
                {
                    if (animPropLabels[propIndex].Text == prop.Name)
                    {
                        array = (int[][])prop.GetValue(animationFile.Animations[animCmb.SelectedIndex]);
                    }
                }

                arrayName = animPropLabels[propIndex].Text;

                if (array != null)
                {
                    SwitchToArrayEditor(array, propIndex);
                }

                // Generate the array if it is null
                else
                {
                    // The only 2D array in the structure is dirFrames

                    array = new int[animationFile.Animations[animCmb.SelectedIndex].Dirs][];

                    for (int index = 0; index < animationFile.Animations[animCmb.SelectedIndex].Dirs; index++)
                    {
                        array[index] = new int[1] { 0 };
                    }

                    animationFile.Animations[animCmb.SelectedIndex].GetType().GetProperty(arrayName).SetValue(animationFile.Animations[animCmb.SelectedIndex], array);

                    // Switch to the array editor
                    SwitchToArrayEditor(array, propIndex);

                    SetUnsavedChanges();
                }
            }
        }

        private void AnimBackBtn_Click(object sender, EventArgs e)
        {
            SwitchToAnimEditor();
        }

        private void AnimClearBtn_Click(object sender, EventArgs e)
        {
            // Show a confirmation message
            if (MetroMessageBox.Show(this, "This will delete the array, confirm?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Find the array
                var arrayProp = animationFile.Animations[animCmb.SelectedIndex].GetType().GetProperty(animPropLabels[0].Text);

                // Set the array to null
                arrayProp.SetValue(animationFile.Animations[animCmb.SelectedIndex], null);

                // Switch back
                SwitchToAnimEditor();

                SetUnsavedChanges();
            }
        }

        // Functions for switching between the array editor and animation editor on the animations panel
        private void SwitchToAnimEditor()
        {
            // Go back to the animation editor
            editingArray = false;
            ResetAnimControls();
            GenerateAnimControls();
            UpdateAnimControlValues();
            animBackBtn.Visible = false;
            animClearBtn.Visible = false;
            DisplayAnim();
        }

        private void SwitchToArrayEditor(int[] array, int propIndex)
        {
            arrayName = animPropLabels[propIndex].Text;
            ResetAnimControls();
            GenerateAnimArrayControls(array, arrayName);
            animBackBtn.Visible = true;
            animClearBtn.Visible = true;
        }

        private void SwitchToArrayEditor(int[][] array, int propIndex)
        {
            arrayName = animPropLabels[propIndex].Text;
            ResetAnimControls();
            GenerateAnim2dArrayControls(array, arrayName);
            animBackBtn.Visible = true;
            animClearBtn.Visible = true;
        }

        private void PlayAnim()
        {
            playAnim = true;

            if (animationFile != null && animationFile.Animations != null)
                animTimer.Start();
        }

        private void PauseAnim()
        {
            playAnim = false;
            playPauseBtn.Text = "Play";
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            if (animationFile.Animations.Count != 0 && animCmb.SelectedIndex >= 1)
            {
                // Increment the frame
                // Reset once at max
                if (animationFile.Animations[animCmb.SelectedIndex].Frames != null)
                {
                    if (animFrameIndex + 1 < animationFile.Animations[animCmb.SelectedIndex].Frames.Length)
                        animFrameIndex++;
                    else
                        animFrameIndex = 0;
                }

                else if (animationFile.Animations[animCmb.SelectedIndex].DirFrames != null)
                {
                    if (animFrameIndex + 1 < animationFile.Animations[animCmb.SelectedIndex].DirFrames[animDir].Length)
                        animFrameIndex++;
                    else
                        animFrameIndex = 0;
                }

                else
                    return;


                // Set the frame text
                frameTxt.Text = animFrameIndex.ToString();
                DisplayAnim();

                if (!playAnim)
                    animTimer.Stop();
            }

        }

        private void ToggleBgBtn_Click(object sender, EventArgs e)
        {
            if (animImgPnl.BackColor != Color.Black)
                animImgPnl.BackColor = Color.Black;
            else
                animImgPnl.BackColor = Color.White;

            if (sheetImgPnl.BackColor != Color.Black)
                sheetImgPnl.BackColor = Color.Black;
            else
                sheetImgPnl.BackColor = Color.White;
        }

        private void AnimSpeedTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (animSpeedTxt.Text != "")
            {
                try
                {
                    double.TryParse(animSpeedTxt.Text, out double speedDouble);
                    animTimer.Interval = GetAnimTimerInterval();
                }

                catch
                {
                    SystemSounds.Beep.Play();
                }
            }
        }

        private string GetSheetPath(Sheet sheet)
        {
            // Get the sheet relative to the game's install dir
            string sheetPath = Settings.CCInstallDir + @"\assets\" + sheet.Src;
            sheetPath = sheetPath.Replace("/", "\\");
            return sheetPath;
        }

        // Control generators
        private void GenerateSheetControls()
        {
            Sheet sheet = new Sheet();

            int pos = 0;

            foreach (var prop in sheet.GetType().GetProperties())
            {

                // Label
                MetroLabel label = new MetroLabel
                {
                    Text = prop.Name,
                    Location = new Point(sheetPropLbl.Location.X, sheetPropLbl.Location.Y + (ControlSpacing * pos)),
                    Theme = MetroThemeStyle.Dark,
                    AutoSize = true
                };

                sheetPropLabels.Add(label);
                sheetsTab.Controls.Add(sheetPropLabels[pos]);

                // TextBox
                MetroTextBox textBox = new MetroTextBox
                {
                    Location = new Point(sheetPropTxt.Location.X, sheetPropTxt.Location.Y + (ControlSpacing * pos)),
                    Theme = MetroThemeStyle.Dark,
                    Size = sheetPropTxt.Size,
                };

                textBox.KeyUp += SheetTextBox_KeyUp;

                sheetPropInputs.Add(textBox);
                sheetsTab.Controls.Add(sheetPropInputs[pos]);

                pos++;
            }
        }

        private void ResetSheetControls()
        {
            if (sheetPropInputs.Count > 0)
            {
                // Remove the controls from the window
                foreach (MetroLabel label in sheetPropLabels)
                    sheetsTab.Controls.Remove(label);

                foreach (Control control in sheetPropInputs)
                    sheetsTab.Controls.Remove(control);

                // Remove the controls from the array
                sheetPropLabels.Clear();
                sheetPropInputs.Clear();
            }
        }

        private void GenerateAnimControls()
        {
            int row = 0;
            int pos = 0;

            // Assign arbitrary values generation purposes
            Animation anim = new Animation
            {
                FlipX = new int[1],
                TileOffsets = new int[1],
                AnchorOffsetX = new int[1],
                AnchorOffsetY = new int[1],
                AnchorOffsetZ = new int[1],
                AlphaFrames = new int[1],
                Repeat = false,
                Frames = new int[1],
                DirFrames = new int[2][]
            };
            anim.DirFrames[0] = new int[1];

            foreach (var prop in anim.GetType().GetProperties())
            {
                // Label
                MetroLabel label = new MetroLabel
                {
                    Text = prop.Name,
                    Location = new Point(animPropLbl.Location.X, animPropLbl.Location.Y + (ControlSpacing * row)),
                    Theme = MetroThemeStyle.Dark,
                    AutoSize = true
                };

                animPropLabels.Add(label);
                animPropsPnl.Controls.Add(animPropLabels[pos]);

                // Arrays
                if (prop.GetValue(anim) is int[] array)
                {
                    MetroButton editBtn = new MetroButton
                    {
                        Location = new Point(animPropTxt.Location.X, animPropTxt.Location.Y + (ControlSpacing * row)),
                        Size = animPropEditBtn.Size,
                        Theme = MetroThemeStyle.Dark,
                        Text = "Edit",
                    };

                    editBtn.Click += AnimArrayEditBtn_Click;

                    animPropInputs.Add(editBtn);
                    animPropsPnl.Controls.Add(animPropInputs[pos]);

                }

                // 2D Arrays
                else if (prop.GetValue(anim) is int[][] array2)
                {
                    MetroButton editBtn = new MetroButton
                    {
                        Location = new Point(animPropTxt.Location.X, animPropTxt.Location.Y + (ControlSpacing * row)),
                        Size = animPropEditBtn.Size,
                        Theme = MetroThemeStyle.Dark,
                        Text = "Edit"
                    };

                    editBtn.Click += Anim2dArrayEditBtn_Click;

                    animPropInputs.Add(editBtn);
                    animPropsPnl.Controls.Add(animPropInputs[pos]);

                }

                // Booleans
                else if (prop.GetValue(anim) is bool boolean)
                {
                    MetroCheckBox checkBox = new MetroCheckBox
                    {
                        Location = new Point(animPropTxt.Location.X, animPropTxt.Location.Y + (ControlSpacing * row)),
                        Theme = MetroThemeStyle.Dark,
                        Size = animPropTxt.Size,
                        Checked = boolean,
                    };

                    checkBox.Click += AnimCheckBox_Click;

                    animPropInputs.Add(checkBox);
                    animPropsPnl.Controls.Add(animPropInputs[pos]);
                }

                // Strings/Ints
                else
                {
                    // Input
                    if (prop.Name == "Sheet" || prop.Name == "Dirs" || prop.Name == "ShapeType")
                    {
                        MetroComboBox comboBox = new MetroComboBox
                        {
                            Location = new Point(animPropTxt.Location.X, animPropTxt.Location.Y + (ControlSpacing * row)),
                            Theme = MetroThemeStyle.Dark,
                            Size = animPropTxt.Size,
                        };

                        if (prop.Name == "Sheet")
                            comboBox.SelectionChangeCommitted += AnimSheetCmb_SelectionChangeCommitted;

                        else if (prop.Name == "Dirs")
                        {
                            // Add directories
                            comboBox.Items.Add("1");
                            comboBox.Items.Add("2");
                            comboBox.Items.Add("4");
                            comboBox.Items.Add("6");
                            comboBox.Items.Add("8");
                            comboBox.Items.Add("16");

                            comboBox.SelectionChangeCommitted += AnimDirsCmb_SelectionChangeCommitted;
                        }

                        else if (prop.Name == "ShapeType")
                        {
                            comboBox.Items.Add("NO_EXPAND");
                            comboBox.Items.Add("Y_EXPAND");
                            comboBox.Items.Add("Z_EXPAND");
                            comboBox.Items.Add("YZ_EXPAND");
                            comboBox.Items.Add("Y_FLAT");
                            comboBox.Items.Add("Z_FLAT");

                            comboBox.SelectionChangeCommitted += AnimShapeTypeCmb_SelectionChangeCommitted;
                        }

                        animPropInputs.Add(comboBox);
                    }

                    else
                    {
                        MetroTextBox textBox = new MetroTextBox
                        {
                            Location = new Point(animPropTxt.Location.X, animPropTxt.Location.Y + (ControlSpacing * row)),
                            Theme = MetroThemeStyle.Dark,
                            Size = animPropTxt.Size,
                        };

                        textBox.KeyUp += AnimTextBox_KeyUp;

                        animPropInputs.Add(textBox);
                    }

                    animPropsPnl.Controls.Add(animPropInputs[pos]);
                }

                row++;
                pos++;
            }
        }

        private void GenerateAnimArrayControls(int[] array, string arrayName)
        {
            int pos = 0;
            int row = 0;

            // Label
            MetroLabel label = new MetroLabel
            {
                Text = arrayName,
                Location = new Point(animPropLbl.Location.X, animPropLbl.Location.Y + (ControlSpacing * row)),
                Theme = MetroThemeStyle.Dark,
                AutoSize = true
            };

            animPropLabels.Add(label);
            animPropsPnl.Controls.Add(animPropLabels[pos]);

            // TextBox (Size)
            MetroTextBox sizeTextBox = new MetroTextBox
            {
                Location = new Point(animPropTxt.Location.X, animPropTxt.Location.Y + (ControlSpacing * row)),
                Theme = MetroThemeStyle.Dark,
                Size = animPropTxt.Size,
            };

            if (arrayName != "Frames")
                sizeTextBox.Enabled = false;

            sizeTextBox.KeyUp += AnimArrayTextBox_KeyUp;

            animPropInputs.Add(sizeTextBox);
            animPropsPnl.Controls.Add(animPropInputs[pos++]);

            int arrayPos = 0;
            foreach (int item in array)
            {
                row++;

                // Label (Array Position)
                MetroLabel arrayPosLabel = new MetroLabel
                {
                    Text = string.Format("[{0}]", arrayPos.ToString()),
                    Location = new Point(animPropLbl.Location.X + 10, animPropLbl.Location.Y + (ControlSpacing * row)),
                    Theme = MetroThemeStyle.Dark,
                    AutoSize = true,
                };

                animPropLabels.Add(arrayPosLabel);
                animPropsPnl.Controls.Add(animPropLabels[pos]);

                // TextBox (Value)
                MetroTextBox textBox = new MetroTextBox
                {
                    Location = new Point(animPropTxt.Location.X + 10, animPropTxt.Location.Y + (ControlSpacing * row)),
                    Theme = MetroThemeStyle.Dark,
                    Size = new Size(animPropTxt.Size.Width - 10, animPropTxt.Size.Height)
                };

                textBox.KeyUp += AnimArrayTextBox_KeyUp;

                animPropInputs.Add(textBox);
                animPropsPnl.Controls.Add(animPropInputs[pos]);

                pos++;
                arrayPos++;
            }

            UpdateAnimArrayControlValues();
        }

        // NOTE: This is really slow
        private void GenerateAnim2dArrayControls(int[][] array, string arrayName)
        {
            int row = 0;

            // Label
            MetroLabel label = new MetroLabel
            {
                Text = arrayName,
                Location = new Point(animPropLbl.Location.X, animPropLbl.Location.Y + (ControlSpacing * row)),
                Theme = MetroThemeStyle.Dark,
                AutoSize = true
            };

            animPropLabels.Add(label);

            // TextBox (Size)
            MetroTextBox sizeTextBox = new MetroTextBox
            {
                Location = new Point(animPropTxt.Location.X, animPropTxt.Location.Y + (ControlSpacing * row)),
                Theme = MetroThemeStyle.Dark,
                Size = animPropTxt.Size,
                Enabled = false
            };

            animPropInputs.Add(sizeTextBox);

            int arrayPos = 0;
            foreach (int[] array2 in array)
            {
                row++;

                // Label (Array Position)
                MetroLabel arrayPosLabel = new MetroLabel
                {
                    Text = string.Format("[{0}]", arrayPos.ToString()),
                    Location = new Point(animPropLbl.Location.X + 10, animPropLbl.Location.Y + (ControlSpacing * row)),
                    Theme = MetroThemeStyle.Dark,
                    AutoSize = true,
                };

                animPropLabels.Add(arrayPosLabel);

                // TextBox (Size)
                MetroTextBox textBox = new MetroTextBox
                {
                    Location = new Point(animPropTxt.Location.X + 10, animPropTxt.Location.Y + (ControlSpacing * row)),
                    Theme = MetroThemeStyle.Dark,
                    Size = new Size(animPropTxt.Size.Width - 10, animPropTxt.Size.Height)
                };

                textBox.KeyUp += AnimArrayTextBox_KeyUp;

                animPropInputs.Add(textBox);

                int arrayPos2 = 0;
                foreach (int item in array2)
                {
                    row++;

                    // Label (Array Position)
                    MetroLabel arrayPosLabel2 = new MetroLabel
                    {
                        Text = string.Format("[{0}][{1}]", arrayPos.ToString(), arrayPos2.ToString()),
                        Location = new Point(animPropLbl.Location.X + 20, animPropLbl.Location.Y + (ControlSpacing * row)),
                        Theme = MetroThemeStyle.Dark,
                        AutoSize = true,
                    };

                    animPropLabels.Add(arrayPosLabel2);

                    // TextBox (Size)
                    MetroTextBox textBox2 = new MetroTextBox
                    {
                        Location = new Point(animPropTxt.Location.X + 20, animPropTxt.Location.Y + (ControlSpacing * row)),
                        Theme = MetroThemeStyle.Dark,
                        Size = new Size(animPropTxt.Size.Width - 20, animPropTxt.Size.Height)
                    };

                    textBox2.KeyUp += AnimArrayTextBox_KeyUp;

                    animPropInputs.Add(textBox2);


                    arrayPos2++;
                }

                arrayPos++;
            }

            // Add all the generated properties to the panel
            for (int pos = 0; pos < animPropLabels.Count; pos++)
            {
                animPropsPnl.Controls.Add(animPropLabels[pos]);
                animPropsPnl.Controls.Add(animPropInputs[pos]);
            }

            // Put the scroll bar at the top
            animPropsPnl.Controls[6].Select();

            UpdateAnimArrayControlValues();
        }

        private void ResetAnimControls()
        {
            if (animPropInputs.Count > 0)
            {
                // Remove the controls from the window
                foreach (MetroLabel label in animPropLabels)
                    animPropsPnl.Controls.Remove(label);

                foreach (Control control in animPropInputs)
                    animPropsPnl.Controls.Remove(control);

                // Remove the controls from the array
                animPropLabels.Clear();
                animPropInputs.Clear();
            }

        }

        // Animation controls
        private void FrameTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (animCmb.SelectedIndex < 0) return;

            if (int.TryParse(frameTxt.Text, out int outInt))
            {
                if (outInt < animationFile.Animations[animCmb.SelectedIndex].Frames.Length)
                {
                    animFrameIndex = outInt;
                    DisplayAnim();
                }

                else
                    SystemSounds.Beep.Play();
            }

        }

        private void DirTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (animCmb.SelectedIndex < 0) return;

            if (int.TryParse(dirTxt.Text, out int outInt))
            {
                Console.WriteLine("Dir " + outInt + "/" + animationFile.Animations[animCmb.SelectedIndex].Dirs);
                if (outInt < animationFile.Animations[animCmb.SelectedIndex].Dirs)
                {
                    animDir = outInt;
                    DisplayAnim();
                }

                else
                    SystemSounds.Beep.Play();
            }
        }

        private void PlayPauseBtn_Click(object sender, EventArgs e)
        {
            if (animationFile.Animations.Count != 0 && animCmb.SelectedIndex >= 0)
            {
                if (!playAnim)
                {
                    PlayAnim();
                    playPauseBtn.Text = "Pause";
                }

                else
                {
                    playAnim = false;
                    playPauseBtn.Text = "Play";
                }
            }

            else
                MetroMessageBox.Show(this, "No animations are currently defined", "Error", MessageBoxButtons.OK);
        }
        private int GetAnimTimerInterval()
        {
            // Divide the time by the amount of frames and apply the speed multiplier
            double.TryParse(animSpeedTxt.Text, out double speedDouble);

            if (animationFile.Animations[animCmb.SelectedIndex].Frames != null)
            {
                int interval = (int)Math.Ceiling(animationFile.Animations[animCmb.SelectedIndex].Time / animationFile.Animations[animCmb.SelectedIndex].Frames.Length / speedDouble * 10000);
                return interval;
            }

            return 1;
        }

        private void CopySheetBtn_MouseHover(object sender, EventArgs e)
        {
            tt.Show("Duplicate", copySheetBtn);
        }

        private void CopyAnimBtn_MouseHover(object sender, EventArgs e)
        {
            tt.Show("Duplicate", copyAnimBtn);
        }

    }
}
