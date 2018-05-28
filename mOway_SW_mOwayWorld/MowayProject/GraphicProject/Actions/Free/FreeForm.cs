using System;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.Free
{
    public partial class FreeForm : ActionForm
    {
        #region Attributes

        private FreeAction action;

        #endregion

        public FreeForm(FreeAction action)
        {
            InitializeComponent();
            this.helpTopic = Free.HelpTopic;

            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                this.Font = new System.Drawing.Font("Sans", 8.25F, System.Drawing.FontStyle.Regular);

            //The action is saved in order to save the changes
            this.action = action;
        }

        #region Private methods

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

        protected override void AddVariable(Variable variable)
        {
            this.cbLeftSpeed.Items.Add(variable.Name);
            this.cbRightSpeed.Items.Add(variable.Name);
            this.cbTime.Items.Add(variable.Name);
            this.cbDistance.Items.Add(variable.Name);
        }

        #endregion

        #region Graphic events on the screen

        private void CbLeftSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbLeftSpeed.SelectedIndex)
            {
                case 0:
                    this.nudLeftSpeed.Enabled = true;
                    break;
                case 1:
                    this.nudLeftSpeed.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbLeftSpeed.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbLeftSpeed.Undo();
                    break;
                default:
                    this.nudLeftSpeed.Enabled = false;
                    break;
            }
        }

        private void CbRightSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbRightSpeed.SelectedIndex)
            {
                case 0:
                    this.nudRightSpeed.Enabled = true;
                    break;
                case 1:
                    this.nudRightSpeed.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbRightSpeed.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbRightSpeed.Undo();
                    break;
                default:
                    this.nudRightSpeed.Enabled = false;
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
    }
}
