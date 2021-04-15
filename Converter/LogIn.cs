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
        Function fnc = new Function();

        public frmLogIn()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainForm f = new frmMainForm();
            f.ShowDialog();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            var NTID = tbxNTID.Text;
            var pass = tbxPassword.Text;
           
            if (NTID=="AOI" && pass=="12345")
            {
                this.Hide();
                frmStation f = new frmStation();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("NTID or Password is invalid", "Warning");
            }
        }
    }
}
