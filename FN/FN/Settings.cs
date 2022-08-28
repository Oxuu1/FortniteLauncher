using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNMainLauncher.Providers;


namespace FN.FN
{
    public partial class Settings : Form
    {
        

        public Settings (Gui gui)
        {
            InitializeComponent();
            this._gui = gui;
            this.materialSingleLineTextFieldInstallLocation.Text = this._gui.Configuration.InstallLocation;
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.Save();
        }
        private void Save()
        {
            this._gui.Configuration.InstallLocation = this.materialSingleLineTextFieldInstallLocation.Text;
            this._gui.Configuration.Save();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = this.folderBrowserDialog1.ShowDialog() == DialogResult.OK;
            bool flag2 = flag;
            if (flag2)
            {
                this.materialSingleLineTextFieldInstallLocation.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
        private Gui _gui;

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
