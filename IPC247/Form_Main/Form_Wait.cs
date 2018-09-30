using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace IPC247
{
    public partial class Form_Wait : WaitForm
    {
        public Form_Wait()
        {
            InitializeComponent();
            this.Wait.AutoHeight = true;
        }

        #region Overrides

        public override void SetCaption(string caption)
        {
            base.SetCaption(caption);
            this.Wait.Caption = caption;
        }
        public override void SetDescription(string description)
        {
            base.SetDescription(description);
            this.Wait.Description = description;
        }
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum WaitFormCommand
        {
        }
    }
}