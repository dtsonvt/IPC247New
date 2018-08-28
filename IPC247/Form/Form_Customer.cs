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
using System.Web.Script.Serialization;

namespace IPC247
{
    public partial class Form_Customer : DevExpress.XtraEditors.XtraForm
    {
        #region Khởi Tạo Tham Số:
        string IDCardCode = "0";
        public Form_Customer()
        {
            InitializeComponent();
        }
        #endregion Khởi Tạo Tham Số:

        #region Function 
        private void LoadComboboxStatus()
        {
            try
            {
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_LoadMaster_Customer";
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                txtTrangThai.Properties.DataSource = dt;

            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Customer", "LoadComboboxStatus()", ex.ToString()));
            }
        }
        private void LoadComboboxCompany()
        {
            try
            {
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_GetList_Company";
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                txtCongTy.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Customer", "LoadComboboxCompany()", ex.ToString()));
            }
        }
        private void sp_Get_Customer()
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_Get_ListCustomer @Flag ='{0}' ", chkHienThi.Checked ? "1" : "0");
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                dgc_Main.DataSource = dt;
                dgv_Main.BestFitColumns(true);

            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Customer", "sp_Get_Customer()", ex.ToString()));
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
                if (string.IsNullOrEmpty(txtTenKH.Text) || txtTenKH.Text.Length < 3)
                {
                    dxErrorProvider1.SetError(txtTenKH, "Tên công ty ít nhất 3 ký tự");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtTenKH, null);
                }
                if (flag_edit)
                {
                    XtraMessageBox.Show("Vui lòng bổ sung những thông tin còn trống", "Thông Báo");
                    return;
                }
                string str = "[" +
                    string.Format(@" 
                                {{""Key"":""ID"",""value"":""{0}"",""Type"":""string""}},
                                {{""Key"":""CardName"",""value"":""{1}"",""Type"":""string""}},
                                {{""Key"":""Address"",""value"":""{2}"",""Type"":""Base64""}},
                                {{""Key"":""Company"",""value"":""{3}"",""Type"":""string""}},
                                {{""Key"":""Phone"",""value"":""{4}"",""Type"":""string""}},
                                {{""Key"":""Email"",""value"":""{5}"",""Type"":""string""}},
                                {{""Key"":""Status"",""value"":""{6}"",""Type"":""string""}},
                                {{""Key"":""User"",""value"":""{7}"",""Type"":""string""}}  ",
                    IDCardCode //0
                    , txtTenKH.Text //1
                    , Convert.ToBase64String(Encoding.UTF8.GetBytes(txtDiaChi.Text)) //2
                    , txtCongTy.EditValue.ToString() //3
                    , txtSDT.Text //4
                    , txtEmail.Text //5
                    , txtTrangThai.EditValue.ToString() //6
                    , Form_Main.user.Username //7
                ) + "]";
                //  JObject json = JObject.Parse(str);
                var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_Customer_Insert", Param = str });
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_SaveQuote";
                json = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                if (Result == 1)//Login thành công
                {
                    sp_Get_Customer();
                }
                else
                {
                    XtraMessageBox.Show("Tạo Báo Giá Không Thành Công", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Customer", "SaveInfo()", ex.ToString()));
            }
        }

        void ClearForm()
        {
            IDCardCode = "0";
            txtTenKH.Text = "";
            txtCongTy.EditValue = null;
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtTrangThai.EditValue = null;
        }

        void DeleteCustomer()
        {
            try
            {
                if (DialogResult.Yes == XtraMessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                        string sql_Exect = string.Format("Exec sp_Customer_Delete @ID ='{0}' ", del);
                        string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                        var json = API.API_GET(sLink);
                        dynamic jsondata = JObject.Parse(json);
                        var jsondataChild = jsondata.GetValue("Data");
                        var Result = jsondataChild.First.GetValue("Result").Value;
                        var Message = jsondataChild.First.GetValue("Message").Value;
                        if (Result == 1)//Login thành công
                        {
                            XtraMessageBox.Show(Message, "Thông Báo");
                            sp_Get_Customer();
                            ClearForm();
                        }
                        else
                        {
                            XtraMessageBox.Show("Hủy Khách Hàng Không Thành Công", "Thông Báo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Customer", "DeleteCustomer()", ex.ToString()));
            }
        }

        #endregion Function 

        #region Event 
        private void Form_Customer_Load(object sender, EventArgs e)
        {
            LoadComboboxStatus();
            sp_Get_Customer();
            LoadComboboxCompany();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            IDCardCode = "0";
            SaveInfo();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SaveInfo();
        }

        private void làmMớiFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void xóaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
        }

        private void dgv_Main_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    IDCardCode = dgv_Main.GetDataRow(focus)["ID"].ToString();
                    txtTenKH.Text = dgv_Main.GetDataRow(focus)["CardName"].ToString();
                    txtCongTy.EditValue =  dgv_Main.GetDataRow(focus)["Company"]; 
                    txtDiaChi.Text = dgv_Main.GetDataRow(focus)["Address"].ToString();
                    txtEmail.Text = dgv_Main.GetDataRow(focus)["Email"].ToString();
                    txtSDT.Text = dgv_Main.GetDataRow(focus)["Phone"].ToString();
                    txtTrangThai.EditValue = dgv_Main.GetDataRow(focus)["Status"];
                }
                else
                {
                    IDCardCode = "0";
                    txtTenKH.Text = "";
                    txtCongTy.EditValue = null;
                    txtDiaChi.Text = "";
                    txtEmail.Text = "";
                    txtSDT.Text = "";
                    txtTrangThai.EditValue = null;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_DoanhNghiep", "dgv_Main_RowClick()", ex.ToString()));
                IDCardCode = "0";
                txtTenKH.Text = "";
                txtCongTy.EditValue = null;
                txtDiaChi.Text = "";
                txtEmail.Text = "";
                txtSDT.Text = "";
                txtTrangThai.EditValue = null;
            }
        }
        private System.Windows.Forms.Form GetChildFormByName(string formname)
        {
            return this.Parent.FindForm().MdiChildren.FirstOrDefault(f => f.Name == formname);
        }
        private void chkHienThi_CheckedChanged(object sender, EventArgs e)
        {
            sp_Get_Customer();
        }

        private void btnThemCty_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form f = GetChildFormByName("Form_DoanhNghiep");
            if (f == null)
            {
                f = new Form_DoanhNghiep();
                f.Name = "Form_DoanhNghiep";
            //    Form_DoanhNghiep.AddNew = true;
                f.MdiParent = this.Parent.FindForm();
                f.Show();
            }
            else
            {
                f.Activate();
            }
        }
        #endregion Event 
    }
}