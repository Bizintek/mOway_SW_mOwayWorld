using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.CompareAccelerometer
{
    public partial class CompareAccelerometerPanel : ActionPanel
    {
        #region Attributes

        private CompareAccelerometerAction action;

        #endregion

        public CompareAccelerometerPanel(CompareAccelerometerAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.Axis == AccelerometerAxis.Y)
                this.rbYAxis.Checked = true;
            else if (this.action.Axis == AccelerometerAxis.Z)
                this.rbZAxis.Checked = true;
            this.cbOperator.SelectedIndex = (int)this.action.Operation;
            if (this.action.CompareVariable == null)
                this.cbCompareVariable.SelectedIndex = 0;
            else
                this.cbCompareVariable.SelectedItem = this.action.CompareVariable.Name;
            this.nudCompareValue.Value = this.action.CompareValue;
        }

        protected override void SaveSettings()
        {
            AccelerometerAxis axis = AccelerometerAxis.X;
            if (this.rbYAxis.Checked)
                axis = AccelerometerAxis.Y;
            else if (this.rbZAxis.Checked)
                axis = AccelerometerAxis.Z;
            ComparativeOp operation = (ComparativeOp)Enum.ToObject(typeof(ComparativeOp), this.cbOperator.SelectedIndex);
            Variable variable = null;
            decimal value = 0;
            if (this.cbCompareVariable.SelectedIndex != 0)
                variable = GraphManager.GetVariable(this.cbCompareVariable.SelectedItem.ToString());
            else
                value = this.nudCompareValue.Value;
            this.action.UpdateSettings(axis, operation, variable, value);
        }

        public override void AddVariable(Variable variable)
        {
            this.cbCompareVariable.Items.Add(variable.Name);
        }

        private void RbAxis_CheckedChanged(object sender, EventArgs e)
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
