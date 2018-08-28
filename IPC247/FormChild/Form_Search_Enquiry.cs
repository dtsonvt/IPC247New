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
    public partial class Form_Search_Enquiry : DevExpress.XtraEditors.XtraForm
    {
        #region Declare 
        public static string IdCardCode = "0";
        public static Enquiry en = new Enquiry();
        public Form_Search_Enquiry()
        {
            InitializeComponent();
        }
        #endregion Declare 

        #region Function
        private void sp_Get_Customer()
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_Get_ListEnquiry_Search");
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                txtCustomer.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Search_Enquiry", "sp_Get_Customer()", ex.ToString()));
            }
        }
        #endregion Function

        #region Event
        private void Form_Search_Enquiry_Load(object sender, EventArgs e)
        {
            sp_Get_Customer();
        }

        private void txtCompany_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int rowHandle = txtCustomer.Properties.GetIndexByKeyValue(txtCustomer.EditValue);
                object row = txtCustomer.Properties.View.GetRow(rowHandle);
                en = new Enquiry();
                en.ID_Request = (row as DataRowView).Row["ID_Request"].ToString();
                en.CompanyName = (row as DataRowView).Row["CompanyName"].ToString();
                en.Description = (row as DataRowView).Row["Description"].ToString();
                en.CardName = (row as DataRowView).Row["CardName"].ToString();
                en.SDT = (row as DataRowView).Row["SDT"].ToString();
                en.Email = (row as DataRowView).Row["Email"].ToString();
                en.ID_Enquiry = (row as DataRowView).Row["ID_Enquiry"].ToString();
                en.EnquiryName = (row as DataRowView).Row["EnquiryName"].ToString();
                en.Curator = (row as DataRowView).Row["Curator"].ToString();
                en.CuratorName = (row as DataRowView).Row["CuratorName"].ToString();
                en.CompanyCode = (row as DataRowView).Row["Company"].ToString();
                en.CardCode = (row as DataRowView).Row["CardCode"].ToString();
                en.Address_Cus = (row as DataRowView).Row["Address_Cus"].ToString();
             //   Form_Add_Enquiry.en = en;
                this.Close();
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Search_Enquiry", "txtCompany_EditValueChanged", ex.ToString()));
            }
        }

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void chkLayALL_CheckedChanged(object sender, EventArgs e)
        {
            sp_Get_Customer();
        }
        #endregion Event
    }
}