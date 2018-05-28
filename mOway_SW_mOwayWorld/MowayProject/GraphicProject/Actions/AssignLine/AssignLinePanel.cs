using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.AssignLine
{
    public partial class AssignLinePanel : ActionPanel
    {
        #region Attributes

        private AssignLineAction action;

        #endregion

        public AssignLinePanel(AssignLineAction action)
        {
            InitializeComponent();
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

        public override void AddVariable(Variable variable)
        {
            this.cbAssignVariable.Items.Add(variable.Name);
        }

        private void CbAssignVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbSensor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
