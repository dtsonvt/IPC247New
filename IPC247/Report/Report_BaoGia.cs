using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.IO;

namespace IPC247.Report
{
    public partial class Report_BaoGia : DevExpress.XtraReports.UI.XtraReport
    {
        public Report_BaoGia()
        {
            InitializeComponent();
        }

        public void Print(List<InfoCustomerPrint> header)
        {
            objectDataSource1.DataSource = header;
            try
            {
                string fileName = AppDomain.CurrentDomain.BaseDirectory + "/AppData/Image/ImageLeft.jpg";
                Image img;
                if(File.Exists(fileName))
                {
                    img = Image.FromFile(fileName);
                    ptbHinhTrai.Image = img;
                }
                fileName = AppDomain.CurrentDomain.BaseDirectory + "/AppData/Image/ImageRight.jpg";
                {
                    img = Image.FromFile(fileName);
                    ptbHinhPhai.Image = img;
                }
            }
            catch (Exception ex)
            {
				API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Report_BaoGia", "Print()", ex.ToString()));
			}
         //   objectDataSource2.DataSource = details;
        }
    }
}
