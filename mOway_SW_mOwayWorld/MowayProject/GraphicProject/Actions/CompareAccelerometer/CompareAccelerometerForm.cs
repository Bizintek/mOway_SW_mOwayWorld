using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.CompareAccelerometer
{
    public partial class CompareAccelerometerForm : ActionForm
    {
        #region Attributes

        private CompareAccelerometerAction action;

        #endregion

        public CompareAccelerometerForm(CompareAccelerometerAction action)
        {
            InitializeComponent();
            this.helpTopic = CompareAccelerometer.HelpTopic;
this.action = action;
        }

        #region Private methods

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

        protected override void AddVariable(Variable variable)
        {
            this.cbCompareVariable.Items.Add(variable.Name);
        }

        private void GenerateMessage()
        {
            this.tbOutput.Text = CompareMessages.TRUE + " - " + CompareMessages.IF + " ";
            if (this.rbXAxis.Checked)
                this.tbOutput.Text += CompareAccelerometerMessages.X_AXIS + " " + CompareMessages.IS + " ";
            else if (this.rbYAxis.Checked)
                this.tbOutput.Text += CompareAccelerometerMessages.Y_AXIS + " " + CompareMessages.IS + " ";
            else
                this.tbOutput.Text += CompareAccelerometerMessages.Z_AXIS + " " + CompareMessages.IS + " ";
            switch (this.cbOperator.SelectedIndex)
            {
                case (int)ComparativeOp.Equal:
                    this.tbOutput.Text += CompareMessages.EQUAL;
                    break;
                case (int)ComparativeOp.Distinct:
                    this.tbOutput.Text += CompareMessages.DISTINCT;
                    break;
                case (int)ComparativeOp.Smaller:
                    this.tbOutput.Text += CompareMessages.SMALLER;
                    break;
                case (int)ComparativeOp.SmallerEqual:
                    this.tbOutput.Text += CompareMessages.SMALLER_OR_EQUAL;
                    break;
                case (int)ComparativeOp.Bigger:
                    this.tbOutput.Text += CompareMessages.BIGGER;
                    break;
                case (int)ComparativeOp.BiggerEqual:
                    this.tbOutput.Text += CompareMessages.BIGGER_OR_EQUAL;
                    break;
            }
            if (this.cbCompareVariable.SelectedIndex == 0)
                this.tbOutput.Text += " " + this.nudCompareValue.Value + "g";
            else
                this.tbOutput.Text += " " + CompareMessages.VALUE_OF + " " + this.cbCompareVariable.SelectedItem;
            this.tbOutput.Text += ".\r\n" + CompareMessages.FALSE + " - " + CompareMessages.OTHERWISE;
        }

        #endregion

        #region Form graphic Events

        private void CbCompareVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbCompareVariable.SelectedIndex)
            {
                case 0:
                    this.nudCompareValue.Enabled = true;
                    break;
                case 1:
                    this.nudCompareValue.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbCompareVariable.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbCompareVariable.Undo();
                    break;
                default:
                    this.nudCompareValue.Enabled = false;
                    break;
            }
            this.GenerateMessage();
        }

        #endregion

        private void RbAxis_CheckedChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }


        private void CbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }

        private void NudCompareValue_ValueChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }
    }
}
