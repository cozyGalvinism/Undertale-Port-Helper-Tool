using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UndertaleOnAndroid
{
    public partial class frmHT : Form
    {
        public static frmHT instance;

        public frmHT()
        {
            InitializeComponent();
            Utils.Pwd = Directory.GetCurrentDirectory();
            instance = this;
        }

        private void btnBrowseUT_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            Utils.UndertaleLocation = fbd.SelectedPath;
            Utils.CheckUndertaleLocation();
            txtLoc.Text = Utils.UndertaleLocation;
            if (Utils.DataWinFound)
            {
                btnCreateApk.Enabled = true;
            }
        }

        private void btnCreateApk_Click(object sender, EventArgs e)
        {
            Utils.PatchAndInclude(Utils.Files.FirstOrDefault(x => x.Name.ToLower() == "data.win"));
        }
    }
}
