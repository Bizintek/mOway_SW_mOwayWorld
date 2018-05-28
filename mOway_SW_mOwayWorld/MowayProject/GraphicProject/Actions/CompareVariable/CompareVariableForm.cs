using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.CompareVariable
{
    public partial class CompareVariableForm : ActionForm
    {
        #region Attributes

        private CompareVariableAction action;

        #endregion

        public CompareVariableForm(CompareVariableAction action)
        {
            InitializeComponent();
            this.helpTopic = CompareVariable.HelpTopic;
this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.Variable != null)
                this.cbVariable.SelectedItem = this.action.Variable.Name;
            this.cbOperator.SelectedIndex = (int)this.action.Operation;
            if (this.action.CompareVariable == null)
                this.cbCompareVariable.SelectedIndex = 0;
            else
                this.cbCompareVariable.SelectedItem = this.action.CompareVariable.Name;
            this.nudCompareValue.Value = this.action.CompareValue;
        }

        protected override void SaveSettings()
        {
            Variable variable = GraphManager.GetVariable(this.cbVariable.SelectedItem.ToString());
            ComparativeOp operation = (ComparativeOp)Enum.ToObject(typeof(ComparativeOp), this.cbOperator.SelectedIndex);
            Variable compareVariable = null;
            int value = 0;
            if (this.cbCompareVariable.SelectedIndex != 0)
                compareVariable = GraphManager.GetVariable(this.cbCompareVariable.SelectedItem.ToString());
            else
                value = (int)this.nudCompareValue.Value;
            this.action.UpdateSettings(variable, operation, compareVariable, value);
        }

        protected override void AddVariable(Variable variable)
        {
            this.cbVariable.Items.Add(variable.Name);
            this.cbCompareVariable.Items.Add(variable.Name);
        }

        private void GenerateMessage()
        {
            this.tbOutput.Text = CompareMessages.TRUE + " - " + CompareMessages.IF + " " + this.cbVariable.SelectedItem + " " + CompareMessages.IS + " ";
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

        private void CbVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable.SelectedIndex >= 1)
                this.bSave.Enabled = true;
            else
                this.bSave.Enabled = false;
            if (this.cbVariable.SelectedIndex == 0)
            {
                NewVariableForm newVariableForm = new NewVariableForm();
                if (DialogResult.OK == newVariableForm.ShowDialog())
                {
                    GraphManager.AddVariable(newVariableForm.VariableCreated);
                    this.AddVariable(newVariableForm.VariableCreated);
                    this.cbVariable.SelectedItem = newVariableForm.VariableCreated.Name;
                }
                else
                    this.cbVariable.Undo();
            }
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
