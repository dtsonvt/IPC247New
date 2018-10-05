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
    public partial class Frm_Config_Order : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Config_Order()
        {
            InitializeComponent();
        }

        private void LoadMasterData()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTable("sp_getData_Quote_header");
                
                
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "MasterData_Commission", "LoadMasterData()", ex.ToString()));
            }
        }

        private void Frm_Config_Order_Load(object sender, EventArgs e)
        {
            LoadMasterData();
        }
    }
}