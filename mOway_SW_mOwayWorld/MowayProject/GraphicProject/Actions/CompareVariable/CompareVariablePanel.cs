using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.CompareVariable
{
    public partial class CompareVariablePanel : ActionPanel
    {
        #region Attributes

        private CompareVariableAction action;

        #endregion

        public CompareVariablePanel(CompareVariableAction action)
        {
            InitializeComponent();
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

        public override void AddVariable(Variable variable)
        {
            this.cbVariable.Items.Add(variable.Name);
            this.cbCompareVariable.Items.Add(variable.Name);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudCompareValue_Load(object sender, EventArgs e)
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

    }
}
