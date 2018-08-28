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
    public partial class Form_Search_Company : DevExpress.XtraEditors.XtraForm
    {
        #region Declare
        public static Company com = new Company();
        public Form_Search_Company()
        {
            InitializeComponent();
        }
        #endregion Declare

        #region Function
        private void sp_Get_Company()
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_Get_ListCompany_Search");
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                txtCompany.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Search_Company", "sp_Get_Company()", ex.ToString()));
            }
        }

        #endregion Function

        #region Event
        private void Form_Search_Company_Load(object sender, EventArgs e)
        {
            sp_Get_Company();
        }

        private void txtCompany_EditValueChanged(object sender, EventArgs e)
        {
            int rowHandle = txtCompany.Properties.GetIndexByKeyValue(txtCompany.EditValue);
            object row = txtCompany.Properties.View.GetRow(rowHandle);
            com = new Company();
            com.ID = (row as DataRowView).Row["ID"].ToString();
            com.CompanyName = (row as DataRowView).Row["CompanyName"].ToString();
            com.Description = (row as DataRowView).Row["Description"].ToString();
            com.Address  = (row as DataRowView).Row["Address"].ToString();
            this.Close();
        }

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar== (char)27)
            {
                this.Close();
            }
        }
        #endregion Event
    }
}