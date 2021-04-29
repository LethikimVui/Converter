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
        public List<Station> listStations;
        public Station selectedStation;

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
            listStations = fnc.GetConfigList(wc);
            dgvStation.DataSource = listStations;
            if (listStations.Count() > 0)
            {
                selectedStation = listStations[0];
            }
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
            var id = Convert.ToInt32(selectedStation.Id);
            var saveResult = fnc.DeleteConfig(id, userLogin);
            if (saveResult == 200)
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
