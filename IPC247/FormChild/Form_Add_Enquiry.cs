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
using System.Web.Script.Serialization;

namespace IPC247
{
    public partial class Form_Add_Enquiry : DevExpress.XtraEditors.XtraForm
    {
        #region Khởi Tạo Biến 

        public static string IdCardCode = "0";
        public static Enquiry en = new Enquiry();
        Company com = new Company();
        Customer cus = new Customer();
        bool flag_reload = false;

        public Form_Add_Enquiry()
        {
            InitializeComponent();
        }

        #endregion Khởi Tạo Biến 

        #region Function 

        /// <summary>
        /// load info User
        /// </summary>
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
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Add_Enquiry", "LoadComboboxUser()", ex.ToString()));
            }
        }

        private void Saveinfo()
        {
            try
            {
                #region Check Validate
                bool flag_edit = false;
                // check tên công ty
                if (string.IsNullOrEmpty(txtCongty.Text) || txtCongty.Text.Length < 3)
                {
                    dxErrorProvider1.SetError(txtCongty, "Tên công ty ít nhất 3 ký tự");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtCongty, null);
                }
                // check tên khách hàng
                if (string.IsNullOrEmpty(txtKhachHang.Text) || txtKhachHang.Text.Length < 3)
                {
                    dxErrorProvider1.SetError(txtKhachHang, "Tên công ty ít nhất 3 ký tự");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtKhachHang, null);
                }
                // check tên dự án
                if (string.IsNullOrEmpty(txtEnquiry.Text) || txtEnquiry.Text.Length < 3)
                {
                    dxErrorProvider1.SetError(txtEnquiry, "Tên công ty ít nhất 3 ký tự");
                    flag_edit = true;
                }
                else
                {
                    dxErrorProvider1.SetError(txtEnquiry, null);
                }

                if (flag_edit)
                {
                    XtraMessageBox.Show("Vui lòng bổ sung những thông tin còn trống", "Thông Báo");
                    return;
                }
                #endregion Check Validate
                #region Lưu thông tin header
                string str = "[" +
                    string.Format(@" 
                                {{""Key"":""IDRequest"",""value"":""{0}"",""Type"":""string""}},
                                {{""Key"":""IDCardCode"",""value"":""{1}"",""Type"":""string""}},
                                {{""Key"":""Company"",""value"":""{2}"",""Type"":""string""}},
                                {{""Key"":""CompanyName"",""value"":""{3}"",""Type"":""string""}},
                                {{""Key"":""Description"",""value"":""{4}"",""Type"":""string""}},
                                {{""Key"":""SDT"",""value"":""{5}"",""Type"":""string""}},
                                {{""Key"":""Email"",""value"":""{6}"",""Type"":""string""}},
                                {{""Key"":""User"",""value"":""{7}"",""Type"":""string""}} ,
                                {{""Key"":""ID_Enquiry"",""value"":""{8}"",""Type"":""string""}} ,
                                {{""Key"":""EnquiryName"",""value"":""{9}"",""Type"":""string""}} ,
                                {{""Key"":""Curator"",""value"":""{10}"",""Type"":""string""}},
                                {{""Key"":""CardName"",""value"":""{11}"",""Type"":""string""}}",
                    en.ID_Request //0
                    , cus.ID //1
                    , com.ID //2
                    , txtCongty.Text //3
                    , txtMoTa.Text  //4
                    , txtSDT.Text //5
                    , txtEmail.Text //6
                    , Form_Main.user.Username //7
                    , en.ID_Enquiry //8
                    , txtEnquiry.Text//9
                    , txtPhuTrach.EditValue //10
                    , txtKhachHang.Text //11
                ) + "]";
                //  JObject json = JObject.Parse(str);
                var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_Enquiry_Insert", Param = str });
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_SaveQuote";
                json = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var ID_Enquiry = jsondataChild.First.GetValue("ID_Enquiry").Value;
                var Company = jsondataChild.First.GetValue("Company").Value;
                var IDCardCode = jsondataChild.First.GetValue("IDCardCode").Value;
                if (Result == 1)//Login thành công
                {
                    if (ID_Enquiry != "0")
                    {
                        en.ID_Enquiry = ID_Enquiry;
                        en.CardCode = IDCardCode;
                        en.CompanyCode = Company;
                        PushInfo();
                        this.Close();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lưu Thông Tin Không Thành Công", "Thông Báo");
                }

                #endregion lưu thông tin header
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Add_Enquiry", "Saveinfo()", ex.ToString()));
            }
        }
        /// <summary>
        /// push info form to form
        /// </summary>
        private void PushInfo()
        {
            Enquiry ennew = new Enquiry();
            ennew.CardName = txtKhachHang.Text;
            ennew.ID_Enquiry = en.ID_Enquiry;
            ennew.SDT = txtSDT.Text;
            ennew.Curator = txtPhuTrach.EditValue.ToString();
            ennew.Email = txtEmail.Text;
            ennew.EnquiryName = txtEnquiry.Text;
            ennew.ID_Request = en.ID_Request;
            ennew.Description = txtMoTa.Text;
            ennew.CompanyName = txtCongty.Text;
            en = new Enquiry(ennew);
            Form_Enquiry.en = new Enquiry(ennew);
        }

        #endregion Function 

        #region Event
        /// <summary>
        /// Load info 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Add_Enquiry_Load(object sender, EventArgs e)
        {
            LoadComboboxUser();
            txtPhuTrach.EditValue = Form_Main.user.Username;
        }
        /// <summary>
        /// Press ESC Exit form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }
        /// <summary>
        /// search info Enquiry 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomer_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form_Search_Enquiry search_Enquiry = new Form_Search_Enquiry();
            search_Enquiry.FormClosed += Search_Enquiry_FormClosed;
            search_Enquiry.ShowDialog();
        }
        /// <summary>
        /// Closed Form Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Enquiry_FormClosed(object sender, FormClosedEventArgs e)
        {
            en = new Enquiry(Form_Search_Enquiry.en);
            if (en != null)
            {
                flag_reload = true;
                txtEnquiry.Text = en.EnquiryName;
                txtCongty.Text = en.CompanyName;
                txtKhachHang.Text = en.CardName;
                txtPhuTrach.EditValue = en.Curator;
                txtSDT.Text = en.SDT;
                txtEmail.Text = en.Email;
                txtMoTa.Text = en.Description;
                cus.ID = en.CardCode;
                com.ID = en.CompanyCode;
                flag_reload = false;
            }
            else
            {
                flag_reload = true;
                txtEnquiry.Text = "";
                txtCongty.Text = "";
                txtKhachHang.Text = "";
                txtPhuTrach.EditValue = null;
                txtSDT.Text = "";
                txtEmail.Text = "";
                txtMoTa.Text = "";
                cus.ID = "0";
                com.ID = "0";
                flag_reload = false;
            }
            btnChonvsThoat.Enabled = true;
        }
        /// <summary>
        /// search info Company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCongty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form_Search_Company search_Company = new Form_Search_Company();
            search_Company.FormClosed += Search_Company_FormClosed;
            search_Company.ShowDialog();
        }
        /// <summary>
        /// Closed Form Search Company
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            com = new Company(Form_Search_Company.com);
            if (com != null)
            {
                txtCongty.Text = com.CompanyName;
                txtMoTa.Text = com.Description;
                txtKhachHang.Text = "";
                txtSDT.Text = "";
                txtEmail.Text = "";
            }
        }
        /// <summary>
        /// Form Search Info Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKhachHang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form_Search_Customer search_Customer = new Form_Search_Customer();
            search_Customer.FormClosed += Search_Customer_FormClosed;
            search_Customer.ShowDialog();
        }
        /// <summary>
        /// Closed Form Search Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            cus = new Customer(Form_Search_Customer.cus);
            com = new Company(Form_Search_Customer.com);
            if (cus != null)
            {
                txtKhachHang.Text = cus.CardName;
                txtEmail.Text = cus.Email;
                txtSDT.Text = cus.Phone;
            }
            if (com != null)
            {
                txtCongty.Text = com.CompanyName;
                txtMoTa.Text = com.Description;
            }
        }

        /// <summary>
        /// Create New Record 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            en.ID_Request = "0";
            Saveinfo();
        }

        /// <summary>
        /// Update Record!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            Saveinfo();
        }

        private void btnChonvsThoat_Click(object sender, EventArgs e)
        {
            PushInfo();
            this.Close();
        }

        private void txtEnquiry_EditValueChanged(object sender, EventArgs e)
        {
            btnChonvsThoat.Enabled = false;
        }
        /// <summary>
        /// changed info name set new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCongty_EditValueChanged(object sender, EventArgs e)
        {
            btnChonvsThoat.Enabled = false;
            if (!flag_reload)
            {
                com.ID = "0";
            }
        }
        /// <summary>
        /// changed info name set new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            btnChonvsThoat.Enabled = false;
            if (!flag_reload)
            {
                cus.ID = "0";
            }
        }

        private void txtPhuTrach_EditValueChanged(object sender, EventArgs e)
        {
            btnChonvsThoat.Enabled = false;
        }

        private void txtSDT_EditValueChanged(object sender, EventArgs e)
        {
            btnChonvsThoat.Enabled = false;
        }

        private void txtEmail_EditValueChanged(object sender, EventArgs e)
        {
            btnChonvsThoat.Enabled = false;
        }

        private void txtMoTa_EditValueChanged(object sender, EventArgs e)
        {
            btnChonvsThoat.Enabled = false;
        }
        #endregion Event
    }
}
