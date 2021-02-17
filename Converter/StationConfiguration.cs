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
    public partial class frmStationConfiguration : Form
    {
        public frmStationConfiguration()
        {
            InitializeComponent();
        }

        private void FrmStationConfiguration_Load(object sender, EventArgs e)
        {
            Function fnc = new Function();
            var dicCustomer = fnc.dicCustomer;
            cbxWC.DataSource =  dicCustomer.Values.ToList();


        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainForm f = new frmMainForm();
            f.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var WC = cbxWC.SelectedItem.ToString();
            var assemby = tbxAssy.Text;
            var station = cbxStation.SelectedItem.ToString();
            var step = tbxStep.Text;
            var content = WC + ":" + assemby + ":" + station + ":" + step;

        }
    }
}
