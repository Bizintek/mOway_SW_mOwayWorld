using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.Turn
{
    public partial class TurnForm : ActionForm
    {
        #region Attributes

        private TurnAction action;

        #endregion

        public TurnForm(TurnAction action)
        {
            InitializeComponent();
            this.helpTopic = Turn.HelpTopic;

            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                this.Font = new System.Drawing.Font("Sans", 8.25F, System.Drawing.FontStyle.Regular);

            //The action is saved in order to save the changes
            this.action = action;
        }

        #region Private methods

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

        protected override void AddVariable(Variable variable)
        {
            this.cbSpeed.Items.Add(variable.Name);
            this.cbRadius.Items.Add(variable.Name);
            this.cbTime.Items.Add(variable.Name);
            this.cbDistance.Items.Add(variable.Name);
        }

        #endregion

        #region Graphic events on the screen

        private void CbSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbSpeed.SelectedIndex)
            {
                case 0:
                    this.nudSpeed.Enabled = true;
                    break;
                case 1:
                    this.nudSpeed.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbSpeed.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbSpeed.Undo();
                    break;
                default:
                    this.nudSpeed.Enabled = false;
                    break;
            }
        }

        private void CbRadius_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbRadius.SelectedIndex)
            {
                case 0:
                    this.nudRadius.Enabled = true;
                    break;
                case 1:
                    this.nudRadius.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbRadius.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbRadius.Undo();
                    break;
                default:
                    this.nudRadius.Enabled = false;
                    break;
            }
        }

        private void RbContiniously_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbContiniously.Checked)
                this.cbFinishCommands.Checked = false;
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
        }

        private void CbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbTime.SelectedIndex)
            {
                case 0:
                    this.nudTime.Enabled = this.rbTime.Checked;
                    break;
                case 1:
                    this.nudTime.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbTime.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbTime.Undo();
                    break;
                default:
                    this.nudTime.Enabled = false;
                    break;
            }
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
        }

        private void CbDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbDistance.SelectedIndex)
            {
                case 0:
                    this.nudDistance.Enabled = this.rbDistance.Checked;
                    break;
                case 1:
                    this.nudDistance.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbDistance.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbDistance.Undo();
                    break;
                default:
                    this.nudDistance.Enabled = false;
                    break;
            }
        }

        #endregion

        private void NudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if ((this.nudSpeed.Value + this.nudRadius.Value) > 100)
                this.nudRadius.Value = 100 - this.nudSpeed.Value;
        }

        private void NudRadius_ValueChanged(object sender, EventArgs e)
        {
            if ((this.nudSpeed.Value + this.nudRadius.Value) > 100)                                
                this.nudSpeed.Value = 100 - this.nudRadius.Value;                
        }
    }
}
