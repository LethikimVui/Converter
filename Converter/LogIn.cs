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
            var password = tbxPassword.Text;
            if (fnc.ADUserExists(NTID, password))
            {
                var reader = fnc.GetUserInfo(NTID);
                if (reader.NTID != null)
                {
                    this.Hide();
                    frmStation f = new frmStation(reader.NTID, reader.WC);
                    f.ShowDialog();
                }
                else
                {

                }
            }            
            else
            {
                MessageBox.Show("NTID or Password is invalid", "Warning");
            }
        }
    }
}
