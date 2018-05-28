using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Actions.ReceptionRf
{
    public partial class ReceptionRfPanel : ActionPanel
    {
        #region Attributes

        private ReceptionRfAction action;
        private MowayComboBox[] cbVariables = new MowayComboBox[8];

        #endregion

        public ReceptionRfPanel(ReceptionRfAction action)
        {
            InitializeComponent();
            this.action = action;
            this.cbVariables = new MowayComboBox[8] { this.cbVariable0, this.cbVariable1, this.cbVariable2, this.cbVariable3, this.cbVariable4, this.cbVariable5, this.cbVariable6, this.cbVariable7 };
        }

        public override void AddVariable(Variable variable)
        {
            this.cbDirection.Items.Add(variable.Name);
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
            if (this.action.Direction == null)
                this.cbDirection.SelectedIndex = 0;
            else
                this.cbDirection.SelectedItem = this.action.Direction.Name;
            for (int i = 0; i < 8; i++)
                if (this.action.Data[i] == null)
                    this.cbVariables[i].SelectedIndex = 0;
                else
                    this.cbVariables[i].SelectedItem = this.action.Data[i].Name;
        }

        protected override void SaveSettings()
        {
            Variable direction = null;
            if (this.cbDirection.SelectedIndex != 0)
                direction = GraphManager.GetVariable(this.cbDirection.SelectedItem.ToString());
            Variable[] dataVariables = { null, null, null, null, null, null, null, null };
            for (int i = 0; i < 8; i++)
            {
                if (this.cbVariables[i].SelectedIndex != 0)
                    dataVariables[i] = GraphManager.GetVariable(this.cbVariables[i].SelectedItem.ToString());
            }
            this.action.UpdateSettings(direction, dataVariables);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
