using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace IPC247
{
    public partial class Frm_NhomQuyen : DevExpress.XtraEditors.XtraForm
    {
        #region Function
        public static AutoCompleteStringCollection dsnhomquyen = new AutoCompleteStringCollection();
      //  string ID = "0";
        public Frm_NhomQuyen()
        {
            InitializeComponent();
        }
        private void LoadThongTinNhomQuyen()
        {
            try
            {
                string sql_Exect = "Exec sp_GetDanhSachChucNang"; //11

                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                grc_NhomQuyen.DataSource = dt;
                grv_NhomQuyen.BestFitColumns(true);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_NhomQuyen", "LoadThongTinNhomQuyen()", ex.ToString()));
			}
        }
        private void LoadDSNhom()
        {
            try
            {
                string sql_Exect = "Exec sp_GetNhomQuyen"; //11

                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));

                if (dt != null && dt.Rows.Count > 0)
                {
                    #region xử lý nhóm quyền
                    string ds = dt.Rows[0]["danhsach"].ToString();
                    if (ds != "")
                    {
                        string[] str = ds.Split(';');
                        dsnhomquyen.Clear();
                        dsnhomquyen.AddRange(str);
                        cbb_ThongTinNhom.MaskBox.AutoCompleteCustomSource = dsnhomquyen;
                        cbb_ThongTinNhom.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        cbb_ThongTinNhom.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    }
                    #endregion xử lý nhóm quyền
                }
                else
                {
                    cbb_ThongTinNhom.MaskBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                }

                sql_Exect = "Exec sp_GetNhomQuyen_header"; //11

                sLink =Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                json = API.API_GET(sLink);

                jsondata = JObject.Parse(json).GetValue("Data");

                dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                cbbSearchNhom.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_NhomQuyen", "LoadDSNhom()", ex.ToString()));
			}
        }
        private void ThemNhomQuyen()
        {
            try
            {
                string DSNhomquyen = "";
                for (int i = 0; i < grv_NhomQuyen.RowCount; i++)
                {
                    DataRow dr = grv_NhomQuyen.GetDataRow(i);
                    if (dr != null)
                    {
                        string item = dr["ID"].ToString();
                        string chon = dr["Chon"].ToString();
                        if (item != null && item != "" && chon != null && chon == "True")
                        {
                            DSNhomquyen = DSNhomquyen == "" ? item : DSNhomquyen + "," + item;
                        }
                    }
                }
                string sql_Exect = string.Format("Exec sp_CapNhatNhomQuyen @TenNhom='{0}',@CreateBy='{1}',@DSQuyen='{2}'", cbb_ThongTinNhom.Text, Form_Main.user.Username, DSNhomquyen); //11

                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Message = dt.Rows[0]["Message"].ToString();
                    string Result = dt.Rows[0]["Result"].ToString();
                    XtraMessageBox.Show(Message, "Thông Báo", MessageBoxButtons.OK);
                    if (Result == "1")
                    {
                        LoadDSNhom();
                    }
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_NhomQuyen", "ThemNhomQuyen()", ex.ToString()));
			}
        }
  
        private bool CheckDuLieu()
        {
            bool flag = false;
            // kiểm tra tên nhân viên
            if (string.IsNullOrEmpty(cbb_ThongTinNhom.Text) || cbb_ThongTinNhom.Text.Length == 1)
            {
                dxErrorProvider_main.SetError(cbbSearchNhom, "Tên nhóm ít nhất 2 ký tự");
                flag = true;
            }
            else
            {
                dxErrorProvider_main.SetError(cbbSearchNhom, null);
            }
            return flag;
        }
        private void LoadDSPhanQuyenTheoTenNhom(string tennhom)
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_GetDSChiTietPQ @TenNhom='{0}'", tennhom); //11

                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                if (dt != null && dt.Rows.Count > 0)
                {
                    string KEYLIST = dt.Rows[0]["IDChucNang"].ToString();
                    if (KEYLIST == null || KEYLIST == ",,")
                    {
                        for (int i = 0; i < grv_NhomQuyen.RowCount; i++)
                        {
                            grv_NhomQuyen.SetRowCellValue(i, "Chon", "False");
                        }
                    }
                    else
                    {
                        grv_NhomQuyen.ExpandAllGroups();
                        for (int i = 0; i < grv_NhomQuyen.RowCount; i++)
                        {
                            DataRow dr = grv_NhomQuyen.GetDataRow(i);
                            if (dr != null)
                            {
                                string ID = dr["ID"].ToString();
                                if (ID != null && KEYLIST.Contains(ID))
                                {
                                    grv_NhomQuyen.SetRowCellValue(i, "Chon", "True");
                                }
                                else
                                {
                                    grv_NhomQuyen.SetRowCellValue(i, "Chon", "False");
                                }
                            }
                        }
                    }
                }
                grv_NhomQuyen.RefreshData();
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_NhomQuyen", "LoadDSPhanQuyenTheoTenNhom()", ex.ToString()));
			}
        }
		private void HuyNhom()
		{
			try
			{
				if (DialogResult.Yes == XtraMessageBox.Show("Bạn có muốn bỏ nhóm quyền này không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
				{
					string sql_Exect = string.Format("Exec sp_NhomQuyen_Update @TenNhom='{0}'", cbb_ThongTinNhom.Text); //11

					string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
					var json = API.API_GET(sLink);

					var jsondata = JObject.Parse(json).GetValue("Data");
				}
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_NhomQuyen", "HuyNhom()", ex.ToString()));
			}
		}

		#endregion Function

		#region Event

		private void Frm_NhomQuyen_Load(object sender, EventArgs e)
        {
            LoadThongTinNhomQuyen();
            LoadDSNhom();
        }
        
        private void grv_NhomQuyen_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Chon"]);
                if (category == "Unchecked")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }
            }
        }

        private void grv_NhomQuyen_RowClick(object sender, RowClickEventArgs e)
        {
            int handle = grv_NhomQuyen.FocusedRowHandle;
            if (handle >= 0)
            {
                string category = grv_NhomQuyen.GetDataRow(handle)["Chon"].ToString();
                if (category == "False")
                {
                    grv_NhomQuyen.SetRowCellValue(grv_NhomQuyen.FocusedRowHandle, "Chon", "True");
                }
                else
                {
                    grv_NhomQuyen.SetRowCellValue(grv_NhomQuyen.FocusedRowHandle, "Chon", "False");
                }

            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (CheckDuLieu())
            {
                return;
            }
            else
            {
                ThemNhomQuyen();
            }
        }

        private void layoutControlItem3_Click(object sender, EventArgs e)
        {
            //Frm_Child_NhomQuyen frm = new Frm_Child_NhomQuyen();
            //frm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormClosingEventHandler);
            //frm.ShowDialog();
        }

        private void cbb_ThongTinNhom_TextChanged(object sender, EventArgs e)
        {
            string a = cbb_ThongTinNhom.Text;
            if (a != "")
            {
                LoadDSPhanQuyenTheoTenNhom(a);
            }
        }

        private void menu_Add_Click(object sender, EventArgs e)
        {
            if (CheckDuLieu())
            {
                return;
            }
            else
            {
                ThemNhomQuyen();
            }
        }

        private void menu_Save_Click(object sender, EventArgs e)
        {
            if (CheckDuLieu())
            {
                return;
            }
            else
            {
                ThemNhomQuyen();
            }
        }

        private void menu_Delete_Click(object sender, EventArgs e)
        {
            if (CheckDuLieu())
            {
                return;
            }
            else
            {
                HuyNhom();
                LoadDSNhom();
            }
        }

        private void menu_Allitem_Click(object sender, EventArgs e)
        {
            grv_NhomQuyen.ExpandAllGroups();
            for (int i = 0; i < grv_NhomQuyen.RowCount; i++)
            {
                DataRow dr = grv_NhomQuyen.GetDataRow(i);
                if (dr != null)
                {
                    string ID = dr["ID"].ToString();
                    if (ID != null)
                    {
                        grv_NhomQuyen.SetRowCellValue(i, "Chon", "True");
                    }
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            HuyNhom();
        }
        
        private void cbb_ThongTinNhom_EditValueChanged(object sender, EventArgs e)
        {
            cbb_ThongTinNhom.Text = cbbSearchNhom.Text.ToString();
        }

		#endregion Event
	}
}