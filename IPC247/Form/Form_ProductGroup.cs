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

namespace IPC247
{
    public partial class Form_ProductGroup : DevExpress.XtraEditors.XtraForm
    {
        public Form_ProductGroup()
        {
            InitializeComponent();
        }
        #region Khởi Tạo Tham Số
        private List<ProductGroupHeader> listHeader = new List<ProductGroupHeader>();
        private List<ProductGroupDetails> listdetails = new List<ProductGroupDetails>();
		string IDGroup = "";
		#endregion Khởi Tạo Tham Số

		#region Function
		bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        /// <summary>
        /// Tạo cọt số TT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Tạo Cột STT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void gridView1_CustomDrawRowIndicatorDetails(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!dgvDetails.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgvDetails); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgvDetails); }));
            }
        }
        /// <summary>
        /// Load Thông Tin Sản Phẩm
        /// </summary>
        private void LoadInfoProduct()
        {
            try
            {
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_Get_Product_Select";
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                var ds = JsonConvert.DeserializeObject<List<ProductSelect>>(jsondata.ToString());
                searchSanPham.DataSource = ds;
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_ProductGroup", "LoadInfoProduct()", ex.ToString()));
			}
        }
        /// <summary>
        /// Load Thông tin Nhóm Sản Phẩm
        /// </summary>
        private void LoadInfoProductGroup()
        {
            try
            {
                string sLink =Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_ProductGroup_Getdata";
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                listHeader = JsonConvert.DeserializeObject<List<ProductGroupHeader>>(jsondata.ToString());
              
                dgc_Main.DataSource = listHeader;
                if(listHeader== null || listHeader.Count ==0)
                {
                    listdetails = new List<ProductGroupDetails>();
                    dgcDetails.DataSource = listdetails;
                    dgvDetails.RefreshData();
                }
                dgv_Main.BestFitColumns(true);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_ProductGroup", "LoadInfoProductGroup()", ex.ToString()));
			}
        }
        /// <summary>
        /// lấy danh sách chi tiết nhóm sản phẩm
        /// </summary>
        private void LoadInfoProductDetails(string ListID)
        {
            try
            {
                string sqlQuery = string.Format("exec sp_ProductGroup_GetdataDetails @ID='{0}' ",ListID);
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sqlQuery;
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                listdetails = JsonConvert.DeserializeObject<List<ProductGroupDetails>>(jsondata.ToString());
                dgcDetails.DataSource = listdetails;
                dgvDetails.BestFitColumns(true);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_ProductGroup", "LoadInfoProductDetails()", ex.ToString()));
			}
        }
        /// <summary>
        /// xử lý load form và ActiveForm
        /// </summary>
        private void LoadForm()
        {
            dgv_Main.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
            dgvDetails.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicatorDetails;
            LoadInfoProduct();
            LoadInfoProductGroup();
        }
        /// <summary>
        /// Lưu Thông Tin Nhóm Sản Phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProductGroup()
        {
            try
            {
                string TenNhom = txtTenNhom.Text;
                string DSSanPham = "";
                
                if (listdetails== null || listdetails.Count ==0)
                {
                    XtraMessageBox.Show("Nhóm chưa có sản phẩm nào!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (ProductGroupDetails item in listdetails)
                {
                    if (!string.IsNullOrEmpty(item.ID))
                    {
                        int sl = int.Parse(item.SoLuong.ToString());
                        for (int j = 0; j < sl; j++)
                        {
                            DSSanPham = DSSanPham + item.ID + ",";
                        }
                    }
                }
                
                string sql_exec = string.Format("exec sp_ProductGroup_Update @ID='{0}',@ListProduct='{1}',@UserName=N'{2}',@ProductGroupName=N'{3}' ", IDGroup, DSSanPham, Form_Main.user.Username, TenNhom);
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_exec;
                var json = API.API_GET(sLink);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                if(Result==1)
                {
                    LoadInfoProductGroup();
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_ProductGroup", "SaveProductGroup()", ex.ToString()));
			}
        }
        /// <summary>
        /// Sự kiện Selected Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void SelectedRow()
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    ProductGroupHeader ob = (ProductGroupHeader)dgv_Main.GetFocusedRow();
                    if (ob != null)
                    {
                        IDGroup = ob.ID;
                        txtTenNhom.Text = ob.ProductGroupName.ToString();
                        string DSSanPham = ob.ListProductCode.ToString();
                        LoadInfoProductDetails(DSSanPham);
                    }
                }
            }
            catch
            {
                IDGroup = "0";
                ProductGroupDetails obd = new ProductGroupDetails();
                listdetails = new List<ProductGroupDetails>();
                obd.SoLuong = 1;
                listdetails.Add(obd);
                dgcDetails.DataSource = listdetails;
                dgvDetails.RefreshData();
                dgvDetails.BestFitColumns(true);
            }
        }
        /// <summary>
        /// Xóa Line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteGroup()
        {
            try
            {
                if(IDGroup=="0")
                {
                    XtraMessageBox.Show("Hãy chọn nhóm sản phẩm mà bạn muốn xóa", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                DialogResult result = XtraMessageBox.Show("Bạn có muốn xóa nhóm này không?", "Thông Báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                string sql_exec = string.Format("exec sp_ProductGroup_Delete @ID='{0}',@UserName='{1}'", IDGroup,Form_Main.user.Username);
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_exec;
                var json = API.API_GET(sLink);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;
				if (Result == 1)
				{
					LoadInfoProductGroup();
				}
				else
				{
					XtraMessageBox.Show(Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Login", "DeleteGroup()", ex.ToString()));
			}
        }
        /// <summary>
        /// xóa tay từng line
        /// </summary>
        private void DeleteDetails()
        {
            try
            {
                // Create an empty list.
                int focus = dgvDetails.FocusedRowHandle;
                if (focus >= 0)
                {
                    ProductGroupDetails dr = (ProductGroupDetails)dgvDetails.GetFocusedRow();
                    if (dr != null)
                    {
                        listdetails.Remove(dr);
                        dgcDetails.DataSource = listdetails;
                        dgvDetails.RefreshData();
                    }
                    focus = dgv_Main.FocusedRowHandle;
                    if (focus >= 0)
                    {
                        dgv_Main.SetFocusedRowCellValue("TongTien", listdetails.Sum(o => o.ThanhTien));
                    }
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Login", "DeleteDetails()", ex.ToString()));
			}
        }
        /// <summary>
        /// Xóa nhiều dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void XoaNhieuLine()
        {
            try
            {
                List<ProductGroupDetails> lstdel = new List<ProductGroupDetails>();
                // Add the selected rows to the list.
                for (int i = 0; i < dgvDetails.SelectedRowsCount; i++)
                {
                    ProductGroupDetails ob = (ProductGroupDetails)dgvDetails.GetRow(dgvDetails.GetSelectedRows()[i]);
                    lstdel.Add(ob);
                }
                if (dgvDetails.SelectedRowsCount == 0)
                {
                    XtraMessageBox.Show("Không có thông tin nào được chọn để xóa! Vui lòng chọn dữ liệu để thao tác", "Thông Tin");
                    return;
                }
                else
                {
                    foreach (ProductGroupDetails item in lstdel)
                    {
                        listdetails.Remove(item);
                    }
                    dgvDetails.RefreshData();
                    dgvDetails.BestFitColumns(true);
                }
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    dgv_Main.SetFocusedRowCellValue("TongTien", listdetails.Sum(o => o.ThanhTien));
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Login", "XoaNhieuLine()", ex.ToString()));
			}
        }
        #endregion Function

        #region Event

        private void Form_ProductGroup_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void TaoMoi()
        {
            IDGroup = "0";
            ProductGroupHeader ob = new ProductGroupHeader();
            ob.ProductGroupName = txtTenNhom.Text;
            ob.CreateBy = Form_Main.user.Username;
            listHeader.Add(ob);
            dgc_Main.DataSource = listHeader;
            dgv_Main.RefreshData();
            dgv_Main.BestFitColumns(true);
            ProductGroupDetails obd = new ProductGroupDetails();
            listdetails = new List<ProductGroupDetails>();
            obd.SoLuong = 1;
            listdetails.Add(obd);
            dgcDetails.DataSource = listdetails;
            dgvDetails.RefreshData();
            dgvDetails.BestFitColumns(true);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SaveProductGroup();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TaoMoi();
        }

        private void dgv_Main_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelectedRow();
        }

        private void thêmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProductGroupDetails ob = listdetails.Find(o => o.ID == "");
                if (ob != null)
                {
                    XtraMessageBox.Show("Bạn đã có 1 dòng trống chưa thao tác vui lòng cập nhật trên dòng đó", "Thông Báo");
                    return;
                }
                ob = new ProductGroupDetails();
                listdetails.Add(ob);
                dgcDetails.DataSource = listdetails;
                ob.SoLuong = 1;
                dgvDetails.RefreshData();
                dgvDetails.BestFitColumns(true);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Login", "thêmSảnPhẩmToolStripMenuItem_Click()", ex.ToString()));
			}
        }

        private void dgv_Main_RowClick(object sender, RowClickEventArgs e)
        {
            SelectedRow();
        }

        private void repositoryItemSearchLookUpEdit1View_MouseDown(object sender, MouseEventArgs e)
        {
            repositoryItemSearchLookUpEdit1View.BestFitColumns();
        }
      
        private void searchSanPham_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            int focus = dgvDetails.FocusedRowHandle;
            if (focus >= 0)
            {
                SearchLookUpEdit edit = sender as SearchLookUpEdit;
                if (e.AcceptValue)
                {
                    ProductSelect row = (edit.Properties.GetRowByKeyValue(e.Value) as ProductSelect);
                    dgvDetails.SetFocusedRowCellValue("ProductCode", row.ProductCode.ToString());
                    dgvDetails.SetFocusedRowCellValue("ID", row.ID.ToString());
                    dgvDetails.SetFocusedRowCellValue("ProductName", row.ProductName.ToString());
                    dgvDetails.SetFocusedRowCellValue("Price", row.Price.ToString());

                    focus = dgv_Main.FocusedRowHandle;
                    if(focus>=0)
                    {
                        dgv_Main.SetFocusedRowCellValue("TongTien", listdetails.Sum(o=>o.ThanhTien));
                        dgv_Main.BestFitColumns(true);
                    }
                    dgvDetails.BestFitColumns(true);
                }
            }
        }
        /// <summary>
        /// Xóa 1 dòng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DeleteDetails();
        }

        private void xóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaNhieuLine();
        }

        private void dgvDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    dgv_Main.SetFocusedRowCellValue("TongTien", listdetails.Sum(o => o.ThanhTien));
                    dgv_Main.BestFitColumns(true);
                }
                dgvDetails.BestFitColumns(true);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_ProductGroup", "LoadInfoProductGroup()", ex.ToString()));
			}
        }

        private void btnHuyNhom_Click(object sender, EventArgs e)
        {
            DeleteGroup();
            //LoadInfoProduct();
            //LoadInfoProductGroup();
        }

		private void tạoBảnSaoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int focus = dgv_Main.FocusedRowHandle;
			if (focus >= 0)
			{
				ProductGroupHeader ob = (ProductGroupHeader)dgv_Main.GetFocusedRow();
				if (ob != null)
				{
					ProductGroupHeader ob1 = new ProductGroupHeader(ob);
					ob1.ID = "0";
					ob1.ProductGroupName = ob1.ProductGroupName + "-(Copy)";
					ob1.CreateBy = Form_Main.user.Username;
					ob1.CreateDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
					ob1.UpdateBy = "";
					ob.CreateDate = "";
					listHeader.Add(ob1);
					dgv_Main.RefreshData();
				}
			}
		}

		private void tạoNhómMớiToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TaoMoi();
		}

		private void CậpNhậtNhóm_Click(object sender, EventArgs e)
		{
			SaveProductGroup();
		}

		private void HủyNhóm_Click(object sender, EventArgs e)
		{
			DeleteGroup();
		}

		#endregion Event
	}
}