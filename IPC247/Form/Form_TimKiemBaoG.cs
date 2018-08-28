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
using System.Xml.Linq;
using DevExpress.XtraSplashScreen;

namespace IPC247
{
    public partial class Form_TimKiemBaoGia : DevExpress.XtraEditors.XtraForm
    {
		#region Khởi Tạo
		string ID = "";
        List<InfoCustomer> listob = new List<InfoCustomer>();
		#endregion Khởi Tạo

		#region Function
		public Form_TimKiemBaoGia()
        {
            InitializeComponent();
        }

		private void LoadDSBaoGia()
		{
			try
			{
				string sql_Exect = string.Format("Exec sp_getData_Quote_header"); //11

				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
				var json = API.API_GET(sLink);
				dynamic jsondata = JObject.Parse(json);
				var jsondataChild = jsondata.GetValue("Data");
				DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondataChild.ToString(), (typeof(DataTable)));

				slk_BaoGia.Properties.DataSource = dt;
				slk_BaoGia.Properties.View.ExpandAllGroups();
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_TimKiemBaoGia", "LoadDSBaoGia()", ex.ToString()));
			}
		}

		private void LoadBaoGiaAll(string ID)
		{
			try
			{
				string sql_Exect = string.Format("Exec sp_GetQuote_Detail " +
			  "@ID={0}", ID); //11
				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
				var json = API.API_GET(sLink);
				dynamic jsondata = JObject.Parse(json);
				var jsondataChild = jsondata.GetValue("Data");
				DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondataChild.ToString(), (typeof(DataTable)));
				listob = new List<InfoCustomer>();
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					InfoCustomer ob = new InfoCustomer();
					ob.ID = dt.Rows[i]["ID"].ToString();
					ob.SoBaoGia = dt.Rows[i]["SoBaoGia"].ToString();
					ob.ToKhachHang = dt.Rows[i]["ToKhachHang"].ToString();
					ob.NguoiNhan = dt.Rows[i]["NguoiNhan"].ToString();
					ob.Mobile_NguoiNhan = dt.Rows[i]["Mobile_NguoiNhan"].ToString();
					ob.Tel_NguoiNhan = dt.Rows[i]["Tel_NguoiNhan"].ToString();
					ob.Email_NguoiNhan = dt.Rows[i]["Email_NguoiNhan"].ToString();
					ob.VAT = int.Parse(dt.Rows[i]["VAT"].ToString());
					ob.NgayBaoGia = dt.Rows[i]["NgayBaoGia"].ToString();
					ob.CreateBy = dt.Rows[i]["CreateBy"].ToString();
					ob.CreateDate = dt.Rows[i]["CreateDate"].ToString();
					ob.UpdateBy = dt.Rows[i]["UpdateBy"].ToString();
					ob.UpdateDate = dt.Rows[i]["UpdateDate"].ToString();
					ob.TongTien = decimal.Parse(dt.Rows[i]["TongTien"].ToString());
					ob.TongTienAfterVat = decimal.Parse(dt.Rows[i]["TongTienSauThue"].ToString());
					ob.DiaChiKhachHang = dt.Rows[i]["DiaChi"].ToString();
					ob.DieuKhoan = dt.Rows[i]["DieuKhoan"].ToString();
                    ob.ID_Enquiry = dt.Rows[i]["ID_Enquiry"].ToString();
                    ob.EnquiryName = dt.Rows[i]["EnquiryName"].ToString();
                    ob.IDCardCode = dt.Rows[i]["IDCardCode"].ToString();
                    ob.IDCompany = dt.Rows[i]["IDCompany"].ToString();
                    string xml = dt.Rows[i]["XML"].ToString();
					if (xml != "")
					{
						XDocument dox = XDocument.Parse(dt.Rows[i]["XML"].ToString());
						List<InfoReportDetails> lstSP = dox.Descendants("Quote").Select(d =>
						new InfoReportDetails
						{
							ID = d.Element("ID").Value,
							MaSP = d.Element("MaSP").Value,
							TenHang = d.Element("TenHang").Value,
							MoTaHangHoa = d.Element("MoTa").Value,
							DonGia = decimal.Parse(d.Element("DonGia").Value),
							SoLuong = int.Parse(d.Element("Quantity").Value),
							ChietKhau = decimal.Parse(d.Element("ChietKhau").Value),
							Profit = decimal.Parse(d.Element("Profit").Value),
							CostPrice = decimal.Parse(d.Element("CostPrice").Value)
						}).ToList();
						ob.DSSanPham = lstSP;
					}
					listob.Add(ob);
				}
				dgc_Main.DataSource = listob;
				dgv_detail.ViewCaption = "Thông Tin Chi Tiết";
				dgv_Main.BestFitColumns(true);
				dgv_detail.BestFitColumns(true);
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_TimKiemBaoGia", "LoadBaoGiaAll", ex.ToString()));
			}
		}

		private InfoCustomer GetQuote_Detail_RealTime(string ID)
		{
			InfoCustomer ob = new InfoCustomer();
			try
			{
				string sql_Exect = string.Format("Exec sp_GetQuote_Detail_RealTime " +
			  "@ID={0}", ID); //11
				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
				var json = API.API_GET(sLink);
				dynamic jsondata = JObject.Parse(json);
				var jsondataChild = jsondata.GetValue("Data");
				DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondataChild.ToString(), (typeof(DataTable)));
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					ob.ID = dt.Rows[i]["ID"].ToString();
					ob.SoBaoGia = dt.Rows[i]["SoBaoGia"].ToString();
					ob.ToKhachHang = dt.Rows[i]["ToKhachHang"].ToString();
					ob.NguoiNhan = dt.Rows[i]["NguoiNhan"].ToString();
					ob.Mobile_NguoiNhan = dt.Rows[i]["Mobile_NguoiNhan"].ToString();
					ob.Tel_NguoiNhan = dt.Rows[i]["Tel_NguoiNhan"].ToString();
					ob.Email_NguoiNhan = dt.Rows[i]["Email_NguoiNhan"].ToString();
					ob.VAT = int.Parse(dt.Rows[i]["VAT"].ToString());
					ob.NgayBaoGia = dt.Rows[i]["NgayBaoGia"].ToString();
					ob.CreateBy = dt.Rows[i]["CreateBy"].ToString();
					ob.CreateDate = dt.Rows[i]["CreateDate"].ToString();
					ob.UpdateBy = dt.Rows[i]["UpdateBy"].ToString();
					ob.UpdateDate = dt.Rows[i]["UpdateDate"].ToString();
					ob.TongTien = decimal.Parse(dt.Rows[i]["TongTien"].ToString());
					ob.TongTienAfterVat = decimal.Parse(dt.Rows[i]["TongTienSauThue"].ToString());
					ob.DiaChiKhachHang = dt.Rows[i]["DiaChi"].ToString();
					ob.DieuKhoan = dt.Rows[i]["DieuKhoan"].ToString();
                    ob.ID_Enquiry = dt.Rows[i]["ID_Enquiry"].ToString();
                    ob.EnquiryName = dt.Rows[i]["EnquiryName"].ToString();
                    ob.IDCardCode = dt.Rows[i]["IDCardCode"].ToString();
                    ob.IDCompany = dt.Rows[i]["IDCompany"].ToString();
                    string xml = dt.Rows[i]["XML"].ToString();
					if (xml != "")
					{
						XDocument dox = XDocument.Parse(dt.Rows[i]["XML"].ToString());
						List<InfoReportDetails> lstSP = dox.Descendants("Quote").Select(d =>
						new InfoReportDetails
						{
							ID = d.Element("ID").Value,
							MaSP = d.Element("MaSP").Value,
							TenHang = d.Element("TenHang").Value,
							MoTaHangHoa = d.Element("MoTa").Value,
							DonGia = decimal.Parse(d.Element("DonGia").Value),
							SoLuong = int.Parse(d.Element("Quantity").Value),
							ChietKhau = decimal.Parse(d.Element("ChietKhau").Value),
							Profit = decimal.Parse(d.Element("Profit").Value),
							CostPrice = decimal.Parse(d.Element("CostPrice").Value),
							Status = int.Parse(d.Element("Status").Value),
							IsGroup = int.Parse(d.Element("IsGroup").Value)
						}).ToList();
						ob.DSSanPham = lstSP;
					}
				}
				return ob;
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_TimKiemBaoGia", "GetQuote_Detail_RealTime", ex.ToString()));
				return ob;
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

        void gridView1_CustomDrawRowIndicator_details(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!dgv_detail.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_detail); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_detail); }));
            }
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

		private void ChonVaThoat()
		{
			btnChonVaThoat.Enabled = false;
			InfoCustomer ob = listob.Find(o => o.ID == ID);
			if (ob == null)
			{
				if (listob.Count == 0)
				{
					Form_Quote.QuoteChoose = null;
				}
			}
			else
			{
				Form_Quote.QuoteChoose = GetQuote_Detail_RealTime(ID);
				this.Close();
			}
			btnChonVaThoat.Enabled = true;
		}

		private void XoaBaoGia()
		{
			DialogResult result = XtraMessageBox.Show("Bạn Có muốn Xóa Báo Giá này không?", "Thông Báo", MessageBoxButtons.YesNo);
			if (result == DialogResult.No)
			{
				return;
			}
			try
			{
				// Create an empty list.
				int focus = dgv_Main.FocusedRowHandle;
				if (focus >= 0)
				{
					InfoCustomer dr = (InfoCustomer)dgv_Main.GetFocusedRow();
					if (dr != null)
					{
						listob.Remove(dr);
						//  dgc_Main.DataSource = listob;
						dgv_Main.RefreshData();
						// Xóa data 
						string sql_Exect = string.Format("Exec sp_Quote_Delete " +
				   "@ID={0}", dr.ID); //11
						string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
						var json = API.API_GET(sLink);
					}
				}
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_TimKiemBaoGia", "XoaBaoGia()", ex.ToString()));
			}
		}

		#endregion Function

		#region Event

		private void Form_TimKiemBaoGia_Load(object sender, EventArgs e)
        {
            dgv_Main.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            dgv_detail.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator_details;
            LoadDSBaoGia();
        }

        private void che_XemALL_CheckedChanged(object sender, EventArgs e)
        {
            if(che_XemALL.Checked)
            {
                LoadBaoGiaAll("0");
            }
            else
            {
                LoadBaoGiaAll(ID);
            }
        }

        private void slk_BaoGia_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                int rowHandle = slk_BaoGia.Properties.GetIndexByKeyValue(slk_BaoGia.EditValue);
                object row = slk_BaoGia.Properties.View.GetRow(rowHandle);
                ID = (row as DataRowView).Row["ID"].ToString();
                LoadBaoGiaAll(ID);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_TimKiemBaoGia", "slk_BaoGia_EditValueChanged()", ex.ToString()));
				dgc_Main.DataSource = null;
            }
        }

        private void btnChonVaThoat_Click(object sender, EventArgs e)
        {
            ChonVaThoat();
        }
      
        private void dgc_Main_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
			try
			{
				GridView view = e.View as GridView;
				view.OptionsView.ShowViewCaption = true;
				view.ViewCaption = "Thông Tin Chi Tiết Báo Giá";
				view.Columns["SoLuong"].Caption = "Số Lượng";
				view.Columns["MaSP"].Caption = "Mã Sản Phẩm";
				view.Columns["TenHang"].Caption = "Tên Sản Phẩm";
				view.Columns["TenHang"].AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
				view.Columns["MoTaHangHoa"].Caption = "Mô Tả Sản Phẩm";
				view.Columns["MoTaHangHoa"].AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
				view.Columns["DonGia"].Caption = "Đơn Giá";
				view.Columns["DonGia"].DisplayFormat.FormatString = "n0";
				view.Columns["DonGia"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
				view.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

				view.Columns["ThanhTien"].Caption = "Thành Tiền";
				view.Columns["ThanhTien"].DisplayFormat.FormatString = "n0";
				view.Columns["ThanhTien"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
				view.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
				view.OptionsDetail.ShowDetailTabs = false;
				view.BestFitColumns(true);
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_TimKiemBaoGia", "LoadDSBaoGia()", ex.ToString()));
			}
        }

        private void chọnBáoGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Quote.QuoteChoose = listob.Find(o => o.ID == ID);
            this.Close();
        }

        private void xemAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            che_XemALL.Checked = true;
            LoadBaoGiaAll("0");
        }

        private void xóaBáoGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaBaoGia();
        }

        private void btnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            XoaBaoGia();
        }

        private void btnView_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int focus = dgv_Main.FocusedRowHandle;
            if (focus >= 0)
            {
                dgv_Main.SetMasterRowExpanded(focus, !dgv_Main.GetMasterRowExpanded(focus));
            }
        }

        private void Form_TimKiemBaoGia_FormClosing(object sender, FormClosingEventArgs e)
        {
           // ChonVaThoat();
        }

        private void slk_BaoGia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            MessageBox.Show(slk_BaoGia.EditValue.ToString());
        }

        private void dgv_Main_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    InfoCustomer ob = (InfoCustomer)dgv_Main.GetFocusedRow();
                    ID = ob.ID;
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_TimKiemBaoGia", "dgv_Main_RowClick", ex.ToString()));
				ID = "0";
            }
        }

        private void dgv_Main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    InfoCustomer ob = (InfoCustomer)dgv_Main.GetFocusedRow();
                    ID = ob.ID;
                }
            }
            catch 
            {
                ID = "0";
            }
        }

		#endregion Event
	}
}