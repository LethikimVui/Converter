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
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {

        }

        private void frmConfiguration_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmConverter f = new frmConverter();
            f.Show();
            this.Hide();
        }
    }
}
