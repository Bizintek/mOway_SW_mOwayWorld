using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.CompareSpeed
{
    public partial class CompareSpeedForm : ActionForm
    {
        #region Attributes

        private CompareSpeedAction action;

        #endregion

        public CompareSpeedForm(CompareSpeedAction action)
        {
            InitializeComponent();
            this.helpTopic = CompareSpeed.HelpTopic;
this.action = action;
        }

        #region Private methods

        protected override void LoadSettings()
        {
            if (this.action.Wheel == Side.Left)
                this.rbLeftSpeed.Checked = true;
            this.cbOperator.SelectedIndex = (int)this.action.Operation;
            if (this.action.CompareVariable == null)
                this.cbCompareVariable.SelectedIndex = 0;
            else
                this.cbCompareVariable.SelectedItem = this.action.CompareVariable.Name;
            this.nudCompareValue.Value = this.action.CompareValue;
        }

        protected override void SaveSettings()
        {
            Side wheel = Side.Right;
            if (this.rbLeftSpeed.Checked)
                wheel = Side.Left;
            ComparativeOp operation = (ComparativeOp)Enum.ToObject(typeof(ComparativeOp), this.cbOperator.SelectedIndex);
            Variable variable = null;
            int value = 0;
            if (this.cbCompareVariable.SelectedIndex != 0)
                variable = GraphManager.GetVariable(this.cbCompareVariable.SelectedItem.ToString());
            else
                value = (int)this.nudCompareValue.Value;
            this.action.UpdateSettings(wheel, operation, variable, value);
        }

        protected override void AddVariable(Variable variable)
        {
            this.cbCompareVariable.Items.Add(variable.Name);
        }

        private void GenerateMessage()
        {
            this.tbOutput.Text = CompareMessages.TRUE + " - " + CompareMessages.IF + " ";
            if (this.rbLeftSpeed.Checked)
                this.tbOutput.Text += CompareSpeedMessages.LEFT_WHEEL + " " + CompareMessages.IS + " ";
            else
                this.tbOutput.Text += CompareSpeedMessages.RIGHT_WHEEL + " " + CompareMessages.IS + " ";
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
                this.tbOutput.Text += " " + this.nudCompareValue.Value;
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

        private void BSpeed_CheckedChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }

        //***ADDED
        private void NudCompareValue_ValueChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }

        private void CbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }
       
    }
}
