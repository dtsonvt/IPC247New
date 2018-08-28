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
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using System.Data.OleDb;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Net;
using System.Diagnostics;
using System.Collections;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraGrid.Views.Grid;

namespace IPC247
{
    public partial class Form_Product : DevExpress.XtraEditors.XtraForm
    {
        public Form_Product()
        {
            InitializeComponent();
        }
        string ID = "";
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            btnChonFile.Enabled = false;
            XtraOpenFileDialog openFileDialog = new XtraOpenFileDialog();
            //openFileDialog.Filter = "Image Files(*.PNG; *.BMP; *.JPG; *.GIF)| *.PNG; *.BMP; *.JPG; *.GIF";
            openFileDialog.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx";  // is OK
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string name = openFileDialog.FileName;
                    if (!name.Contains(".xlsx"))
                    {
                        XtraMessageBox.Show("File Bạn chọn không đúng định dạng excel","Thông Báo");
                    }
                    else
                    {
                        txtLinkFile.Text = name;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            btnChonFile.Enabled = true;
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            btn_Template.Enabled = false;
            if (xtraFolderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string filepath = xtraFolderBrowserDialog1.SelectedPath;
                System.Net.WebClient webClient = new System.Net.WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadFileAsync(new Uri(Form_Main.URL_API + "/Uploads/Tmp/template/template.xlsx"), filepath+"/template.xlsx");
            }
            btn_Template.Enabled = true;
        }

        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!dgv_Product.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_Product); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_Product); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            XtraMessageBox.Show("Download completed!");
        }
        private List<Dictionary<string, object>> ConvertDataTableToListObject(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return rows;
        }
        private void LoadInfoProduct()
        {
            try
            {
                string sLink = Form_Main.URL_API+ "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_Get_Product";
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                dgc_Product.DataSource = dt;
                dgv_Product.BestFitColumns(true);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "LoadInfoProduct()", ex.ToString()));
			}
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if(DialogResult.No == XtraMessageBox.Show("Bạn có muốn xóa toàn bộ sản phẩm không? Nhấn Yes để thực hiện!","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                return;
            }

            try
            {
                btnXoaAll.Enabled = false;
                string sLink = Form_Main.URL_API+ "/api/IPC247/sp_extension_DeleteAllProduct";

                var json = API.API_GET(sLink);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                if (Result == 1)//Login thành công
                {
                    XtraMessageBox.Show(Message, "Thông Báo");
                    LoadInfoProduct();

                }
                else
                {
                    XtraMessageBox.Show("Xóa Dữ Liệu KHông Thành Công", "Thông Báo");
                }
                btnXoaAll.Enabled = true;
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "btnDeleteAll_Click", ex.ToString()));
			}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnImport.Enabled = false;
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang thực hiện thao tác...");
            string filename = txtLinkFile.Text;
            if (filename == "")
            {
                XtraMessageBox.Show("Vui Lòng Chọn File để IMPORT", "Thông Báo");
                return;
            }
            try
            {
                DataTable dt = new DataTable();
                string FRConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", filename);
                OleDbConnection connection = new OleDbConnection();
                connection.ConnectionString = FRConnectionString;
                //OleDbCommand cmd = new OleDbCommand("Select '" + DateTime.Today.ToShortDateString() + "',* from [Sheet1$]", connection);
                OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$]", connection);
                connection.Open();
                // OleDbDataReader dr = cmd.ExecuteReader();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                List<Product> lstnew = new List<Product>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Product ob = new Product();
					ob.ProductCode = dt.Rows[i]["ProductCode"].ToString().Replace("\"", "''");
					if (string.IsNullOrEmpty(ob.ProductCode))
					{
						continue;
					}
					ob.ProductName = dt.Rows[i]["ProductName"].ToString().Replace("\"", "''");
					ob.Description = dt.Rows[i]["Description"].ToString().Replace("\"", "''");
					ob.CostPrice = decimal.Parse(dt.Rows[i]["CostPrice"].ToString());
                    ob.Price = decimal.Parse(dt.Rows[i]["Price"].ToString());
                    ob.UserID = Form_Main.user.Username;
                    lstnew.Add(ob);
                }
                var json = JsonConvert.SerializeObject(lstnew);


                string sLink = Form_Main.URL_API+ "/api/IPC247/sp_extension_ImportProduct";
				JavaScriptSerializer serializer = new JavaScriptSerializer();
				serializer.MaxJsonLength = Int32.MaxValue;

				json = serializer.Serialize(new { UserName = Form_Main.user.Username, Data = json });

                var jsonReturn = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(jsonReturn);
                var jsondataChild = jsondata.GetValue("Data");
                //var Result = jsondataChild.First.GetValue("Result").Value;
                //var Message = jsondataChild.First.GetValue("Message").Value;
                LoadInfoProduct();
                btnImport.Enabled = false;
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "Imort Dữ Liệu()", ex.ToString()));

				btnImport.Enabled = true;
                if (XtraMessageBox.Show(
                            "Máy bạn chưa hỗ trợ xử lý excel, Bấm 'YES' để tải file setup hỗ trợ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                        ) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start("chrome.exe", Form_Main.URL_API + "/Uploads/Tmp/template/AccessDatabaseEngine.exe");
                    }
                    catch
                    {
                        System.Diagnostics.Process.Start(Form_Main.URL_API + "/Uploads/Tmp/template/AccessDatabaseEngine.exe");
                        throw;
                    }
                }
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void Form_Product_Load(object sender, EventArgs e)
        {
			//SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang thực hiện thao tác...");
			LoadInfoProduct();
            dgv_Product.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
			//SplashScreenManager.CloseDefaultWaitForm();
		}

        private void dgv_Product_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > 0)
            {
                //txtMaNhom.Text = grv_NhomSanPham.GetDataRow(e.FocusedRowHandle)["Code"].ToString();
                //txtTenNhom.Text = grv_NhomSanPham.GetDataRow(e.FocusedRowHandle)["Name"].ToString();
                //txtMoTa.Text = grv_NhomSanPham.GetDataRow(e.FocusedRowHandle)["GhiChu"].ToString();
            }
        }

        private void dgv_Product_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                int focus = dgv_Product.FocusedRowHandle;
                if (focus >= 0)
                {
                    txtMaSP.Text = dgv_Product.GetDataRow(focus)["ProductCode"].ToString();
                    txtTenSP.Text = dgv_Product.GetDataRow(focus)["ProductName"].ToString();
                    txtMoTa.Text = dgv_Product.GetDataRow(focus)["Description"].ToString();
                    txtDonGia.EditValue = dgv_Product.GetDataRow(focus)["Price"].ToString();
                    txtGiaNhap.EditValue = dgv_Product.GetDataRow(focus)["CostPrice"].ToString();
                    ID = dgv_Product.GetDataRow(focus)["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "dgv_Product_RowClick()", ex.ToString()));
			}
          
        }

        private void ExportData()
        {
            try
            {
                btnExport.Enabled = false;  
                string pathFileSave = "";
                 XtraSaveFileDialog fileSave = new XtraSaveFileDialog();
                fileSave.Filter = "Excel files (.xlsx)|*.xlsx";
                fileSave.AutoUpdateFilterDescription = true;
                if (fileSave.ShowDialog() == DialogResult.OK)
                {
                    if (!fileSave.FileName.Contains(".xlsx"))
                    {
                        XtraMessageBox.Show("File save phải định dạng .xlsx", "Thông Báo");
                    }
                    else
                    {
                        //System.IO.File.Copy(PathFile, fileSave.FileName, true);
                        pathFileSave = fileSave.FileName;
                    }
                }
                else
                {
                    return;
                }

                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_Get_Product_Export";
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                string Folder = AppDomain.CurrentDomain.BaseDirectory + "/AppData";
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/AppData"))
                {
                    Directory.CreateDirectory(Folder);
                }

                Folder = AppDomain.CurrentDomain.BaseDirectory + string.Format("/AppData/{0}/", DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(Folder))
                {
                    Directory.CreateDirectory(Folder);
                }

                #region Xóa File cũ
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/AppData/");
                foreach (System.IO.DirectoryInfo di in dir.GetDirectories())
                {
                    if (di.Name != DateTime.Today.ToString("yyyyMMdd"))
                    {
                        System.IO.Directory.Delete(di.FullName, true);
                    }
                }
                #endregion Xóa File cũ

                string PathFile = Folder + string.Format("/ExportData_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(new Uri(Form_Main.URL_API + "/Uploads/Tmp/template/template.xlsx"), PathFile);
                }

                System.IO.FileInfo fnew = new System.IO.FileInfo(PathFile);
                using (ExcelPackage pck = new ExcelPackage(fnew))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets["Sheet1"];
                    if (ws == null)
                    {
                        ws = pck.Workbook.Worksheets.Add("Sheet1");
                    }
                    ws.Cells["A2"].LoadFromDataTable(dt, false);
                    pck.Save();
                }
                System.IO.File.Copy(PathFile, fileSave.FileName, true);

                if (File.Exists(PathFile))
                {
                    File.Delete(PathFile);
                }
                try
                {
                    Process.Start(fileSave.FileName);
                }
                catch 
                {
                    XtraMessageBox.Show("Bạn cần cài đặt Excel để mở file!", "Thông Báo");
                }
                btnExport.Enabled = true;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "ExportData()", ex.ToString()));
				btnExport.Enabled = true;
                return;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang kết nối Server...");
            ExportData();
            SplashScreenManager.CloseForm(false);

        }
        private void UpdateData()
        {
			try
			{
				Product product = new Product();
				product.Id = int.Parse(ID == "" ? "0" : ID);
				product.ProductCode = txtMaSP.Text;
				product.ProductName = txtTenSP.Text;
				product.Description = txtMoTa.Text;
				product.Price = decimal.Parse(txtDonGia.EditValue.ToString());
				product.CostPrice = decimal.Parse(txtGiaNhap.EditValue.ToString());
				//string sql_Exect = string.Format("Exec sp_Product_Update @ID ={0},@ProductCode=N'{1}',@ProductName=N'{2}',@Description=N'{3}'," +
				//    "@Price={4},@UserID='{5}',@CostPrice={6}", product.Id, product.ProductCode, product.ProductName, product.Description, product.Price, Form_Main.user.Username,product.CostPrice);

				//string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
				string str = "[" +
				  string.Format(@" {{""Key"":""ID"",""value"":""{0}"",""Type"":""string""}},
{{""Key"":""ProductCode"",""value"":""{1}"",""Type"":""string""}},
{{""Key"":""ProductName"",""value"":""{2}"",""Type"":""string""}},
{{""Key"":""Description"",""value"":""{3}"",""Type"":""string""}},
{{""Key"":""Price"",""value"":""{4}"",""Type"":""string""}},
{{""Key"":""UserID"",""value"":""{5}"",""Type"":""string""}},
{{""Key"":""CostPrice"",""value"":""{6}"",""Type"":""string""}}"
				 , product.Id //0
				 , product.ProductCode //1
				 , product.ProductName //2
				 , product.Description //3
				 , product.Price //4
				 , Form_Main.user.Username //5
				 , product.CostPrice) + "]"; //6
											 //  JObject json = JObject.Parse(str);
				var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_Product_Update", Param = str });
				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_SaveQuote";
				json = API.API_POS(sLink, json);
				dynamic jsondata = JObject.Parse(json);
				//	var json = API.API_GET(sLink);
				//   dynamic jsondata = JObject.Parse(json);
				var jsondataChild = jsondata.GetValue("Data");
				string result = jsondataChild.First.GetValue("Result").Value.ToString();
				if (result != null && result == "1")
				{
					ID = jsondataChild.First.GetValue("ID").Value.ToString();
					LoadInfoProduct();
				}
				else
				{
					string Message = jsondataChild.First.GetValue("Message").Value.ToString();
					XtraMessageBox.Show(Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "UpdateData()", ex.ToString()));
			}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
			SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang thực hiện thao tác...");
			btnUpdate.Enabled = false;
            UpdateData();
            btnUpdate.Enabled = true;
			SplashScreenManager.CloseDefaultWaitForm();
		}

        private void làmMớiDữLiêuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInfoProduct();
        }

        private void thêmSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.EditValue  = 0;
			txtGiaNhap.EditValue = 0;
            txtMoTa.Text = "";
            ID = "";
        }

        private void làmMớiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInfoProduct();
        }

        private void XoaDuLieu(string MaSP)
        {
            
            try
            {
                string sql_Exect = string.Format("Exec sp_Product_Delete @ID ='{0}', @UserName='{1}'", MaSP,Form_Main.user.Username);

                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);
				dynamic jsondata = JObject.Parse(json);
				var jsondataChild = jsondata.GetValue("Data");
				var Result = jsondataChild.First.GetValue("Result").Value;
				var Message = jsondataChild.First.GetValue("Message").Value;

				if (Result == 1)//Login thành công
				{
					XtraMessageBox.Show(Message, "Thông Báo");
					LoadInfoProduct();
				}
				else
				{
					XtraMessageBox.Show(Message, "Thông Báo");
				}
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "XoaDuLieu()", ex.ToString()));
			}
           
        }

        private void xóaSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn Có muốn Xóa Những Sản Phẩm Này Không?", "Thông Báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang thực hiện thao tác...");
            string MaSP = "";
            // Create an empty list.
            ArrayList rows = new ArrayList();
            // Add the selected rows to the list.
            for (int i = 0; i < dgv_Product.SelectedRowsCount; i++)
            {
                if (dgv_Product.GetSelectedRows()[i] >= 0)
                    rows.Add(dgv_Product.GetDataRow(dgv_Product.GetSelectedRows()[i]));
            }
            if (rows.Count == 0)
            {
                XtraMessageBox.Show("Không có thông tin nào được chọn để xóa! Vui lòng chọn dữ liệu để thao tác", "Thông Tin");
                return;
            }
            try
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    DataRow row = rows[i] as DataRow;
                    string IDCode = row["ID"].ToString();
                    if (IDCode != null && IDCode != "")
                    {
                        MaSP = MaSP == "" ? IDCode : MaSP + "," + IDCode;
                    }
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Product", "xóaSảnPhẩmToolStripMenuItem_Click()", ex.ToString()));
			}
            XoaDuLieu(MaSP);
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void cậpNhậtDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang thực hiện thao tác...");
            UpdateData();
            SplashScreenManager.CloseDefaultWaitForm();
        }

		private void Form_Product_Activated(object sender, EventArgs e)
		{
			//SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang thực hiện thao tác...");
			LoadInfoProduct();
			dgv_Product.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
			//SplashScreenManager.CloseDefaultWaitForm();
		}
	}
}
