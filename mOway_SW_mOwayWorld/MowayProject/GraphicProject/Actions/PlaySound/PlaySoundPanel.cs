using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.PlaySound
{
    public partial class PlaySoundPanel : ActionPanel
    {
        #region Attributes

        private PlaySoundAction action;

        #endregion

        public PlaySoundPanel(PlaySoundAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            if (this.action.FrequencyVariable == null)
                this.cbFrequency.SelectedIndex = 0;
            else
                this.cbFrequency.SelectedItem = this.action.FrequencyVariable.Name;
            this.nudFrequency.Value = this.action.FrecuencyValue;

            switch (this.action.FlowchartControl)
            {
                case FlowchartControl.Continuously:
                    this.rbContiniously.Checked = true;
                    break;
                case FlowchartControl.FinishTime:
                    this.rbTime.Checked = true;
                    break;
            }
            if (this.action.TimeVariable == null)
                this.cbTime.SelectedIndex = 0;
            else
                this.cbTime.SelectedItem = this.action.TimeVariable.Name;
            this.nudTime.Value = this.action.TimeValue;
            this.cbFinishCommands.Checked = this.action.WaitFinish;
        }

        protected override void SaveSettings()
        {
            Variable frequencyVariable = null;
            decimal frequencyValue = 244.14M;
            if (this.cbFrequency.SelectedIndex != 0)
                frequencyVariable = GraphManager.GetVariable(this.cbFrequency.SelectedItem.ToString());
            else
                frequencyValue = this.nudFrequency.Value;

            FlowchartControl flowchartControl = FlowchartControl.Continuously;
            Variable timeVariable = null;
            Decimal timeValue = 0.1M;
            bool waitFinish = false;
            if (this.rbTime.Checked)
            {
                flowchartControl = FlowchartControl.FinishTime;
                if (this.cbTime.SelectedIndex != 0)
                    timeVariable = GraphManager.GetVariable(this.cbTime.SelectedItem.ToString());
                else
                    timeValue = this.nudTime.Value;
            }
            waitFinish = this.cbFinishCommands.Checked;

            this.action.UpdateSettings(frequencyVariable, frequencyValue, flowchartControl, timeVariable, timeValue, waitFinish);
        }

        public override void AddVariable(Variable variable)
        {
            this.cbFrequency.Items.Add(variable.Name);
            this.cbTime.Items.Add(variable.Name);
        }

        private void CbFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbFrequency.SelectedIndex == 0)
                this.nudFrequency.Enabled = true;
            else
                this.nudFrequency.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbTime.Enabled) && (this.cbTime.SelectedIndex == 0))
                this.nudTime.Enabled = true;
            else
                this.nudTime.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbContiniously_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbContiniously.Checked)
                this.cbFinishCommands.Checked = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbTime.Checked)
            {
                this.cbTime.Enabled = true;
                if (this.cbTime.SelectedIndex == 0)
                    this.nudTime.Enabled = true;
                this.cbFinishCommands.Enabled = true;
                this.cbFinishCommands.Checked = true;
            }
            else
            {
                this.cbTime.Enabled = false;
                this.nudTime.Enabled = false;
                this.cbFinishCommands.Enabled = false;
            }
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbFinishCommands_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

    }
}
