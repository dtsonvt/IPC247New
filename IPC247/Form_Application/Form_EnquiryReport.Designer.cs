namespace IPC247
{
    partial class Form_EnquiryReport
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dgc_Main = new DevExpress.XtraGrid.GridControl();
            this.dgv_Main = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclEnquiryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclMoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gclCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDeadLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclNguoiPhuTrach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclOld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgc_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dgc_Main);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1213, 598);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dgc_Main
            // 
            this.dgc_Main.Location = new System.Drawing.Point(12, 12);
            this.dgc_Main.MainView = this.dgv_Main;
            this.dgc_Main.Name = "dgc_Main";
            this.dgc_Main.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoExEdit1,
            this.repositoryItemMemoEdit1});
            this.dgc_Main.Size = new System.Drawing.Size(1189, 574);
            this.dgc_Main.TabIndex = 4;
            this.dgc_Main.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgv_Main});
            // 
            // dgv_Main
            // 
            this.dgv_Main.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclCompanyName,
            this.gclDescription,
            this.gclCardName,
            this.gclSDT,
            this.gclEmail,
            this.gclEnquiryName,
            this.gclMoTa,
            this.gclCreateDate,
            this.gclDeadLine,
            this.gclTrangThai,
            this.gclNguoiPhuTrach,
            this.gclOld});
            this.dgv_Main.GridControl = this.dgc_Main;
            this.dgv_Main.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ThanhTien", null, "(Thành Tiền: SUM={0:n0})")});
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
            this.dgv_Main.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.dgv_Main.OptionsFilter.AllowFilterEditor = false;
            this.dgv_Main.OptionsMenu.EnableColumnMenu = false;
            this.dgv_Main.OptionsMenu.EnableFooterMenu = false;
            this.dgv_Main.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgv_Main.OptionsMenu.ShowAutoFilterRowItem = false;
            this.dgv_Main.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.dgv_Main.OptionsNavigation.AutoMoveRowFocus = false;
            this.dgv_Main.OptionsSelection.MultiSelect = true;
            this.dgv_Main.OptionsView.AllowCellMerge = true;
            this.dgv_Main.OptionsView.ColumnAutoWidth = false;
            this.dgv_Main.OptionsView.EnableAppearanceOddRow = true;
            this.dgv_Main.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.dgv_Main.OptionsView.RowAutoHeight = true;
            this.dgv_Main.OptionsView.ShowAutoFilterRow = true;
            this.dgv_Main.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.dgv_Main.OptionsView.ShowFooter = true;
            this.dgv_Main.OptionsView.ShowGroupPanel = false;
            this.dgv_Main.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.dgv_Main_CellMerge);
            this.dgv_Main.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.dgv_Main_RowStyle);
            // 
            // gclCompanyName
            // 
            this.gclCompanyName.Caption = "Công Ty";
            this.gclCompanyName.FieldName = "CompanyName";
            this.gclCompanyName.Name = "gclCompanyName";
            this.gclCompanyName.Visible = true;
            this.gclCompanyName.VisibleIndex = 0;
            // 
            // gclDescription
            // 
            this.gclDescription.Caption = "Mô Tả Ngắn";
            this.gclDescription.FieldName = "Description";
            this.gclDescription.Name = "gclDescription";
            this.gclDescription.Visible = true;
            this.gclDescription.VisibleIndex = 1;
            // 
            // gclCardName
            // 
            this.gclCardName.Caption = "Tên Khách Hàng";
            this.gclCardName.FieldName = "CardName";
            this.gclCardName.Name = "gclCardName";
            this.gclCardName.Visible = true;
            this.gclCardName.VisibleIndex = 2;
            // 
            // gclSDT
            // 
            this.gclSDT.Caption = "SĐT";
            this.gclSDT.FieldName = "SDT";
            this.gclSDT.Name = "gclSDT";
            this.gclSDT.Visible = true;
            this.gclSDT.VisibleIndex = 3;
            // 
            // gclEmail
            // 
            this.gclEmail.Caption = "Email";
            this.gclEmail.FieldName = "Email";
            this.gclEmail.Name = "gclEmail";
            this.gclEmail.Visible = true;
            this.gclEmail.VisibleIndex = 4;
            // 
            // gclEnquiryName
            // 
            this.gclEnquiryName.Caption = "Tên Dự Án";
            this.gclEnquiryName.FieldName = "EnquiryName";
            this.gclEnquiryName.Name = "gclEnquiryName";
            this.gclEnquiryName.Visible = true;
            this.gclEnquiryName.VisibleIndex = 5;
            // 
            // gclMoTa
            // 
            this.gclMoTa.Caption = "Chi Tiết Dự Án";
            this.gclMoTa.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gclMoTa.FieldName = "Mota";
            this.gclMoTa.Name = "gclMoTa";
            this.gclMoTa.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gclMoTa.Visible = true;
            this.gclMoTa.VisibleIndex = 6;
            this.gclMoTa.Width = 115;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gclCreateDate
            // 
            this.gclCreateDate.Caption = "Ngày Tạo";
            this.gclCreateDate.FieldName = "Date";
            this.gclCreateDate.Name = "gclCreateDate";
            this.gclCreateDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gclCreateDate.Visible = true;
            this.gclCreateDate.VisibleIndex = 7;
            // 
            // gclDeadLine
            // 
            this.gclDeadLine.Caption = "Thời Hạn";
            this.gclDeadLine.FieldName = "DeadLine";
            this.gclDeadLine.Name = "gclDeadLine";
            this.gclDeadLine.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gclDeadLine.Visible = true;
            this.gclDeadLine.VisibleIndex = 8;
            // 
            // gclTrangThai
            // 
            this.gclTrangThai.Caption = "Trạng Thái";
            this.gclTrangThai.FieldName = "TrangThai";
            this.gclTrangThai.Name = "gclTrangThai";
            this.gclTrangThai.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gclTrangThai.Visible = true;
            this.gclTrangThai.VisibleIndex = 9;
            // 
            // gclNguoiPhuTrach
            // 
            this.gclNguoiPhuTrach.Caption = "Người Phụ Trách";
            this.gclNguoiPhuTrach.FieldName = "NguoiPhuTrach";
            this.gclNguoiPhuTrach.Name = "gclNguoiPhuTrach";
            this.gclNguoiPhuTrach.Visible = true;
            this.gclNguoiPhuTrach.VisibleIndex = 10;
            this.gclNguoiPhuTrach.Width = 123;
            // 
            // gclOld
            // 
            this.gclOld.Caption = "Old";
            this.gclOld.FieldName = "Old";
            this.gclOld.Name = "gclOld";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1213, 598);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dgc_Main;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1193, 578);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Form_EnquiryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 598);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Form_EnquiryReport";
            this.Text = "THÔNG TIN DỰ ÁN";
            this.Activated += new System.EventHandler(this.Form_EnquiryReport_Load);
            this.Load += new System.EventHandler(this.Form_EnquiryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgc_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl dgc_Main;
        private DevExpress.XtraGrid.Views.Grid.GridView dgv_Main;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gclCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gclDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gclCardName;
        private DevExpress.XtraGrid.Columns.GridColumn gclSDT;
        private DevExpress.XtraGrid.Columns.GridColumn gclEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gclEnquiryName;
        private DevExpress.XtraGrid.Columns.GridColumn gclMoTa;
        private DevExpress.XtraGrid.Columns.GridColumn gclCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gclDeadLine;
        private DevExpress.XtraGrid.Columns.GridColumn gclTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn gclNguoiPhuTrach;
        private DevExpress.XtraGrid.Columns.GridColumn gclOld;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}