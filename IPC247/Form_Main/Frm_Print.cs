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

namespace IPC247
{
    public partial class Frm_Print : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Print()
        {
            InitializeComponent();
        }

        public void Print(List<InfoCustomerPrint> header)
        {
            Report.Report_BaoGia bill = new Report.Report_BaoGia();
            bill.Print(header);
            documentViewer1.DocumentSource = bill;
            bill.CreateDocument();
        }
    }
}