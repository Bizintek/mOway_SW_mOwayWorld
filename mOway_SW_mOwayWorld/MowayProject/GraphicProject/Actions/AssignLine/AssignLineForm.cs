using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.AssignLine
{
    public partial class AssignLineForm : ActionForm
    {
        #region Attributes

        private AssignLineAction action;

        #endregion

        public AssignLineForm(AssignLineAction action)
        {
            InitializeComponent();
            this.helpTopic = AssignLine.HelpTopic;
                this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.AssignVariable != null)
                this.cbAssignVariable.SelectedItem = this.action.AssignVariable.Name;
            if (this.action.LineSensor == Side.Left)
                this.rbLeftSensor.Checked = true;
        }

        protected override void SaveSettings()
        {
            Variable variable = GraphManager.GetVariable(this.cbAssignVariable.SelectedItem.ToString());
            Side sensor = Side.Right;
            if (this.rbLeftSensor.Checked)
                sensor = Side.Left;
            this.action.UpdateSettings(variable, sensor);
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

    }
}
