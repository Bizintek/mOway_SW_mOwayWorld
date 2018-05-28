using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Math
{
    public partial class MathPanel : ActionPanel
    {
        #region Attributes

        private MathAction action;

        #endregion

        public MathPanel(MathAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        public override void AddVariable(Variable variable)
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

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbOperand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbOperand.SelectedIndex == 0)
                this.nudOperandValue.Enabled = true;
            else
                this.nudOperandValue.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudOperandValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
