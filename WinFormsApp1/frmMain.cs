using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxData
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

      
        private void btnTis_Click(object sender, EventArgs e)
        {
            frmSale frm = new frmSale();
            frm.Tsp = 1; //tis:1
            frm.ShowDialog();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDirect_Click(object sender, EventArgs e)
        {
            frmDirect frm = new frmDirect();
            frm.ShowDialog();
        }
    }
}
