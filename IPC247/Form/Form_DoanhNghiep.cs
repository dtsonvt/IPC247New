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
using DevExpress.XtraGrid.Views.Grid;
using System.Web.Script.Serialization;

namespace IPC247
{
    public partial class Form_DoanhNghiep : DevExpress.XtraEditors.XtraForm
    {

        #region Khởi Tạo
        public Form_DoanhNghiep()
        {
            InitializeComponent();
        }
        string IDCompany = "0";
        #endregion Khởi Tạo
        #region Load Thông Tin Default
        private void LoadComboboxStatus()
        {
            try
            {
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_LoadMaster_Company";
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                cbbTrangThai.Properties.DataSource = dt;

            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_DoanhNghiep", "LoadComboboxStatus()", ex.ToString()));
            }
        }
        private void sp_Get_Company()
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_Get_ListCompany @Flag ='{0}' ", chkHienThi.Checked?"1":"0");
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
             //   string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_Get_ListCompany";
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                dgc_Main.DataSource = dt;
                dgv_Main.BestFitColumns(true);

            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_DoanhNghiep", "sp_Get_Company()", ex.ToString()));
            }
        }
        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!dgv_Main.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_Main); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_Main); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        void SaveInfo()
        {
            try
            {
                bool flag_edit = false;
                if (string.IsNullOrEmpty(txtTenCongTy.Text) || txtTenCongTy.Text.Length < 4)
                {
                    dxErrorProvider1.SetError(txtTenCongTy, "Tên công ty ít nhất 4 ký tự");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtTenCongTy, null);
                }
                if (flag_edit)
                {
                    XtraMessageBox.Show("Vui lòng bổ sung những thông tin còn trống", "Thông Báo");
                    return;
                }

                string str = "[" +
                    string.Format(@" 
                                {{""Key"":""ID"",""value"":""{0}"",""Type"":""string""}},
                                {{""Key"":""CompanyName"",""value"":""{1}"",""Type"":""Base64""}},
                                {{""Key"":""Description"",""value"":""{2}"",""Type"":""Base64""}},
                                {{""Key"":""Address"",""value"":""{3}"",""Type"":""string""}},
                                {{""Key"":""Status"",""value"":""{4}"",""Type"":""string""}},
                                {{""Key"":""User"",""value"":""{5}"",""Type"":""string""}}  ",
                    IDCompany //0
                    , Convert.ToBase64String(Encoding.UTF8.GetBytes(txtTenCongTy.Text)) //1
                    , Convert.ToBase64String(Encoding.UTF8.GetBytes(txtMoTa.Text)) //2
                    , txtDiaChi.Text //3
                    , cbbTrangThai.EditValue.ToString() //4
                    , Form_Main.user.Username //5
                ) + "]";
                //  JObject json = JObject.Parse(str);
                var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_Company_Insert", Param = str });
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_SaveQuote";
                json = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                if (Result == 1)//Login thành công
                {
                    //XtraMessageBox.Show(Message, "Thông Báo");
                    sp_Get_Company();
                }
                else
                {
                    XtraMessageBox.Show("Lưu Thông Tin Không Thành Công", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_DoanhNghiep", "SaveInfo()", ex.ToString()));
            }
        }

        void ClearForm()
        {
            IDCompany = "";
            txtTenCongTy.Text = "";
            txtDiaChi.Text = "";
            txtMoTa.Text = "";
            cbbTrangThai.EditValue = 1;
        }

        void DeleteCompany()
        {
            try
            {
                if (DialogResult.Yes == XtraMessageBox.Show("Bạn có muốn xóa doanh nghiệp này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                    if(del!="")
                    {
                        string sql_Exect = string.Format("Exec sp_Company_Delete @ID ='{0}' ", del);
                        string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                        var json = API.API_GET(sLink);
                        dynamic jsondata = JObject.Parse(json);
                        var jsondataChild = jsondata.GetValue("Data");
                        var Result = jsondataChild.First.GetValue("Result").Value;
                        var Message = jsondataChild.First.GetValue("Message").Value;
                        if (Result == 1)//Login thành công
                        {
                            XtraMessageBox.Show(Message, "Thông Báo");
                            sp_Get_Company();
                            ClearForm();
                        }
                        else
                        {
                            XtraMessageBox.Show("Hủy Doanh Nghiệp Không Thành Công", "Thông Báo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_DoanhNghiep", "DeleteCompany()", ex.ToString()));
            }
        }

        #endregion Load Thông Tin Default


        private void Form_DoanhNghiep_Load(object sender, EventArgs e)
        {
            LoadComboboxStatus();
            sp_Get_Company();
        }

        private void btnLuuthongtin_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        private void dgv_Main_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    IDCompany = dgv_Main.GetDataRow(focus)["ID"].ToString();
                    txtTenCongTy.Text = dgv_Main.GetDataRow(focus)["CompanyName"].ToString();
                    txtDiaChi.Text = dgv_Main.GetDataRow(focus)["Address"].ToString();
                    txtMoTa.Text = dgv_Main.GetDataRow(focus)["Description"].ToString();
                    cbbTrangThai.EditValue = dgv_Main.GetDataRow(focus)["Status"].ToString();
                }
                else
                {
                    IDCompany = "";
                    txtTenCongTy.Text = "";
                    txtDiaChi.Text = "";
                    txtMoTa.Text = "";
                    cbbTrangThai.EditValue = 1;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_DoanhNghiep", "dgv_Main_RowClick()", ex.ToString()));
                IDCompany = "";
                txtTenCongTy.Text = "";
                txtDiaChi.Text = "";
                txtMoTa.Text = "";
                cbbTrangThai.EditValue = 1;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IDCompany = "";
            SaveInfo();
        }

        private void xóaDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCompany();
        }

        private void tạoMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDCompany = "";
            SaveInfo();
        }

        private void làmMớiFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void lưuThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            sp_Get_Company();
        }
    }
}