using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Turn
{
    public partial class TurnPanel : ActionPanel
    {
        #region Attributes

        private TurnAction action;

        #endregion

        public TurnPanel(TurnAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.nudSpeed.Value = this.action.SpeedValue;
            if (this.action.SpeedVariable == null)
                this.cbSpeed.SelectedIndex = 0;
            else
                this.cbSpeed.SelectedItem = this.action.SpeedVariable.Name;
            if (this.action.Direction == Direction.Backward)
                this.rbBackward.Checked = true;
            this.nudRadius.Value = this.action.RadiusValue;
            if (this.action.RadiusVariable == null)
                this.cbRadius.SelectedIndex = 0;
            else
                this.cbRadius.SelectedItem = this.action.RadiusVariable.Name;
            if (this.action.TurnSide == Side.Left)
                this.rbLeft.Checked = true;

            switch (this.action.FlowachartControl)
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
            Variable speedVariable = null;
            int speedValue = 50;
            if (this.cbSpeed.SelectedIndex != 0)
                speedVariable = GraphManager.GetVariable(this.cbSpeed.SelectedItem.ToString());
            else
                speedValue = (int)this.nudSpeed.Value;
            Direction direction = Direction.Forward;
            if (this.rbBackward.Checked)
                direction = Direction.Backward;

            Variable radiusVariable = null;
            decimal radiusValue = 0.17M;
            if (this.cbRadius.SelectedIndex != 0)
                radiusVariable = GraphManager.GetVariable(this.cbRadius.SelectedItem.ToString());
            else
                radiusValue = this.nudRadius.Value;
            Side turnSide = Side.Right;
            if (this.rbLeft.Checked)
                turnSide = Side.Left;

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

            this.action.UpdateSettings(speedVariable, speedValue, direction, radiusVariable, radiusValue, turnSide, flowchartControl, timeVariable, timeValue, distanceVariable, distanceValue, waitFinish);
        }

        public override void AddVariable(Variable variable)
        {
            this.cbSpeed.Items.Add(variable.Name);
            this.cbRadius.Items.Add(variable.Name);
            this.cbTime.Items.Add(variable.Name);
            this.cbDistance.Items.Add(variable.Name);
        }

        private void CbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbSpeed.SelectedIndex == 0)
                this.nudSpeed.Enabled = true;
            else
                this.nudSpeed.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbRadius_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbRadius.SelectedIndex == 0)
                this.nudRadius.Enabled = true;
            else
                this.nudRadius.Enabled = false;
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

        private void RbForward_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbRight_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();

        }

        //***AÑADIDO
        private void NudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if ((this.nudSpeed.Value + this.nudRadius.Value) > 100)
                this.nudRadius.Value = 100 - this.nudSpeed.Value;

            if (this.autoSave)
                this.SaveSettings();
        }

        //***AÑADIDO
        private void NudRadius_ValueChanged(object sender, EventArgs e)
        {
            if ((this.nudSpeed.Value + this.nudRadius.Value) > 100)
                this.nudSpeed.Value = 100 - this.nudRadius.Value;

            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
