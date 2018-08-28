using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
//using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Net;

namespace IPC247
{
    public partial class Form_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Static Param
        public static bool Flag_Login = false;
        public static User user = new User();
        public static InfoIPC info = new InfoIPC();
        public static string URL_API = ConfigurationManager.AppSettings["URL_API"].ToString();
        public static string URL_Log = ConfigurationManager.AppSettings["URL_Log"].ToString();
		public static string IPAddress = "";
        bool exist = false;
        #endregion Static Param

        #region Function 
        public void DisposeAllButThis()
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm != Parent)
                {
                    frm.Close();
                }
            }
        }
		private string GetVersion()
		{
			string version = "";
			try
			{
				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByStore?sql_Exec=" + "sp_getVersion";
				var json = API.API_GET_Rep(sLink);

				var jsondata = JObject.Parse(json).GetValue("Data");
				DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
				version =  dt.Rows[0][0].ToString();
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Main", "GetVersion()", ex.ToString()));
			}
			return version;
		}
		private void LoadThongTinDefault()
        {
            try
            {
                string sql_Exect = "Exec sp_GetInfoMaster @Key='Info,ImageLeft,ImageRight'"; //11

                string sLink = URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                string base64 = dt.Rows[0][0].ToString();

                json = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64));
                JObject a = JObject.Parse(json);
                info = new InfoIPC();
                info.TenCongTy = a.GetValue("TenCongTy").ToString();
                info.NguoiGui = a.GetValue("NguoiGui").ToString();
                info.Mobile = a.GetValue("Mobile").ToString();
                info.Email = a.GetValue("Email").ToString();
                info.DiaChi = a.GetValue("DiaChi").ToString();


                string FileFolder = AppDomain.CurrentDomain.BaseDirectory + "/AppData/Image";
                if (!Directory.Exists(FileFolder))
                {
                    Directory.CreateDirectory(FileFolder);
                }
                Image img;
                string image = dt.Rows[1][0].ToString();
                if (image != "")
                {
                    FileFolder = FileFolder + "/" + "ImageLeft.jpg";
                    if (File.Exists(FileFolder))
                    {
                        File.Delete(FileFolder);
                    }
                    try
                    {
                        img = byteArrayToImage(Convert.FromBase64String(image));
                        img.Save(FileFolder);
                    }
                    catch (Exception ex)
                    {
						API.API_ERRORLOG(new ERRORLOG(IPAddress, "Form_Main", "LoadThongTinDefault() - Save ImageLeft.jpg", ex.ToString()));
					}
                }
                image = dt.Rows[2][0].ToString();
                if (image != "")
                {
                    FileFolder = AppDomain.CurrentDomain.BaseDirectory + "/AppData/Image";
                    FileFolder = FileFolder + "/" + "ImageRight.jpg";
                    if (!File.Exists(FileFolder))
                    {
                        File.Delete(FileFolder);
                    }
                    try
                    {
                        img = byteArrayToImage(Convert.FromBase64String(image));
                        img.Save(FileFolder);
                    }
                    catch (Exception ex)
                    {
						API.API_ERRORLOG(new ERRORLOG(IPAddress, "Form_Main", "LoadThongTinDefault() - Save ImageRight.jpg", ex.ToString()));
					}
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(IPAddress, "Form_Main", "LoadThongTinDefault()", ex.ToString()));
			}
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        private void Logoff()
        {
            try
            {
				if (!string.IsNullOrEmpty(user.Username))
				{
					string sql_Exect = string.Format("Exec sp_extension_Logoff @UserName='{0}'", user.Username); //11
					string sLink = URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
					var json = API.API_GET(sLink);
				}
            }
            catch(Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(IPAddress, "Form_Main", "Logoff()", ex.ToString()));
			}
        }
        private System.Windows.Forms.DialogResult PreClosingConfirmation()
        {
            System.Windows.Forms.DialogResult res = XtraMessageBox.Show("Bạn Có muốn Thoát Ứng Dụng Không?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
            return res;
        }
        private System.Windows.Forms.Form GetChildFormByName(string formname)
        {
            return this.MdiChildren.FirstOrDefault(f => f.Name == formname);
        }

        private void LoadControlForPhanQuyen()
        {
            if(!string.IsNullOrEmpty(user.ChucNang))
            {
                string[] key = user.ChucNang.Split(',');
                for (int i = 0; i < key.Count(); i++)
                {
                    try
                    {
                        ribbonControl1.Items[key[i]].Enabled = true;
                    }
                    catch (Exception ex)
                    {
						API.API_ERRORLOG(new ERRORLOG(IPAddress, "Form_Main", "LoadControlForPhanQuyen()", ex.ToString()));
					}
                }
            }
        }
		string getIP()
		{
			string localIP = string.Empty;
			IPHostEntry host;

			host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (IPAddress ip in host.AddressList)
			{
				if (ip.AddressFamily.ToString() == "InterNetwork")
				{
					localIP = ip.ToString();
				}
			}
			return Dns.GetHostName() +'-'+ localIP;

		}
		#endregion Function 

		#region Event
		public Form_Main()
        {
            InitializeComponent();
        }

        private void Frm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if(!Flag_Login)
            {
                this.Close();
                //Cancel exist
                if(!exist)
                {
                    Form_Login frm = new Form_Login();
                    Flag_Login = false;
                    frm.txtUserName.Text = user.Username;
                    frm.txtPassword.Focus();
                    frm.FormClosed += Frm_FormClosed;
                    LoadControlForPhanQuyen();
                    frm.ShowDialog();
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
            else
            {
                this.Show();
            }
        }
       
        private void Form_Main_Load(object sender, EventArgs e)
        {
			try
			{
				IPAddress = getIP();
				/// check version:
				/// 
				string _version = System.Windows.Forms.Application.ProductVersion;
				if (_version != GetVersion())
				{
					XtraMessageBox.Show(string.Format("Version Hiện Tại là {0}, Vui lòng cập nhật bản mới nhất!", GetVersion()), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					Flag_ExitNow = true;
					Application.Exit();
				}
			}
			catch (Exception)
			{
				IPAddress = "";
			}
			if (!Flag_Login)
            {
                this.Hide();
                Form_Login frm = new Form_Login();
                frm.FormClosed += Frm_FormClosed;
                frm.ShowDialog();
                LoadControlForPhanQuyen();
            }
            else
            {
                Get_Push_Notify.Start();
            }
            if (string.IsNullOrEmpty(info.TenCongTy))
            {
                LoadThongTinDefault();
            }

            this.barheader_text.Caption = string.Format("Xin Chào: {0} - chúc bạn một ngày làm việc hiệu quả", user.Name);
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = string.Format("IPC247 - Version - {0}", version);
        }
       
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_Product");
            if (f == null)
            {
                f = new Form_Product();
                f.Name = "Form_Product";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void DisableAllControl()
        {
            try
            {
                for (int i = 0; i < ribbonControl1.Items.Count; i++)
                {
                    if(ribbonControl1.Items[i].Name != "skinRibbonGalleryBarItem1" && ribbonControl1.Items[i].Name != "barheader_text" && ribbonControl1.Items[i].Name != "barButtonItem2")
                    {
                        ribbonControl1.Items[i].Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(IPAddress, "Form_Main", "DisableAllControl()", ex.ToString()));
			}
        }
		/// <summary>
		/// LOGOFF
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DisableAllControl();
            this.Hide();
            DisposeAllButThis();
            Form_Login frm = new Form_Login();
            Flag_Login = false;
           // info = new InfoIPC();
            Logoff();
            frm.txtUserName.Text = user.Username;
            frm.txtPassword.Focus();
            user = new User();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
            this.barheader_text.Caption = string.Format("Xin Chào: {0} - chúc bạn một ngày làm việc hiệu quả", user.Name);
            ribbonControl1.SelectedPage = ribbonPage1;
            LoadControlForPhanQuyen();
        }
		bool Flag_ExitNow = false;
		protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
		{
			base.OnFormClosing(e);
			if (Flag_ExitNow)
			{
				Dispose(true);
				System.Windows.Forms.Application.Exit();
			}
			else
			{
				if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
				{
					exist = true;
					Logoff();
					Dispose(true);
					System.Windows.Forms.Application.Exit();
				}
				else
				{
					e.Cancel = true;
					exist = false;
				}
			}
		}

		private void Form_Main_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
			PreClosingConfirmation();
            Get_Push_Notify.Stop();
			Application.Exit();
		}
		/// <summary>
		/// Báo Giá
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_Quote");
            if (f == null)
            {
                f = new Form_Quote();
                f.Name = "Form_Quote";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }
		/// <summary>
		/// NHÓM SẢN PHẨM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_ProductGroup");
            if (f == null)
            {
                f = new Form_ProductGroup();
                f.Name = "Form_ProductGroup";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btnThongTin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_MasterData");
            if (f == null)
            {
                f = new Form_MasterData();
                f.Name = "Form_MasterData";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btn_TaoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_Account");
            if (f == null)
            {
                f = new Form_Account();
                f.Name = "Form_Account";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btn_NhomQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Frm_NhomQuyen");
            if (f == null)
            {
                f = new Frm_NhomQuyen();
                f.Name = "Frm_NhomQuyen";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

		#endregion Event

		private void ribbonControl1_Click(object sender, EventArgs e)
		{

		}

        private void btn_DoanhNghiep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_DoanhNghiep");
            if (f == null)
            {
                f = new Form_DoanhNghiep();
                f.Name = "Form_DoanhNghiep";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btn_Customer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_Customer");
            if (f == null)
            {
                f = new Form_Customer();
                f.Name = "Form_Customer";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }

        private void btn_Enquiry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_Enquiry");
            if (f == null)
            {
                f = new Form_Enquiry();
                f.Name = "Form_Enquiry";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }
      
        private void Get_Push_Notify_Tick(object sender, EventArgs e)
        {
            try
            {
                string sql_Exect = string.Format("Exec sp_Get_Notify @UserName='{0}'",Form_Main.user.Username);
                string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET_Rep(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Caption = dt.Rows[i]["Caption"].ToString();
                    string Body = dt.Rows[i]["Body"].ToString();
                    int AutoFormDelay;
                    int.TryParse(dt.Rows[i]["AutoFormDelay"].ToString(),out AutoFormDelay);
                    alertControl1.AutoFormDelay = AutoFormDelay;
                    alertControl1.Show(this, Caption, Body, "", Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/AppData/Image/switchtimescalesto_32x32.png"), null);
                }
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Main", "Get_Push_Notify_Tick()", ex.ToString()));
            }
        }

        private void btn_EnquiryDetails_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang tải dữ liệu...");
            System.Windows.Forms.Form f = GetChildFormByName("Form_EnquiryReport");
            if (f == null)
            {
                f = new Form_EnquiryReport();
                f.Name = "Form_EnquiryReport";
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                f.Activate();
            }
            SplashScreenManager.CloseDefaultWaitForm();
        }
    }
}
