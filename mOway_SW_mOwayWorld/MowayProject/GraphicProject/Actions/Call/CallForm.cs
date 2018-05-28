using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;
using Moway.Project.GraphicProject.DiagramLayout;

namespace Moway.Project.GraphicProject.Actions.Call
{
    public partial class CallForm : ActionForm
    {
        #region Attributes

        private CallAction action;
        private SortedList<string, Diagram> diagrams = new SortedList<string, Diagram>();

        #endregion

        public CallForm(CallAction action)
        {
            InitializeComponent();
            this.helpTopic = Call.HelpTopic;
            this.action = action;
            foreach (Diagram function in GraphManager.GetFunctions())
            {
                this.diagrams.Add(function.Name, function);
                this.cbAsignVariable.Items.Add(function.Name);
            }
        }

        protected override void LoadSettings()
        {
            if (this.action.Function != null)
                this.cbAsignVariable.SelectedItem = this.action.Function.Name;
        }

        protected override void SaveSettings()
        {
            this.action.UpdateSettings(this.diagrams[this.cbAsignVariable.SelectedItem.ToString()]);
        }

        private void CbAsignVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbAsignVariable.SelectedIndex != -1)
            {
                this.bSave.Enabled = true;
                this.label1.Text = this.diagrams[this.cbAsignVariable.SelectedItem.ToString()].Description;
            }
        }
    }
}
