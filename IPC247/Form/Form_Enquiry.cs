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
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace IPC247
{
    public partial class Form_Enquiry : DevExpress.XtraEditors.XtraForm
    {
        #region Declare 
        public static Enquiry en = new Enquiry();
        string IDDetail = "0";
        bool flag_Edit_Enquiry = false;
        public Form_Enquiry()
        {
            InitializeComponent();
            dgv_Main.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        #endregion Declare

        #region Function 
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

        private void LoadComboboxStatus()
        {
            try
            {
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_LoadMaster_Enquiry";
                var json = API.API_GET_Rep(sLink);
                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                txtTrangThai.Properties.DataSource = dt;
                txtTrangThai.EditValue = 0;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Enquiry", "LoadComboboxStatus()", ex.ToString()));
            }
        }

        private void Saveinfo()
        {
            try
            {

                #region Check Validate
                bool flag_edit = false;
                // check tên dự án
                if (string.IsNullOrEmpty(txtNoiDung.Text) || txtNoiDung.Text.Length < 3)
                {
                    dxErrorProvider1.SetError(txtNoiDung, "Phần Mồ Tả ít nhất 3 ký tự");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtNoiDung, null);
                }
                // check trạng thái dự án
                if (string.IsNullOrEmpty(txtTrangThai.Text) || txtTrangThai.Text.Length < 3)
                {
                    dxErrorProvider1.SetError(txtTrangThai, "Phần Trạng thái ít nhất 3 ký tự");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtTrangThai, null);
                }
                // check deadline
                if (txtDeadline.DateTime < DateTime.Now)
                {
                    dxErrorProvider1.SetError(txtDeadline, "Thời gian DEADLINE không được nhỏ hơn thời gian hiện tại");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtDeadline, null);
                }
                if (flag_edit)
                {
                    XtraMessageBox.Show("Vui lòng bổ sung những thông tin còn trống", "Thông Báo");
                    return;
                }
                #endregion Check Validate
                #region Lưu thông tin 
                string str = "[" +
                    string.Format(@" 
                                {{""Key"":""Id_Enquiry"",""value"":""{0}"",""Type"":""string""}},
                                {{""Key"":""ID"",""value"":""{1}"",""Type"":""string""}},
                                {{""Key"":""Description"",""value"":""{2}"",""Type"":""string""}},
                                {{""Key"":""Curator"",""value"":""{3}"",""Type"":""string""}},
                                {{""Key"":""Status"",""value"":""{4}"",""Type"":""string""}},
                                {{""Key"":""User"",""value"":""{5}"",""Type"":""string""}},
                                {{""Key"":""DeadLine"",""value"":""{6}"",""Type"":""Base64""}} ",
                    en.ID_Enquiry //0
                    , IDDetail //1
                    , txtNoiDung.Text //2
                    , txtPhuTrach.EditValue.ToString()//3
                    , txtTrangThai.EditValue.ToString()  //4
                    , Form_Main.user.Username //5
                    , Convert.ToBase64String(Encoding.UTF8.GetBytes(txtDeadline.DateTime.ToString("dd/MM/yyyy HH:mm:ss")))  // 6
                ) + "]";
                //  JObject json = JObject.Parse(str);
                var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_Save_info_EnquiryDetails", Param = str });
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_SaveQuote";
                json = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;
                if (Result == 1)//Login thành công
                {
                    LoadEnquiryDetial(en.ID_Enquiry);
                }
                else
                {
                    XtraMessageBox.Show("Lưu Thông Tin Không Thành Công", "Thông Báo");
                }
                #endregion Lưu thông tin 
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Enquiry", "Saveinfo()", ex.ToString()));
            }
        }

        private void LoadComboboxUser()
        {
            try
            {
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_Get_ListUser";
                var json = API.API_GET_Rep(sLink);
                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                txtPhuTrach.Properties.DataSource = dt;
                txtPhuTrach.EditValue = Form_Main.user.Username;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Enquiry", "LoadComboboxUser()", ex.ToString()));
            }
        }

        private void LoadEnquiryDetial(string ID_Enquiry)
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_GetList_EnquiryDetails @ID_Enquiry={0}", ID_Enquiry);
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET_Rep(sLink);
                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                dgc_Main.DataSource = dt;
                dgv_Main.BestFitColumns(true);
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Enquiry", "LoadEnquiryDetial()", ex.ToString()));
            }
        }

        void DeleteEnquiryDetails()
        {
            try
            {
                if (DialogResult.Yes == XtraMessageBox.Show("Bạn có muốn xóa thông tin này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                        string sql_Exect = string.Format("Exec sp_EnquiryDetail_Delete @ID ='{0}' ", del);
                        string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                        var json = API.API_GET(sLink);
                        dynamic jsondata = JObject.Parse(json);
                        var jsondataChild = jsondata.GetValue("Data");
                        var Result = jsondataChild.First.GetValue("Result").Value;
                        var Message = jsondataChild.First.GetValue("Message").Value;
                        if (Result == 1)//Login thành công
                        {
                            XtraMessageBox.Show(Message, "Thông Báo");
                            LoadEnquiryDetial(en.ID_Enquiry);
                        }
                        else
                        {
                            XtraMessageBox.Show("Xóa Thông Tin Không Thành Công", "Thông Báo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Enquiry", "DeleteEnquiryDetails()", ex.ToString()));
            }
        }

        #endregion Function 

        #region event
        private void Form_Enquiry_Load(object sender, EventArgs e)
        {
            LoadComboboxStatus();
            LoadComboboxUser();
            txtDeadline.EditValue = DateTime.Now;
        }

        private void txtDuAn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form_Add_Enquiry search_Enquiry = new Form_Add_Enquiry();
            search_Enquiry.FormClosed += Search_Enquiry_FormClosed;
            search_Enquiry.ShowDialog();
        }
     
        private void Search_Enquiry_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (en != null)
            {
                flag_Edit_Enquiry = true;
                txtDuAn.Text = en.EnquiryName;
                flag_Edit_Enquiry = false;
                txtCongty.Text = en.CompanyName;
                txtKhachHang.Text = en.CardName;
                txtMoTa.Text = en.Description;
                txtSDT.Text = en.SDT;
                txtEmail.Text = en.Email;
                LoadEnquiryDetial(en.ID_Enquiry);
            }
            else
            {

                flag_Edit_Enquiry = true;
                txtDuAn.Text = "";
                flag_Edit_Enquiry = false;
                txtCongty.Text = "";
                txtKhachHang.Text = "";
                txtMoTa.Text = "";
                txtSDT.Text = "";
                txtEmail.Text = "";
                LoadEnquiryDetial("0");
            }
        }

        private void dgv_Main_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    txtNoiDung.Text = dgv_Main.GetDataRow(focus)["Description"].ToString();
                    txtTrangThai.EditValue = dgv_Main.GetDataRow(focus)["Status"];
                    txtPhuTrach.EditValue = dgv_Main.GetDataRow(focus)["Curator"];
                    IDDetail = dgv_Main.GetDataRow(focus)["ID"].ToString();
                }
                else
                {
                    txtNoiDung.Text = "";
                    IDDetail = "0";
                    txtTrangThai.EditValue = null;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_DoanhNghiep", "dgv_Main_RowClick()", ex.ToString()));
                txtNoiDung.Text = "";
                txtTrangThai.EditValue = null;
            }
        }

        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            IDDetail = "0";
            Saveinfo();
        }

        private void txtDuAn_EditValueChanged(object sender, EventArgs e)
        {
            if(txtDuAn.Text.Length > 0)
            {
                txtNoiDung.ReadOnly = false;
                txtPhuTrach.ReadOnly = false;
                txtTrangThai.ReadOnly = false;
                txtDeadline.ReadOnly = false;
            }
            else
            {
                txtDeadline.ReadOnly = true;
                txtNoiDung.ReadOnly = true;
                txtPhuTrach.ReadOnly = true;
                txtTrangThai.ReadOnly = true;
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            Saveinfo();
        }

        private void tìmDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Add_Enquiry search_Enquiry = new Form_Add_Enquiry();
            search_Enquiry.FormClosed += Search_Enquiry_FormClosed;
            search_Enquiry.ShowDialog();
        }
        private void xóaChiTiếtChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEnquiryDetails();
        }
        #endregion event


    }
}