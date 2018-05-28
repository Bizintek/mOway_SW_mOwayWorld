using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.PlaySound
{
    public partial class PlaySoundForm : ActionForm
    {
        // private decimal[] notes = { 8372.018M, 8869.844M, 9397.273M, 9956.063M, 10548.082M, 11175.303M, 11839.822M, 12543.854M, 13289.75M, 14080M, 14917.24M, 15804.266M };       
        private decimal[] notes = { 520M, 554M, 588M, 622M, 660M, 698M, 740M, 784M, 830M, 880M, 932M, 988M, 1046M, 1108M, 1176M, 1244M, 1320M, 1396M, 1480M, 1568M };       

        #region Attributes

        private PlaySoundAction action;

        #endregion

        public PlaySoundForm(PlaySoundAction action)
        {
            InitializeComponent();
            this.helpTopic = PlaySound.HelpTopic;

            //The action is saved in order to save the changes
            this.action = action;
        }

        #region Private methods

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


        protected override void AddVariable(Variable variable)
        {
            this.cbFrequency.Items.Add(variable.Name);
            this.cbTime.Items.Add(variable.Name);
        }

        #endregion

        #region Graphic events on the screen
        
        private void CbFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbFrequency.SelectedIndex)
            {
                case 0:
                    this.nudFrequency.Enabled = true;
                    break;
                case 1:
                    this.nudFrequency.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbFrequency.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbFrequency.Undo();
                    break;
                default:
                    this.nudFrequency.Enabled = false;
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

        #endregion

        #region Piano keys
        private void MowayButton1_Click(object sender, EventArgs e)
        {
            // Do
            this.nudFrequency.Value = notes[0];
        }

        private void MowayButton13_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[1];
        }        

        private void MowayButton2_Click(object sender, EventArgs e)
        {
            // Re
            this.nudFrequency.Value = notes[2];
        }

        private void MowayButton17_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[3];
        }

        private void MowayButton3_Click(object sender, EventArgs e)
        {
            // Mi
            this.nudFrequency.Value = notes[4];
        }

        private void MowayButton4_Click(object sender, EventArgs e)
        {
            // Fa
            this.nudFrequency.Value = notes[5];
        }        

        private void MowayButton15_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[6];
        }

        private void MowayButton5_Click(object sender, EventArgs e)
        {
            // Sol
            this.nudFrequency.Value = notes[7];
        }

        private void MowayButton14_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[8];
        }

        private void MowayButton6_Click(object sender, EventArgs e)
        {
            // La
            this.nudFrequency.Value = notes[9];
        }

        private void MowayButton20_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[10];
        }

        private void MowayButton7_Click(object sender, EventArgs e)
        {
            // Si
            this.nudFrequency.Value = notes[11];
        }

        private void MowayButton8_Click(object sender, EventArgs e)
        {
            // Do
            this.nudFrequency.Value = notes[12];
        }

        private void MowayButton19_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[13];
        }

        private void MowayButton9_Click(object sender, EventArgs e)
        {
            // Re
            this.nudFrequency.Value = notes[14];
        }

        private void MowayButton18_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[15];
        }

        private void MowayButton10_Click(object sender, EventArgs e)
        {
            // Mi
            this.nudFrequency.Value = notes[16];
        }

        private void MowayButton11_Click(object sender, EventArgs e)
        {
            // Fa
            this.nudFrequency.Value = notes[17];
        }

        private void MowayButton16_Click(object sender, EventArgs e)
        {
            this.nudFrequency.Value = notes[18];
        }

        private void MowayButton12_Click(object sender, EventArgs e)
        {
            // Sol
            this.nudFrequency.Value = notes[19];
        }
        #endregion
    }
}
