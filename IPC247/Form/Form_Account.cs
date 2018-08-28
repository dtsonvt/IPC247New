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
using System.Security.Cryptography;
using System.Web.Script.Serialization;

namespace IPC247
{
    public partial class Form_Account : DevExpress.XtraEditors.XtraForm
    {
        #region Khai Báo
        string ID = "";
        string MatKhauOld = "";
        #endregion Khai Báo

        #region Function
        private void LoadForm()
        {
            string sql_Exect = "Exec sp_Account_GetData"; //11

            string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
            var json = API.API_GET(sLink);

            var jsondata = JObject.Parse(json).GetValue("Data");
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
            dgc_Main.DataSource = dt;
            dgv_Main.BestFitColumns(true);

            sql_Exect = "Exec sp_GetNhomQuyen_header"; //11

            sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
            json = API.API_GET(sLink);

            jsondata = JObject.Parse(json).GetValue("Data");

            dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
            cbbNhomQuyen.Properties.DataSource = dt;
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
        public static string EncryptPass(string original, string key)
        {
            TripleDESCryptoServiceProvider objDESProvider;
            MD5CryptoServiceProvider objHashMD5Provider;
            byte[] keyhash;
            byte[] buffer;
            try
            {
                objHashMD5Provider = new MD5CryptoServiceProvider();
                keyhash = objHashMD5Provider.ComputeHash(UnicodeEncoding.Unicode.GetBytes(key));
                objHashMD5Provider = null;

                objDESProvider = new TripleDESCryptoServiceProvider();
                objDESProvider.Key = keyhash;
                objDESProvider.Mode = CipherMode.ECB;

                buffer = UnicodeEncoding.Unicode.GetBytes(original);
                return Convert.ToBase64String(objDESProvider.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                return string.Empty;
            }
        }
        private void  LuuThongTin()
        {
            bool flag_edit = false;
            if(txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            {
                dxErrorProvider1.SetError(txtMatKhau, "Mật Khẩu Nhập Lại Không Khớp");
                dxErrorProvider1.SetError(txtNhapLaiMatKhau, "Mật Khẩu Nhập Lại Không Khớp");
                flag_edit = true;
            }
            else
            {
                dxErrorProvider1.SetError(txtMatKhau, null);
                dxErrorProvider1.SetError(txtNhapLaiMatKhau, null);
            }
            if (string.IsNullOrEmpty(txtUserName.Text) || txtUserName.Text.Length < 4)
            {
                dxErrorProvider1.SetError(txtUserName, "Tên đăng nhập ít nhất 4 ký tự");
                flag_edit = true;
            }
            else
            {
                dxErrorProvider1.SetError(txtUserName, null);
            }
            if (string.IsNullOrEmpty(cbbNhomQuyen.Text) || cbbNhomQuyen.Text.Length == 0)
            {
                dxErrorProvider1.SetError(cbbNhomQuyen, "Bạn cần phải thiết lập nhóm quyền cho tài khoản");
                flag_edit = true;
            }
            else
            {
                dxErrorProvider1.SetError(cbbNhomQuyen, null);
            }
            if (string.IsNullOrEmpty(txtTenUser.Text) || txtTenUser.Text.Length < 3)
            {
                dxErrorProvider1.SetError(txtTenUser, "Tên Người Dùng Phải có ít nhất 2 Ký tự");
                flag_edit = true;
            }
            else
            {
                dxErrorProvider1.SetError(txtTenUser, null);
            }
            if (flag_edit)
            {
                XtraMessageBox.Show("Vui lòng bổ sung những thông tin còn trống", "Thông Báo");
                return;
            }
            string MatKhau = txtMatKhau.Text;
            if(MatKhau ==MatKhauOld)
            {
                MatKhau = "";
            }
            else
            {
                MatKhau = EncryptPass(txtNhapLaiMatKhau.Text);
            }
            try
            {
                string str = "[" +
                   string.Format(@" {{""Key"":""ID"",""value"":""{0}"",""Type"":""string""}},{{""Key"":""UserName"",""value"":""{1}"",""Type"":""string""}},
{{""Key"":""Password"",""value"":""{2}"",""Type"":""string""}},{{""Key"":""Name"",""value"":""{3}"",""Type"":""string""}},{{""Key"":""RoleGroup"",""value"":""{4}"",""Type"":""string""}},
{{""Key"":""Address"",""value"":""{5}"",""Type"":""string""}},{{""Key"":""Email"",""value"":""{6}"",""Type"":""string""}},{{""Key"":""Phone"",""value"":""{7}"",""Type"":""string""}},{{""Key"":""Status"",""value"":""{8}"",""Type"":""string""}},
{{""Key"":""IsLogin"",""value"":""{9}"",""Type"":""string""}},{{""Key"":""User"",""value"":""{10}"",""Type"":""string""}}"
                   , ID //0
                   , txtUserName.Text //1
                   , MatKhau //2
                   , txtTenUser.Text //3
                   , cbbNhomQuyen.EditValue //4
                   , txtDiaChi.Text // 5
                   , txtEmail.Text //6
                   , txtSDT.Text//7
                   , txtTrangThai.Checked?"1":"0"//8
                   , cbbTrangThaiDangNhap.Checked ? "1" : "0" //9                           ,                                       // , xEle.ToString()
                   , Form_Main.user.Username) + "]"; //10
                                                     //  JObject json = JObject.Parse(str);
                var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_Account_Insert", Param = str });
                string sLink = Form_Main.URL_API+  "/api/IPC247/sp_extension_SaveQuote";
                json = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                if (Result == 1)//Login thành công
                {
                    XtraMessageBox.Show(Message, "Thông Báo");
                    LoadForm();
                }
                else
                {
                    XtraMessageBox.Show("Cập Nhật Thông Tin Không Thành Công", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_NhomQuyen", "LuuThongTin()", ex.ToString()));
			}
        }

        public static string EncryptPass(string original)
        {
            return EncryptPass(original, "!@#$%^&*()~_+|");
        }

        void HuyTaiKhoan()
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_HuyUser @ID ='{0}' ", ID);
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                if (Result == 1)//Login thành công
                {
                    XtraMessageBox.Show(Message, "Thông Báo");
                }
                else
                {
                    XtraMessageBox.Show("Hủy Tài Khoản Không Thành Công", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_NhomQuyen", "HuyTaiKhoan()", ex.ToString()));
            }
        }


        #endregion Function


        #region Event


        public Form_Account()
        {
            InitializeComponent();
        }

        private void dgv_Main_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    ID = dgv_Main.GetDataRow(focus)["ID"].ToString();
                    txtUserName.Text = dgv_Main.GetDataRow(focus)["UserName"].ToString();
                    txtMatKhau.Text = dgv_Main.GetDataRow(focus)["Password"].ToString();
                    txtNhapLaiMatKhau.Text = dgv_Main.GetDataRow(focus)["Password"].ToString();
                    txtTenUser.Text = dgv_Main.GetDataRow(focus)["Name"].ToString();
                    cbbNhomQuyen.EditValue = dgv_Main.GetDataRow(focus)["RoleGroup"];
                    txtTenUser.Text = dgv_Main.GetDataRow(focus)["Name"].ToString();
                    txtDiaChi.Text = dgv_Main.GetDataRow(focus)["Address"].ToString();
                    txtEmail.Text = dgv_Main.GetDataRow(focus)["Email"].ToString();
                    txtSDT.Text = dgv_Main.GetDataRow(focus)["Phone"].ToString();
                    txtTrangThai.Checked = bool.Parse(dgv_Main.GetDataRow(focus)["Status"].ToString());
                    cbbTrangThaiDangNhap.EditValue = bool.Parse(dgv_Main.GetDataRow(focus)["IsLogin"].ToString());
                    MatKhauOld = dgv_Main.GetDataRow(focus)["Password"].ToString();
                }
            }
            catch
            {
            }
        }

        private void Form_Account_Load(object sender, EventArgs e)
        {
            LoadForm();
            dgv_Main.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }

        #endregion Event

        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                ID = "0";
                txtUserName.Text = "";
                txtMatKhau.Text = "";
                txtNhapLaiMatKhau.Text = "";
                txtTenUser.Text = "";
                cbbNhomQuyen.EditValue =null;
                txtTenUser.Text = "";
                txtDiaChi.Text = "";
                txtEmail.Text = "";
                txtSDT.Text = "";
                txtTrangThai.EditValue = true;
                MatKhauOld = "";
                cbbTrangThaiDangNhap.EditValue = false;
            }
            catch (Exception)
            {
                
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LuuThongTin();
       
        }

        private void btnHuyTK_Click(object sender, EventArgs e)
        {
            if(ID == "")
            {
                XtraMessageBox.Show("Chưa Có User Nào Được Chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if( DialogResult.Yes == (XtraMessageBox.Show("Bạn có chắc muốn hủy user này?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)))
                {
                    HuyTaiKhoan();
                }
            }
        }
    }
}