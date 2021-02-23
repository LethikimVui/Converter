﻿using System;
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
    public partial class frmStation : Form
    {
        Function fnc = new Function();
        public frmStation()
        {
            InitializeComponent();
        }

        private void FrmStation_Load(object sender, EventArgs e)
        {
            dgvStation.DataSource = fnc.StationConfig();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmStationConfiguration f = new frmStationConfiguration();
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
            var content = "";

            foreach (DataGridViewRow row in dgvStation.SelectedRows)
            {
                //dgvStation.Rows.RemoveAt(item.Index);
                var test = fnc.StationConfig();
                test.RemoveAt(row.Index);
                foreach (var item in test)
                {
                    content += item.WC + ";" + item.Assembly + ";" + item.RouteStep  + ";" + item.Step + ";" + item.Side + Environment.NewLine;
                    
                }
                dgvStation.DataSource = test;

            }

            fnc.WriteFile(content, fnc.ConfigPath);

        }
    }
}