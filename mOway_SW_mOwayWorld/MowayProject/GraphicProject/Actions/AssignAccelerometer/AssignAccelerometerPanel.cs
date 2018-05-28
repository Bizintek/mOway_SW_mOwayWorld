using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.AssignAccelerometer
{
    public partial class AssignAccelerometerPanel : ActionPanel
    {
        #region Attributes

        private AssignAccelerometerAction action;

        #endregion

        public AssignAccelerometerPanel(AssignAccelerometerAction action)
        {
            InitializeComponent();
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

        public override void AddVariable(Variable variable)
        {
            this.cbAssignVariable.Items.Add(variable.Name);
        }

        private void CbAssignVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}