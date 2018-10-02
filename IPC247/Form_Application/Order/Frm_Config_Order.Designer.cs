namespace IPC247
{
    partial class Frm_Config_Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lct_Main = new DevExpress.XtraLayout.LayoutControl();
            this.lcg_Main = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dgc_Main = new DevExpress.XtraGrid.GridControl();
            this.dgv_Main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).BeginInit();
            this.lct_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgc_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lct_Main
            // 
            this.lct_Main.Controls.Add(this.dgc_Main);
            this.lct_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lct_Main.Location = new System.Drawing.Point(0, 0);
            this.lct_Main.Name = "lct_Main";
            this.lct_Main.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lct_Main.Root = this.lcg_Main;
            this.lct_Main.Size = new System.Drawing.Size(878, 520);
            this.lct_Main.TabIndex = 0;
            this.lct_Main.Text = "layoutControl1";
            // 
            // lcg_Main
            // 
            this.lcg_Main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg_Main.GroupBordersVisible = false;
            this.lcg_Main.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcg_Main.Name = "lcg_Main";
            this.lcg_Main.Size = new System.Drawing.Size(878, 520);
            this.lcg_Main.TextVisible = false;
            // 
            // dgc_Main
            // 
            this.dgc_Main.Location = new System.Drawing.Point(12, 12);
            this.dgc_Main.MainView = this.dgv_Main;
            this.dgc_Main.Name = "dgc_Main";
            this.dgc_Main.Size = new System.Drawing.Size(854, 496);
            this.dgc_Main.TabIndex = 4;
            this.dgc_Main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv_Main});
            // 
            // dgv_Main
            // 
            this.dgv_Main.GridControl = this.dgc_Main;
            this.dgv_Main.Name = "dgv_Main";
            this.dgv_Main.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgv_Main.OptionsBehavior.Editable = false;
            this.dgv_Main.OptionsBehavior.ReadOnly = true;
            this.dgv_Main.OptionsCustomization.AllowColumnMoving = false;
            this.dgv_Main.OptionsCustomization.AllowColumnResizing = false;
            this.dgv_Main.OptionsCustomization.AllowFilter = false;
            this.dgv_Main.OptionsCustomization.AllowGroup = false;
            this.dgv_Main.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgv_Main.OptionsCustomization.AllowSort = false;
            this.dgv_Main.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.dgv_Main.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.dgv_Main.OptionsFilter.AllowFilterEditor = false;
            this.dgv_Main.OptionsMenu.EnableColumnMenu = false;
            this.dgv_Main.OptionsMenu.EnableFooterMenu = false;
            this.dgv_Main.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgv_Main.OptionsMenu.ShowAutoFilterRowItem = false;
            this.dgv_Main.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.dgv_Main.OptionsNavigation.AutoMoveRowFocus = false;
            this.dgv_Main.OptionsSelection.MultiSelect = true;
            this.dgv_Main.OptionsView.ColumnAutoWidth = false;
            this.dgv_Main.OptionsView.EnableAppearanceOddRow = true;
            this.dgv_Main.OptionsView.RowAutoHeight = true;
            this.dgv_Main.OptionsView.ShowAutoFilterRow = true;
            this.dgv_Main.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgv_Main.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dgc_Main;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(858, 500);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Frm_Config_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 520);
            this.Controls.Add(this.lct_Main);
            this.Name = "Frm_Config_Order";
            this.Text = "CẤU HÌNH THÔNG TIN ĐƠN HÀNG";
            this.Load += new System.EventHandler(this.Frm_Config_Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).EndInit();
            this.lct_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcg_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgc_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lct_Main;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_Main;
        private DevExpress.XtraGrid.GridControl dgc_Main;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv_Main;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}