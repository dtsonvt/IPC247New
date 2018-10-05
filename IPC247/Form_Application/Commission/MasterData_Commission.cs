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

namespace IPC247
{
    public partial class MasterData_Commission : DevExpress.XtraEditors.XtraForm
    {
        public MasterData_Commission()
        {
            InitializeComponent();
        }
        private string ID = "-1";
        private void LoadMasterData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTable("sp_Get_Masster_Commission");
                dgc_Main.DataSource = dt;
                dgv_Main.BestFitColumns(true);
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "LoadMasterData()", ex.ToString()));
            }
        }
        private void CheckEqual()
        {
            lblDoanhSo.Text = string.Format("{0} DS {1}", chk_Minimum.Checked ? "<=" : "<", chk_Maximum.Checked ? "<=":"<");
        }

        private void MasterData_Commission_Load(object sender, EventArgs e)
        {
            LoadMasterData();
        }

        private void dgv_Main_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    bool mini = false;
                    bool maxi = false;
                    bool.TryParse(dgv_Main.GetDataRow(focus)["IsEqualMinimum"].ToString(), out mini);
                    bool.TryParse(dgv_Main.GetDataRow(focus)["IsEqualMaximum"].ToString(), out maxi);
                    lblDoanhSo.Text = string.Format("{0} DS {1}", mini ? "<=" : "<", maxi ? "<=" : "");
                    chk_Minimum.Checked = mini;
                    chk_Maximum.Checked = maxi;
                    txtMinimum.EditValue = dgv_Main.GetDataRow(focus)["Minimun"];
                    txtMaximum.EditValue = dgv_Main.GetDataRow(focus)["Maximum"];
                    txtLuongTheoDS.EditValue = dgv_Main.GetDataRow(focus)["LuongTheoDS"];
                    ID = dgv_Main.GetDataRow(focus)["ID"].ToString();
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "dgv_Main_RowClick()", ex.ToString()));
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.No == XtraMessageBox.Show("Thay đổi của bạn sẽ ảnh hưởng đến thưởng của nhân viên? Bạn có chắc đây là điều bạn muốn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID", ID); //0
                param.Add("Minimun", txtMinimum.EditValue); //0
                param.Add("IsEqualMinimum", chk_Minimum.Checked?"1":"0"); //0
                param.Add("Maximum", txtMaximum.EditValue); //0
                param.Add("IsEqualMaximum", chk_Maximum.Checked ? "1" : "0"); //0
                param.Add("LuongTheoDS", txtLuongTheoDS.EditValue); //0
                param.Add("UserID", Form_Main.user.Username); //0

                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTableUndefine("sp_Update_Masster_Commission", param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Result = dt.Rows[0]["Result"].ToString();
                    string Message = dt.Rows[0]["Message"].ToString();
                    XtraMessageBox.Show(Message, "Thông Báo");
                    if (Result == "1")//Login thành công
                    {
                        LoadMasterData();
                    }
                }
                else
                {
                    API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "btnCapNhat_Click()", "Không có kết quả trả về"));
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "dgv_Main_RowClick()", ex.ToString()));
            }
        }

        private void chk_Minimum_CheckedChanged(object sender, EventArgs e)
        {
            CheckEqual();
        }

        private void chk_Maximum_CheckedChanged(object sender, EventArgs e)
        {
            CheckEqual();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.No == XtraMessageBox.Show("Thay đổi của bạn sẽ ảnh hưởng đến thưởng của nhân viên? Bạn có chắc đây là điều bạn muốn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID", ID); //0
                param.Add("UserID", Form_Main.user.Username); //0

                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTableUndefine("sp_Delete_Masster_Commission", param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Result = dt.Rows[0]["Result"].ToString();
                    string Message = dt.Rows[0]["Message"].ToString();
                    XtraMessageBox.Show(Message, "Thông Báo");
                    if (Result == "1")//Login thành công
                    {
                        LoadMasterData();
                    }
                }
                else
                {
                    API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "btnHuyBo_Click()", "Không có kết quả trả về"));
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "btnHuyBo_Click()", ex.ToString()));
            }

        }

        private void xóaThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string del = "";
            for (int i = 0; i < dgv_Main.SelectedRowsCount; i++)
            {
                DataRow dataRow = (DataRow)dgv_Main.GetDataRow(i);
                if (dataRow != null)
                {
                    del = (del == "" ? "" : (del + ";")) + dataRow["ID"].ToString();
                }
            }
            if (del != "")
            {
                if (DialogResult.No == XtraMessageBox.Show("Thay đổi của bạn sẽ ảnh hưởng đến thưởng của nhân viên? Bạn có chắc đây là điều bạn muốn", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID", del); //0
                param.Add("UserID", Form_Main.user.Username); //0

                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTableUndefine("sp_Delete_Masster_Commission", param);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Result = dt.Rows[0]["Result"].ToString();
                    string Message = dt.Rows[0]["Message"].ToString();
                    XtraMessageBox.Show(Message, "Thông Báo");
                    if (Result == "1")//Login thành công
                    {
                        LoadMasterData();
                    }
                }
                else
                {
                    API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "xóaThôngTinToolStripMenuItem_Click()", "Không có kết quả trả về"));
                }
            }
            else
            {
                XtraMessageBox.Show("Bạn vui lòng tích chọn những dòng cần xóa", "Thông Báo");
            }
        }
    }
}