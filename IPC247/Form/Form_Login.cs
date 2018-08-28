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
using System.Web.Script.Serialization;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using DevExpress.XtraSplashScreen;

namespace IPC247
{
    public partial class Form_Login : DevExpress.XtraEditors.XtraForm
    {
		#region Function
		/// <summary>
		/// mã hóa password
		/// </summary>
		/// <param name="original"></param>
		/// <param name="key"></param>
		/// <returns></returns>
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

		public static string EncryptPass(string original)
		{
			return EncryptPass(original, "!@#$%^&*()~_+|");
		}

		public void XuLyDangNhap(string username, string password)
		{
			try
			{
				string sLink = Form_Main.URL_API + "/api/IPC247/sp_extension_Login";
				var json = new JavaScriptSerializer().Serialize(new { UserName = username, Password = password });
				json = API.API_POS(sLink, json);
				if (json != null)
				{
					dynamic jsondata = JObject.Parse(json);
					var jsondataChild = jsondata.GetValue("Data");
					var Result = jsondataChild.First.GetValue("Result").Value;
					var Message = jsondataChild.First.GetValue("Message").Value;

					if (Result == 1)//Login thành công
					{
						Form_Main.Flag_Login = true;
						Form_Main.user.Username = username;
						Form_Main.user.Name = Message;
						Form_Main.user.Email = jsondataChild.First.GetValue("Email").Value;
						Form_Main.user.Phone = jsondataChild.First.GetValue("Phone").Value;
						Form_Main.user.ChucNang = jsondataChild.First.GetValue("ChucNang").Value;
                        this.Close();
					}
					else
					{
						XtraMessageBox.Show(Message, "Thông Báo");
						this.Show();
					}
				}
				else
				{
					XtraMessageBox.Show("Không kết nối được tới Server! vui lòng thử lại sau", "Thông Báo");
				}
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_Login", "XuLyDangNhap()", ex.ToString()));
			}
		}

		private void Login()
		{
			this.Hide();
			SplashScreenManager.ShowDefaultWaitForm("Vui Lòng Chờ...", "Đang kết nối Server...");
			string username = txtUserName.Text;
			string password = EncryptPass(txtPassword.Text);
			XuLyDangNhap(username, password);
			SplashScreenManager.CloseForm(false);
		}

		#endregion Function

		#region Khởi Tạo
		public Form_Login()
        {
            InitializeComponent();
        }
		#endregion Khởi Tạo

		#region Event
		private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // xử lý enter khi đăng nhập
            if (e.KeyChar == (char)13)
            {
                Login();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
		private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				txtPassword.Focus();
			}
		}
		private void Form_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
		#endregion Event

		
	}
}