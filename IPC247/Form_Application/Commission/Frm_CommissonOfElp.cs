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
using DevExpress.XtraGrid.Views.Grid;

namespace IPC247
{
    public partial class Frm_CommissonOfElp : DevExpress.XtraEditors.XtraForm
    {
        public Frm_CommissonOfElp()
        {
            InitializeComponent();
        }
        void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!dgv_Main.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
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
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_Main); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, dgv_Main); }));
            }
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
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
            dgv_Main.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
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
                param.Add("p_FromDate", dte_FromDate.Text == "" ? "" : dte_FromDate.DateTime.ToString("dd/MM/yyyy")); //0
                param.Add("p_ToDate", dte_ToDate.Text == "" ? "" : dte_ToDate.DateTime.ToString("dd/MM/yyyy")); //0
                param.Add("UserName", slu_SearchUser.EditValue.ToString()); //2
                param.Add("UserID", Form_Main.user.Username); //3
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataSetUndefine("sp_Get_Commission_Of_Employees", param);
                DataTable dt = new DataTable();
                if (ds != null && ds.Tables.Count == 2)
                {
                    dt = ds.Tables[0];
                }
                dgc_Main.DataSource = dt;
                dt = ds.Tables[1];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string colname = dt.Rows[i][0].ToString();
                    if (colname != null && colname != "")
                    {
                        dgv_Main.Columns[colname].Visible = true;
                    }
                }
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
                    txtSumAllAmountOfElp.EditValue = dgv_Main.GetDataRow(focus)["SumAmount"];
                    decimal commissionAmount = 0;
                    decimal commissionProduct = 0;
                    decimal.TryParse(dgv_Main.GetDataRow(focus)["CommissionOfAmount"].ToString(), out commissionAmount);
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
            catch (Exception ex)
            {
                API.API_ERRORLOG(new ERRORLOG(Form_Main.IPAddress, "Frm_CommissonOfElp", "dgc_Main_Click()", ex.ToString()));
            }

        }

        private void dgv_Main_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (View.RowCount > 0)
            {
                if (e.RowHandle >= 0)
                {
                    string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["RowStyle"]);
                    switch (category)
                    {
                        //0 đã thanh toán - green / 1 : chưa đến hạn -yellow / 2 đã trễ hạn red
                        case "0":
                            e.Appearance.BackColor = Color.LightGreen;
                            // e.Appearance.BackColor2 = Color.White;
                            break;
                        case "1":
                            e.Appearance.BackColor = Color.Gold;
                            // e.Appearance.BackColor2 = Color.White;
                            break;
                        default:
                            e.Appearance.BackColor = Color.OrangeRed;
                            //  e.Appearance.BackColor2 = Color.White;
                            break;
                    }
                }
            }
        }
    }
}