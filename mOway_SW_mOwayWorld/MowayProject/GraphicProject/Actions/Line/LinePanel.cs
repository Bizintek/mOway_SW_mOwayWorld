using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Line
{
    public partial class LinePanel : ActionPanel
    {
        #region Attributes

        private LineAction action;

        #endregion

        public LinePanel(LineAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.cbLeft.SelectedIndex = (int)this.action.LeftSensor;
            this.cbRight.SelectedIndex = (int)this.action.RightSensor;

            if (this.action.Operation == LogicOp.Or)
                this.rbOr.Checked = true;
        }

        protected override void SaveSettings()
        {
            LineState left = (LineState)Enum.ToObject(typeof(LineState), this.cbLeft.SelectedIndex);
            LineState right = (LineState)Enum.ToObject(typeof(LineState), this.cbRight.SelectedIndex);

            LogicOp operation = LogicOp.And;
            if (this.rbOr.Checked)
                operation = LogicOp.Or;

            this.action.UpdateSettings(left, right, operation);
        }

        private void CbSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbOperator_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

    }
}
