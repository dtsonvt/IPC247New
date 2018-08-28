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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace IPC247
{
    public partial class Form_EnquiryReport : DevExpress.XtraEditors.XtraForm
    {
        public Form_EnquiryReport()
        {
            InitializeComponent();
        }

        private void LoadInfo_Enquiry()
        {
            try
            {
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_getInfo_Enquiry";
                var json = API.API_GET_Rep(sLink);
                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                dgc_Main.DataSource = dt;
                dgv_Main.BestFitColumns(true);
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_EnquiryReport", "LoadInfo_Enquiry()", ex.ToString()));
            }
        }

        private void Form_EnquiryReport_Load(object sender, EventArgs e)
        {
            LoadInfo_Enquiry();
        }

        private void dgv_Main_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colCreatorID = dgv_Main.Columns["CompanyName"];
            if (view == null) return;
            if (e.Column == colCreatorID)
            {
                string text1 = view.GetRowCellDisplayText(e.RowHandle1, colCreatorID);
                string text2 = view.GetRowCellDisplayText(e.RowHandle2, colCreatorID);
                e.Merge = (text1 == text2);
                e.Handled = true;
            }
            //if (e.Column.FieldName == "CompanyName")
            //{
            //    GridView view = sender as GridView;
            //    DateTime val1 = (DateTime)view.GetRowCellValue(e.RowHandle1, e.Column);
            //    DateTime val2 = (DateTime)view.GetRowCellValue(e.RowHandle2, e.Column);
            //    e.Merge = val1.Date == val2.Date;
            //    e.Handled = true;
            //}
        }

        private void dgv_Main_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Old"]);
                if (category == "1")
                {
                    e.Appearance.BackColor = Color.Beige;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                }
            }
        }
    }
}