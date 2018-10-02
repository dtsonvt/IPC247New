﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Globalization;

namespace IPC247
{
    public partial class Frm_Manage_Order : DevExpress.XtraEditors.XtraForm
    {
        List<InfoCustomer> listob = new List<InfoCustomer>();
        decimal Profit = 0;
        bool Check_Save = true;
        public Frm_Manage_Order()
        {
            InitializeComponent();
        }
        private void LoadMaster_Quote()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTable("sp_getData_Quote_header");
                slk_BaoGia.Properties.DataSource = dt;
                slk_BaoGia.Properties.View.ExpandAllGroups();

            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "LoadMasterData()", ex.ToString()));
            }
        }
        private void LoadComboboxUser()
        {
            try
            {
                DataTable dt = SQLHelper.ExecuteDataTable("sp_Get_ListUser");
                slu_Saler.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "LoadComboboxUser()", ex.ToString()));
            }
        }
        private void LoadPayStatus()
        {
            try
            {
                DataTable dt = SQLHelper.ExecuteDataTable("sp_Get_PayStatus");
                slu_Paystatus.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "LoadPayStatus()", ex.ToString()));
            }
        }
        private void LoadComboboxVendor()
        {
            try
            {
                DataTable dt = SQLHelper.ExecuteDataTable("sp_get_Vendor");
                slu_Vendor.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "LoadComboboxVendor()", ex.ToString()));
            }
        }
        private void LoadBaoGiaAll(string ID)
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_GetQuote_To_Order " +
              "@ID={0}", ID);
                DataTable dt = SQLHelper.ExecuteDataTableByQuery(sql_Exect);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DateTime createOrder, PayOffDate;
                    if (dt.Rows[0]["CreateDate"].ToString() != "")
                    {
                        createOrder = DateTime.ParseExact(dt.Rows[0]["CreateDate"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        dte_CreateOrder.EditValue = createOrder;
                    }
                    txtContractNum.Text = dt.Rows[0]["ContractNum"].ToString();
                    txt_Policy.Text = dt.Rows[0]["DieuKhoan"].ToString();
                    txt_ProductCode.Text = dt.Rows[0]["ProductCode"].ToString();
                    txtCardName.Text = dt.Rows[0]["TenKH"].ToString();
                    txtAddress.Text = dt.Rows[0]["DiaChi"].ToString();
                    txtContactPerson.Text = dt.Rows[0]["ContractPerson"].ToString();
                    txtSum_CostPrice.EditValue = dt.Rows[0]["CostPrice"];
                    txtSum_Price.Text = dt.Rows[0]["TongTien"].ToString();
                    txtDeposit.Text = dt.Rows[0]["Deposit"].ToString();
                    txt_DayDebt.EditValue = dt.Rows[0]["DayDebt"];
                    if (dt.Rows[0]["PayOffDate"].ToString() != "")
                    {
                        PayOffDate = DateTime.ParseExact(dt.Rows[0]["PayOffDate"].ToString(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        dte_PayOffDate.EditValue = PayOffDate;
                    }
                    slu_Paystatus.EditValue = dt.Rows[0]["PayStatus"];
                    slu_Saler.EditValue = dt.Rows[0]["Sales"];
                    slu_Vendor.EditValue = dt.Rows[0]["VendorCode"];
                    txt_PayNote.EditValue = dt.Rows[0]["PayNote"].ToString();
                    txt_SaleNote.EditValue = dt.Rows[0]["SalesNote"].ToString();
                    decimal.TryParse(dt.Rows[0]["Profit"].ToString(),out Profit);
                    txt_Profit.EditValue = Profit;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "LoadBaoGiaAll", ex.ToString()));
            }
        }


        private void Frm_Manage_Order_Load(object sender, EventArgs e)
        {
            dte_FromDate.DateTime = DateTime.Today.AddDays(-(DateTime.Today.Day - 1));
            dte_ToDate.DateTime = DateTime.Today;
            dte_CreateOrder.DateTime = DateTime.Now;
            LoadMaster_Quote();
            LoadComboboxUser();
            LoadComboboxVendor();
            LoadPayStatus();
        }

        private void txt_DayDebt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int songay = 0;
                int.TryParse(txt_DayDebt.EditValue.ToString(), out songay);
                if (songay < 0)
                {
                    dxErrorProvider1.SetError(txt_DayDebt, "số ngày trễ thanh toán phải lớn hơn 0");
                    Check_Save = false;
                }
                else
                {
                    dte_DayofPlank.DateTime = dte_CreateOrder.DateTime.AddDays(songay);
                    dxErrorProvider1.SetError(txt_DayDebt, null);
                    Check_Save = true;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "txt_DayDebt_EditValueChanged()", ex.ToString()));
            }
        }

        private void slk_BaoGia_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int rowHandle = slk_BaoGia.Properties.GetIndexByKeyValue(slk_BaoGia.EditValue);
                object row = slk_BaoGia.Properties.View.GetRow(rowHandle);
                string ID = (row as DataRowView).Row["ID"].ToString();
                LoadBaoGiaAll(ID);
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "slk_BaoGia_EditValueChanged()", ex.ToString()));
                dgc_Main.DataSource = null;
            }
        }

        private void dte_PayOffDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int dayoflate = (dte_PayOffDate.DateTime.Date - dte_DayofPlank.DateTime.Date).Days;
                txtDayLate.EditValue = dayoflate > 0 ? dayoflate : 0;
                if (dte_PayOffDate.DateTime <= dte_CreateOrder.DateTime && dte_PayOffDate.Text != "")
                {
                    dxErrorProvider1.SetError(dte_PayOffDate, "Ngày thực tế thanh toán không được nhỏ hơn ngày tạo đơn hàng");
                    Check_Save = false;
                }
                else
                {
                    dxErrorProvider1.SetError(dte_PayOffDate, null);
                    Check_Save = true;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "dte_PayOffDate_EditValueChanged()", ex.ToString()));
            }
            
        }

        private void dte_CreateOrder_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int songay = 0;
                if (txt_DayDebt.EditValue != null)
                {
                    int.TryParse(txt_DayDebt.EditValue.ToString(), out songay);
                }
                dte_DayofPlank.DateTime = dte_CreateOrder.DateTime.AddDays(songay);
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "dte_CreateOrder_EditValueChanged()", ex.ToString()));
            }
        }

        private void txtDeposit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal deposit = 0;
                decimal.TryParse(txtDeposit.EditValue.ToString(), out deposit);
                decimal money = 0;
                if (txtSum_Price.EditValue != null)
                {
                    decimal.TryParse(txtSum_Price.EditValue.ToString(), out money);
                }
                if (deposit < 0 || deposit > money)
                {
                    dxErrorProvider1.SetError(txtDeposit, "số tiền đặt cọc phải lớn hơn 0 và không quá số tiền đơn hàng");
                    Check_Save = false;
                }
                else
                {
                    txt_Remainder.EditValue = money - deposit;
                    dxErrorProvider1.SetError(txtDeposit, null);
                    Check_Save = true;
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "txtDeposit_EditValueChanged()", ex.ToString()));
            }
        }

        private void txt_Remainder_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                decimal Remainder = 0;
                decimal.TryParse(txt_Remainder.EditValue.ToString(), out Remainder);
                decimal Deposit = 0;
                if (txtDeposit.EditValue == null)
                {
                    Deposit = 0;
                }
                else
                {
                    decimal.TryParse(txtDeposit.EditValue.ToString(), out Deposit);
                }
                if (Remainder == 0)
                {
                    slu_Paystatus.EditValue = "F";
                    dte_PayOffDate.EditValue = DateTime.Now;
                }
                else
                {
                    dte_PayOffDate.EditValue = null;
                    if (Deposit > 0)
                    {
                        slu_Paystatus.EditValue = "O";
                    }
                    else
                    {
                        slu_Paystatus.EditValue = "N";
                    }
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "txt_Remainder_EditValueChanged()", ex.ToString()));
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (slk_BaoGia.EditValue == null || slk_BaoGia.EditValue.ToString() =="")
                {
                    XtraMessageBox.Show("Bạn vui lòng chọn báo giá để tạo đơn hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if(!Check_Save)
                {
                    XtraMessageBox.Show("Bạn Vui Lòng Bổ Sung Thông Tin Còn Thiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("ID", ID_Header); //0
                param.Add("SoBaoGia", txtTenBaoGia.Text); //1
                param.Add("ToKhachHang", txtToKH.Text); //2
                param.Add("NguoiNhan", txtTenKH.Text); //3
                param.Add("Mobile_NguoiNhan", txtSDT.Text); //4
                param.Add("Tel_NguoiNhan", txtTel.Text); //5
                param.Add("NgayBaoGia", NgayBaoGia.ToString("dd/MM/yyyy")); //6
                param.Add("Email_NguoiNhan", txtEmail.Text); //7
                param.Add("VAT", txtVAT.EditValue.ToString()); //8
                param.Add("XMLSanPham", xEle.ToString());//9
                param.Add("TongTien", lst.Sum(o => o.ThanhTien).ToString());//10
                param.Add("UserID", Form_Main.user.Username);//11
                param.Add("DiaChi", txtDiaChi.Text);//12
                param.Add("DieuKhoan", txtDieuKhoan.Text);//13
                param.Add("ID_Enquiry", en.ID_Enquiry);//14
                param.Add("IDCardCode", cus.ID);//15
                param.Add("Company", com.ID);//16
                param.Add("EnquiryName", txtDuAn.Text);//17
                param.Add("EnquiryDetail", txtEnquiry.Text);//18
                param.Add("DeadLine", dteDeadLine.DateTime.ToString("dd/MM/yyyy HH:mm:ss"));//19
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTableUndefine("sp_SaveQuote", param);

                if (dt != null && dt.Rows.Count > 0)
                {
                    var Result = dt.Rows[0]["Result"].ToString();
                    var Message = dt.Rows[0]["Message"].ToString();
                    cus.ID = dt.Rows[0]["IDCardCode"].ToString();
                    com.ID = dt.Rows[0]["IDCompany"].ToString();
                    if (Result == "1")//Login thành công
                    {
                        XtraMessageBox.Show(Message, "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show("Tạo Báo Giá Không Thành Công", "Thông Báo");
                    }
                }
                else
                {
                    API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "SaveQuote()", "Không có dữ liệu trả về!"));
                }

            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_Manage_Order", "btn_Save_Click()", ex.ToString()));
            }
           

        }
    }
}