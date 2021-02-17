using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Converter
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainForm f = new frmMainForm();
            f.ShowDialog();
        }
    }
}
