using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;
using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Actions.TransmissionRf
{
    public partial class TransmissionRfForm : ActionForm
    {
        #region Attributes

        private TransmissionRfAction action;
        private MowayComboBox[] cbVariables = new MowayComboBox[8];
        private MowayNumericUpDown[] nudValues = new MowayNumericUpDown[8];

        #endregion

        public TransmissionRfForm(TransmissionRfAction action)
        {
            InitializeComponent();
            this.helpTopic = TransmissionRf.HelpTopic;
this.action = action;
            this.cbVariables = new MowayComboBox[8] { this.cbVariable0, this.cbVariable1, this.cbVariable2, this.cbVariable3, this.cbVariable4, this.cbVariable5, this.cbVariable6, this.cbVariable7 };
            this.nudValues = new MowayNumericUpDown[8] { this.nudValue0, this.nudValue1, this.nudValue2, this.nudValue3, this.nudValue4, this.nudValue5, this.nudValue6, this.nudValue7 };
        }

        protected override void AddVariable(Variable variable)
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
        
        private void CbVariable0_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable0.SelectedIndex)
            {
                case 0:
                    this.nudValue0.Enabled = true;
                    break;
                case 1:
                    this.nudValue0.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable0.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable0.Undo();
                    break;
                default:
                    this.nudValue0.Enabled = false;
                    break;
            }
        }

        private void CbVariable1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable1.SelectedIndex)
            {
                case 0:
                    this.nudValue1.Enabled = true;
                    break;
                case 1:
                    this.nudValue1.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable1.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable1.Undo();
                    break;
                default:
                    this.nudValue1.Enabled = false;
                    break;
            }
        }

        private void CbVariable2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable2.SelectedIndex)
            {
                case 0:
                    this.nudValue2.Enabled = true;
                    break;
                case 1:
                    this.nudValue2.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable2.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable2.Undo();
                    break;
                default:
                    this.nudValue2.Enabled = false;
                    break;
            }
        }

        private void CbVariable3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable3.SelectedIndex)
            {
                case 0:
                    this.nudValue3.Enabled = true;
                    break;
                case 1:
                    this.nudValue3.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable3.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable3.Undo();
                    break;
                default:
                    this.nudValue3.Enabled = false;
                    break;
            }
        }

        private void CbVariable4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable4.SelectedIndex)
            {
                case 0:
                    this.nudValue4.Enabled = true;
                    break;
                case 1:
                    this.nudValue4.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable4.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable4.Undo();
                    break;
                default:
                    this.nudValue4.Enabled = false;
                    break;
            }
        }

        private void CbVariable5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable5.SelectedIndex)
            {
                case 0:
                    this.nudValue5.Enabled = true;
                    break;
                case 1:
                    this.nudValue5.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable5.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable5.Undo();
                    break;
                default:
                    this.nudValue5.Enabled = false;
                    break;
            }
        }

        private void CbVariable6_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable6.SelectedIndex)
            {
                case 0:
                    this.nudValue6.Enabled = true;
                    break;
                case 1:
                    this.nudValue6.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable6.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable6.Undo();
                    break;
                default:
                    this.nudValue6.Enabled = false;
                    break;
            }
        }

        private void CbVariable7_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbVariable7.SelectedIndex)
            {
                case 0:
                    this.nudValue7.Enabled = true;
                    break;
                case 1:
                    this.nudValue7.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbVariable7.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        this.cbVariable7.Undo();
                    break;
                default:
                    this.nudValue7.Enabled = false;
                    break;
            }
        }

        private void LData7_Click(object sender, EventArgs e)
        {

        }

        private void NudValue7_Load(object sender, EventArgs e)
        {

        }

        private void LData6_Click(object sender, EventArgs e)
        {

        }

        private void NudValue6_Load(object sender, EventArgs e)
        {

        }

        private void LData5_Click(object sender, EventArgs e)
        {

        }

        private void NudValue5_Load(object sender, EventArgs e)
        {

        }

        private void LData4_Click(object sender, EventArgs e)
        {

        }

        private void NudValue4_Load(object sender, EventArgs e)
        {

        }

        private void LData3_Click(object sender, EventArgs e)
        {

        }

        private void LDirection_Click(object sender, EventArgs e)
        {

        }

        private void NudValue3_Load(object sender, EventArgs e)
        {

        }

        private void LData2_Click(object sender, EventArgs e)
        {

        }

        private void NudValue2_Load(object sender, EventArgs e)
        {

        }

        private void LData0_Click(object sender, EventArgs e)
        {

        }

        private void NudValue0_Load(object sender, EventArgs e)
        {

        }

        private void NudDirection_Load(object sender, EventArgs e)
        {

        }

        private void NudValue1_Load(object sender, EventArgs e)
        {

        }

        private void LData1_Click(object sender, EventArgs e)
        {

        }
    }
}
