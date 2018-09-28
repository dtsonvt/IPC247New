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
using DevExpress.XtraSplashScreen;
using System.Collections;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Web.Script.Serialization;

namespace IPC247
{
	public partial class Form_Quote : DevExpress.XtraEditors.XtraForm
	{
		#region Khai Báo
		List<InfoReportDetails> lst = new List<InfoReportDetails>();
		public static InfoCustomer QuoteChoose = new InfoCustomer();
		string ID = "";
		string ID_Header = "";
		DateTime NgayBaoGia = DateTime.Now;
		decimal ProfitValue = 0;
		decimal ProfitValue_MAX = 0;
		decimal HeSoBienDoi = 5;
		decimal CostPrice = 0;
		int _IsGroup = 0;

        Enquiry en = new Enquiry();
        Company com = new Company();
        Customer cus = new Customer();
        bool flag_edit = false;
        bool flag_edit_Customer = false;
        bool flag_edit_Company = false;
        #endregion

        #region Function
        public Form_Quote()
		{
			InitializeComponent();
		}

		private void LoadSoBaoGia()
		{
			try
			{
                //string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_Quote_GenKey";
                //var json = API.API_GET_Rep(sLink);

                //var jsondata = JObject.Parse(json).GetValue("Data");
                //DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                DataTable dt = SQLHelper.ExecuteDataTableByQuery("sp_Quote_GenKey");
                if(dt!=null && dt.Rows.Count > 0)
                {
                    txtTenBaoGia.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "LoadSoBaoGia()","không có data "));
                }
            }
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "LoadSoBaoGia()", ex.ToString()));
			}
		}

		private void LoadControlProduct()
		{
            try
            {
                //	string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_Get_Product";
                //	var json = API.API_GET_Rep(sLink);

                //	var jsondata = JObject.Parse(json).GetValue("Data");
                //	DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTable("sp_Get_Product");
                searchSP.Properties.DataSource = dt;

                LoadSoBaoGia();
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "LoadControlProduct()", ex.ToString()));
            }
		}
		private void TinhTien()
		{
			try
			{
				int sl = int.Parse(txtSoLuong.EditValue.ToString());

				decimal dongia = 0;
				decimal.TryParse(txtDonGia.EditValue.ToString(), out dongia);

				int ChietKhau = 0;
				int.TryParse(txtPTChietKhau.EditValue.ToString(), out ChietKhau);

				decimal tyle = 100; decimal khautru = 0;
				khautru = (ChietKhau / tyle) * decimal.Parse(dongia.ToString());
				//flag_Money = true;
				//txtTienChietKhau.EditValue = khautru;
				//flag_Money = false;

				txtThanhTien.EditValue = sl * (dongia - khautru);
			}
			catch
			{
				txtThanhTien.EditValue = 0;
			}
		}

		// Lưu báo Giá
		private void SaveQuote()
		{
			try
			{
				if (lst.Count == 0)
				{
					XtraMessageBox.Show("Danh sách sản phẩm chưa có sản phẩm nào!", "Thông Báo");
					return;
				}
				if (lst.Exists(o => o.Status == 0))
				{
					XtraMessageBox.Show("Trong báo giá có ít nhất một sản phẩm không còn bán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}
                /// thêm ràng buộc: nếu đã chọn dự án thì bắt buộc phải có yêu cầu từ dự án đó
                /// nếu đã đủ ràng buộc sẽ lưu thông tin Enquiry trước
                if(txtDuAn.Text.Length > 0)
                {
                    if(txtEnquiry.Text.Length == 0 || dteDeadLine.Text.Length == 0)
                    {
                        XtraMessageBox.Show("Dự án phải có yêu cầu và DeadLine theo dự án đó", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
               
				var xEle = new XElement("line",
				from emp in lst
				select new XElement("item",
							 new XAttribute("ID", emp.ID),
							   new XAttribute("MaSP", emp.MaSP),
							   new XAttribute("TenHang", emp.TenHang),
							   new XAttribute("MoTa", emp.MoTaHangHoa),
							   new XAttribute("DonGia", emp.DonGia),
							   new XAttribute("Quantity", emp.SoLuong),
							   new XAttribute("ChietKhau", emp.ChietKhau),
							   new XAttribute("ThanhTien", emp.ThanhTien),
							   new XAttribute("Profit", emp.Profit),
							   new XAttribute("CostPrice", emp.CostPrice),
							   new XAttribute("IsGroup", emp.IsGroup)
						   ));

				string A = xEle.ToString();
				if (ID_Header == "")
				{
					ID_Header = "0";
				}
                //   return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, Data = ConvertDataTableToListObject(dt) });
                // };
                //				string str = "[" +
                //					string.Format(@" {{""Key"":""ID"",""value"":""{0}"",""Type"":""string""}},{{""Key"":""SoBaoGia"",""value"":""{1}"",""Type"":""string""}},
                //{{""Key"":""ToKhachHang"",""value"":""{2}"",""Type"":""string""}},{{""Key"":""NguoiNhan"",""value"":""{3}"",""Type"":""string""}},{{""Key"":""Mobile_NguoiNhan"",""value"":""{4}"",""Type"":""string""}},
                //{{""Key"":""Tel_NguoiNhan"",""value"":""{5}"",""Type"":""string""}},{{""Key"":""NgayBaoGia"",""value"":""{6}"",""Type"":""string""}},{{""Key"":""Email_NguoiNhan"",""value"":""{7}"",""Type"":""string""}},{{""Key"":""VAT"",""value"":""{8}"",""Type"":""string""}},
                //{{""Key"":""XMLSanPham"",""value"":""{9}"",""Type"":""Base64""}},{{""Key"":""TongTien"",""value"":""{10}"",""Type"":""string""}},{{""Key"":""UserID"",""value"":""{11}"",""Type"":""string""}},{{""Key"":""DiaChi"",""value"":""{12}"",""Type"":""string""}},{{""Key"":""DieuKhoan"",""value"":""{13}"",""Type"":""string""}},{{""Key"":""ID_Enquiry"",""value"":""{14}"",""Type"":""string""}},{{""Key"":""IDCardCode"",""value"":""{15}"",""Type"":""string""}},{{""Key"":""Company"",""value"":""{16}"",""Type"":""string""}} "
                //                    , ID_Header //0
                //					, txtTenBaoGia.Text //1
                //					, txtToKH.Text //2
                //					, txtTenKH.Text //3
                //					, txtSDT.Text //4
                //					, txtTel.Text //5
                //					, NgayBaoGia.ToString("dd/MM/yyyy") // 6
                //					, txtEmail.Text //7
                //					, txtVAT.EditValue.ToString() //8
                //					, Convert.ToBase64String(Encoding.UTF8.GetBytes(xEle.ToString())) //9
                //					, lst.Sum(o => o.ThanhTien).ToString() //10
                //					, Form_Main.user.Username //11
                //					, txtDiaChi.Text //12
                //					, txtDieuKhoan.Text //13
                //                    , en.ID_Enquiry //14
                //                    , cus.ID //15
                //                    , com.ID //16
                //                    ) + "]";
                //				//  JObject json = JObject.Parse(str);
                //				var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_SaveQuote", Param = str });
                //				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_SaveQuote";
                //				json = API.API_POS(sLink, json);
                //				dynamic jsondata = JObject.Parse(json);
                //				var jsondataChild = jsondata.GetValue("Data");
                //				var Result = jsondataChild.First.GetValue("Result").Value;
                //				var Message = jsondataChild.First.GetValue("Message").Value;
                //                cus.ID = jsondataChild.First.GetValue("IDCardCode").Value.ToString();
                //                com.ID = jsondataChild.First.GetValue("IDCompany").Value.ToString();

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

                if(dt!= null && dt.Rows.Count > 0)
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
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "SaveQuote()", ex.ToString()));
			}
		}
		private void PrintBaoGia()
		{
			try
			{
				int i = 1;
				List<InfoCustomerPrint> list = new List<InfoCustomerPrint>();
				foreach (InfoReportDetails item in lst)
				{
					InfoCustomerPrint header = new InfoCustomerPrint();
					if (i == 1)
					{
						header.TenCongTy = Form_Main.info.TenCongTy;
						header.DiaChi = Form_Main.info.DiaChi;
						header.NguoiGui = Form_Main.user.Name;
						header.Mobile = Form_Main.user.Phone;
						header.Email = Form_Main.user.Email;
						header.Email_NguoiNhan = txtEmail.Text;
						header.ToKhachHang = txtToKH.Text;
						header.DiaChiKhachHang = txtDiaChi.Text;
						header.NguoiNhan = txtTenKH.Text;
						header.Mobile_NguoiNhan = txtSDT.Text;
						header.Tel_NguoiNhan = txtTel.Text;
						header.Email_NguoiNhan = txtEmail.Text;
					}
					header.TongTien = lst.Sum(o => o.ThanhTien);
					header.VAT = int.Parse(txtVAT.EditValue.ToString());
					header.DieuKhoanHopDong = txtDieuKhoan.Text;
					header.NgayBaoGia = DateTime.Today.ToString("dd/MM/yyyy");
					header.SoBaoGia = txtTenBaoGia.Text;
					header.STT = i.ToString(); i++;
					header.TenHang = item.TenHang;
					header.DonGia = item.DonGiaKhauTru;
					header.SoLuong = item.SoLuong.ToString();
					header.ThanhTien = item.ThanhTien;
					header.MoTaHangHoa = item.MoTaHangHoa;

					list.Add(header);
				}
				Frm_Print frmbill = new Frm_Print();

				frmbill.Print(list);
				frmbill.ShowDialog();
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "PrintBaoGia()", ex.ToString()));
			}
		}

		void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
		{
			if (!dgv_BaoGia.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
					BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_BaoGia); })); //Tăng kích thước nếu Text vượt quá
				}
			}
			else
			{
				e.Info.ImageIndex = -1;
				e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
				SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
				Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
				BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_BaoGia); }));
			}
		}
		bool cal(Int32 _Width, GridView _View)
		{
			_View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
			return true;
		}

		#endregion Function

		#region Event

		private void Form_Quote_Load(object sender, EventArgs e)
		{
			//SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang thực hiện thao tác...");
			
			dgv_BaoGia.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
			//SplashScreenManager.CloseDefaultWaitForm();
		}

		private void searchSP_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				int rowHandle = searchSP.Properties.GetIndexByKeyValue(searchSP.EditValue);
				object row = searchSP.Properties.View.GetRow(rowHandle);
				if (row == null)
				{
					flag_edit = true;
					txtMaSP.Text = "";
					txtTenSanPham.Text = "";
					txtDonGia.EditValue = 0;
					txtMoTa.Text = "";
					ProfitValue = 0;
					txtPTChietKhau.EditValue = 0;
					txtTienChietKhau.EditValue = 0;
					txtDonGiaNew.EditValue = 0;
					ProfitValue_MAX = 0;
					flag_edit = false;
					txtProfit.EditValue = 0;
					_IsGroup = 0;
				}
				else
				{
					flag_edit = true;
					txtMaSP.Text = (row as DataRowView).Row["ProductCode"].ToString();
					txtTenSanPham.Text = (row as DataRowView).Row["ProductName"].ToString();
					txtDonGia.EditValue = (row as DataRowView).Row["Price"].ToString();
					txtMoTa.Text = (row as DataRowView).Row["Description"].ToString();
					ProfitValue = decimal.Parse((row as DataRowView).Row["Profit"].ToString());
					ProfitValue_MAX = ProfitValue;
					CostPrice = decimal.Parse((row as DataRowView).Row["CostPrice"].ToString());
					_IsGroup = int.Parse((row as DataRowView).Row["IsGroup"].ToString());
					// thiết lập profit:
					txtProfit.Properties.MinValue = 0;
					
					decimal dongia;
					decimal.TryParse(txtDonGia.EditValue.ToString(), out dongia);
					// set max values không được vượt quá lợi nhuận
					txtTienChietKhau.Properties.MaxValue = dongia - CostPrice;
					txtTienChietKhau.Properties.MinValue = -dongia;
					txtPTChietKhau.Properties.MaxValue = ProfitValue;
					txtPTChietKhau.Properties.MinValue = -100;
					txtDonGiaNew.Properties.MinValue = CostPrice;
					txtDonGiaNew.Properties.MaxValue = dongia * 2;
					txtPTChietKhau.EditValue = 0;
					txtTienChietKhau.EditValue = 0;
					txtDonGiaNew.EditValue = dongia;
					flag_edit = false;
					txtProfit.EditValue = ProfitValue * HeSoBienDoi;
				}
			}
			catch (Exception)
			{
				flag_edit = true;
				txtMaSP.Text = "";
				txtTenSanPham.Text = "";
				txtDonGia.EditValue = 0;
				txtMoTa.Text = "";
				txtPTChietKhau.EditValue = 0;
				ProfitValue = 0;
				txtPTChietKhau.EditValue = 0;
				txtTienChietKhau.EditValue = 0;
				txtDonGiaNew.EditValue = 0;
				_IsGroup = 0;
				flag_edit = false;
				txtProfit.EditValue = 0;
			}
		}

		private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
		{
			decimal dongia;
			decimal quantity;
			decimal.TryParse(txtDonGiaNew.EditValue.ToString(), out dongia);
			decimal.TryParse(txtSoLuong.EditValue.ToString(), out quantity);
			txtThanhTien.EditValue = dongia * quantity;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				InfoReportDetails ob = new InfoReportDetails();
				ob.MaSP = txtMaSP.Text;
				if (ob.MaSP == "")
				{
					XtraMessageBox.Show("Vui lòng chọn sản phẩm", "Thông Báo");
					return;
				}
                if(lst== null)
                {
                    lst = new List<InfoReportDetails>();
                }
				ob.ID = (lst.Count + 1).ToString();
				ID = (lst.Count + 1).ToString();
				ob.TenHang = txtTenSanPham.Text;
				ob.DonGia = decimal.Parse(txtDonGia.EditValue.ToString());
				ob.SoLuong = int.Parse(txtSoLuong.EditValue.ToString());
				ob.IsGroup = _IsGroup;
				ob.ChietKhau = decimal.Parse(txtTienChietKhau.EditValue.ToString());
				ob.Profit = decimal.Parse(txtProfit.EditValue.ToString());
				ob.CostPrice = CostPrice;
				ob.Status = 1;
				ProfitValue = ob.Profit;

				ob.MoTaHangHoa = txtMoTa.Text;
				lst.Add(ob);
				if (lst.Exists(o => o.Status == 0))
				{
					dgv_BaoGia.OptionsView.EnableAppearanceOddRow = false;
				}
				else
				{
					dgv_BaoGia.OptionsView.EnableAppearanceOddRow = true;
				}
				dgc_BaoGia.DataSource = lst;
				dgv_BaoGia.RefreshData();
				dgv_BaoGia.BestFitColumns(true);
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "btnAdd_Click", ex.ToString()));
			}
		}

		private void dgv_BaoGia_RowClick(object sender, RowClickEventArgs e)
		{
			try
			{
				int focus = dgv_BaoGia.FocusedRowHandle;
				if (focus >= 0)
				{
					InfoReportDetails ob = (InfoReportDetails)dgv_BaoGia.GetFocusedRow();
					if (ob != null)
					{
						// thiết lập lại profit:
						flag_edit = true;
						decimal PTChietKhau, tienChietKhauMax, tyle = 100;
						PTChietKhau = ob.DonGia == 0 ? 0 : (ob.ChietKhau * tyle) / ob.DonGia;
						ProfitValue = Math.Round(ob.Profit / HeSoBienDoi + PTChietKhau, 2);
						CostPrice = ob.CostPrice;
						tienChietKhauMax = (ProfitValue * ob.DonGia) / tyle;
						txtProfit.Properties.MinValue = 0;
						txtProfit.EditValue = ob.Profit;
						txtPTChietKhau.Properties.MaxValue = ProfitValue;
						ProfitValue_MAX = ProfitValue;
						txtPTChietKhau.Properties.MinValue = -100;
						txtTienChietKhau.Properties.MaxValue = tienChietKhauMax;
						txtTienChietKhau.Properties.MinValue = -ob.DonGia;
						txtDonGiaNew.Properties.MinValue = ob.DonGia - tienChietKhauMax;
						txtDonGiaNew.Properties.MaxValue = ob.DonGia * 2;
						txtPTChietKhau.EditValue = PTChietKhau;
						txtTienChietKhau.EditValue = ob.ChietKhau;
						txtDonGiaNew.EditValue = ob.DonGia - ob.ChietKhau;
						_IsGroup = ob.IsGroup;
						ID = ob.ID;
						txtMaSP.Text = ob.MaSP;
						txtTenSanPham.Text = ob.TenHang;
						txtMoTa.Text = ob.MoTaHangHoa;
						txtDonGia.EditValue = ob.DonGia;
						txtSoLuong.EditValue = ob.SoLuong;
						flag_edit = false;
					}
				}
			}
			catch (Exception ex)
			{
				ID = "0";
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "dgv_BaoGia_RowClick", ex.ToString()));
			}
		}

		private void btnCapNhat_Click(object sender, EventArgs e)
		{
			try
			{
				InfoReportDetails ob = lst.Find(o => o.ID == ID);
				if (ob != null)
				{
					ob.MaSP = txtMaSP.Text;
					ob.TenHang = txtTenSanPham.Text;
					ob.MoTaHangHoa = txtMoTa.Text;
					//   ob.ThanhTien = decimal.Parse(txtThanhTien.EditValue.ToString());
					ob.ChietKhau = decimal.Parse(txtTienChietKhau.EditValue.ToString());
					ob.DonGia = decimal.Parse(txtDonGia.EditValue.ToString());
					ob.SoLuong = int.Parse(txtSoLuong.EditValue.ToString());
					ob.Profit = decimal.Parse(txtProfit.EditValue.ToString());
					ob.IsGroup = _IsGroup;
					ob.Status = 1;
					// ob.MoneyProfit = decimal.Parse(txtTienLoiNhuan.EditValue.ToString());
				}
				if (lst.Exists(o => o.Status == 0))
				{
					dgv_BaoGia.OptionsView.EnableAppearanceOddRow = false;
				}
				else
				{
					dgv_BaoGia.OptionsView.EnableAppearanceOddRow = true;
				}
				dgv_BaoGia.RefreshData();
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "btnCapNhat_Click", ex.ToString()));
			}
		}

		private void xóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogResult result = XtraMessageBox.Show("Bạn Có muốn Xóa Những Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo);
			if (result == DialogResult.No)
			{
				return;
			}
			// Create an empty list.
			try
			{
				List<InfoReportDetails> lstdel = new List<InfoReportDetails>();
				// Add the selected rows to the list.
				for (int i = 0; i < dgv_BaoGia.SelectedRowsCount; i++)
				{
					InfoReportDetails ob = (InfoReportDetails)dgv_BaoGia.GetRow(dgv_BaoGia.GetSelectedRows()[i]);
					lstdel.Add(ob);
				}
				if (dgv_BaoGia.SelectedRowsCount == 0)
				{
					XtraMessageBox.Show("Không có thông tin nào được chọn để xóa! Vui lòng chọn dữ liệu để thao tác", "Thông Tin");
					return;
				}
				else
				{
					foreach (InfoReportDetails item in lstdel)
					{
						lst.Remove(item);
					}
					dgv_BaoGia.RefreshData();
				}
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "xóaSảnPhẩmToolStripMenuItem_Click", ex.ToString()));
			}
		}

		private void btnTaoBaoGia_Click(object sender, EventArgs e)
		{
			SaveQuote();
		}

		private void btnTimBaoGia_Click(object sender, EventArgs e)
		{
			Form_TimKiemBaoGia frm = new Form_TimKiemBaoGia();
			frm.FormClosed += Frm_FormClosed_TimKiem;
			frm.ShowDialog();
		}

		private void Frm_FormClosed_TimKiem(object sender, FormClosedEventArgs e)
		{
			try
			{
				if (QuoteChoose != null)
				{
					DialogResult result = XtraMessageBox.Show("Dữ Liệu bạn đang thao tác bạn có chắc muốn tải lại báo giá khác", "Thông Báo", MessageBoxButtons.YesNo);
					if (result == DialogResult.No)
					{
						return;
					}
					else
					{
						// txtTenBaoGia.Text = QuoteChoose.SoBaoGia;
						LoadSoBaoGia();
                        flag_edit_Company = true;
                        flag_edit_Customer = true;
						txtToKH.Text = QuoteChoose.ToKhachHang;
						txtTenKH.Text = QuoteChoose.NguoiNhan;
						txtDiaChi.Text = QuoteChoose.DiaChiKhachHang;
						txtSDT.Text = QuoteChoose.Mobile_NguoiNhan;
						txtEmail.Text = QuoteChoose.Email_NguoiNhan;
						txtTel.Text = QuoteChoose.Tel_NguoiNhan;
						txtVAT.EditValue = QuoteChoose.VAT;
                        txtDuAn.Text = QuoteChoose.EnquiryName;
						dgc_BaoGia.DataSource = QuoteChoose.DSSanPham;
                        flag_edit_Company = false;
                        flag_edit_Customer = false;
                        cus.ID = QuoteChoose.IDCardCode;
                        com.ID = QuoteChoose.IDCompany;
						if (!string.IsNullOrEmpty(QuoteChoose.DieuKhoan))
						{
							txtDieuKhoan.Text = QuoteChoose.DieuKhoan;
						}
						else
						{
							txtDieuKhoan.EditValue = "+ Thanh toán 100% trước khi giao hàng.\r\n + Thanh toán bằng VNĐ theo tỷ giá USD tại Vietcombank tại ngày xuất hóa đơn.";
						}
						ID_Header = "0";
						// load dữ liệu print
						#region load dữ liệu print
						lst = QuoteChoose.DSSanPham;
						if (lst!= null && lst.Exists(o => o.Status == 0))
						{
							dgv_BaoGia.OptionsView.EnableAppearanceOddRow = false;
						}
						else
						{
							dgv_BaoGia.OptionsView.EnableAppearanceOddRow = true;
						}
						
						#endregion load dữ liệu print
						dgv_BaoGia.BestFitColumns(true);
					}
				}
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "Frm_FormClosed_TimKiem()", ex.ToString()));
			}
		}

		private void btnInBaoGia_Click(object sender, EventArgs e)
		{
			if (lst.Exists(o => o.Status == 0))
			{
				XtraMessageBox.Show("Trong báo giá có ít nhất một sản phẩm không còn bán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			PrintBaoGia();
		}

		private void inBáoGiáToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrintBaoGia();
		}


		private void txtChietKhau_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (flag_edit)
				{
					return;
				}
				flag_edit = true;
				decimal pt, dongia, tienchietkhau, tyle, dongianew;
				tyle = 100;
				decimal.TryParse(txtPTChietKhau.EditValue.ToString(), out pt);
				decimal.TryParse(txtDonGia.EditValue.ToString(), out dongia);
				tienchietkhau = dongia * (pt / tyle);
				txtTienChietKhau.EditValue = tienchietkhau;
				dongianew = dongia - tienchietkhau;
				txtDonGiaNew.EditValue = dongianew;
				if (dongianew == 0)
				{
					ProfitValue = 0;
				}
				else
				{
					if (pt == ProfitValue_MAX)
					{
						ProfitValue = 0;
					}
					else
					{
						ProfitValue = Math.Round(((dongianew - CostPrice) / dongianew) * tyle, 2);
					}
				}
				txtProfit.EditValue = (ProfitValue) * HeSoBienDoi;
				flag_edit = false;
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "txtChietKhau_EditValueChanged()", ex.ToString()));
			}
		}

		private void txtChietKhauTien_EditValueChanged(object sender, EventArgs e)
		{
			if (flag_edit)
			{
				return;
			}
			try
			{
				flag_edit = true;
				decimal pt, dongia, tienchietkhau, tyle, dongianew;
				tyle = 100;
				decimal.TryParse(txtTienChietKhau.EditValue.ToString(), out tienchietkhau);
				decimal.TryParse(txtDonGia.EditValue.ToString(), out dongia);
				if (dongia != 0)
				{
					if (tienchietkhau == dongia)
					{
						pt = ProfitValue;
					}
					else
					{
						pt = (tienchietkhau / dongia) * tyle;
					}
				}
				else
				{
					pt = 0;
				}
				txtPTChietKhau.EditValue = pt;
				txtDonGiaNew.EditValue = dongia - tienchietkhau;
				dongianew = dongia - tienchietkhau;
				txtDonGiaNew.EditValue = dongianew;
				if (dongianew != 0)
				{
					ProfitValue = Math.Round(((dongianew - CostPrice) / dongianew) * tyle, 2);
				}
				else
				{
					ProfitValue = 0;
				}
				flag_edit = false;
				txtProfit.EditValue = (ProfitValue) * HeSoBienDoi;

			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "txtChietKhauTien_EditValueChanged()", ex.ToString()));
			}
		}

		#endregion Event

		private void txtDonGiaNew_EditValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (flag_edit)
				{
					return;
				}
				flag_edit = true;
				decimal dongianew, dongia, tyle = 100, pt;
				decimal quantity;
				decimal.TryParse(txtDonGiaNew.EditValue.ToString(), out dongianew);
				decimal.TryParse(txtSoLuong.EditValue.ToString(), out quantity);
				decimal.TryParse(txtDonGia.EditValue.ToString(), out dongia);
				txtThanhTien.EditValue = dongianew * quantity;
				txtTienChietKhau.EditValue = dongia - dongianew;
				if (dongia == 0)
				{
					pt = 0;
				}
				else
				{
					pt = Math.Round(((dongia - dongianew) / dongia) * tyle, 2);
				}
				txtPTChietKhau.EditValue = pt;
				if (dongianew == 0)
				{
					ProfitValue = 0;
				}
				else
				{
					ProfitValue = Math.Round(((dongianew - CostPrice) / dongianew) * tyle, 2);
				}
				flag_edit = false;
				txtProfit.EditValue = (ProfitValue) * HeSoBienDoi;
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Quote", "txtDonGiaNew_EditValueChanged()", ex.ToString()));
			}
		}

		private void txtDonGiaNew_TextChanged(object sender, EventArgs e)
		{
			decimal dongianew;
			decimal quantity;
			decimal.TryParse(txtDonGiaNew.EditValue.ToString(), out dongianew);
			decimal.TryParse(txtSoLuong.EditValue.ToString(), out quantity);
			txtThanhTien.EditValue = dongianew * quantity;
		}

		private void dgv_BaoGia_RowStyle(object sender, RowStyleEventArgs e)
		{
			GridView View = sender as GridView;
			if (e.RowHandle >= 0)
			{
				string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Status"]);
				if (category == "0")
				{
					e.Appearance.BackColor = Color.Salmon;
					e.Appearance.BackColor2 = Color.SeaShell;
				}
				else
				{
					e.Appearance.BackColor = Color.White;
				}
			}
		}

		private void btnLamMoi_Click(object sender, EventArgs e)
		{
			searchSP.EditValue = null;
			txtDiaChi.Text = "";
			txtEmail.Text = "";
			txtTenKH.Text = "";
			txtSDT.Text = "";
			txtTel.Text = "";
			txtToKH.Text = "";
			LoadSoBaoGia();
			lst = new List<InfoReportDetails>();
			dgc_BaoGia.DataSource = lst;
			dgv_BaoGia.RefreshData();
			dgv_BaoGia.BestFitColumns(true);
		}

		private void txtProfit_EditValueChanged(object sender, EventArgs e)
		{
			decimal dongia, profit;
			decimal.TryParse(txtDonGia.EditValue.ToString(), out dongia);
			decimal.TryParse(txtProfit.EditValue.ToString(), out profit);

			if (profit < 0)
			{
				txtTienChietKhau.EditValue = dongia - CostPrice;
			}
		}

        private void txtTenKH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                flag_edit_Customer = true;
                flag_edit_Company = true;
                txtToKH.Text = cus.CompanyName;
                txtEmail.Text = cus.Email;
                txtSDT.Text = cus.Phone;
                txtTenKH.Text = cus.CardName;
                txtDiaChi.Text = cus.Address;
                flag_edit_Customer = false;
                flag_edit_Company = false;
            }
        }

        private void txtDuAn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form_Add_Enquiry search_Enquiry = new Form_Add_Enquiry();
            search_Enquiry.FormClosed += Search_Enquiry_FormClosed;
            search_Enquiry.ShowDialog();
        }
        private void Search_Enquiry_FormClosed(object sender, FormClosedEventArgs e)
        {
            en = new Enquiry(Form_Search_Enquiry.en);
            if (en != null && en.EnquiryName != "")
            {
                txtDuAn.Text = en.EnquiryName;
                flag_edit_Customer = true;
                flag_edit_Company = true;
                txtToKH.Text = en.CompanyName;
                txtEmail.Text = en.Email;
                txtSDT.Text = en.SDT;
                txtTenKH.Text = en.CardName;
                txtDiaChi.Text = en.Address_Cus;
                cus.ID = en.CardCode;
                com.ID = en.CompanyCode;
                flag_edit_Customer = false;
                flag_edit_Company = false;
            }
        }

        private void txtTenKH_EditValueChanged(object sender, EventArgs e)
        {
            if(!flag_edit_Customer)
            {
                cus.ID = "0";
            }
        }

        private void txtToKH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Form_Search_Company search_Company = new Form_Search_Company();
            search_Company.FormClosed += Search_Company_FormClosed;
            search_Company.ShowDialog();
        }  /// <summary>
           /// Closed Form Search Company
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
        private void Search_Company_FormClosed(object sender, FormClosedEventArgs e)
        {
            com = new Company(Form_Search_Company.com);
            if (com != null)
            {
                flag_edit_Company = true;
                txtToKH.Text = com.CompanyName;
                flag_edit_Company = false;
            }
        }

        private void txtToKH_EditValueChanged(object sender, EventArgs e)
        {
            if (!flag_edit_Company)
            {
                com.ID = "0";
            }
        }

        private void Form_Quote_Activated(object sender, EventArgs e)
        {
            LoadControlProduct();
        }
    }
}
