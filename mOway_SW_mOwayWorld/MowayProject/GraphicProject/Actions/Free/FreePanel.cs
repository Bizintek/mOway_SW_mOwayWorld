using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Free
{
    public partial class FreePanel : ActionPanel
    {
        #region Attributes

        private FreeAction action;

        #endregion

        public FreePanel(FreeAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.nudLeftSpeed.Value = this.action.LeftSpeedValue;
            if (this.action.LeftSpeedVariable == null)
                this.cbLeftSpeed.SelectedIndex = 0;
            else
                this.cbLeftSpeed.SelectedItem = this.action.LeftSpeedVariable.Name;
            if (this.action.LeftDirection == Direction.Backward)
                this.rbLeftBackward.Checked = true;
            this.nudRightSpeed.Value = this.action.RightSpeedValue;
            if (this.action.RightSpeedVariable == null)
                this.cbRightSpeed.SelectedIndex = 0;
            else
                this.cbRightSpeed.SelectedItem = this.action.RightSpeedVariable.Name;
            if (this.action.RightDirection == Direction.Backward)
                this.rbRightBackward.Checked = true;

            switch (this.action.FlowchartControl)
            {
                case FlowchartControl.Continuously:
                    this.rbContiniously.Checked = true;
                    break;
                case FlowchartControl.FinishTime:
                    this.rbTime.Checked = true;
                    break;
                case FlowchartControl.FinishDistance:
                    this.rbDistance.Checked = true;
                    break;
            }
            this.nudTime.Value = this.action.TimeValue;
            if (this.action.TimeVariable == null)
                this.cbTime.SelectedIndex = 0;
            else
                this.cbTime.SelectedItem = this.action.TimeVariable.Name;
            this.nudDistance.Value = this.action.DistanceValue;
            if (this.action.DistanceVariable == null)
                this.cbDistance.SelectedIndex = 0;
            else
                this.cbDistance.SelectedItem = this.action.DistanceVariable.Name;
            this.cbFinishCommands.Checked = this.action.WaitFinish;
        }

        protected override void SaveSettings()
        {
            Variable leftSpeedVariable = null;
            int leftSpeedValue = 50;
            Direction leftDirection = Direction.Forward;
            if (this.cbLeftSpeed.SelectedIndex != 0)
                leftSpeedVariable = GraphManager.GetVariable(this.cbLeftSpeed.SelectedItem.ToString());
            else
                leftSpeedValue = (int)this.nudLeftSpeed.Value;
            if (this.rbLeftBackward.Checked)
                leftDirection = Direction.Backward;
            Variable rightSpeedVariable = null;
            int rightSpeedValue = 50;
            Direction rightDirection = Direction.Forward;
            if (this.cbRightSpeed.SelectedIndex != 0)
                rightSpeedVariable = GraphManager.GetVariable(this.cbRightSpeed.SelectedItem.ToString());
            else
                rightSpeedValue = (int)this.nudRightSpeed.Value;
            if (this.rbRightBackward.Checked)
                rightDirection = Direction.Backward;

            FlowchartControl flowchartControl = FlowchartControl.Continuously;
            Variable timeVariable = null;
            Decimal timeValue = 0.1M;
            Variable distanceVariable = null;
            Decimal distanceValue = 0.17M;
            if (this.rbTime.Checked)
            {
                flowchartControl = FlowchartControl.FinishTime;
                if (this.cbTime.SelectedIndex != 0)
                    timeVariable = GraphManager.GetVariable(this.cbTime.SelectedItem.ToString());
                else
                    timeValue = this.nudTime.Value;
            }
            else if (this.rbDistance.Checked)
            {
                flowchartControl = FlowchartControl.FinishDistance;
                if (this.cbDistance.SelectedIndex != 0)
                    distanceVariable = GraphManager.GetVariable(this.cbDistance.SelectedItem.ToString());
                else
                    distanceValue = this.nudDistance.Value;
            }
            bool waitFinish = this.cbFinishCommands.Checked;

            this.action.UpdateSettings(leftSpeedVariable, leftSpeedValue, leftDirection, rightSpeedVariable, rightSpeedValue, rightDirection, flowchartControl, timeVariable, timeValue, distanceVariable, distanceValue, waitFinish);
        }

        public override void AddVariable(Variable variable)
        {
            this.cbLeftSpeed.Items.Add(variable.Name);
            this.cbRightSpeed.Items.Add(variable.Name);
            this.cbTime.Items.Add(variable.Name);
            this.cbDistance.Items.Add(variable.Name);
        }

        private void CbLeftSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbLeftSpeed.SelectedIndex == 0)
                this.nudLeftSpeed.Enabled = true;
            else
                this.nudLeftSpeed.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbRightSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbRightSpeed.SelectedIndex == 0)
                this.nudRightSpeed.Enabled = true;
            else
                this.nudRightSpeed.Enabled = false;
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

        private void CbDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbDistance.Enabled) && (this.cbDistance.SelectedIndex == 0))
                this.nudDistance.Enabled = true;
            else
                this.nudDistance.Enabled = false;
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

        private void RbDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDistance.Checked)
            {
                this.cbDistance.Enabled = true;
                if (this.cbDistance.SelectedIndex == 0)
                    this.nudDistance.Enabled = true;
                this.cbFinishCommands.Enabled = true;
                this.cbFinishCommands.Checked = true;
            }
            else
            {
                this.cbDistance.Enabled = false;
                this.nudDistance.Enabled = false;
                this.cbFinishCommands.Enabled = false;
            }
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbFinishCommands_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbLeftForward_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbRightForward_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
