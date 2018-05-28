using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.CompareObstacle
{
    public partial class CompareObstacleForm : ActionForm
    {
        #region Attributes

        private CompareObstacleAction action;

        #endregion

        public CompareObstacleForm(CompareObstacleAction action)
        {
            InitializeComponent();
            this.helpTopic = CompareObstacle.HelpTopic;
this.action = action;
        }

        #region Private methods

        protected override void LoadSettings()
        {
            switch (this.action.ObstacleSensor)
            {
                case ObstacleSensor.UpperRight:
                    this.rbUpperRightSensor.Checked = true;
                    break;
                case ObstacleSensor.Left:
                    this.rbLeftSensor.Checked = true;
                    break;
                case ObstacleSensor.UpperLeft:
                    this.rbUpperLeftSensor.Checked = true;
                    break;
            }
            this.cbOperator.SelectedIndex = (int)this.action.Operation;
            if (this.action.CompareVariable == null)
                this.cbCompareVariable.SelectedIndex = 0;
            else
                this.cbCompareVariable.SelectedItem = this.action.CompareVariable.Name;
            this.nudCompareValue.Value = this.action.CompareValue;
        }

        protected override void SaveSettings()
        {
            ObstacleSensor sensor = ObstacleSensor.Right;
            if (this.rbUpperRightSensor.Checked)
                sensor = ObstacleSensor.UpperRight;
            else if (this.rbLeftSensor.Checked)
                sensor = ObstacleSensor.Left;
            else if (this.rbUpperLeftSensor.Checked)
                sensor = ObstacleSensor.UpperLeft;
            ComparativeOp operation = (ComparativeOp)Enum.ToObject(typeof(ComparativeOp), this.cbOperator.SelectedIndex);
            Variable variable = null;
            int value = 0;
            if (this.cbCompareVariable.SelectedIndex != 0)
                variable = GraphManager.GetVariable(this.cbCompareVariable.SelectedItem.ToString());
            else
                value = (int)this.nudCompareValue.Value;
            this.action.UpdateSettings(sensor, operation, variable, value);
        }

        protected override void AddVariable(Variable variable)
        {
            this.cbCompareVariable.Items.Add(variable.Name);
        }

        private void GenerateMessage()
        {
            this.tbOutput.Text = CompareMessages.TRUE + " - " + CompareMessages.IF + " ";
            if (this.rbLeftSensor.Checked)
                this.tbOutput.Text += CompareObstacleMessages.LEFT_SENSOR + " " + CompareMessages.IS + " ";
            else if (this.rbUpperLeftSensor.Checked)
                this.tbOutput.Text += CompareObstacleMessages.UPPER_LEFT_SENSOR + " " + CompareMessages.IS + " ";
            else if (this.rbRightSensor.Checked)
                this.tbOutput.Text += CompareObstacleMessages.RIGHT_SENSOR + " " + CompareMessages.IS + " ";
            else
                this.tbOutput.Text += CompareObstacleMessages.UPPER_RIGHT_SENSOR + " " + CompareMessages.IS + " ";
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
                this.tbOutput.Text += " " + this.nudCompareValue.Value + "%";
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

        private void CbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }

        private void NudCompareValue_ValueChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }

        private void RbSensor_CheckedChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }
    }
}
