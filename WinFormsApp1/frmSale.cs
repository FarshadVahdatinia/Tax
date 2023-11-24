using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TaxData
{
    public partial class frmSale : Form
    {
        private int tsp = 0;
        public int Tsp { get => tsp; set => tsp = value; }

        public frmSale()
        {
            InitializeComponent();
        }
        
        private void frmSale_Load(object sender, EventArgs e)
        {
            if (tsp == 1)
                this.Text = "تبادل اطلاعات صورتحساب های فروش و برگشت از فروش با شرکت معتمد تیس ";

            txtToDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
        }


        private void btnData_Click(object sender, EventArgs e)
        {
            string saleStat = "1";
            if (rdbSale.Checked) saleStat = "1";
            else saleStat = "2";
            DataTable dt = new DataTable();
            string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
            SqlConnection Connection = new SqlConnection(MyConnection);
            try
            {
                Connection.Open();
                
                string cmdText = "Exec dbo.TaxTrxTisSale " + saleStat + ",'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, Connection);
                adp.Fill(dt);
                grdData.AutoGenerateColumns = false;
                grdData.DataSource = dt;
                grdResult.DataSource = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"خطا", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
            SqlConnection Connection = new SqlConnection(MyConnection);
            try
            {
                Connection.Open();
                string cmdText = "Select * From ResponseStatus";
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, Connection);
                adp.Fill(dt);
                grdResult.AutoGenerateColumns = false;
                grdResult.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
            SqlConnection Connection = new SqlConnection(MyConnection);
            try
            {
                Connection.Open();
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Connection;
                cmd.CommandTimeout = 0;
                cmd.CommandText= "Exec dbo.TaxTrxTisSave";
                cmd.ExecuteNonQuery();
                MessageBox.Show("دستور ذخیره سازی شماره مالیاتی اسناد صادر شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLog.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }

        }

    }
}
