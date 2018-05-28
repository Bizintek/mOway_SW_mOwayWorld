using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;

namespace Moway.Project.GraphicProject.Actions
{
    public partial class ActionForm : MowayForm
    {
        #region Attributes

        protected string helpTopic = "";

        #endregion

        public ActionForm()
        {
            InitializeComponent();
            this.helpProvider.HelpNamespace = Application.StartupPath + "\\help\\" + this.helpProvider.HelpNamespace;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            //The focus is loaded to launch the event and the numeric up down will be updated
            this.bSave.Focus(); 
            this.SaveSettings();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected virtual void AddVariable(Variable variable) { }

        protected virtual void LoadSettings() { }

        protected virtual void SaveSettings() { }

        private void ActionForm_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Variable variable in GraphManager.Project.Variables)
                    this.AddVariable(variable);
            }
            catch { }
            this.LoadSettings();
        }

        private void ActionForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case Keys.Enter:
                    if (this.bSave.Enabled)
                    {
                        this.SaveSettings();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    break;
            }
        }

        private void LlHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help.ShowHelp(this, this.helpProvider.HelpNamespace, HelpNavigator.Topic, this.helpTopic + ".html");
        }
    }
}
