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
        Function fnc = new Function();

        public frmStationConfiguration()
        {
            InitializeComponent();
        }

        private void FrmStationConfiguration_Load(object sender, EventArgs e)
        {
            var dicCustomer = fnc.dicCustomer;
            cbxWC.DataSource =  dicCustomer.Values.ToList();
            cbxStation.SelectedText = "--select--";
            cbxStation.Items.Add("QC");
            cbxStation.Items.Add("SMT");
            cbxSide.SelectedText = "--select--";
            cbxSide.Items.Add("T");
            cbxSide.Items.Add("B");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainForm f = new frmMainForm();
            f.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var WC = cbxWC.SelectedItem.ToString();
                var assemby = tbxAssy.Text;
                var station = cbxStation.SelectedItem.ToString();
                var step = tbxStep.Text;
                var side = cbxSide.Text;
                if (string.IsNullOrEmpty(assemby) || (station == "--select--" )|| string.IsNullOrEmpty(step) || (side == "--select--"))
                {
                    MessageBox.Show("Fields cannot be empty");
                }
                else
                {                   
                    var content = WC.Substring(1) + ";" + assemby.ToUpper() + ";" + station.ToUpper() + ";" + step.ToUpper() + ";" + side.ToUpper();
                    fnc.WriteFile(content, fnc.ConfigPath, 1);
                    MessageBox.Show("Save successfully!");
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    string message = "Do you want to add more config?";
                    string title = "Notification";
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        tbxAssy.Text = "";
                        //cbxStation.SelectedText = "--select--";
                        tbxStep.Text = "";
                        //cbxSide.SelectedText = "--select--";
                    }
                    else
                    {
                       
                        this.Hide();
                        frmStation f = new frmStation();
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }
    }
}
