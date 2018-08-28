namespace IPC247
{
    partial class Form_Search_Company
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
            this.txtCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gclID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gclAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcg_main = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lctCompany = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).BeginInit();
            this.lct_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // lct_Main
            // 
            this.lct_Main.AllowCustomization = false;
            this.lct_Main.Controls.Add(this.txtCompany);
            this.lct_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lct_Main.Location = new System.Drawing.Point(0, 0);
            this.lct_Main.Name = "lct_Main";
            this.lct_Main.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lct_Main.Root = this.lcg_main;
            this.lct_Main.Size = new System.Drawing.Size(552, 47);
            this.lct_Main.TabIndex = 0;
            this.lct_Main.Text = "layoutControl1";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(53, 12);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtCompany.Properties.DisplayMember = "CompanyName";
            this.txtCompany.Properties.NullText = "";
            this.txtCompany.Properties.PopupView = this.searchLookUpEdit1View;
            this.txtCompany.Properties.ValueMember = "ID";
            this.txtCompany.Size = new System.Drawing.Size(487, 20);
            this.txtCompany.StyleController = this.lct_Main;
            this.txtCompany.TabIndex = 4;
            this.txtCompany.EditValueChanged += new System.EventHandler(this.txtCompany_EditValueChanged);
            this.txtCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompany_KeyPress);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gclID,
            this.gclCompanyName,
            this.gclDescription,
            this.gclAddress});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gclID
            // 
            this.gclID.Caption = "ID";
            this.gclID.FieldName = "ID";
            this.gclID.Name = "gclID";
            // 
            // gclCompanyName
            // 
            this.gclCompanyName.Caption = "Tên Công Ty";
            this.gclCompanyName.FieldName = "CompanyName";
            this.gclCompanyName.Name = "gclCompanyName";
            this.gclCompanyName.Visible = true;
            this.gclCompanyName.VisibleIndex = 0;
            // 
            // gclDescription
            // 
            this.gclDescription.Caption = "Mô Tả";
            this.gclDescription.FieldName = "Description";
            this.gclDescription.Name = "gclDescription";
            this.gclDescription.Visible = true;
            this.gclDescription.VisibleIndex = 1;
            // 
            // gclAddress
            // 
            this.gclAddress.Caption = "Địa Chỉ";
            this.gclAddress.FieldName = "Address";
            this.gclAddress.Name = "gclAddress";
            this.gclAddress.Visible = true;
            this.gclAddress.VisibleIndex = 2;
            // 
            // lcg_main
            // 
            this.lcg_main.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcg_main.GroupBordersVisible = false;
            this.lcg_main.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lctCompany});
            this.lcg_main.Name = "lcg_main";
            this.lcg_main.Size = new System.Drawing.Size(552, 47);
            this.lcg_main.TextVisible = false;
            // 
            // lctCompany
            // 
            this.lctCompany.Control = this.txtCompany;
            this.lctCompany.Location = new System.Drawing.Point(0, 0);
            this.lctCompany.Name = "lctCompany";
            this.lctCompany.Size = new System.Drawing.Size(532, 27);
            this.lctCompany.Text = "Công ty";
            this.lctCompany.TextSize = new System.Drawing.Size(38, 13);
            // 
            // Form_Search_Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 47);
            this.Controls.Add(this.lct_Main);
            this.Name = "Form_Search_Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM CÔNG TY";
            this.Load += new System.EventHandler(this.Form_Search_Company_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lct_Main)).EndInit();
            this.lct_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcg_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lct_Main;
        private DevExpress.XtraLayout.LayoutControlGroup lcg_main;
        private DevExpress.XtraEditors.SearchLookUpEdit txtCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem lctCompany;
        private DevExpress.XtraGrid.Columns.GridColumn gclID;
        private DevExpress.XtraGrid.Columns.GridColumn gclCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gclDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gclAddress;
    }
}