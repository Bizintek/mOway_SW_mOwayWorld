using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.CompareLine
{
    public partial class CompareLinePanel : ActionPanel
    {
        #region Attributes

        private CompareLineAction action;

        #endregion

        public CompareLinePanel(CompareLineAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.LineSensor == Side.Left)
                this.rbLeftSensor.Checked = true;
            this.cbOperator.SelectedIndex = (int)this.action.Operation;
            if (this.action.CompareVariable == null)
                this.cbCompareVariable.SelectedIndex = 0;
            else
                this.cbCompareVariable.SelectedItem = this.action.CompareVariable.Name;
            this.nudCompareValue.Value = this.action.CompareValue;
        }

        protected override void SaveSettings()
        {
            Side sensor = Side.Right;
            if (this.rbLeftSensor.Checked)
                sensor = Side.Left;
            ComparativeOp operation = (ComparativeOp)Enum.ToObject(typeof(ComparativeOp), this.cbOperator.SelectedIndex);
            Variable variable = null;
            int value = 0;
            if (this.cbCompareVariable.SelectedIndex != 0)
                variable = GraphManager.GetVariable(this.cbCompareVariable.SelectedItem.ToString());
            else
                value = (int)this.nudCompareValue.Value;
            this.action.UpdateSettings(sensor, operation, variable, value);
        }

        public override void AddVariable(Variable variable)
        {
            this.cbCompareVariable.Items.Add(variable.Name);
        }
        
        private void RbSensor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbCompareVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbCompareVariable.SelectedIndex == 0)
                this.nudCompareValue.Enabled = true;
            else
                this.nudCompareValue.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudCompareValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
