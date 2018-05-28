using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.AssignObstacle
{
    public partial class AssignObstacleForm : ActionForm
    {
        #region Attributes

        private AssignObstacleAction action;

        #endregion

        public AssignObstacleForm(AssignObstacleAction action)
        {
            InitializeComponent();
            this.helpTopic = AssignObstacle.HelpTopic;
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.AssignVariable != null)
                this.cbAssignVariable.SelectedItem = this.action.AssignVariable.Name;
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
        }

        protected override void SaveSettings()
        {
            Variable variable = GraphManager.GetVariable(this.cbAssignVariable.SelectedItem.ToString());
            ObstacleSensor sensor = ObstacleSensor.Right;
            if (this.rbUpperRightSensor.Checked)
                sensor = ObstacleSensor.UpperRight;
            else if (this.rbLeftSensor.Checked)
                sensor = ObstacleSensor.Left;
            else if (this.rbUpperLeftSensor.Checked)
                sensor = ObstacleSensor.UpperLeft;
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
