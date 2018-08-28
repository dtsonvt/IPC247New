namespace IPC247
{
    partial class Frm_NhomQuyen
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_NhomQuyen));
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.cbb_ThongTinNhom = new DevExpress.XtraEditors.TextEdit();
			this.btnHuyNhomQuyen = new DevExpress.XtraEditors.SimpleButton();
			this.btn_CapNhat = new DevExpress.XtraEditors.SimpleButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.grc_NhomQuyen = new DevExpress.XtraGrid.GridControl();
			this.grv_NhomQuyen = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcl_ID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcl_TenChucNang = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gcl_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
			this.rcheck_Chon = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.cbbSearchNhom = new DevExpress.XtraEditors.LookUpEdit();
			this.layoutmain = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutgroup_main = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			this.lctCbbNhomQuyen = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.dxErrorProvider_main = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menu_Add = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
			this.sep_1 = new System.Windows.Forms.ToolStripSeparator();
			this.menu_Allitem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cbb_ThongTinNhom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grc_NhomQuyen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grv_NhomQuyen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rcheck_Chon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cbbSearchNhom.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutmain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutgroup_main)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lctCbbNhomQuyen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider_main)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// layoutControl1
			// 
			this.layoutControl1.AllowCustomization = false;
			this.layoutControl1.Controls.Add(this.cbb_ThongTinNhom);
			this.layoutControl1.Controls.Add(this.btnHuyNhomQuyen);
			this.layoutControl1.Controls.Add(this.btn_CapNhat);
			this.layoutControl1.Controls.Add(this.pictureBox1);
			this.layoutControl1.Controls.Add(this.grc_NhomQuyen);
			this.layoutControl1.Controls.Add(this.cbbSearchNhom);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.Root = this.layoutmain;
			this.layoutControl1.Size = new System.Drawing.Size(975, 366);
			this.layoutControl1.TabIndex = 0;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// cbb_ThongTinNhom
			// 
			this.cbb_ThongTinNhom.Location = new System.Drawing.Point(75, 42);
			this.cbb_ThongTinNhom.Name = "cbb_ThongTinNhom";
			this.cbb_ThongTinNhom.Size = new System.Drawing.Size(137, 20);
			this.cbb_ThongTinNhom.StyleController = this.layoutControl1;
			this.cbb_ThongTinNhom.TabIndex = 9;
			this.cbb_ThongTinNhom.EditValueChanged += new System.EventHandler(this.cbb_ThongTinNhom_TextChanged);
			// 
			// btnHuyNhomQuyen
			// 
			this.btnHuyNhomQuyen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHuyNhomQuyen.ImageOptions.Image")));
			this.btnHuyNhomQuyen.Location = new System.Drawing.Point(347, 42);
			this.btnHuyNhomQuyen.Name = "btnHuyNhomQuyen";
			this.btnHuyNhomQuyen.Size = new System.Drawing.Size(62, 22);
			this.btnHuyNhomQuyen.StyleController = this.layoutControl1;
			this.btnHuyNhomQuyen.TabIndex = 7;
			this.btnHuyNhomQuyen.Text = "Hủy Bỏ";
			this.btnHuyNhomQuyen.Click += new System.EventHandler(this.btn_Delete_Click);
			// 
			// btn_CapNhat
			// 
			this.btn_CapNhat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_CapNhat.ImageOptions.Image")));
			this.btn_CapNhat.Location = new System.Drawing.Point(270, 42);
			this.btn_CapNhat.Name = "btn_CapNhat";
			this.btn_CapNhat.Size = new System.Drawing.Size(73, 22);
			this.btn_CapNhat.StyleController = this.layoutControl1;
			this.btn_CapNhat.TabIndex = 3;
			this.btn_CapNhat.Text = "Cập Nhật";
			this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(425, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(538, 342);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// grc_NhomQuyen
			// 
			this.grc_NhomQuyen.Location = new System.Drawing.Point(24, 68);
			this.grc_NhomQuyen.MainView = this.grv_NhomQuyen;
			this.grc_NhomQuyen.Name = "grc_NhomQuyen";
			this.grc_NhomQuyen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rcheck_Chon});
			this.grc_NhomQuyen.Size = new System.Drawing.Size(385, 274);
			this.grc_NhomQuyen.TabIndex = 6;
			this.grc_NhomQuyen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv_NhomQuyen});
			// 
			// grv_NhomQuyen
			// 
			this.grv_NhomQuyen.ActiveFilterEnabled = false;
			this.grv_NhomQuyen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gcl_ID,
            this.gcl_TenChucNang,
            this.gcl_Chon});
			this.grv_NhomQuyen.GridControl = this.grc_NhomQuyen;
			this.grv_NhomQuyen.GroupCount = 1;
			this.grv_NhomQuyen.Name = "grv_NhomQuyen";
			this.grv_NhomQuyen.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
			this.grv_NhomQuyen.OptionsCustomization.AllowFilter = false;
			this.grv_NhomQuyen.OptionsFilter.AllowColumnMRUFilterList = false;
			this.grv_NhomQuyen.OptionsFilter.AllowFilterEditor = false;
			this.grv_NhomQuyen.OptionsFilter.AllowFilterIncrementalSearch = false;
			this.grv_NhomQuyen.OptionsFilter.AllowMRUFilterList = false;
			this.grv_NhomQuyen.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
			this.grv_NhomQuyen.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
			this.grv_NhomQuyen.OptionsNavigation.AutoMoveRowFocus = false;
			this.grv_NhomQuyen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
			this.grv_NhomQuyen.OptionsView.ShowGroupPanel = false;
			this.grv_NhomQuyen.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
			this.grv_NhomQuyen.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grv_NhomQuyen_RowClick);
			this.grv_NhomQuyen.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grv_NhomQuyen_RowStyle);
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Tên Nhóm";
			this.gridColumn1.FieldName = "TenNhom";
			this.gridColumn1.FieldNameSortGroup = "TenNhom";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
			this.gridColumn1.OptionsColumn.AllowMove = false;
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 3;
			// 
			// gcl_ID
			// 
			this.gcl_ID.AppearanceCell.Options.UseTextOptions = true;
			this.gcl_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gcl_ID.Caption = "Mã CN";
			this.gcl_ID.FieldName = "ID";
			this.gcl_ID.Name = "gcl_ID";
			this.gcl_ID.OptionsColumn.AllowEdit = false;
			this.gcl_ID.OptionsColumn.AllowMove = false;
			this.gcl_ID.OptionsColumn.ReadOnly = true;
			this.gcl_ID.Visible = true;
			this.gcl_ID.VisibleIndex = 0;
			this.gcl_ID.Width = 59;
			// 
			// gcl_TenChucNang
			// 
			this.gcl_TenChucNang.AppearanceHeader.Options.UseTextOptions = true;
			this.gcl_TenChucNang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gcl_TenChucNang.Caption = "Tên Chức Năng";
			this.gcl_TenChucNang.FieldName = "TenChucNang";
			this.gcl_TenChucNang.Name = "gcl_TenChucNang";
			this.gcl_TenChucNang.OptionsColumn.AllowEdit = false;
			this.gcl_TenChucNang.OptionsColumn.AllowMove = false;
			this.gcl_TenChucNang.OptionsColumn.ReadOnly = true;
			this.gcl_TenChucNang.Visible = true;
			this.gcl_TenChucNang.VisibleIndex = 1;
			this.gcl_TenChucNang.Width = 259;
			// 
			// gcl_Chon
			// 
			this.gcl_Chon.Caption = "Chọn";
			this.gcl_Chon.ColumnEdit = this.rcheck_Chon;
			this.gcl_Chon.FieldName = "Chon";
			this.gcl_Chon.Name = "gcl_Chon";
			this.gcl_Chon.Visible = true;
			this.gcl_Chon.VisibleIndex = 2;
			// 
			// rcheck_Chon
			// 
			this.rcheck_Chon.AutoHeight = false;
			this.rcheck_Chon.Name = "rcheck_Chon";
			// 
			// cbbSearchNhom
			// 
			this.cbbSearchNhom.Location = new System.Drawing.Point(216, 42);
			this.cbbSearchNhom.Name = "cbbSearchNhom";
			this.cbbSearchNhom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
			this.cbbSearchNhom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhom", "Tên Nhóm"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
			this.cbbSearchNhom.Properties.DisplayMember = "TenNhom";
			this.cbbSearchNhom.Properties.NullText = "";
			this.cbbSearchNhom.Properties.PopupSizeable = false;
			this.cbbSearchNhom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
			this.cbbSearchNhom.Properties.ValueMember = "ID";
			this.cbbSearchNhom.Size = new System.Drawing.Size(50, 20);
			this.cbbSearchNhom.StyleController = this.layoutControl1;
			this.cbbSearchNhom.TabIndex = 8;
			this.cbbSearchNhom.EditValueChanged += new System.EventHandler(this.cbb_ThongTinNhom_EditValueChanged);
			// 
			// layoutmain
			// 
			this.layoutmain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutmain.GroupBordersVisible = false;
			this.layoutmain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutgroup_main,
            this.layoutControlItem3});
			this.layoutmain.Name = "layoutmain";
			this.layoutmain.Size = new System.Drawing.Size(975, 366);
			this.layoutmain.TextVisible = false;
			// 
			// layoutgroup_main
			// 
			this.layoutgroup_main.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.lctCbbNhomQuyen});
			this.layoutgroup_main.Location = new System.Drawing.Point(0, 0);
			this.layoutgroup_main.Name = "layoutgroup_main";
			this.layoutgroup_main.Size = new System.Drawing.Size(413, 346);
			this.layoutgroup_main.Text = "THÔNG TIN NHÓM QUYỀN";
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.grc_NhomQuyen;
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(389, 278);
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			this.layoutControlItem4.Control = this.btn_CapNhat;
			this.layoutControlItem4.Location = new System.Drawing.Point(246, 0);
			this.layoutControlItem4.MaxSize = new System.Drawing.Size(77, 26);
			this.layoutControlItem4.MinSize = new System.Drawing.Size(77, 26);
			this.layoutControlItem4.Name = "layoutControlItem4";
			this.layoutControlItem4.Size = new System.Drawing.Size(77, 26);
			this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.btnHuyNhomQuyen;
			this.layoutControlItem5.Location = new System.Drawing.Point(323, 0);
			this.layoutControlItem5.MaxSize = new System.Drawing.Size(66, 26);
			this.layoutControlItem5.MinSize = new System.Drawing.Size(66, 26);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(66, 26);
			this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			this.layoutControlItem2.Control = this.cbbSearchNhom;
			this.layoutControlItem2.Location = new System.Drawing.Point(192, 0);
			this.layoutControlItem2.MaxSize = new System.Drawing.Size(54, 26);
			this.layoutControlItem2.MinSize = new System.Drawing.Size(54, 26);
			this.layoutControlItem2.Name = "layoutControlItem2";
			this.layoutControlItem2.Size = new System.Drawing.Size(54, 26);
			this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem2.Text = "Nhóm Quyền";
			this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem2.TextVisible = false;
			// 
			// lctCbbNhomQuyen
			// 
			this.lctCbbNhomQuyen.Control = this.cbb_ThongTinNhom;
			this.lctCbbNhomQuyen.Location = new System.Drawing.Point(0, 0);
			this.lctCbbNhomQuyen.MaxSize = new System.Drawing.Size(192, 26);
			this.lctCbbNhomQuyen.MinSize = new System.Drawing.Size(192, 26);
			this.lctCbbNhomQuyen.Name = "lctCbbNhomQuyen";
			this.lctCbbNhomQuyen.Size = new System.Drawing.Size(192, 26);
			this.lctCbbNhomQuyen.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lctCbbNhomQuyen.Text = "Tên Nhóm";
			this.lctCbbNhomQuyen.TextSize = new System.Drawing.Size(48, 13);
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.pictureBox1;
			this.layoutControlItem3.Location = new System.Drawing.Point(413, 0);
			this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 24);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(542, 346);
			this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			this.layoutControlItem3.Click += new System.EventHandler(this.layoutControlItem3_Click);
			// 
			// dxErrorProvider_main
			// 
			this.dxErrorProvider_main.ContainerControl = this;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Add,
            this.menu_Save,
            this.menu_Delete,
            this.sep_1,
            this.menu_Allitem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(186, 98);
			// 
			// menu_Add
			// 
			this.menu_Add.Name = "menu_Add";
			this.menu_Add.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.menu_Add.Size = new System.Drawing.Size(185, 22);
			this.menu_Add.Text = "Thêm Nhóm";
			this.menu_Add.Click += new System.EventHandler(this.menu_Add_Click);
			// 
			// menu_Save
			// 
			this.menu_Save.Name = "menu_Save";
			this.menu_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.menu_Save.Size = new System.Drawing.Size(185, 22);
			this.menu_Save.Text = "Cập Nhật";
			this.menu_Save.Click += new System.EventHandler(this.menu_Save_Click);
			// 
			// menu_Delete
			// 
			this.menu_Delete.Name = "menu_Delete";
			this.menu_Delete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.menu_Delete.Size = new System.Drawing.Size(185, 22);
			this.menu_Delete.Text = "Xóa";
			this.menu_Delete.Click += new System.EventHandler(this.menu_Delete_Click);
			// 
			// sep_1
			// 
			this.sep_1.Name = "sep_1";
			this.sep_1.Size = new System.Drawing.Size(182, 6);
			// 
			// menu_Allitem
			// 
			this.menu_Allitem.Name = "menu_Allitem";
			this.menu_Allitem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.menu_Allitem.Size = new System.Drawing.Size(185, 22);
			this.menu_Allitem.Text = "Chọn Tất Cả";
			this.menu_Allitem.Click += new System.EventHandler(this.menu_Allitem_Click);
			// 
			// Frm_NhomQuyen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(975, 366);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.layoutControl1);
			this.Name = "Frm_NhomQuyen";
			this.Text = "PHÂN QUYỀN CHỨC NĂNG";
			this.Load += new System.EventHandler(this.Frm_NhomQuyen_Load);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cbb_ThongTinNhom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grc_NhomQuyen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grv_NhomQuyen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rcheck_Chon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cbbSearchNhom.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutmain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutgroup_main)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lctCbbNhomQuyen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider_main)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutmain;
        private DevExpress.XtraLayout.LayoutControlGroup layoutgroup_main;
        private DevExpress.XtraGrid.GridControl grc_NhomQuyen;
        private DevExpress.XtraGrid.Views.Grid.GridView grv_NhomQuyen;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcl_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gcl_TenChucNang;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btn_CapNhat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider_main;
        private DevExpress.XtraGrid.Columns.GridColumn gcl_Chon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rcheck_Chon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_Add;
        private System.Windows.Forms.ToolStripMenuItem menu_Save;
        private System.Windows.Forms.ToolStripMenuItem menu_Delete;
        private System.Windows.Forms.ToolStripSeparator sep_1;
        private System.Windows.Forms.ToolStripMenuItem menu_Allitem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnHuyNhomQuyen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit cbbSearchNhom;
        private DevExpress.XtraEditors.TextEdit cbb_ThongTinNhom;
        private DevExpress.XtraLayout.LayoutControlItem lctCbbNhomQuyen;
    }
}