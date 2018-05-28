using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Moway.Project.GraphicProject.Forms;


namespace Moway.Project.GraphicProject.Actions.AssignAccelerometer
{
    public partial class AssignAccelerometerForm : ActionForm
    {
        #region Attributes

        private AssignAccelerometerAction action;

        #endregion

        public AssignAccelerometerForm(AssignAccelerometerAction action)
        {
            InitializeComponent();
            this.helpTopic = AssignAccelerometer.HelpTopic;
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.AssignVariable != null)
                this.cbAssignVariable.SelectedItem = this.action.AssignVariable.Name;
            switch (this.action.Axis)
            {
                case AccelerometerAxis.Y:
                    this.rbYAxis.Checked = true;
                    break;
                case AccelerometerAxis.Z:
                    this.rbZAxis.Checked = true;
                    break;
            }
        }

        protected override void SaveSettings()
        {
            Variable variable = GraphManager.GetVariable(this.cbAssignVariable.SelectedItem.ToString());
            AccelerometerAxis axis = AccelerometerAxis.X;
            if (this.rbYAxis.Checked)
                axis = AccelerometerAxis.Y;
            else if (this.rbZAxis.Checked)
                axis = AccelerometerAxis.Z;
            this.action.UpdateSettings(variable, axis);
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
