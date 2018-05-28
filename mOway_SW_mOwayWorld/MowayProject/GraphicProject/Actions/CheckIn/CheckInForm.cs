using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.CheckIn
{
    public partial class CheckInForm : ActionForm
    {
        #region Attributes

        private CheckInAction action;

        #endregion

        public CheckInForm(CheckInAction action)
        {
            InitializeComponent();
            this.helpTopic = CheckIn.HelpTopic;
            this.action = action;
        }

        protected override void LoadSettings()
        {
            switch (this.action.Line)
            {
                case 1:
                    this.rbLine1.Checked = true;
                    break;
                case 2:
                    this.rbLine2.Checked = true;
                    break;
                case 3:
                    this.rbLine3.Checked = true;
                    break;
                case 4:
                    this.rbLine4.Checked = true;
                    break;
                case 5:
                    this.rbLine5.Checked = true;
                    break;
            }
            this.cbOperator.SelectedIndex = (int)this.action.Operation;
            if (this.action.LineValue == IoValue.On)
                this.cbLineValue.SelectedIndex = 0;
            else
                this.cbLineValue.SelectedIndex = 1;
        }

        protected override void SaveSettings()
        {
            int line = 0;
            if (this.rbLine1.Checked)
                line = 1;
            else if (this.rbLine2.Checked)
                line = 2;
            else if (this.rbLine3.Checked)
                line = 3;
            else if (this.rbLine4.Checked)
                line = 4;
            else if (this.rbLine5.Checked)
                line = 5;
            ComparativeOp operation = (ComparativeOp)Enum.ToObject(typeof(ComparativeOp), this.cbOperator.SelectedIndex);
            IoValue lineValue = IoValue.On;
            if (this.cbLineValue.SelectedIndex == 1)
                lineValue = IoValue.Off;
            this.action.UpdateSettings(line, operation, lineValue);
        }
    }
}
