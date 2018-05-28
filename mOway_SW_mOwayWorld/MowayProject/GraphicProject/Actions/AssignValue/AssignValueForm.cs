using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.AssignValue
{
    public partial class AssignValueForm : ActionForm
    {
        #region Attributes

        private AssignValueAction action;

        #endregion

        public AssignValueForm(AssignValueAction action)
        {
            InitializeComponent();
            this.helpTopic = AssignValue.HelpTopic;
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

        protected override void AddVariable(Variable variable)
        {
            this.cbAsignVariable.Items.Add(variable.Name);
            this.cbVariable.Items.Add(variable.Name);
        }

        private void CbAsignVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbAsignVariable.SelectedIndex >= 1)
                this.bSave.Enabled = true;
            else
                this.bSave.Enabled = false;
            if (this.cbAsignVariable.SelectedIndex == 0)
            {
                NewVariableForm newVariableForm = new NewVariableForm();
                if (DialogResult.OK == newVariableForm.ShowDialog())
                {
                    GraphManager.AddVariable(newVariableForm.VariableCreated);
                    this.AddVariable(newVariableForm.VariableCreated);
                    this.cbAsignVariable.SelectedItem = newVariableForm.VariableCreated.Name;
                }
                else
                    this.cbAsignVariable.Undo();
            }
        }

        private void CbVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable.SelectedIndex)
            {
                case 0:
                    this.nudValue.Enabled = true;
                    break;
                case 1:
                    this.nudValue.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable.Undo();
                    break;
                default:
                    this.nudValue.Enabled = false;
                    break;
            }

        }

    }
}
