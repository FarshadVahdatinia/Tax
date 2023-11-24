using GW.Repository.Entities.Taxiation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxCollectData.Library.Dto.Content;
using TaxData.Taxiation;

namespace TaxData.Operations
{
    public class TaxDirect
    {
        string LoyaltyBaseAddress = string.Empty;
        string LoyaltyUserName = string.Empty;
        string LoyaltyPassword = string.Empty;
        string APIToken = string.Empty;
        private int transferRate = 1;

        public TaxDirect()
        {
            transferRate = Convert.ToInt32(ConfigurationManager.AppSettings["transferRate"].ToString());
            string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
            SqlConnection Connection = new SqlConnection(MyConnection);
            try
            {
                Connection.Open();
                DataTable dt = new DataTable();
                //dt.Columns.Add("Name");
                //dt.Columns.Add("Id");
                //dt.Columns.Add("Value");
                SqlDataAdapter adp = new SqlDataAdapter("select id,name,Value from SetupConfig where name in('LoyaltyBaseAddress','LoyaltyUserName','LoyaltyPassword')", Connection);
                adp.Fill(dt);
                LoyaltyBaseAddress = dt.Select("Name='LoyaltyBaseAddress'")[0]["Value"].ToString();
                LoyaltyUserName = dt.Select("Name='LoyaltyUserName'")[0]["Value"].ToString();
                LoyaltyUserName = dt.Select("Name = 'LoyaltyPassword'")[0]["Value"].ToString();  
                //LoyaltyBaseAddress = dt.Rows[0]["Value"].ToString();
                //LoyaltyUserName = dt.Rows[0]["Value"].ToString();
                //LoyaltyUserName = dt.Rows[0]["Value"].ToString();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        private readonly string jwtHeaderName = "Authorization";

        public string GetToken(string userName, string password, string LoyaltyBaseAddressParam = "")
        {
            
            string LBaseAddress;
            if (LoyaltyBaseAddressParam == "")
            {
                LBaseAddress = LoyaltyBaseAddress;
            }
            else
                LBaseAddress = LoyaltyBaseAddressParam;
            string s1 = "";
            string baseAddress = LBaseAddress + "/TOKEN";
            string postString = string.Format("grant_type={0}&userName={1}&password={2}", "password", userName, password);
            WebRequest http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            http.ContentType = "application/json";
            http.Method = "POST";
            http.ContentLength = postString.Length;
            StreamWriter requestWriter = new StreamWriter(http.GetRequestStream());
            requestWriter.Write(postString);
            requestWriter.Close();
            WebResponse response = http.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string content = sr.ReadToEnd();
            string[] df = content.Split(',');
            string[] tok = df[0].Split(':');
            s1 = new string(tok[1].ToCharArray(1, tok[1].Length - 2));
            return s1;
        }
        public async Task<List<TaxSendInvoiceResponse>> TaxDirectSendInvoice(List<InvoiceDtoWrapper> param)
        {
            if (APIToken == string.Empty)
            {
                MessageBox.Show($"Getting Token from CashApi userName:{LoyaltyUserName}  Password:{LoyaltyPassword} address:{LoyaltyBaseAddress}", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                APIToken = GetToken(LoyaltyUserName, LoyaltyPassword);
            }
            MessageBox.Show("توکن دریافت گردید", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(param);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Add(jwtHeaderName, "bearer " + APIToken);
                    client.Timeout = TimeSpan.FromMinutes(1000);
                    var url = new Uri(LoyaltyBaseAddress + "/api/Taxation/sendInvoices");
                    var response = await client.PostAsync(url, data);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("اتصال با CashApi موفقیت آمیز نبود ", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        var res = JsonConvert.DeserializeObject<List<TaxSendInvoiceResponse>>(Task.Run(async () => await response.Content.ReadAsStringAsync()).Result);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        response.Dispose();
                        return res;
                    }
                    else
                    {
                        foreach (var item in res.Where(x => !string.IsNullOrEmpty(x?.ErrorDetail)))
                        {
                            response.Dispose();
                            throw new Exception("error" + item);
                        }
                        throw new Exception("error");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString(), e.InnerException);
            }
        }
        public List<TaxationInquiryResult> TaxDirectInqiryInvoice(InquiryByReferenceNumberDto param)
        {
            string LBaseAddress = LoyaltyBaseAddress;

            if (APIToken == string.Empty)
            {
                APIToken = GetToken(LoyaltyUserName, LoyaltyPassword);
            }
            try
            {
                var json = JsonConvert.SerializeObject(param);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMinutes(1000);
                    httpClient.BaseAddress = new Uri(LBaseAddress);
                    httpClient.DefaultRequestHeaders.Add(jwtHeaderName, "bearer " + APIToken);

                    var response = Task.Run(async () => await httpClient.PostAsync("api/Taxation/inquiryInvoiceByRefNo", data)).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var otpResult = JsonConvert.DeserializeObject<List<TaxationInquiryResult>>(Task.Run(async () => await response.Content.ReadAsStringAsync()).Result);
                        return otpResult;
                    }
                    else
                    {
                        throw new Exception("error");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString(), e.InnerException);
            }
        }
        public List<InvoiceDtoWrapper> InvoiceMaker(DataSet ds, int numOfSent)
        {
            var numToSend = ds.Tables[0].Rows.Count;
            var invoices = new List<InvoiceDtoWrapper>();
            var factors = ds.Tables[0].Rows.Cast<DataRow>().Skip(numOfSent).Take(transferRate == 0 ? numToSend : transferRate).GroupJoin(ds.Tables[1].Rows.Cast<DataRow>(), x => x.Field<long>("Inno"), y => y.Field<long>("Inno"), (x, y) => new { Header = x, Body = y }).ToList();
            foreach (var item in factors)
            {
                var body = new List<TaxInvoiceBody>();
                foreach (var row in item.Body)
                {
                    body.Add(new TaxInvoiceBody()
                    {
                        Adis = Convert.ToDecimal(row["Adis"]),
                        Am = Convert.ToDecimal(row["Am"]),
                        Dis = Convert.ToDecimal(row["Dis"]),
                        Fee = Convert.ToDecimal(row["Fee"]),
                        Mu = Convert.ToString(row["Mu"]),
                        Prdis = Convert.ToDecimal(row["Prdis"]),
                        Sstid = Convert.ToString(row["Sstid"]),
                        Sstt = Convert.ToString(row["Sstt"]),
                        Tsstam = Convert.ToDecimal(row["Tsstam"]),
                        Vam = Convert.ToDecimal(row["Vam"]),
                        Vra = Convert.ToDecimal(row["Vra"]),
                        Inno = Convert.ToString(Convert.ToInt64(row["Inno"])),
                        //Bros = Convert.ToDecimal(row["Bros"]),
                        //Bsrn = Convert.ToString(row["Bsrn"]),
                        //Cfee = Convert.ToDecimal(row["Cfee"]),
                        //Consfee = Convert.ToDecimal(row["Consfee"]),
                        //Cop = Convert.ToDecimal(row["Cop"]),
                        //Cut = Convert.ToString(row["Cut"]),
                        //Exr = Convert.ToDecimal(row["Exr"]),
                        //Odam = Convert.ToDecimal(row["Odam"]),
                        //Odr = Convert.ToDecimal(row["Odr"]),
                        //Odt = Convert.ToString(row["Odt"]),
                        //Olam = Convert.ToDecimal(row["Olam"]),
                        //Olr = Convert.ToDecimal(row["Olr"]),
                        //Olt = Convert.ToString(row["Olt"]),
                        //Spro = Convert.ToDecimal(row["Spro"]),
                        //Tcpbs = Convert.ToDecimal(row["Tcpbs"]),
                        // Vop = Convert.ToDecimal(row["Vop"]),
                    });
                }
                var headerRow = item.Header;
                invoices.Add(new InvoiceDtoWrapper()
                {
                    Uid = Convert.ToString(headerRow["Uid"]),
                    Invoice = new TaxInvoice()
                    {
                        CreatedOn = Convert.ToDateTime(headerRow["Indati2m"]),
                        Header = new TaxInvoiceHeader()
                        {
                            Bid = headerRow["Bid"] != null ? Convert.ToString(headerRow["Bid"]) : "",
                            Indati2m = new DateTimeOffset(Convert.ToDateTime(headerRow["Indati2m"])).ToUnixTimeMilliseconds(),
                            Indatim = new DateTimeOffset(Convert.ToDateTime(headerRow["Indatim"])).ToUnixTimeMilliseconds(),
                            Inno = Convert.ToString(Convert.ToInt64(headerRow["Inno"])),
                            Inp = Convert.ToInt32(headerRow["Inp"]),
                            Ins = Convert.ToInt32(headerRow["Ins"]),
                            Inty = Convert.ToInt32(headerRow["Inty"]),
                            Setm = Convert.ToInt32(headerRow["Setm"]),
                            Tadis = Convert.ToDecimal(headerRow["Tadis"]),
                            Tbill = Convert.ToDecimal(headerRow["Tbill"]),
                            Tdis = Convert.ToDecimal(headerRow["Tdis"]),
                            Tinb = headerRow["Tinb"] != null ? Convert.ToString(headerRow["Tinb"]) : "",
                            Tins = Convert.ToString(headerRow["Tins"]),
                            Tprdis = Convert.ToDecimal(headerRow["Tprdis"]),
                            Tvam = Convert.ToDecimal(headerRow["Tvam"]),
                            Todam = Convert.ToDecimal(headerRow["Todam"]),
                            CreatedOn = Convert.ToDateTime(headerRow["Indatim"]),
                            //Bbc = Convert.ToString(headerRow["Bbc"]),
                            //Billid = Convert.ToString(headerRow["Billid"]),
                            //Bpc = Convert.ToString(headerRow["Bpc"]),
                            //Bpn = Convert.ToString(headerRow["Bpn"]),
                            //Cap = Convert.ToDecimal(headerRow["Cap"]),
                            //Crn = Convert.ToString(headerRow["Crn"]),
                            //Ft = Convert.ToInt32(headerRow["Ft"]),
                            //Insp = Convert.ToDecimal(headerRow["Insp"]),
                            //Irtaxid = Convert.ToString(headerRow["Irtaxid"]),
                            //Sbc = Convert.ToString(headerRow["Sbc"]),
                            //Scc = Convert.ToString(headerRow["Scc"]),
                            //Scln = Convert.ToString(headerRow["Scln"]),
                            //Tax17 = Convert.ToDecimal(headerRow["Tax17"]),
                            //Taxid = Convert.ToString(headerRow["Taxid"]),
                            //Tob = headerRow["Tob"] != null ? Convert.ToInt32(headerRow["Tob"]): 0,
                            //Tvop = Convert.ToDecimal(headerRow["Tvop"]),}
                        },
                        Body = body,
                        Payment = new List<TaxInvoicePayment>() { new TaxInvoicePayment() { } }
                    }
                });
            }
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    payment.Add(new TaxInvoicePayment
            //    {
            //        Acn = Convert.ToString(row["Acn"]),
            //        Iinn = Convert.ToString(row["Iinn"]),
            //        Pcn = Convert.ToString(row["Pcn"]),
            //        Pdt = Convert.ToInt64(row["Pdt"]),
            //        Pid = Convert.ToString(row["Pid"]),
            //        Pmt = Convert.ToInt32(row["Pmt"]),
            //        Pv = Convert.ToInt64(row["Pv"]),
            //        Trmn = Convert.ToString(row["Trmn"]),
            //        Trn = Convert.ToString(row["Trn"]),
            //    });
            //}
            return invoices;
        }
        public DataSet ShowProcedure(string procedureName)
        {
            string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
            var ds = new DataSet();
            using (SqlConnection Connection = new SqlConnection(MyConnection))
            {
                string cmdText = procedureName;
                SqlDataAdapter adp = new SqlDataAdapter(cmdText, Connection);
                adp.Fill(ds);
            }
            return ds;
        }

        public void SaveProcedure(List<TaxationInquiryResult> responseSave)
        {
            try
            {
                string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
                SqlParameter _Table;
                var res1 = new DataTable();

                res1.Columns.Add("Inno");
                res1.Columns.Add("ReferenceNo");
                res1.Columns.Add("TaxId");
                res1.Columns.Add("uuid", typeof(Guid));
                res1.Columns.Add("ErrorCode");
                res1.Columns.Add("ErrorMessage");
                res1.Columns.Add("DocStatusId");
                res1.Columns.Add("TaxStatus");
                foreach (var item in responseSave)
                {
                    var newRow = res1.NewRow();
                    newRow["ReferenceNo"] = item.ReferenceNumber;
                    newRow["uuid"] = item.Uid;
                    newRow["ErrorMessage"] = item?.Error;
                    newRow["TaxStatus"] = item.Status;
                    res1.Rows.Add(newRow);
                }
                using (SqlConnection Connection = new SqlConnection(MyConnection))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("TaxTrxDirectSave", Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    _Table = new SqlParameter("@Invoice", SqlDbType.Structured);

                    _Table.Value = res1;
                    cmd.Parameters.Add(_Table);

                    cmd.ExecuteNonQuery();
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SaveInvoiceProcedure(List<TaxSendInvoiceResponse> responseSave)
        {
            try
            {
                string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
                SqlParameter _Table;
                var res1 = new DataTable();

                res1.Columns.Add("Inno");
                res1.Columns.Add("ReferenceNo");
                res1.Columns.Add("TaxId");
                res1.Columns.Add("uuid", typeof(Guid));
                res1.Columns.Add("ErrorCode");
                res1.Columns.Add("ErrorMessage");
                res1.Columns.Add("DocStatusId");
                res1.Columns.Add("TaxStatus");
                foreach (var item in responseSave)
                {
                    var newRow = res1.NewRow();
                    newRow["ReferenceNo"] = item.ReferenceNumber;
                    newRow["uuid"] = item.Uid;
                    newRow["ErrorMessage"] = item.ErrorDetail;
                    newRow["Inno"] = item.Inno;
                    newRow["TaxId"] = item.TaxId;
                    newRow["ErrorCode"] = item.ErrorCode;
                    res1.Rows.Add(newRow);
                }
                using (SqlConnection Connection = new SqlConnection(MyConnection))
                {
                    Connection.Open();
                    SqlCommand cmd = new SqlCommand("TaxTrxDirectSave", Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    _Table = new SqlParameter("@Invoice", SqlDbType.Structured);
                    var isFirst = new SqlParameter("@IsFirstTime", SqlDbType.Bit);
                    isFirst.Value = true;

                    _Table.Value = res1;
                    cmd.Parameters.Add(_Table);
                    cmd.Parameters.Add(isFirst);
                    cmd.ExecuteNonQuery();
                    Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void GetRejectedProcedure(List<TaxationInquiryResult> responseSave)
        {
            try
            {
                string MyConnection = new TaxData.Connectivity().ReadConnectionStringFromConfig();
                SqlParameter _Table;
                var res1 = new DataTable();

                res1.Columns.Add("Inno");
                res1.Columns.Add("ReferenceNo");
                res1.Columns.Add("TaxId");
                res1.Columns.Add("uuid", typeof(Guid));
                res1.Columns.Add("ErrorCode");
                res1.Columns.Add("ErrorMessage");
                res1.Columns.Add("DocStatusId");
                res1.Columns.Add("TaxStatus");
                foreach (var item in responseSave)
                {
                    var newRow = res1.NewRow();
                    newRow["ReferenceNo"] = item.ReferenceNumber;
                    newRow["uuid"] = item.Uid;
                    newRow["ErrorMessage"] = item.Error;
                    newRow["TaxStatus"] = item.Status;
                    newRow["TaxStatus"] = item.Status;
                    res1.Rows.Add(newRow);
                }
                using (SqlConnection Connection = new SqlConnection(MyConnection))
                {
                    SqlCommand cmd = new SqlCommand("TaxTrxDirectSave", Connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    _Table = new SqlParameter("@Invoice", SqlDbType.Structured);


                    _Table.Value = res1;
                    cmd.Parameters.Add(_Table);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
