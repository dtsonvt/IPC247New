namespace IPC247
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpg_SanPham = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btn_SanPham = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NhomSanPham = new DevExpress.XtraBars.BarButtonItem();
            this.rpg_BaoGia = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btn_TaoBaoGia = new DevExpress.XtraBars.BarButtonItem();
            this.rpg_YeuCau = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btn_DoanhNghiep = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Customer = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Enquiry = new DevExpress.XtraBars.BarButtonItem();
            this.btn_EnquiryDetails = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barheader_text = new DevExpress.XtraBars.BarHeaderItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ThongTin = new DevExpress.XtraBars.BarButtonItem();
            this.btn_TaoTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btn_NhomQuyen = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.rbp_NhanSu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpg_TaiKhoan = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbb_Masterdata = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpg_ThongTin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbp_ThayDoiGiaoDien = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpg_GiaoDien = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage6 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.Get_Push_Notify = new System.Windows.Forms.Timer(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpg_SanPham,
            this.rpg_BaoGia,
            this.rpg_YeuCau});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Báo Giá";
            // 
            // rpg_SanPham
            // 
            this.rpg_SanPham.ItemLinks.Add(this.btn_SanPham);
            this.rpg_SanPham.ItemLinks.Add(this.btn_NhomSanPham);
            this.rpg_SanPham.Name = "rpg_SanPham";
            this.rpg_SanPham.Text = "Sản Phẩm";
            // 
            // btn_SanPham
            // 
            this.btn_SanPham.Caption = "Sản Phẩm";
            this.btn_SanPham.Enabled = false;
            this.btn_SanPham.Id = 4;
            this.btn_SanPham.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_SanPham.ImageOptions.LargeImage")));
            this.btn_SanPham.Name = "btn_SanPham";
            this.btn_SanPham.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // btn_NhomSanPham
            // 
            this.btn_NhomSanPham.Caption = "Nhóm Sản Phẩm";
            this.btn_NhomSanPham.Enabled = false;
            this.btn_NhomSanPham.Id = 7;
            this.btn_NhomSanPham.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NhomSanPham.ImageOptions.Image")));
            this.btn_NhomSanPham.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_NhomSanPham.ImageOptions.LargeImage")));
            this.btn_NhomSanPham.Name = "btn_NhomSanPham";
            this.btn_NhomSanPham.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // rpg_BaoGia
            // 
            this.rpg_BaoGia.ItemLinks.Add(this.btn_TaoBaoGia);
            this.rpg_BaoGia.Name = "rpg_BaoGia";
            this.rpg_BaoGia.Text = "Báo Giá";
            // 
            // btn_TaoBaoGia
            // 
            this.btn_TaoBaoGia.Caption = "Tạo Báo Giá";
            this.btn_TaoBaoGia.Enabled = false;
            this.btn_TaoBaoGia.Id = 6;
            this.btn_TaoBaoGia.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_TaoBaoGia.ImageOptions.Image")));
            this.btn_TaoBaoGia.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_TaoBaoGia.ImageOptions.LargeImage")));
            this.btn_TaoBaoGia.Name = "btn_TaoBaoGia";
            this.btn_TaoBaoGia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // rpg_YeuCau
            // 
            this.rpg_YeuCau.ItemLinks.Add(this.btn_DoanhNghiep);
            this.rpg_YeuCau.ItemLinks.Add(this.btn_Customer);
            this.rpg_YeuCau.ItemLinks.Add(this.btn_Enquiry);
            this.rpg_YeuCau.ItemLinks.Add(this.btn_EnquiryDetails);
            this.rpg_YeuCau.Name = "rpg_YeuCau";
            this.rpg_YeuCau.Text = "Yêu Cầu Khách Hàng";
            // 
            // btn_DoanhNghiep
            // 
            this.btn_DoanhNghiep.Caption = "Doanh Nghiệp";
            this.btn_DoanhNghiep.Enabled = false;
            this.btn_DoanhNghiep.Id = 14;
            this.btn_DoanhNghiep.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_DoanhNghiep.ImageOptions.Image")));
            this.btn_DoanhNghiep.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_DoanhNghiep.ImageOptions.LargeImage")));
            this.btn_DoanhNghiep.Name = "btn_DoanhNghiep";
            this.btn_DoanhNghiep.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_DoanhNghiep_ItemClick);
            // 
            // btn_Customer
            // 
            this.btn_Customer.Caption = "Khách Hàng";
            this.btn_Customer.Enabled = false;
            this.btn_Customer.Id = 15;
            this.btn_Customer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Customer.ImageOptions.Image")));
            this.btn_Customer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Customer.ImageOptions.LargeImage")));
            this.btn_Customer.Name = "btn_Customer";
            this.btn_Customer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Customer_ItemClick);
            // 
            // btn_Enquiry
            // 
            this.btn_Enquiry.Caption = "Dự Án";
            this.btn_Enquiry.Enabled = false;
            this.btn_Enquiry.Id = 16;
            this.btn_Enquiry.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Enquiry.ImageOptions.Image")));
            this.btn_Enquiry.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Enquiry.ImageOptions.LargeImage")));
            this.btn_Enquiry.Name = "btn_Enquiry";
            this.btn_Enquiry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Enquiry_ItemClick);
            // 
            // btn_EnquiryDetails
            // 
            this.btn_EnquiryDetails.Caption = "Quản Lý Dự Án";
            this.btn_EnquiryDetails.Enabled = false;
            this.btn_EnquiryDetails.Id = 17;
            this.btn_EnquiryDetails.ImageOptions.Image = global::IPC247.Properties.Resources.managerules_16x16;
            this.btn_EnquiryDetails.ImageOptions.LargeImage = global::IPC247.Properties.Resources.managerules_32x32;
            this.btn_EnquiryDetails.Name = "btn_EnquiryDetails";
            this.btn_EnquiryDetails.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_EnquiryDetails_ItemClick);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowKeyTips = false;
            this.ribbonControl1.AllowMdiChildButtons = false;
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.AllowTrimPageText = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.barheader_text,
            this.barButtonItem2,
            this.btn_SanPham,
            this.barButtonItem4,
            this.btn_TaoBaoGia,
            this.btn_NhomSanPham,
            this.btn_ThongTin,
            this.btn_TaoTaiKhoan,
            this.btn_NhomQuyen,
            this.barButtonItem3,
            this.barButtonItem5,
            this.skinRibbonGalleryBarItem1,
            this.btn_DoanhNghiep,
            this.btn_Customer,
            this.btn_Enquiry,
            this.btn_EnquiryDetails});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 18;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.barheader_text);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.barButtonItem2);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.rbp_NhanSu,
            this.rbb_Masterdata,
            this.rbp_ThayDoiGiaoDien});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(997, 143);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barheader_text
            // 
            this.barheader_text.Caption = "Xin Chào: Đặng Thái Sơn - chúc bạn một ngày làm việc hiệu quả";
            this.barheader_text.Id = 2;
            this.barheader_text.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barheader_text.ImageOptions.Image")));
            this.barheader_text.Name = "barheader_text";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Logoff";
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 5;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // btn_ThongTin
            // 
            this.btn_ThongTin.Caption = "Thông Tin Công ty";
            this.btn_ThongTin.Enabled = false;
            this.btn_ThongTin.Id = 8;
            this.btn_ThongTin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_ThongTin.ImageOptions.LargeImage")));
            this.btn_ThongTin.Name = "btn_ThongTin";
            this.btn_ThongTin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongTin_ItemClick);
            // 
            // btn_TaoTaiKhoan
            // 
            this.btn_TaoTaiKhoan.Caption = "Tạo Tài Khoản";
            this.btn_TaoTaiKhoan.Enabled = false;
            this.btn_TaoTaiKhoan.Id = 9;
            this.btn_TaoTaiKhoan.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_TaoTaiKhoan.ImageOptions.Image")));
            this.btn_TaoTaiKhoan.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_TaoTaiKhoan.ImageOptions.LargeImage")));
            this.btn_TaoTaiKhoan.Name = "btn_TaoTaiKhoan";
            this.btn_TaoTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_TaoTaiKhoan_ItemClick);
            // 
            // btn_NhomQuyen
            // 
            this.btn_NhomQuyen.Caption = "Nhóm Quyền";
            this.btn_NhomQuyen.Enabled = false;
            this.btn_NhomQuyen.Id = 10;
            this.btn_NhomQuyen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NhomQuyen.ImageOptions.Image")));
            this.btn_NhomQuyen.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_NhomQuyen.ImageOptions.LargeImage")));
            this.btn_NhomQuyen.Name = "btn_NhomQuyen";
            this.btn_NhomQuyen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_NhomQuyen_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 11;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 12;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 13;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // rbp_NhanSu
            // 
            this.rbp_NhanSu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpg_TaiKhoan});
            this.rbp_NhanSu.Name = "rbp_NhanSu";
            this.rbp_NhanSu.Text = "Nhân Sự";
            // 
            // rpg_TaiKhoan
            // 
            this.rpg_TaiKhoan.ItemLinks.Add(this.btn_TaoTaiKhoan);
            this.rpg_TaiKhoan.ItemLinks.Add(this.btn_NhomQuyen);
            this.rpg_TaiKhoan.Name = "rpg_TaiKhoan";
            this.rpg_TaiKhoan.Text = "Tài khoản";
            // 
            // rbb_Masterdata
            // 
            this.rbb_Masterdata.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpg_ThongTin});
            this.rbb_Masterdata.Name = "rbb_Masterdata";
            this.rbb_Masterdata.Text = "Cấu Hình";
            // 
            // rpg_ThongTin
            // 
            this.rpg_ThongTin.ItemLinks.Add(this.btn_ThongTin);
            this.rpg_ThongTin.Name = "rpg_ThongTin";
            this.rpg_ThongTin.Text = "Thông Tin Chung";
            // 
            // rbp_ThayDoiGiaoDien
            // 
            this.rbp_ThayDoiGiaoDien.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpg_GiaoDien});
            this.rbp_ThayDoiGiaoDien.Name = "rbp_ThayDoiGiaoDien";
            this.rbp_ThayDoiGiaoDien.Text = "Giao Diện";
            // 
            // rpg_GiaoDien
            // 
            this.rpg_GiaoDien.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.rpg_GiaoDien.Name = "rpg_GiaoDien";
            this.rpg_GiaoDien.Text = "Đổi Giao Diện";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "ribbonPage4";
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "ribbonPage5";
            // 
            // ribbonPage6
            // 
            this.ribbonPage6.Name = "ribbonPage6";
            this.ribbonPage6.Text = "ribbonPage6";
            // 
            // Get_Push_Notify
            // 
            this.Get_Push_Notify.Interval = 300000;
            this.Get_Push_Notify.Tick += new System.EventHandler(this.Get_Push_Notify_Tick);
            // 
            // alertControl1
            // 
            this.alertControl1.AppearanceText.ForeColor = System.Drawing.Color.Red;
            this.alertControl1.AppearanceText.Options.UseForeColor = true;
            // 
            // Form_Main
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 528);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Form_Main";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPC247";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form_Main_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_SanPham;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarHeaderItem barheader_text;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btn_SanPham;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_BaoGia;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.BarButtonItem btn_TaoBaoGia;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btn_NhomSanPham;
        private DevExpress.XtraBars.BarButtonItem btn_ThongTin;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbb_Masterdata;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_ThongTin;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.BarButtonItem btn_TaoTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btn_NhomQuyen;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbp_NhanSu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_TaiKhoan;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbp_ThayDoiGiaoDien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_GiaoDien;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpg_YeuCau;
        private DevExpress.XtraBars.BarButtonItem btn_DoanhNghiep;
        private DevExpress.XtraBars.BarButtonItem btn_Customer;
        private DevExpress.XtraBars.BarButtonItem btn_Enquiry;
        private System.Windows.Forms.Timer Get_Push_Notify;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraBars.BarButtonItem btn_EnquiryDetails;
    }
}