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
    public partial class Frm_CommissonOfElp : DevExpress.XtraEditors.XtraForm
    {
        public Frm_CommissonOfElp()
        {
            InitializeComponent();
        }

        private void LoadComboboxUser()
        {
            try
            {
                DataTable dt = SQLHelper.ExecuteDataTable("sp_Get_ListUser_All");
                slu_SearchUser.Properties.DataSource = dt;
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_CommissonOfElp", "LoadComboboxUser()", ex.ToString()));
            }
        }

        private void Frm_CommissonOfElp_Load(object sender, EventArgs e)
        {
            LoadComboboxUser();
            slu_SearchUser.EditValue = "";
            txtNam.EditValue = DateTime.Now.Year;
            cbb_Month.EditValue = DateTime.Now.Month;

        }
        private void LoadFormDateToDate()
        {
            try
            {
                int Month = 0;
                int Year = 0;
                int.TryParse(cbb_Month.Text, out Month);
                int.TryParse(txtNam.Text, out Year);
                dte_FromDate.EditValue = new DateTime(Year, Month, 1);
                dte_ToDate.EditValue = dte_FromDate.DateTime.AddMonths(1).AddDays(-1);
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_CommissonOfElp", "LoadFormDateToDate()", ex.ToString()));
            }
        }

        private void cbb_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFormDateToDate();
        }

        private void btn_SearchIfo_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("p_FromDate", dte_FromDate.DateTime.ToString("dd/MM/yyyy")); //0
                param.Add("p_ToDate", dte_ToDate.DateTime.ToString("dd/MM/yyyy")); //0
                param.Add("UserName", slu_SearchUser.EditValue.ToString()); //2
                DataTable dt = new DataTable();
                dt = SQLHelper.ExecuteDataTableUndefine("sp_Get_Commission_Of_Employees", param);

                dgc_Main.DataSource = dt;
                dgv_Main.BestFitColumns(true);
            }
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_CommissonOfElp", "btn_SearchIfo_Click()", ex.ToString()));
            }
        }

        private void cbb_Month_TextChanged(object sender, EventArgs e)
        {
            LoadFormDateToDate();
        }

        private void dgc_Main_Click(object sender, EventArgs e)
        {
            try
            {
                int focus = dgv_Main.FocusedRowHandle;
                if (focus >= 0)
                {
                    txtSumAllAmountOfElp.EditValue =  dgv_Main.GetDataRow(focus)["SumAmount"];
                    decimal commissionAmount = 0;
                    decimal commissionProduct = 0;
                    decimal.TryParse(dgv_Main.GetDataRow(focus)["CommissionOfAmount"].ToString(),out commissionAmount);
                    decimal.TryParse(dgv_Main.GetDataRow(focus)["SumCommission"].ToString(), out commissionProduct);
                    txt_SumCommissionAmountOfElp.EditValue = commissionAmount;
                    txt_CommissionOfProductElp.EditValue = commissionProduct;
                    txt_SumAllCommissionOfElp.EditValue = commissionAmount + commissionProduct;
                    decimal commissionAmount_all = 0;
                    decimal commissionProduct_all = 0;
                    decimal.TryParse(dgv_Main.GetDataRow(focus)["CommissionOfAmountAll"].ToString(), out commissionAmount_all);
                    decimal.TryParse(dgv_Main.GetDataRow(focus)["SumCommissionAll"].ToString(), out commissionProduct_all);
                    txt_SumAllOrderOfDate.EditValue = dgv_Main.GetDataRow(focus)["SumAmountAll"];
                    txt_SumCommissionAmount.EditValue = commissionAmount_all;
                    txt_SumCommisionProduct.EditValue = commissionProduct_all;
                    txt_SumAllcommision.EditValue = commissionAmount_all + commissionProduct_all;
                }
            }
            catch(Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_CommissonOfElp", "dgc_Main_Click()", ex.ToString()));
            }

        }
    }
}