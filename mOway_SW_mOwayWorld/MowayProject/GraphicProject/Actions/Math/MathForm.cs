using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.Math
{
    public partial class MathForm : ActionForm
    {
        #region Attributes

        private MathAction action;

        #endregion

        public MathForm(MathAction action)
        {
            InitializeComponent();
            this.helpTopic = Math.HelpTopic;
this.action = action;
        }

        protected override void AddVariable(Variable variable)
        {
            this.cbResult.Items.Add(variable.Name);
            this.cbOperand.Items.Add(variable.Name);
        }

        protected override void LoadSettings()
        {
            if (this.action.ResultVariable != null)
                this.cbResult.SelectedItem = this.action.ResultVariable.Name;
            this.cbOperator.SelectedIndex = (int)this.action.Operation;
            if (this.action.Variable == null)
                this.cbOperand.SelectedIndex = 0;
            else
                this.cbOperand.SelectedItem = this.action.Variable.Name;
            this.nudOperandValue.Value = this.action.Value;
        }

        protected override void SaveSettings()
        {
            Variable resultVariable = GraphManager.GetVariable(this.cbResult.SelectedItem.ToString());
            ArithmeticOp operation = (ArithmeticOp)Enum.ToObject(typeof(ArithmeticOp), this.cbOperator.SelectedIndex);
            Variable variable = null;
            int value = 0;
            if (this.cbOperand.SelectedIndex != 0)
                variable = GraphManager.GetVariable(this.cbOperand.SelectedItem.ToString());
            else
                value = (int)this.nudOperandValue.Value;
            this.action.UpdateSettings(resultVariable, operation, variable, value);
        }

        private void CbOperand_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbOperand.SelectedIndex)
            {
                case 0:
                    this.nudOperandValue.Enabled = true;
                    break;
                case 1:
                    this.nudOperandValue.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbOperand.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbOperand.Undo();
                    break;
                default:
                    this.nudOperandValue.Enabled = false;
                    break;
            }
        }

        private void CbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbResult.SelectedIndex >= 1)
                this.bSave.Enabled = true;
            else
                this.bSave.Enabled = false;
            if (this.cbResult.SelectedIndex == 0)
            {
                NewVariableForm newVariableForm = new NewVariableForm();
                if (DialogResult.OK == newVariableForm.ShowDialog())
                {
                    GraphManager.AddVariable(newVariableForm.VariableCreated);
                    this.AddVariable(newVariableForm.VariableCreated);
                    this.cbResult.SelectedItem = newVariableForm.VariableCreated.Name;
                }
                else
                    this.cbResult.Undo();
            }
        }
    }
}
