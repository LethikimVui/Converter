using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Converter.Function;

namespace Converter
{
    public partial class frmStation : Form
    {
        Function fnc = new Function();
        private string userLogin;
        private readonly string wc;
        public Station selectedStation;
        public UserInfo userInfo;
        public List<Station> listStations;

        public frmStation(string userLogin, string wc)
        {
            this.userLogin = userLogin;
            this.wc = wc;
            InitializeComponent();
        }

        private void FrmStation_Load(object sender, EventArgs e)
        {
            ReloadStation();
        }
        private void ReloadStation()
        {
            listStations = fnc.StationConfig(wc);
            if (listStations.Count()>0)
            {
                selectedStation = listStations[0];
            }
            dgvStation.DataSource = listStations;

        }
        private void DgvStation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = dgvStation.Rows[e.RowIndex].Index;
            selectedStation = listStations[index];

        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStationConfiguration f = new frmStationConfiguration(userLogin, wc);
            f.ShowDialog();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMainForm f = new frmMainForm();
            f.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //var content = "";

            //foreach (DataGridViewRow row in dgvStation.SelectedRows)
            //{
            //    //dgvStation.Rows.RemoveAt(item.Index);
            //    var test = fnc.StationConfig();
            //    test.RemoveAt(row.Index);
            //    foreach (var item in test)
            //    {
            //        content += item.WC + ";" + item.Assembly + ";" + item.RouteStep  + ";" + item.Step +  Environment.NewLine;                    
            //    }
            //    dgvStation.DataSource = test;
            //}
            //fnc.WriteFile(content, fnc.ConfigPath);
            var id = Convert.ToInt32(selectedStation.Id);
            var saveResult = fnc.DeleteStation(id, userLogin);
            if (saveResult ==200)
            {
                MessageBox.Show($"Assembly {selectedStation.Assembly} is deleted");
                ReloadStation();
            }
            else
            {
                MessageBox.Show("Delete got error");
            }

        }


    }
}
