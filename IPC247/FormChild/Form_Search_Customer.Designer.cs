namespace IPC247
{
    partial class Form_Search_Customer
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
            this.chkLayALL = new DevExpress.XtraEditors.CheckEdit();
            this.txtCustomer = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lcg_main = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lctCustomer = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gclID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCardName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).BeginInit();
            this.lct_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLayALL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lct_Main
            // 
            this.lct_Main.AllowCustomization = false;
            this.lct_Main.Controls.Add(this.chkLayALL);
            this.lct_Main.Controls.Add(this.txtCustomer);
            this.lct_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lct_Main.Location = new System.Drawing.Point(0, 0);
            this.lct_Main.Name = "lct_Main";
            this.lct_Main.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lct_Main.Root = this.lcg_main;
            this.lct_Main.Size = new System.Drawing.Size(552, 45);
            this.lct_Main.TabIndex = 0;
            this.lct_Main.Text = "layoutControl1";
            // 
            // chkLayALL
            // 
            this.chkLayALL.Location = new System.Drawing.Point(452, 12);
            this.chkLayALL.Name = "chkLayALL";
            this.chkLayALL.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.chkLayALL.Properties.Appearance.Options.UseFont = true;
            this.chkLayALL.Properties.Caption = "Lấy Tất Cả";
            this.chkLayALL.Size = new System.Drawing.Size(88, 20);
            this.chkLayALL.StyleController = this.lct_Main;
            this.chkLayALL.TabIndex = 5;
            this.chkLayALL.CheckedChanged += new System.EventHandler(this.chkLayALL_CheckedChanged);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(80, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCustomer.Properties.DisplayMember = "CardName";
            this.txtCustomer.Properties.NullText = "";
            this.txtCustomer.Properties.PopupView = this.searchLookUpEdit1View;
            this.txtCustomer.Properties.ValueMember = "ID";
            this.txtCustomer.Size = new System.Drawing.Size(368, 20);
            this.txtCustomer.StyleController = this.lct_Main;
            this.txtCustomer.TabIndex = 4;
            this.txtCustomer.EditValueChanged += new System.EventHandler(this.txtCompany_EditValueChanged);
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompany_KeyPress);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclID,
            this.gclCardName,
            this.gclAddress,
            this.gclPhone,
            this.gclEmail,
            this.gclCompany,
            this.gclCompanyName});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lcg_main
            // 
            this.lcg_main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg_main.GroupBordersVisible = false;
            this.lcg_main.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lctCustomer,
            this.layoutControlItem1});
            this.lcg_main.Name = "lcg_main";
            this.lcg_main.Size = new System.Drawing.Size(552, 45);
            this.lcg_main.TextVisible = false;
            // 
            // lctCustomer
            // 
            this.lctCustomer.Control = this.txtCustomer;
            this.lctCustomer.Location = new System.Drawing.Point(0, 0);
            this.lctCustomer.Name = "lctCustomer";
            this.lctCustomer.Size = new System.Drawing.Size(440, 25);
            this.lctCustomer.Text = "KHÁCH HÀNG";
            this.lctCustomer.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkLayALL;
            this.layoutControlItem1.Location = new System.Drawing.Point(440, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(92, 25);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gclID
            // 
            this.gclID.Caption = "ID";
            this.gclID.FieldName = "ID";
            this.gclID.Name = "gclID";
            // 
            // gclCardName
            // 
            this.gclCardName.Caption = "Tên Khách Hàng";
            this.gclCardName.FieldName = "CardName";
            this.gclCardName.Name = "gclCardName";
            this.gclCardName.Visible = true;
            this.gclCardName.VisibleIndex = 0;
            // 
            // gclAddress
            // 
            this.gclAddress.Caption = "Địa Chỉ";
            this.gclAddress.FieldName = "Address";
            this.gclAddress.Name = "gclAddress";
            this.gclAddress.Visible = true;
            this.gclAddress.VisibleIndex = 3;
            // 
            // gclPhone
            // 
            this.gclPhone.Caption = "Phone";
            this.gclPhone.FieldName = "Phone";
            this.gclPhone.Name = "gclPhone";
            this.gclPhone.Visible = true;
            this.gclPhone.VisibleIndex = 2;
            // 
            // gclEmail
            // 
            this.gclEmail.Caption = "Email";
            this.gclEmail.FieldName = "Email";
            this.gclEmail.Name = "gclEmail";
            this.gclEmail.Visible = true;
            this.gclEmail.VisibleIndex = 1;
            // 
            // gclCompany
            // 
            this.gclCompany.Caption = "Company";
            this.gclCompany.FieldName = "Company";
            this.gclCompany.Name = "gclCompany";
            // 
            // gclCompanyName
            // 
            this.gclCompanyName.Caption = "Tên Công Ty";
            this.gclCompanyName.FieldName = "CompanyName";
            this.gclCompanyName.Name = "gclCompanyName";
            this.gclCompanyName.Visible = true;
            this.gclCompanyName.VisibleIndex = 4;
            // 
            // Form_Search_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 45);
            this.Controls.Add(this.lct_Main);
            this.Name = "Form_Search_Customer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.Form_Search_Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).EndInit();
            this.lct_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLayALL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lct_Main;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_main;
        private DevExpress.XtraEditors.SearchLookUpEdit txtCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem lctCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn gclID;
        private DevExpress.XtraGrid.Columns.GridColumn gclEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gclCardName;
        private DevExpress.XtraGrid.Columns.GridColumn gclAddress;
        private DevExpress.XtraEditors.CheckEdit chkLayALL;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gclCompany;
        private DevExpress.XtraGrid.Columns.GridColumn gclPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gclCompanyName;
    }
}