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
using System.Configuration;
using TaxData.Operations;
using GW.Repository.Entities.Taxiation;
using System.Reflection;
using TaxCollectData.Library.Dto.Content;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TaxData.Taxiation;

namespace TaxData
{
    public partial class frmDirect : Form
    {
        DataSet ds;
        private int refreshTime = 0, qtyRefreshTime = 0;
        private int riderPickupTimeDefault = 0, transferRate = 1;
        private NumberFormatInfo nfi;
        public frmDirect()
        {
            InitializeComponent();
            ds = new DataSet();
            refreshTime = Convert.ToInt32(ConfigurationManager.AppSettings["refreshTime"].ToString());
            qtyRefreshTime = Convert.ToInt32(ConfigurationManager.AppSettings["qtyRefreshTime"].ToString());
            riderPickupTimeDefault = Convert.ToInt32(ConfigurationManager.AppSettings["riderPickupTime"].ToString());
            transferRate = Convert.ToInt32(ConfigurationManager.AppSettings["transferRate"].ToString());
        }
        #region Design
        private void frmDirect_Load(object sender, EventArgs e)
        {
            txtFromDate.Text = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
            txtToDate.Text = DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
            grdData.Columns["irtaxid"].Visible = rdbRet.Checked;
            tabsend.Controls.Add(panel3);
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl.SelectedTab.Text == "مشاهده و ارسال")
            {
                btnData.Visible = true;
                btnSale.Visible = true;
                btnInquery.Visible = false;
                btnSentInformation.Visible = false;
                btnInquiryNeed.Visible = false;
                btnShowRejected.Visible = false;
                btnSendRejected.Visible = false;
            }
            if (tabControl.SelectedTab.Text == "استعلام")
            {
                btnData.Visible = false;
                btnSale.Visible = false;
                btnInquery.Visible = true;
                btnSentInformation.Visible = true;
                btnInquiryNeed.Visible = true;
                btnShowRejected.Visible = false;
                btnSendRejected.Visible = false;
            }
            if (tabControl.SelectedTab.Text == "رد شده ها")
            {
                btnData.Visible = false;
                btnSale.Visible = false;
                btnInquery.Visible = false;
                btnSentInformation.Visible = false;
                btnInquiryNeed.Visible = false;
                btnShowRejected.Visible = true;
                btnSendRejected.Visible = false;
            }
    
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Text == "مشاهده و ارسال")
            {
                btnData.Visible = true;
                btnSale.Visible = true;
                btnInquery.Visible = false;
                btnSentInformation.Visible = false;
                btnInquiryNeed.Visible = false;
                btnShowRejected.Visible = false;
                btnSendRejected.Visible = false;
            }

            if (tabControl.SelectedTab.Text == "استعلام")
            {
                btnData.Visible = false;
                btnSale.Visible = false;
                btnInquery.Visible = true;
                btnSentInformation.Visible = true;
                btnInquiryNeed.Visible = true;
                btnShowRejected.Visible = false;
                btnSendRejected.Visible = false;
            }
            if (tabControl.SelectedTab.Text == "رد شده ها")
            {
                btnData.Visible = false;
                btnSale.Visible = false;
                btnInquery.Visible = false;
                btnSentInformation.Visible = false;
                btnInquiryNeed.Visible = false;
                btnShowRejected.Visible = true;
                btnSendRejected.Visible = false;
            }
   
            //if (tabControl.SelectedIndex == 0)
            //{
            //    tabsend.Controls.Add(panel3);
            //}
            //else if (tabControl.SelectedIndex == 2)
            //{
            //    tabRejected.Controls.Add(panel3);
            //}
            //if (tabControl.SelectedIndex == 1)
            //{
            //    tabInquiry.Controls.Add(dgvInquiry);
            //    tabInquiry.Controls.Add(btnXls);
            //}
            //else if (tabControl.SelectedIndex == 2)
            //{
            //    tabRejected.Controls.Add(dgvInquiry);
            //    tabRejected.Controls.Add(btnXls);
            //}
        }
        private void copyAlltoClipboard()
        {
            dgvInquiry.SelectAll();
            DataObject dataObj = dgvInquiry.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void btnXls_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
        private void grdData_SelectionChanged(object sender, EventArgs e)
        {
            ds.Tables[1].DefaultView.RowFilter = "inno=" + grdData.CurrentRow.Cells["inno"].Value.ToString();
        }
        #endregion
        #region btnMethods
        private void btnData_Click(object sender, EventArgs e)
        {
            string saleStat = "1";
            if (rdbSale.Checked) saleStat = "1";
            else saleStat = "2";
            string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
            SqlConnection Connection = new SqlConnection(MyConnection);
            try
            {
                Connection.Open();
                ds = new DataSet();
                string cmdText = "Exec dbo.TaxTrxDirectGet " + saleStat + ",'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, Connection);
                adp.Fill(ds);
                grdData.AutoGenerateColumns = false;
                grdData.DataSource = ds.Tables[0];
                grdDetail.DataSource = ds.Tables[1];
                grdData.Columns["irtaxid"].Visible = rdbRet.Checked;

                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("اطلاعات آماده ای برای ارسال وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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
        private async void btnSale_Click(object sender, EventArgs e)
        {
            string saleStat = "1";
            if (rdbSale.Checked) saleStat = "1";
            else saleStat = "2";
            try
            {
                TaxDirect taxdirect = new TaxDirect();
                string cmdText = "Exec dbo.TaxTrxDirectSale " + saleStat + ",'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                var ds = taxdirect.ShowProcedure(cmdText);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("اطلاعات آماده ای برای ارسال وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                grdData.AutoGenerateColumns = false;
                grdData.DataSource = ds.Tables[0];
                grdDetail.DataSource = ds.Tables[1];
                grdData.Columns["irtaxid"].Visible = rdbRet.Checked;
                //send to tax service
                var numToSend = ds.Tables[0].Rows.Count;
                int numOfSent = 0;
                while (numOfSent < numToSend)
                {
                    var invoices = taxdirect.InvoiceMaker(ds, numOfSent);
                    numOfSent += invoices.Count;
                    var Result = await taxdirect.TaxDirectSendInvoice(invoices);
                    if (Result.Count == 0)
                    {
                        MessageBox.Show("اطلاعات ذخیره نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    taxdirect.SaveInvoiceProcedure(Result);
                    //after save Inquiry
                    var refrenceNo = new InquiryByReferenceNumberDto();
                    foreach (var item in Result)
                        refrenceNo.ReferenceNumber.Add(item.ReferenceNumber);
                    var res = taxdirect.TaxDirectInqiryInvoice(refrenceNo);
                    taxdirect.SaveProcedure(res);
                }
                MessageBox.Show("اطلاعات ذخیره شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInquery_Click(object sender, EventArgs e)
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

                //string cmdText = "Exec dbo.TaxTrxDirectInqueryGet'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                string cmdText = "Exec dbo.TaxTrxDirectNeedInqueryGet'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, Connection);
                adp.Fill(dt);
                dgvInquiry.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("اطلاعات آماده ای برای استعلام وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //send this dt to inquery tax service for get TaxId 

                var referenceNo = new InquiryByReferenceNumberDto();
                foreach (DataRow row in dt.Rows)
                    referenceNo.ReferenceNumber.Add(row["ReferenceNo"]?.ToString());

                TaxDirect taxdirect = new TaxDirect();
                var Result = taxdirect.TaxDirectInqiryInvoice(referenceNo);
                Connection.Close();
                //get TaxId & execute TaxTrxDirectSave for save CompletedOn,TaxId
                //DataTable res = ToDataTable(Result);
                //DataTable dt = new DataTable();
                try
                {
                    SqlParameter _Table;
                    SqlCommand cmd = new SqlCommand("TaxTrxDirectSave", Connection);
                    Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    _Table = new SqlParameter("@Invoice", SqlDbType.Structured);

                    var res1 = new DataTable();

                    res1.Columns.Add("Inno");
                    res1.Columns.Add("ReferenceNo");
                    res1.Columns.Add("TaxId");
                    res1.Columns.Add("uuid", typeof(Guid));
                    res1.Columns.Add("ErrorCode");
                    res1.Columns.Add("ErrorMessage");
                    res1.Columns.Add("DocStatusId");
                    res1.Columns.Add("TaxStatus");
                    foreach (var dtRow in Result)
                    {
                        var newRow = res1.NewRow();
                        //newRow["Inno"] = Convert.ToInt64(dtRow.Inno);
                        newRow["ReferenceNo"] = dtRow.ReferenceNumber;
                        //newRow["TaxId"] = dtRow.TaxId;
                        newRow["TaxStatus"] = dtRow.Status;
                        newRow["uuid"] = dtRow.Uid;
                        newRow["ErrorMessage"] = dtRow.Error;
                        //newRow["ErrorMessage"] = dtRow.ErrorDetail;
                        res1.Rows.Add(newRow);
                    }
                    _Table.Value = res1;
                    cmd.Parameters.Add(_Table);

                    cmd.ExecuteNonQuery();
                    if (Result.Count == 0)
                    {
                        MessageBox.Show("اطلاعات ذخیره نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("اطلاعات ذخیره شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSentInformation_Click(object sender, EventArgs e)
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

                string cmdText = "Exec dbo.TaxTrxDirectInqueryGet'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, Connection);
                adp.Fill(dt);
                dgvInquiry.DataSource = dt;
                Connection.Close();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("اطلاعات آماده ای برای استعلام وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex) { }
        }
        private void btnInquiryNeed_Click(object sender, EventArgs e)
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

                string cmdText = "Exec dbo.TaxTrxDirectNeedInqueryGet'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, Connection);
                adp.Fill(dt);
                dgvInquiry.DataSource = dt;
                Connection.Close();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("اطلاعات آماده ای برای استعلام وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex) { }
        }
        private void btnShowRejected_Click(object sender, EventArgs e)
        {
            TaxDirect taxdirect = new TaxDirect();
            string cmdText = "Exec dbo.TaxTrxDirectRejectedInqueryGet'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
            var ds = taxdirect.ShowProcedure(cmdText);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("اطلاعات وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvRejected.DataSource = ds.Tables[0];
            //grdData.AutoGenerateColumns = false;
            //grdData.DataSource = ds.Tables[0];
            //grdDetail.DataSource = ds.Tables[1];
            grdData.Columns["irtaxid"].Visible = rdbRet.Checked;
        }
        private async void btnSendRejected_Click(object sender, EventArgs e)
        {
            string saleStat = "1";
            if (rdbSale.Checked) saleStat = "1";
            else saleStat = "2";
            try
            {
                TaxDirect taxdirect = new TaxDirect();
                string cmdText = "Exec dbo.TaxTrxDirectRejectedSendAgain" + saleStat + ",'" + txtFromDate.Text.Trim() + "','" + txtToDate.Text.Trim() + "'";
                var ds = taxdirect.ShowProcedure(cmdText);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("اطلاعات آماده ای برای ارسال وجود ندارد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                grdData.AutoGenerateColumns = false;
                grdData.DataSource = ds.Tables[0];
                grdDetail.DataSource = ds.Tables[1];
                grdData.Columns["irtaxid"].Visible = rdbRet.Checked;
                //send to tax service
                var numToSend = ds.Tables[0].Rows.Count;
                int numOfSent = 0;
                while (numOfSent < numToSend)
                {
                    var invoices = taxdirect.InvoiceMaker(ds, numOfSent);
                    numOfSent += invoices.Count;
                    var Result = await taxdirect.TaxDirectSendInvoice(invoices);
                    if (Result.Count == 0)
                    {
                        MessageBox.Show("اطلاعات ذخیره نشد", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    taxdirect.SaveInvoiceProcedure(Result);
                    //after save Inquiry
                    var refrenceNo = new InquiryByReferenceNumberDto();
                    foreach (var item in Result)
                        refrenceNo.ReferenceNumber.Add(item.ReferenceNumber);
                    var res = taxdirect.TaxDirectInqiryInvoice(refrenceNo);
                    taxdirect.SaveProcedure(res);
                }
                MessageBox.Show("اطلاعات ذخیره شد", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion




    }

}
