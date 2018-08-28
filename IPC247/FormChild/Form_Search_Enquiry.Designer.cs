namespace IPC247
{
    partial class Form_Search_Enquiry
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
            this.txtCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcg_main = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lctCustomer = new DevExpress.XtraLayout.LayoutControlItem();
            this.gclID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclSDT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclID_Enquiry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclEnquiryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCurator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCuratorName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclAddress_Cus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).BeginInit();
            this.lct_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // lct_Main
            // 
            this.lct_Main.AllowCustomization = false;
            this.lct_Main.Controls.Add(this.txtCustomer);
            this.lct_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lct_Main.Location = new System.Drawing.Point(0, 0);
            this.lct_Main.Name = "lct_Main";
            this.lct_Main.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lct_Main.Root = this.lcg_main;
            this.lct_Main.Size = new System.Drawing.Size(954, 46);
            this.lct_Main.TabIndex = 0;
            this.lct_Main.Text = "layoutControl1";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(47, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCustomer.Properties.DisplayMember = "EnquiryName";
            this.txtCustomer.Properties.NullText = "";
            this.txtCustomer.Properties.PopupView = this.searchLookUpEdit1View;
            this.txtCustomer.Properties.ValueMember = "ID";
            this.txtCustomer.Size = new System.Drawing.Size(895, 20);
            this.txtCustomer.StyleController = this.lct_Main;
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.EditValueChanged += new System.EventHandler(this.txtCompany_EditValueChanged);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompany_KeyPress);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclID,
            this.gclCompanyName,
            this.gclDescription,
            this.gclCardName,
            this.gclSDT,
            this.gclEmail,
            this.gclID_Enquiry,
            this.gclEnquiryName,
            this.gclCurator,
            this.gclCuratorName,
            this.gclAddress_Cus});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.searchLookUpEdit1View.OptionsFilter.AllowFilterEditor = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.searchLookUpEdit1View.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lcg_main
            // 
            this.lcg_main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg_main.GroupBordersVisible = false;
            this.lcg_main.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lctCustomer});
            this.lcg_main.Name = "lcg_main";
            this.lcg_main.Size = new System.Drawing.Size(954, 46);
            this.lcg_main.TextVisible = false;
            // 
            // lctCustomer
            // 
            this.lctCustomer.Control = this.txtCustomer;
            this.lctCustomer.Location = new System.Drawing.Point(0, 0);
            this.lctCustomer.Name = "lctCustomer";
            this.lctCustomer.Size = new System.Drawing.Size(934, 26);
            this.lctCustomer.Text = "DỰ ÁN";
            this.lctCustomer.TextSize = new System.Drawing.Size(32, 13);
            // 
            // gclID
            // 
            this.gclID.Caption = "ID";
            this.gclID.FieldName = "ID_Request";
            this.gclID.Name = "gclID";
            // 
            // gclCompanyName
            // 
            this.gclCompanyName.Caption = "Tên Công Ty";
            this.gclCompanyName.FieldName = "CompanyName";
            this.gclCompanyName.Name = "gclCompanyName";
            this.gclCompanyName.Visible = true;
            this.gclCompanyName.VisibleIndex = 1;
            this.gclCompanyName.Width = 174;
            // 
            // gclDescription
            // 
            this.gclDescription.Caption = "Mô Tả";
            this.gclDescription.FieldName = "Description";
            this.gclDescription.Name = "gclDescription";
            this.gclDescription.Visible = true;
            this.gclDescription.VisibleIndex = 2;
            this.gclDescription.Width = 106;
            // 
            // gclCardName
            // 
            this.gclCardName.Caption = "Tên Khách Hàng";
            this.gclCardName.FieldName = "CardName";
            this.gclCardName.Name = "gclCardName";
            this.gclCardName.Visible = true;
            this.gclCardName.VisibleIndex = 3;
            this.gclCardName.Width = 106;
            // 
            // gclSDT
            // 
            this.gclSDT.Caption = "SDT";
            this.gclSDT.FieldName = "SDT";
            this.gclSDT.Name = "gclSDT";
            this.gclSDT.Visible = true;
            this.gclSDT.VisibleIndex = 4;
            this.gclSDT.Width = 106;
            // 
            // gclEmail
            // 
            this.gclEmail.Caption = "Email";
            this.gclEmail.FieldName = "Email";
            this.gclEmail.Name = "gclEmail";
            this.gclEmail.Visible = true;
            this.gclEmail.VisibleIndex = 5;
            this.gclEmail.Width = 115;
            // 
            // gclID_Enquiry
            // 
            this.gclID_Enquiry.Caption = "ID_Enquiry";
            this.gclID_Enquiry.FieldName = "ID_Enquiry";
            this.gclID_Enquiry.Name = "gclID_Enquiry";
            // 
            // gclEnquiryName
            // 
            this.gclEnquiryName.Caption = "Tên Dự Án";
            this.gclEnquiryName.FieldName = "EnquiryName";
            this.gclEnquiryName.Name = "gclEnquiryName";
            this.gclEnquiryName.Visible = true;
            this.gclEnquiryName.VisibleIndex = 0;
            this.gclEnquiryName.Width = 290;
            // 
            // gclCurator
            // 
            this.gclCurator.Caption = "Curator";
            this.gclCurator.FieldName = "Curator";
            this.gclCurator.Name = "gclCurator";
            this.gclCurator.Width = 94;
            // 
            // gclCuratorName
            // 
            this.gclCuratorName.Caption = "Người Phụ Trách";
            this.gclCuratorName.FieldName = "CuratorName";
            this.gclCuratorName.Name = "gclCuratorName";
            this.gclCuratorName.Visible = true;
            this.gclCuratorName.VisibleIndex = 6;
            this.gclCuratorName.Width = 109;
            // 
            // gclAddress_Cus
            // 
            this.gclAddress_Cus.Caption = "Address_Cus";
            this.gclAddress_Cus.FieldName = "Address_Cus";
            this.gclAddress_Cus.Name = "gclAddress_Cus";
            // 
            // Form_Search_Enquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 46);
            this.Controls.Add(this.lct_Main);
            this.Name = "Form_Search_Enquiry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM THÔNG TIN DỰ ÁN";
            this.Load += new System.EventHandler(this.Form_Search_Enquiry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).EndInit();
            this.lct_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lct_Main;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_main;
        private DevExpress.XtraEditors.SearchLookUpEdit txtCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem lctCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gclID;
        private DevExpress.XtraGrid.Columns.GridColumn gclEnquiryName;
        private DevExpress.XtraGrid.Columns.GridColumn gclCurator;
        private DevExpress.XtraGrid.Columns.GridColumn gclCuratorName;
        private DevExpress.XtraGrid.Columns.GridColumn gclCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gclDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gclCardName;
        private DevExpress.XtraGrid.Columns.GridColumn gclSDT;
        private DevExpress.XtraGrid.Columns.GridColumn gclEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gclID_Enquiry;
        private DevExpress.XtraGrid.Columns.GridColumn gclAddress_Cus;
    }
}