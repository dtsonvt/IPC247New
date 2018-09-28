using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AutoUpdate
{
    public partial class Form_AutoUpdate : DevExpress.XtraEditors.XtraForm
    {
        public Form_AutoUpdate()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                do
                {
                    foreach (var process in Process.GetProcessesByName("IPC247"))
                    {
                        process.Kill();
                    }
                } while (Process.GetProcessesByName("IPC247").Count() > 0);
            }
            catch (Exception ex)
            {
              //  SendMailERROR(string.Format("Lỗi rồi Kill IPC247: {0}", ex.ToString()));
            }
            string path_FileVersion = AppDomain.CurrentDomain.BaseDirectory + "version.txt";
            if(File.Exists(path_FileVersion))
            {
                string[] lines = System.IO.File.ReadAllLines(path_FileVersion);
                if(lines.Count() == 2)
                {
                    lblCapNhat.Text = "AUTO UPDATE " + lines[0].ToString();
                    string thongbao = lines[1].ToString();
                    string[] row = thongbao.Split('-');
                    this.Height = this.Height + 12 * (row.Count()-1);
                    lblUpdateDetails.Text = thongbao.Replace("-", "\r\n");
                }
            }
            else
            {
                MessageBox.Show("Mày đã làm gì");
            }
        }

        private void startDownload(string Url, string Path_File)
        {
            try
            {
                lblThongBao.Text = "Đang Tải dữ liệu...";
                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                    client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                    client.DownloadFileAsync(new Uri(Url), Path_File);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã Phát sinh lỗi trong quá trình xử lý, Vui lòng liên hệ quản trị để được hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendMailERROR(string.Format("Lỗi rồi startDownload: {0}", ex.ToString()));
                Application.Exit();
            }
        }
        private static void SendMailERROR(string Error)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.Credentials = new System.Net.NetworkCredential("IPC247Mail@gmail.com", "Th@ison@123456");
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailMessage mail = new MailMessage("dtson.vt@gmail.com", "sondt13@fpt.com.vn");
                    mail.Subject = "Admin - ERROR LOG";
                    mail.Body = Error;
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thế này chịu rồi",ex.ToString());
            }

        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                lblThongBao.Text = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                progressBarControl1.EditValue = int.Parse(Math.Truncate(percentage).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã Phát sinh lỗi trong quá trình xử lý, Vui lòng liên hệ quản trị để được hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendMailERROR(string.Format("Lỗi rồi client_DownloadProgressChanged: {0}", ex.ToString()));
                Application.Exit();
            }
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                lblThongBao.Text = "Đã Tải File Xong";
                Application.DoEvents();
                lblThongBao.Text = "Đang cập nhật dữ liêu...";
                Application.DoEvents();
                string Path_File = AppDomain.CurrentDomain.BaseDirectory + "Update.Zip";
                using (ZipFile zip = ZipFile.Read(Path_File))
                {
                    zip.ExtractAll(AppDomain.CurrentDomain.BaseDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
                if (File.Exists(Path_File))
                {
                    File.Delete(Path_File);
                }
                lblThongBao.Text = "Version mới đã được cập nhật!";
                Application.DoEvents();
                lblThongBao.Text = "Đang khởi động chương trình...";
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "IPC247.exe");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show( "Đã Phát sinh lỗi trong quá trình xử lý, Vui lòng liên hệ quản trị để được hỗ trợ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendMailERROR(string.Format("Lỗi rồi client_DownloadFileCompleted: {0}", ex.ToString()));
                Application.Exit();
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Url = "http://171.244.140.175:2018/Uploads/Update/Update.zip";
            string Path_File = AppDomain.CurrentDomain.BaseDirectory + "Update.Zip";
            startDownload(Url, Path_File);
        }
    }
}
