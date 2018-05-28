using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Pause
{
    public partial class PausePanel : ActionPanel
    {
        #region Attributes

        private PauseAction action;

        #endregion

        public PausePanel(PauseAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.TimeVariable == null)
                this.cbTime.SelectedIndex = 0;
            else
                this.cbTime.SelectedItem = this.action.TimeVariable.Name;
            this.nudTime.Value = this.action.TimeValue;
        }

        public override void AddVariable(Variable variable)
        {
            this.cbTime.Items.Add(variable.Name);
        }

        protected override void SaveSettings()
        {
            Variable timeVariable = null;
            decimal timeValue = 1;
            if (this.cbTime.SelectedIndex != 0)
                timeVariable = GraphManager.GetVariable(this.cbTime.SelectedItem.ToString());
            else
                timeValue = this.nudTime.Value;
            this.action.UpdateSettings(timeVariable, timeValue);
        }

        private void CbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbTime.SelectedIndex == 0)
                this.nudTime.Enabled = true;
            else
                this.nudTime.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudTime_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
