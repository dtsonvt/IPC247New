namespace IPC247
{
    partial class Form_Add_Enquiry
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
            this.lct_Main = new DevExpress.XtraLayout.LayoutControl();
            this.btnChonvsThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnCapNhat = new DevExpress.XtraEditors.SimpleButton();
            this.btnTaoMoi = new DevExpress.XtraEditors.SimpleButton();
            this.txtMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.txtCongty = new DevExpress.XtraEditors.ButtonEdit();
            this.txtKhachHang = new DevExpress.XtraEditors.ButtonEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtEnquiry = new DevExpress.XtraEditors.ButtonEdit();
            this.txtPhuTrach = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcg_main = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lctCustomer = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgThongtinkh = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lctMoTa = new DevExpress.XtraLayout.LayoutControlItem();
            this.lctCongty = new DevExpress.XtraLayout.LayoutControlItem();
            this.lctKhachHang = new DevExpress.XtraLayout.LayoutControlItem();
            this.lctSDT = new DevExpress.XtraLayout.LayoutControlItem();
            this.lctEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.lctPhuTrach = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).BeginInit();
            this.lct_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnquiry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhuTrach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgThongtinkh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctMoTa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCongty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctSDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPhuTrach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lct_Main
            // 
            this.lct_Main.AllowCustomization = false;
            this.lct_Main.Controls.Add(this.btnChonvsThoat);
            this.lct_Main.Controls.Add(this.btnCapNhat);
            this.lct_Main.Controls.Add(this.btnTaoMoi);
            this.lct_Main.Controls.Add(this.txtMoTa);
            this.lct_Main.Controls.Add(this.txtCongty);
            this.lct_Main.Controls.Add(this.txtKhachHang);
            this.lct_Main.Controls.Add(this.txtSDT);
            this.lct_Main.Controls.Add(this.txtEmail);
            this.lct_Main.Controls.Add(this.txtEnquiry);
            this.lct_Main.Controls.Add(this.txtPhuTrach);
            this.lct_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lct_Main.Location = new System.Drawing.Point(0, 0);
            this.lct_Main.Name = "lct_Main";
            this.lct_Main.Root = this.lcg_main;
            this.lct_Main.Size = new System.Drawing.Size(1000, 137);
            this.lct_Main.TabIndex = 0;
            this.lct_Main.Text = "layoutControl1";
            // 
            // btnChonvsThoat
            // 
            this.btnChonvsThoat.ImageOptions.Image = global::IPC247.Properties.Resources.close_16x16;
            this.btnChonvsThoat.Location = new System.Drawing.Point(882, 12);
            this.btnChonvsThoat.Name = "btnChonvsThoat";
            this.btnChonvsThoat.Size = new System.Drawing.Size(89, 22);
            this.btnChonvsThoat.StyleController = this.lct_Main;
            this.btnChonvsThoat.TabIndex = 9;
            this.btnChonvsThoat.Text = "Chọn - Đóng";
            this.btnChonvsThoat.Click += new System.EventHandler(this.btnChonvsThoat_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.ImageOptions.Image = global::IPC247.Properties.Resources.saveto_16x16;
            this.btnCapNhat.Location = new System.Drawing.Point(792, 12);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(86, 22);
            this.btnCapNhat.StyleController = this.lct_Main;
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.ImageOptions.Image = global::IPC247.Properties.Resources.add_16x16;
            this.btnTaoMoi.Location = new System.Drawing.Point(709, 12);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(79, 22);
            this.btnTaoMoi.StyleController = this.lct_Main;
            this.btnTaoMoi.TabIndex = 7;
            this.btnTaoMoi.Text = "Tạo Mới";
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(729, 70);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(230, 44);
            this.txtMoTa.StyleController = this.lct_Main;
            this.txtMoTa.TabIndex = 3;
            this.txtMoTa.EditValueChanged += new System.EventHandler(this.txtMoTa_EditValueChanged);
            // 
            // txtCongty
            // 
            this.txtCongty.Location = new System.Drawing.Point(84, 70);
            this.txtCongty.Name = "txtCongty";
            this.txtCongty.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.txtCongty.Size = new System.Drawing.Size(440, 20);
            this.txtCongty.StyleController = this.lct_Main;
            this.txtCongty.TabIndex = 1;
            this.txtCongty.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtCongty_ButtonClick);
            this.txtCongty.EditValueChanged += new System.EventHandler(this.txtCongty_EditValueChanged);
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Location = new System.Drawing.Point(84, 94);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.txtKhachHang.Size = new System.Drawing.Size(251, 20);
            this.txtKhachHang.StyleController = this.lct_Main;
            this.txtKhachHang.TabIndex = 4;
            this.txtKhachHang.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtKhachHang_ButtonClick);
            this.txtKhachHang.EditValueChanged += new System.EventHandler(this.txtKhachHang_EditValueChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(578, 70);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(113, 20);
            this.txtSDT.StyleController = this.lct_Main;
            this.txtSDT.TabIndex = 2;
            this.txtSDT.EditValueChanged += new System.EventHandler(this.txtSDT_EditValueChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(578, 94);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(113, 20);
            this.txtEmail.StyleController = this.lct_Main;
            this.txtEmail.TabIndex = 6;
            this.txtEmail.EditValueChanged += new System.EventHandler(this.txtEmail_EditValueChanged);
            // 
            // txtEnquiry
            // 
            this.txtEnquiry.Location = new System.Drawing.Point(72, 12);
            this.txtEnquiry.Name = "txtEnquiry";
            this.txtEnquiry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.txtEnquiry.Size = new System.Drawing.Size(633, 20);
            this.txtEnquiry.StyleController = this.lct_Main;
            this.txtEnquiry.TabIndex = 0;
            this.txtEnquiry.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtCustomer_ButtonClick);
            this.txtEnquiry.EditValueChanged += new System.EventHandler(this.txtEnquiry_EditValueChanged);
            // 
            // txtPhuTrach
            // 
            this.txtPhuTrach.Location = new System.Drawing.Point(396, 94);
            this.txtPhuTrach.Name = "txtPhuTrach";
            this.txtPhuTrach.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPhuTrach.Properties.DisplayMember = "Name";
            this.txtPhuTrach.Properties.NullText = "";
            this.txtPhuTrach.Properties.PopupView = this.gridView1;
            this.txtPhuTrach.Properties.ValueMember = "Code";
            this.txtPhuTrach.Size = new System.Drawing.Size(128, 20);
            this.txtPhuTrach.StyleController = this.lct_Main;
            this.txtPhuTrach.TabIndex = 5;
            this.txtPhuTrach.EditValueChanged += new System.EventHandler(this.txtPhuTrach_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // lcg_main
            // 
            this.lcg_main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg_main.GroupBordersVisible = false;
            this.lcg_main.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lctCustomer,
            this.lcgThongtinkh,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.lcg_main.Name = "lcg_main";
            this.lcg_main.Size = new System.Drawing.Size(983, 138);
            this.lcg_main.TextVisible = false;
            // 
            // lctCustomer
            // 
            this.lctCustomer.Control = this.txtEnquiry;
            this.lctCustomer.Location = new System.Drawing.Point(0, 0);
            this.lctCustomer.Name = "lctCustomer";
            this.lctCustomer.Size = new System.Drawing.Size(697, 26);
            this.lctCustomer.Text = "DỰ ÁN";
            this.lctCustomer.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lcgThongtinkh
            // 
            this.lcgThongtinkh.CustomizationFormText = "THÔNG TIN KHÁCH HÀNG";
            this.lcgThongtinkh.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lctMoTa,
            this.lctCongty,
            this.lctKhachHang,
            this.lctSDT,
            this.lctEmail,
            this.lctPhuTrach});
            this.lcgThongtinkh.Location = new System.Drawing.Point(0, 26);
            this.lcgThongtinkh.Name = "lcgThongtinkh";
            this.lcgThongtinkh.Size = new System.Drawing.Size(963, 92);
            this.lcgThongtinkh.Text = "THÔNG TIN KHÁCH HÀNG";
            // 
            // lctMoTa
            // 
            this.lctMoTa.Control = this.txtMoTa;
            this.lctMoTa.CustomizationFormText = "Mô Tả";
            this.lctMoTa.Location = new System.Drawing.Point(671, 0);
            this.lctMoTa.Name = "lctMoTa";
            this.lctMoTa.Size = new System.Drawing.Size(268, 48);
            this.lctMoTa.Text = "Mô Tả";
            this.lctMoTa.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lctMoTa.TextSize = new System.Drawing.Size(29, 13);
            this.lctMoTa.TextToControlDistance = 5;
            // 
            // lctCongty
            // 
            this.lctCongty.Control = this.txtCongty;
            this.lctCongty.CustomizationFormText = "Công Ty";
            this.lctCongty.Location = new System.Drawing.Point(0, 0);
            this.lctCongty.Name = "lctCongty";
            this.lctCongty.Size = new System.Drawing.Size(504, 24);
            this.lctCongty.Text = "Công Ty";
            this.lctCongty.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lctKhachHang
            // 
            this.lctKhachHang.Control = this.txtKhachHang;
            this.lctKhachHang.CustomizationFormText = "Khách Hàng";
            this.lctKhachHang.Location = new System.Drawing.Point(0, 24);
            this.lctKhachHang.MinSize = new System.Drawing.Size(114, 24);
            this.lctKhachHang.Name = "lctKhachHang";
            this.lctKhachHang.Size = new System.Drawing.Size(315, 24);
            this.lctKhachHang.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lctKhachHang.Text = "Khách Hàng";
            this.lctKhachHang.TextSize = new System.Drawing.Size(57, 13);
            // 
            // lctSDT
            // 
            this.lctSDT.Control = this.txtSDT;
            this.lctSDT.CustomizationFormText = "SĐT";
            this.lctSDT.Location = new System.Drawing.Point(504, 0);
            this.lctSDT.MaxSize = new System.Drawing.Size(167, 24);
            this.lctSDT.MinSize = new System.Drawing.Size(167, 24);
            this.lctSDT.Name = "lctSDT";
            this.lctSDT.Size = new System.Drawing.Size(167, 24);
            this.lctSDT.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lctSDT.Text = "SĐT";
            this.lctSDT.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lctSDT.TextSize = new System.Drawing.Size(50, 20);
            this.lctSDT.TextToControlDistance = 0;
            // 
            // lctEmail
            // 
            this.lctEmail.Control = this.txtEmail;
            this.lctEmail.CustomizationFormText = "Email";
            this.lctEmail.Location = new System.Drawing.Point(504, 24);
            this.lctEmail.MaxSize = new System.Drawing.Size(167, 24);
            this.lctEmail.MinSize = new System.Drawing.Size(167, 24);
            this.lctEmail.Name = "lctEmail";
            this.lctEmail.Size = new System.Drawing.Size(167, 24);
            this.lctEmail.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lctEmail.Text = "Email";
            this.lctEmail.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lctEmail.TextSize = new System.Drawing.Size(24, 13);
            this.lctEmail.TextToControlDistance = 26;
            // 
            // lctPhuTrach
            // 
            this.lctPhuTrach.Control = this.txtPhuTrach;
            this.lctPhuTrach.CustomizationFormText = "Phụ Trách";
            this.lctPhuTrach.Location = new System.Drawing.Point(315, 24);
            this.lctPhuTrach.Name = "lctPhuTrach";
            this.lctPhuTrach.Size = new System.Drawing.Size(189, 24);
            this.lctPhuTrach.Text = "Phụ Trách";
            this.lctPhuTrach.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lctPhuTrach.TextSize = new System.Drawing.Size(50, 20);
            this.lctPhuTrach.TextToControlDistance = 7;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnTaoMoi;
            this.layoutControlItem1.Location = new System.Drawing.Point(697, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(83, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(83, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCapNhat;
            this.layoutControlItem2.Location = new System.Drawing.Point(780, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(90, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnChonvsThoat;
            this.layoutControlItem3.Location = new System.Drawing.Point(870, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(93, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // Form_Add_Enquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 137);
            this.Controls.Add(this.lct_Main);
            this.Name = "Form_Add_Enquiry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM THÔNG TIN DỰ ÁN";
            this.Load += new System.EventHandler(this.Form_Add_Enquiry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).EndInit();
            this.lct_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMoTa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCongty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnquiry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhuTrach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgThongtinkh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctMoTa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCongty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctSDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPhuTrach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lct_Main;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_main;
        private DevExpress.XtraLayout.LayoutControlItem lctCustomer;
        private DevExpress.XtraEditors.MemoEdit txtMoTa;
        private DevExpress.XtraEditors.ButtonEdit txtCongty;
        private DevExpress.XtraEditors.ButtonEdit txtKhachHang;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.ButtonEdit txtEnquiry;
        private DevExpress.XtraLayout.LayoutControlGroup lcgThongtinkh;
        private DevExpress.XtraLayout.LayoutControlItem lctMoTa;
        private DevExpress.XtraLayout.LayoutControlItem lctCongty;
        private DevExpress.XtraLayout.LayoutControlItem lctKhachHang;
        private DevExpress.XtraLayout.LayoutControlItem lctSDT;
        private DevExpress.XtraLayout.LayoutControlItem lctEmail;
        private DevExpress.XtraEditors.SimpleButton btnCapNhat;
        private DevExpress.XtraEditors.SimpleButton btnTaoMoi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.GridLookUpEdit txtPhuTrach;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem lctPhuTrach;
        private DevExpress.XtraEditors.SimpleButton btnChonvsThoat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}