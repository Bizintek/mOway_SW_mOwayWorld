using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Actions.TransmissionRf
{
    public partial class TransmissionRfPanel : ActionPanel
    {
        #region Attributes

        private TransmissionRfAction action;
        private MowayComboBox[] cbVariables = new MowayComboBox[8];
        private MowayNumericUpDown[] nudValues = new MowayNumericUpDown[8];

        #endregion

        public override void AddVariable(Variable variable)
        {
            this.cbVariable0.Items.Add(variable.Name);
            this.cbVariable1.Items.Add(variable.Name);
            this.cbVariable2.Items.Add(variable.Name);
            this.cbVariable3.Items.Add(variable.Name);
            this.cbVariable4.Items.Add(variable.Name);
            this.cbVariable5.Items.Add(variable.Name);
            this.cbVariable6.Items.Add(variable.Name);
            this.cbVariable7.Items.Add(variable.Name);
        }

        protected override void LoadSettings()
        {
            this.nudDirection.Value = this.action.Direction;
            for (int i = 0; i < 8; i++)
            {
                if (this.action.DataVariable[i] == null)
                    this.cbVariables[i].SelectedIndex = 0;
                else
                    this.cbVariables[i].SelectedItem = this.action.DataVariable[i].Name;
                this.nudValues[i].Value = this.action.DataValue[i];
            }
        }

        protected override void SaveSettings()
        {
            int direction = (int)this.nudDirection.Value;
            Variable[] dataVariable = { null, null, null, null, null, null, null, null };
            int[] dataValue = { 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 8; i++)
                if (this.cbVariables[i].SelectedIndex != 0)
                    dataVariable[i] = GraphManager.GetVariable(this.cbVariables[i].SelectedItem.ToString());
                else
                    dataValue[i] = (int)this.nudValues[i].Value;
            this.action.UpdateSettings(direction, dataVariable, dataValue);
        }

        public TransmissionRfPanel(TransmissionRfAction action)
        {
            InitializeComponent();
            this.action = action;
            this.cbVariables = new MowayComboBox[8] { this.cbVariable0, this.cbVariable1, this.cbVariable2, this.cbVariable3, this.cbVariable4, this.cbVariable5, this.cbVariable6, this.cbVariable7 };
            this.nudValues = new MowayNumericUpDown[8] { this.nudValue0, this.nudValue1, this.nudValue2, this.nudValue3, this.nudValue4, this.nudValue5, this.nudValue6, this.nudValue7 };
        }

        private void CbVariable0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable0.SelectedIndex == 0)
                this.nudValue0.Enabled = true;
            else
                this.nudValue0.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable1.SelectedIndex == 0)
                this.nudValue1.Enabled = true;
            else
                this.nudValue1.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable2.SelectedIndex == 0)
                this.nudValue2.Enabled = true;
            else
                this.nudValue2.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable3.SelectedIndex == 0)
                this.nudValue3.Enabled = true;
            else
                this.nudValue3.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable4.SelectedIndex == 0)
                this.nudValue4.Enabled = true;
            else
                this.nudValue4.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable5.SelectedIndex == 0)
                this.nudValue5.Enabled = true;
            else
                this.nudValue5.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable6.SelectedIndex == 0)
                this.nudValue6.Enabled = true;
            else
                this.nudValue6.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void CbVariable7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbVariable7.SelectedIndex == 0)
                this.nudValue7.Enabled = true;
            else
                this.nudValue7.Enabled = false;
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudValue_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
