using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.AssignBrightness
{
    public partial class AssignBrightnessForm : ActionForm
    {
        #region Attributes

        private AssignBrightnessAction action;

        #endregion

        public AssignBrightnessForm(AssignBrightnessAction action)
        {
            InitializeComponent();
            this.helpTopic = AssignBrightness.HelpTopic;
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.AssignVariable != null)
                this.cbAssignVariable.SelectedItem = this.action.AssignVariable.Name;
        }

        protected override void SaveSettings()
        {
            Variable variable = GraphManager.GetVariable(this.cbAssignVariable.SelectedItem.ToString());
            this.action.UpdateSettings(variable);
        }

        protected override void AddVariable(Variable variable)
        {
            this.cbAssignVariable.Items.Add(variable.Name);
        }

        private void CbAssignVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbAssignVariable.SelectedIndex >= 1)
                this.bSave.Enabled = true;
            else
                this.bSave.Enabled = false;
            if (this.cbAssignVariable.SelectedIndex == 0)
            {
                NewVariableForm newVariableForm = new NewVariableForm();
                if (DialogResult.OK == newVariableForm.ShowDialog())
                {
                    GraphManager.AddVariable(newVariableForm.VariableCreated);
                    this.AddVariable(newVariableForm.VariableCreated);
                    this.cbAssignVariable.SelectedItem = newVariableForm.VariableCreated.Name;
                }
                else
                    this.cbAssignVariable.Undo();
            }
        }

        private void LHelp_Click(object sender, EventArgs e)
        {

        }

        private void GbSettings_Enter(object sender, EventArgs e)
        {

        }

        private void PFormSeparator_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LFormDescription_Click(object sender, EventArgs e)
        {

        }

    }
}
