using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.AssignValue
{
    public partial class AssignValuePanel : ActionPanel
    {
        #region Attributes

        private AssignValueAction action;

        #endregion

        public AssignValuePanel(AssignValueAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.AssignVariable != null)
                this.cbAsignVariable.SelectedItem = this.action.AssignVariable.Name;
            if (this.action.Variable == null)
                this.cbVariable.SelectedIndex = 0;
            else
                this.cbVariable.SelectedItem = this.action.Variable.Name;
            this.nudValue.Value = this.action.Value;
        }

        protected override void SaveSettings()
        {
            Variable variable = GraphManager.GetVariable(this.cbAsignVariable.SelectedItem.ToString());
            Variable valueVariable = null;
            int value = 0;
            if (this.cbVariable.SelectedIndex != 0)
                valueVariable = GraphManager.GetVariable(this.cbVariable.SelectedItem.ToString());
            else
                value = (int)this.nudValue.Value;
            this.action.UpdateSettings(variable, valueVariable, value);
        }

        public override void AddVariable(Variable variable)
        {
            this.cbAsignVariable.Items.Add(variable.Name);
            this.cbVariable.Items.Add(variable.Name);
        }

        private void CbAsignVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
            if (this.cbVariable.SelectedIndex == 0)
                this.nudValue.Enabled = true;
            else
                this.nudValue.Enabled = false;
        }

        private void NudValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
