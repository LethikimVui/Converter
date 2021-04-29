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
        private readonly string userLogin;
        private readonly string wc;
        public frmStationConfiguration(string userLogin, string wc)
        {
            this.userLogin = userLogin;
            this.wc = wc;
            InitializeComponent();
        }

        private void FrmStationConfiguration_Load(object sender, EventArgs e)
        {
            var dicCustomer = fnc.dicCustomer;
            cbxWC.DataSource = dicCustomer.Values.ToList();
            cbxStep.SelectedText = "--select--";
            cbxStep.Items.Add("QC");
            cbxStep.Items.Add("Rework");

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
                var assembly = tbxAssy.Text;
                var step = cbxStep.SelectedItem == null ? String.Empty : cbxStep.SelectedItem.ToString();
                var routeStep = tbxRouteStep.Text;
                if (string.IsNullOrEmpty(assembly) || string.IsNullOrEmpty(step) || string.IsNullOrEmpty(routeStep))
                {
                    MessageBox.Show("Fields cannot be empty");
                }
                else
                {
                    var saveResult = fnc.SaveConfig(WC.Substring(1).ToUpper(), assembly.ToUpper(), step.ToUpper(), routeStep.ToUpper(), "Vui");
                    string message = "Save succcessfully!";
                    if (saveResult != 200)
                    {
                        message = "Save failed";
                    }
                    string title = "Notification";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.OK)
                    {
                        this.Hide();
                        frmStation f = new frmStation(userLogin, wc);
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
