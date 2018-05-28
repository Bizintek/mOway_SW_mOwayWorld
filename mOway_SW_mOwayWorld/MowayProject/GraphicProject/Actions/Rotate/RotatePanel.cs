using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Rotate
{
    public partial class RotatePanel : ActionPanel
    {
        #region Attributes

        private RotateAction action;

        #endregion

        public RotatePanel(RotateAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.nudSpeed.Value = this.action.RotateValue;
            if (this.action.RotateVariable == null)
                this.cbSpeed.SelectedIndex = 0;
            else
                this.cbSpeed.SelectedItem = this.action.RotateVariable.Name;
            if (this.action.RotateMode == RotateMode.Wheel)
                this.rbRotateWheel.Checked = true;
            this.cbRotateCenter.SelectedIndex = (int)this.action.RotateSide;
            this.cbRotateWheel.SelectedIndex = (int)this.action.RotateWheel * 2 + (int)this.action.RotateDirection;

            switch (this.action.FlowachartControl)
            {
                case FlowchartControl.Continuously:
                    this.rbContiniously.Checked = true;
                    break;
                case FlowchartControl.FinishTime:
                    this.rbTime.Checked = true;
                    break;
                case FlowchartControl.FinishAngle:
                    this.rbAngle.Checked = true;
                    break;
            }
            this.nudTime.Value = this.action.TimeValue;
            if (this.action.TimeVariable == null)
                this.cbTime.SelectedIndex = 0;
            else
                this.cbTime.SelectedItem = this.action.TimeVariable.Name;
            this.nudAngle.Value = this.action.AngleValue;
            if (this.action.AngleVariable == null)
                this.cbAngle.SelectedIndex = 0;
            else
                this.cbAngle.SelectedItem = this.action.AngleVariable.Name;
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
            RotateMode mode = RotateMode.Center;
            if (this.rbRotateWheel.Checked)
                mode = RotateMode.Wheel;
            Side rotateSide = Side.Right;
            if (this.cbRotateCenter.SelectedIndex == 1)
                rotateSide = Side.Left;
            Side rotateWheel = Side.Right;
            if (this.cbRotateWheel.SelectedIndex >= 2)
                rotateWheel = Side.Left;
            Direction rotateDirection = Direction.Forward;
            if (this.cbRotateWheel.SelectedIndex % 2 == 1)
                rotateDirection = Direction.Backward;

            FlowchartControl flowchartControl = FlowchartControl.Continuously;
            Variable timeVariable = null;
            Decimal timeValue = 0.1M;
            Variable distanceVariable = null;
            Decimal distanceValue = 3.6M;
            if (this.rbTime.Checked)
            {
                flowchartControl = FlowchartControl.FinishTime;
                if (this.cbTime.SelectedIndex != 0)
                    timeVariable = GraphManager.GetVariable(this.cbTime.SelectedItem.ToString());
                else
                    timeValue = this.nudTime.Value;
            }
            else if (this.rbAngle.Checked)
            {
                flowchartControl = FlowchartControl.FinishAngle;
                if (this.cbAngle.SelectedIndex != 0)
                    distanceVariable = GraphManager.GetVariable(this.cbAngle.SelectedItem.ToString());
                else
                    distanceValue = this.nudAngle.Value;
            }
            bool waitFinish = this.cbFinishCommands.Checked;

            this.action.UpdateSettings(speedVariable, speedValue, mode, rotateSide, rotateWheel, rotateDirection, flowchartControl, timeVariable, timeValue, distanceVariable, distanceValue, waitFinish);
        }

        public override void AddVariable(Variable variable)
        {
            this.cbSpeed.Items.Add(variable.Name);
            this.cbTime.Items.Add(variable.Name);
            this.cbAngle.Items.Add(variable.Name);
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

        private void CbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbTime.Enabled) && (this.cbTime.SelectedIndex == 0))
                this.nudTime.Enabled = true;
            else
                this.nudTime.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.cbAngle.Enabled) &&  (this.cbAngle.SelectedIndex == 0))
                this.nudAngle.Enabled = true;
            else
                this.nudAngle.Enabled = false;
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

        private void RbAngle_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbAngle.Checked)
            {
                this.cbAngle.Enabled = true;
                if (this.cbAngle.SelectedIndex == 0)
                    this.nudAngle.Enabled = true;
                this.cbFinishCommands.Enabled = true;
                this.cbFinishCommands.Checked = true;
            }
            else
            {
                this.cbAngle.Enabled = false;
                this.nudAngle.Enabled = false;
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

        private void RbRotateCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbRotateCenter.Checked)
            {
                this.cbRotateCenter.Enabled = true;
                this.cbRotateWheel.Enabled = false;
            }
            else
            {
                this.cbRotateCenter.Enabled = false;
                this.cbRotateWheel.Enabled = true;
            }
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbRotateMode_SelectedIndexChanged(object sender, EventArgs e)
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
