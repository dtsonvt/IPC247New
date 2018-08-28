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
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Web.Script.Serialization;
using System.Drawing.Imaging;

namespace IPC247
{
    public partial class Form_MasterData : DevExpress.XtraEditors.XtraForm
    {
        public Form_MasterData()
        {
            InitializeComponent();
        }
        bool flag_Image1 = false;
        bool flag_Image2 = false;

        private void SaveInfo()
        {
            try
            {
                InfoIPC ipc = new InfoIPC();
                ipc.TenCongTy = txtTenCty.Text;
                ipc.NguoiGui = txtNguoiGui.Text;
                ipc.Mobile = txtMobile.Text;
                ipc.Email = txtEmail.Text;
                ipc.DiaChi = txtDiaChi.Text;
                var jsonsave = new JavaScriptSerializer().Serialize(ipc);
                string base64info = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonsave.ToString()));
                string str = "[" + string.Format(@"{{""Key"":""Key"",""value"":""{0}"",""Type"":""string""}},{{""Key"":""Value"",""value"":""{1}"",""Type"":""string""}},{{""Key"":""UserID"",""value"":""{2}"",""Type"":""string""}}", "Info", base64info, Form_Main.user.Username) + "]";

                var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_UpdateInfoMaster", Param = str });
                string sLink = Form_Main.URL_API+ "/api/IPC247/sp_extension_SaveQuote";
                json = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                XtraMessageBox.Show(Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "SaveInfo()", ex.ToString()));
				XtraMessageBox.Show("Cập Nhật Thông Tin Không Thành Công", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
			try
			{
				using (var ms = new MemoryStream())
				{
					imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
					return ms.ToArray();
				}
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "ImageToByteArray", ex.ToString()));
			}
			return null;
        }
        /// <summary>
        /// ImageIndex : option 1: ImageLeft/ 2: ImageRight 
        /// </summary>
        /// <param name="ImageIndex"></param>
        private void SaveImage(string ImageIndex)
        {
            try
            {
                Image img;
                if (ImageIndex == "ImageLeft")
                {
                    img = ptbHinhTrai.Image;

                }
                else
                {
                    img = ptbHinhPhai.Image;
                }
                string base64 = "";
                if (img != null)
                {
                    base64 = Convert.ToBase64String(ImageToByteArray(img));
                }
                string str = "[" + string.Format(@"{{""Key"":""Key"",""value"":""{0}"",""Type"":""string""}},{{""Key"":""Value"",""value"":""{1}"",""Type"":""string""}},{{""Key"":""UserID"",""value"":""{2}"",""Type"":""string""}}", ImageIndex, base64, Form_Main.user.Username) + "]";

                var json = new JavaScriptSerializer().Serialize(new { StoreProcedure = "sp_UpdateInfoMaster", Param = str });
                string sLink = Form_Main.URL_API+ "/api/IPC247/sp_extension_SaveQuote";
                json = API.API_POS(sLink, json);
                dynamic jsondata = JObject.Parse(json);
                var jsondataChild = jsondata.GetValue("Data");
                var Result = jsondataChild.First.GetValue("Result").Value;
                var Message = jsondataChild.First.GetValue("Message").Value;

                // XtraMessageBox.Show(Message, "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "SaveImage()", ex.ToString()));
				XtraMessageBox.Show("Cập Nhật Thông Tin Không Thành Công", "Thông Báo", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static InfoIPC LoadFromXMLString(string xmlText)
        {
			try
			{
				var stringReader = new System.IO.StringReader(xmlText);
				var serializer = new XmlSerializer(typeof(InfoIPC));
				return serializer.Deserialize(stringReader) as InfoIPC;
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "LoadFromXMLString()", ex.ToString()));
			}
			return null;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveInfo();
            if (flag_Image1)
            {
                SaveImage("ImageLeft");
            }
            if (flag_Image2)
            {
                SaveImage("ImageRight");
            }
            LoadThongTinDefaultBeforSave();
        }
        private void LoadThongTinDefault()
        {
            try
            {
                txtTenCty.Text = Form_Main.info.TenCongTy;
                txtNguoiGui.Text = Form_Main.info.NguoiGui;
                txtMobile.Text = Form_Main.info.Mobile;
                txtEmail.Text = Form_Main.info.Email;
                txtDiaChi.Text = Form_Main.info.DiaChi;

                string FilePaht = AppDomain.CurrentDomain.BaseDirectory + "/AppData/Image/ImageLeft.jpg";
                if (File.Exists(FilePaht))
                {
                    using (FileStream stream = new FileStream(FilePaht, FileMode.Open, FileAccess.Read))
                    {
                        ptbHinhTrai.Image = Image.FromStream(stream);
                    }
                }
                FilePaht = AppDomain.CurrentDomain.BaseDirectory + "/AppData/Image/ImageRight.jpg";
                if (File.Exists(FilePaht))
                {
                    using (FileStream stream = new FileStream(FilePaht, FileMode.Open, FileAccess.Read))
                    {
                        ptbHinhPhai.Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "LoadThongTinDefault()", ex.ToString()));
			}
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
			try
			{
				MemoryStream ms = new MemoryStream(byteArrayIn);
				Image returnImage = Image.FromStream(ms);
				return returnImage;
			}
			catch (Exception ex)
			{
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "LoadThongTinDefault()", ex.ToString()));
			}
			return null;
        }
        private void LoadThongTinDefaultBeforSave()
        {
            try
            {
                string sql_Exect = "Exec sp_GetInfoMaster @Key='Info,ImageLeft,ImageRight'"; //11

                string sLink =Form_Main.URL_API+ "/api/IPC247/sp_extension_GetDataByQueryString?str_Query=" + sql_Exect;
                var json = API.API_GET(sLink);

                var jsondata = JObject.Parse(json).GetValue("Data");
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsondata.ToString(), (typeof(DataTable)));
                string base64 = dt.Rows[0][0].ToString();

                json = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64));
                JObject a = JObject.Parse(json);
                Form_Main.info.TenCongTy = a.GetValue("TenCongTy").ToString();
                Form_Main.info.NguoiGui = a.GetValue("NguoiGui").ToString();
                Form_Main.info.Mobile = a.GetValue("Mobile").ToString();
                Form_Main.info.Email = a.GetValue("Email").ToString();
                Form_Main.info.DiaChi = a.GetValue("DiaChi").ToString();
                txtTenCty.Text = Form_Main.info.TenCongTy;
                txtNguoiGui.Text = Form_Main.info.NguoiGui;
                txtMobile.Text = Form_Main.info.Mobile;
                txtEmail.Text = Form_Main.info.Email;
                txtDiaChi.Text = Form_Main.info.DiaChi;

                string FileFolder = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "AppData/Image";
                if (!Directory.Exists(FileFolder))
                {
                    Directory.CreateDirectory(FileFolder);
                }
                if (ptbHinhTrai.Image != null)
                {
                    FileFolder = FileFolder + "/" + "ImageLeft.jpg";
                    if (File.Exists(FileFolder))
                    {
                        if(flag_Image1)
                        {
                            File.Delete(FileFolder);
                            try
                            {
                                ptbHinhTrai.Image.Save(FileFolder, ImageFormat.Jpeg);
                            }
                            catch (Exception ex)
                            {
								API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "ImageLeft()", ex.ToString()));
							}
                        }
                    }
                }
                if (ptbHinhPhai.Image != null)
                {
                    FileFolder = AppDomain.CurrentDomain.BaseDirectory.Replace("\\","/") + "AppData/Image";
                    FileFolder = FileFolder + "/" + "ImageRight.jpg";
                    if (File.Exists(FileFolder))
                    {
                        if(flag_Image2)
                        {
                            File.Delete(FileFolder);
                            try
                            {
                                ptbHinhPhai.Image.Save(FileFolder, ImageFormat.Jpeg);
                            }
                            catch (Exception ex)
                            {
								API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "ImageRight()", ex.ToString()));
							}
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "LoadThongTinDefaultBeforSave()", ex.ToString()));
			}
        }

        private void Form_MasterData_Load(object sender, EventArgs e)
        {
            LoadThongTinDefault();
        }

        private void ptbHinhTrai_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Open Image";
                dlg.Filter = "Image files(*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(dlg.FileName);
                    if (img.Width != 350 || img.Height != 100)
                    {
                        if (DialogResult.Cancel == XtraMessageBox.Show("File bạn chọn có kích thước không đúng với kích thước 350x100!", "Bạn có chắc muốn sử dụng hình này", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                        {
                            return;
                        }
                    }
                    else
                    {
                        flag_Image1 = true;
                        ptbHinhTrai.Image = Image.FromFile(dlg.FileName);
                    }
                }

                dlg.Dispose();
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "ptbHinhTrai_Click", ex.ToString()));
				XtraMessageBox.Show("File Bạn Chọn Không Đúng Format", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ptbHinhPhai_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Open Image";
                dlg.Filter = "Image files(*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";


                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Image img = Image.FromFile(dlg.FileName);
                    if (img.Width != 450 || img.Height != 100)
                    {
                        if (DialogResult.Cancel == XtraMessageBox.Show("File bạn chọn có kích thước không đúng với kích thước 450x100!", "Bạn có chắc muốn sử dụng hình này", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                        {
                            return;
                        }
                    }
                    else
                    {
                        flag_Image2 = true;
                        ptbHinhPhai.Image = Image.FromFile(dlg.FileName);
                    }
                }

                dlg.Dispose();
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Form_MasterData", "ptbHinhPhai_Click", ex.ToString()));
				XtraMessageBox.Show("File Bạn Chọn Không Đúng Format", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}