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
            InitializeComponent();
            this.userLogin = userLogin;
            this.wc = wc;
        }

        private void FrmStationConfiguration_Load(object sender, EventArgs e)
        {
            //var dicCustomer = fnc.dicCustomer;
            //cbxWC.DataSource =  dicCustomer.Values.ToList();
            cbxStep.SelectedText = "--select--";
            cbxStep.Items.Add("QC");
            cbxStep.Items.Add("Rework");
            cbxWC.Items.Add(wc);

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
                var step = cbxStep.SelectedItem.ToString();
                var routeStep = tbxRouteStep.Text;
                if (string.IsNullOrEmpty(assembly) || (step == "--select--" )|| string.IsNullOrEmpty(routeStep) )
                {
                    MessageBox.Show("Fields cannot be empty");
                }
                else
                {                   
                    var content = WC.Substring(1).ToUpper() + ";" + assembly.ToUpper() + ";" + step.ToUpper() + ";" + routeStep.ToUpper() ;
                    fnc.WriteFile(content, fnc.ConfigPath, 1);
                    MessageBox.Show("Save successfully!");
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    string message = "Do you want to add more config?";
                    string title = "Notification";
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        tbxAssy.Text = "";
                        tbxRouteStep.Text = "";
                    }
                    else
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

        private void BtnSaveSQLServer_Click(object sender, EventArgs e)
        {
            try
            {
                //var WC = cbxWC.SelectedItem.ToString().Substring(1);
                var WC = wc;

                var assembly = tbxAssy.Text;
                var step = cbxStep.SelectedItem.ToString();
                var routeStep = tbxRouteStep.Text;
                if (string.IsNullOrEmpty(assembly) || (step == "--select--") || string.IsNullOrEmpty(routeStep))
                {
                    MessageBox.Show("Fields cannot be empty");
                }
                else
                {
                    var saveResult = fnc.SaveStation(WC, assembly, step, routeStep, userLogin);
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    string message = "Save succcessfully!";
                    if (saveResult == 400)
                    {
                        message = "Save failed";
                    }                    
                    string title = "Notification";
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
