using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace IPC247
{
    public partial class Form_Search_Customer : DevExpress.XtraEditors.XtraForm
    {
        public static string idCompany = "0";
        public static Customer cus = new Customer();
        public static Company com = new Company();
        public Form_Search_Customer()
        {
            InitializeComponent();
        }
        private void sp_Get_Customer()
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_Get_ListCustomer_Search @Company={0}", chkLayALL.Checked? "0":idCompany);
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                txtCustomer.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Search_Customer", "sp_Get_Customer()", ex.ToString()));
            }
        }
        private void Form_Search_Customer_Load(object sender, EventArgs e)
        {
            sp_Get_Customer();
        }

        private void txtCompany_EditValueChanged(object sender, EventArgs e)
        {
            int rowHandle = txtCustomer.Properties.GetIndexByKeyValue(txtCustomer.EditValue);
            object row = txtCustomer.Properties.View.GetRow(rowHandle);
            //  Customer cus = new Customer();
            cus = new Customer();
            cus.ID = (row as DataRowView).Row["ID"].ToString();
            cus.CardName = (row as DataRowView).Row["CardName"].ToString();
            cus.Address = (row as DataRowView).Row["Address"].ToString();
            cus.Phone = (row as DataRowView).Row["Phone"].ToString();
            cus.CompanyName = (row as DataRowView).Row["CompanyName"].ToString();
            cus.Company = (row as DataRowView).Row["Company"].ToString();
            cus.Email = (row as DataRowView).Row["Email"].ToString();
            cus.Description = (row as DataRowView).Row["Description"].ToString();
            com = new Company();
            com.ID = (row as DataRowView).Row["Company"].ToString();
            com.CompanyName = (row as DataRowView).Row["CompanyName"].ToString();
            com.Description = (row as DataRowView).Row["Description"].ToString();
            com.Address = (row as DataRowView).Row["AddressCom"].ToString();
          //  Form_Add_Enquiry.cus = cus;
          //  Form_Add_Enquiry.com = com;
            this.Close();
        }
        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar== (char)27)
            {
                this.Close();
            }
        }

        private void chkLayALL_CheckedChanged(object sender, EventArgs e)
        {
            sp_Get_Customer();
        }
    }
}