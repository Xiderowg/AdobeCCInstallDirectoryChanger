using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCInstallDirChanger
{
    public partial class Form1 : Form
    {
        private RegistryEdit RE;
        private string ProgramFileDirsOld, ProgramFileDirsX86Old, ProgramFilePathOld, ProgramW6432DirOld;
        private string Path = @"SOFTWARE\Microsoft\Windows\CurrentVersion";
        private string DesiredDir;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When Button Browse is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Browse_Click(object sender, EventArgs e)
        {
            // Enable Components
            Btn_Activate.Enabled = true;
            // Browse Directory
            FolderBrowserDialog browserDialog = new FolderBrowserDialog()
            {
                Description = "Please Select a Disired Directory"
            };
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                TxtBox_Dir.Text = browserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// When Button Activate is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Activate_Click(object sender, EventArgs e)
        {
            DesiredDir = TxtBox_Dir.Text;
            // Enable Componets
            Btn_Deactivate.Enabled = true;
            Btn_Activate.Enabled = false;
            // Backup Original Registry
            string tmpProgramFileDirsOld = RE.GetKeyValue<string>(Path, "ProgramFilesDir");
            string tmpProgramFileDirsX86Old = RE.GetKeyValue<string>(Path, "ProgramFilesDir (x86)");
            string tmpProgramFilePathOld = RE.GetKeyValue<string>(Path, "ProgramFilesPath");
            string tmpProgramW6432DirOld = RE.GetKeyValue<string>(Path, "ProgramW6432Dir");
            if (tmpProgramFileDirsOld != ProgramFileDirsOld || tmpProgramFileDirsX86Old != ProgramFileDirsX86Old ||
                tmpProgramFilePathOld != ProgramFilePathOld || tmpProgramW6432DirOld != ProgramW6432DirOld)
            {
                DialogResult UserResult = MessageBox.Show("It seems that your default config has been modified before, backup current cofig press YES or use program default press NO", "ATTENTION!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (UserResult.Equals(DialogResult.Yes))
                {
                    ProgramFileDirsOld = tmpProgramFileDirsOld;
                    ProgramFileDirsX86Old = tmpProgramFileDirsX86Old;
                    ProgramFilePathOld = tmpProgramFilePathOld;
                    ProgramW6432DirOld = tmpProgramW6432DirOld;
                }
            }
            // Setup the new directory
            MessageBox.Show("Don't Forget To Hit \"Deactivate\" Button After Installing Adobe CC", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bool result = true;
            result = result & RE.SetKey<string>(Path, "ProgramFilesDir", DesiredDir, Microsoft.Win32.RegistryValueKind.String);
            result = result & RE.SetKey<string>(Path, "ProgramFilesDir (x86)", DesiredDir, Microsoft.Win32.RegistryValueKind.String);
            result = result & RE.SetKey<string>(Path, "ProgramFilesPath", DesiredDir, Microsoft.Win32.RegistryValueKind.ExpandString);
            result = result & RE.SetKey<string>(Path, "ProgramW6432Dir", DesiredDir, Microsoft.Win32.RegistryValueKind.String);
            if (!result)
            {
                MessageBox.Show("Something goes wrong", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Deactivate_Click(null, null);
                return;
            }
            MessageBox.Show("Activate Successfully! Now you can go install Adobe CC on your computer", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// When Button Deactivate is Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Deactivate_Click(object sender, EventArgs e)
        {
            // Enable Component
            Btn_Activate.Enabled = true;
            Btn_Deactivate.Enabled = false;
            // Restore Default
            bool result = true;
            result = result & RE.SetKey<string>(Path, "ProgramFilesDir", ProgramFileDirsOld, Microsoft.Win32.RegistryValueKind.String);
            result = result & RE.SetKey<string>(Path, "ProgramFilesDir (x86)", ProgramFileDirsX86Old, Microsoft.Win32.RegistryValueKind.String);
            result = result & RE.SetKey<string>(Path, "ProgramFilesPath", ProgramFilePathOld, Microsoft.Win32.RegistryValueKind.ExpandString);
            result = result & RE.SetKey<string>(Path, "ProgramW6432Dir", ProgramW6432DirOld, Microsoft.Win32.RegistryValueKind.String);
            if (!result)
            {
                MessageBox.Show("Something goes wrong, Please reopen the program and retry.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("DeActivate Successfully! Now you exit this program", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialized Registry Editor
            RE = new RegistryEdit(Microsoft.Win32.Registry.LocalMachine);
            // Load Default Value
            ProgramFileDirsOld = @"C:\Program Files";
            ProgramFileDirsX86Old = @"C:\Program Files (x86)";
            ProgramFilePathOld = @"%ProgramFiles%";
            ProgramW6432DirOld = @"C:\Program Files";
        }
    }
}
