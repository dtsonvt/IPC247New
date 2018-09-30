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
using DevExpress.XtraGrid.Columns;

namespace IPC247
{
    public partial class Frm_Commission : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Commission()
        {
            InitializeComponent();
        }
        DataTable table_Part_Profit = new DataTable();
        DataTable table_Part_Profit_Other = new DataTable();
        string ID_Part_Profit = "0";
        string ID_DayOfLate = "0";
        string ID_Part_Profit_Other = "0";
        string ID_DayOfLate_Other = "0";
        private void LoadMasterData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataSetByStore("sp_Get_Master_Commission_ADVAN_JHCTECH");
                DataTable dt = new DataTable();
                if (ds!=null && ds.Tables.Count == 2)
                {
                    dt = ds.Tables[0];
                    table_Part_Profit = ds.Tables[1];
                }
                dgv_AdvJHC.Columns.Clear();
                dgc_AdvJHC.DataSource = dt;
                dgv_AdvJHC.BestFitColumns(true);

                GridColumn col = dgv_AdvJHC.Columns["MinDay"];
                if(col!= null)
                {
                    col.Visible = false;
                }
                col = dgv_AdvJHC.Columns["MaxDay"];
                if (col != null)
                {
                    col.Visible = false;
                }
                col = dgv_AdvJHC.Columns["ID"];
                if (col != null)
                {
                    col.Visible = false;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "LoadMasterData()", ex.ToString()));
            }
        }
        private void LoadMasterData_Other()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataSetByStore("sp_Get_Master_Commission_Other");
                DataTable dt = new DataTable();
                if (ds != null && ds.Tables.Count == 2)
                {
                    dt = ds.Tables[0];
                    table_Part_Profit_Other = ds.Tables[1];
                }
                dgv_Other.Columns.Clear();
                dgc_Other.DataSource = dt;
                dgv_Other.BestFitColumns(true);

                GridColumn col = dgv_Other.Columns["MinDay"];
                if (col != null)
                {
                    col.Visible = false;
                }
                col = dgv_Other.Columns["MaxDay"];
                if (col != null)
                {
                    col.Visible = false;
                }
                col = dgv_Other.Columns["ID"];
                if (col != null)
                {
                    col.Visible = false;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "LoadMasterData_Other()", ex.ToString()));
            }
        }

        private void Frm_Commission_Load(object sender, EventArgs e)
        {
            LoadMasterData();
            LoadMasterData_Other();
        }

        private void dgv_AdvJHC_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_AdvJHC.FocusedRowHandle;
                if (focus >= 0)
                {
                    string name = dgv_AdvJHC.FocusedColumn.FieldName;
                    if(name != "ID" && name != "ThanhToan")
                    {
                        DataRow result = table_Part_Profit.AsEnumerable().Where(p => p.Field<string>("Key") == name).FirstOrDefault();
                        if(result != null)
                        {
                            txtMin_ADV_JHC.EditValue = result["Minimum"];
                            txtMax_ADV_JHC.EditValue = result["Maximum"];
                            ID_Part_Profit = result["ID"].ToString();
                            ID_DayOfLate = dgv_AdvJHC.GetDataRow(focus)["ID"].ToString();
                            txt_HoaHong_ADV_JHC.EditValue = dgv_AdvJHC.GetDataRow(focus)[name];
                            txt_MaxLateDay_ADV_JHC.EditValue = dgv_AdvJHC.GetDataRow(focus)["MaxDay"];
                            txt_MinLateDay_ADV_JHC.EditValue = dgv_AdvJHC.GetDataRow(focus)["MinDay"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "dgv_Main_RowClick()", ex.ToString()));
            }
        }

        private void btnSave_Adv_JHC_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.No == XtraMessageBox.Show("Thay đổi của bạn sẽ ảnh hưởng đến thưởng của nhân viên? Bạn có chắc đây là điều bạn muốn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID_DayOfLate", ID_DayOfLate); //0
                param.Add("MinDay", txt_MinLateDay_ADV_JHC.EditValue); //0
                param.Add("MaxDay", txt_MaxLateDay_ADV_JHC.EditValue); //0
                param.Add("ID_Part_Profit", ID_Part_Profit); //0
                param.Add("Minimum", txtMin_ADV_JHC.EditValue); //0
                param.Add("Maximum", txtMax_ADV_JHC.EditValue); //0
                param.Add("Values", txt_HoaHong_ADV_JHC.EditValue); //0
                param.Add("UserID", Form_Main.user.Username); //0

                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTableUndefine("sp_Save_Commission_ADV_JHC", param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Result = dt.Rows[0]["Result"].ToString();
                    string Message = dt.Rows[0]["Message"].ToString();
                    XtraMessageBox.Show(Message, "Thông Báo");
                    if (Result == "1")//Login thành công
                    {
                        LoadMasterData();
                        //if(Flag_Changed=="1")
                        //{
                        //    LoadMasterData_Other();
                        //}
                    }
                }
                else
                {
                    API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "btnSave_Adv_JHC_Click()", "Không có kết quả trả về"));
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "btnSave_Adv_JHC_Click()", ex.ToString()));
            }
        }

        private void dgv_Other_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Other.FocusedRowHandle;
                if (focus >= 0)
                {
                    string name = dgv_Other.FocusedColumn.FieldName;
                    if (name != "ID" && name != "ThanhToan")
                    {
                        DataRow result = table_Part_Profit_Other.AsEnumerable().Where(p => p.Field<string>("Key") == name).FirstOrDefault();
                        if (result != null)
                        {
                            txtMin_Other.EditValue = result["Minimum"];
                            txtMax_Other.EditValue = result["Maximum"];
                            ID_Part_Profit_Other = result["ID"].ToString();
                            ID_DayOfLate_Other = dgv_Other.GetDataRow(focus)["ID"].ToString();
                            txt_HoaHong_Other.EditValue = dgv_Other.GetDataRow(focus)[name];
                            txt_MaxLateDay_Other.EditValue = dgv_Other.GetDataRow(focus)["MaxDay"];
                            txt_MinLateDay_Other.EditValue = dgv_Other.GetDataRow(focus)["MinDay"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "dgv_Other_RowClick()", ex.ToString()));
            }
        }

        private void btnSave_Other_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.No == XtraMessageBox.Show("Thay đổi của bạn sẽ ảnh hưởng đến thưởng của nhân viên? Bạn có chắc đây là điều bạn muốn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID_DayOfLate", ID_DayOfLate_Other); //0
                param.Add("MinDay", txt_MinLateDay_Other.EditValue); //0
                param.Add("MaxDay", txt_MaxLateDay_Other.EditValue); //0
                param.Add("ID_Part_Profit", ID_Part_Profit_Other); //0
                param.Add("Minimum", txtMin_Other.EditValue); //0
                param.Add("Maximum", txtMax_Other.EditValue); //0
                param.Add("Values", txt_HoaHong_Other.EditValue); //0
                param.Add("UserID", Form_Main.user.Username); //0

                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTableUndefine("sp_Save_Commission_Other", param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Result = dt.Rows[0]["Result"].ToString();
                    string Message = dt.Rows[0]["Message"].ToString();
                    //string Flag_Changed = dt.Rows[0]["Flag_Changed"].ToString();
                    XtraMessageBox.Show(Message, "Thông Báo");
                    if (Result == "1")//Login thành công
                    {
                        LoadMasterData_Other();
                        //if (Flag_Changed == "1")
                        //{
                        //    LoadMasterData();
                        //}
                    }
                }
                else
                {
                    API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "btnSave_Other_Click()", "Không có kết quả trả về"));
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Commission", "btnSave_Other_Click()", ex.ToString()));
            }
        }
    }
}