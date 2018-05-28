using System;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.Pause
{
    /// <summary>
    /// Setup form for "Pause" actions
    /// </summary>
    public partial class PauseForm : ActionForm
    {
        #region Attributes

        /// <summary>
        /// Action that the form represents
        /// </summary>
        private PauseAction action;

        #endregion

        /// <summary>
        /// Configuration Form Builder
        /// </summary>
        /// <param name="action">Action that the form represents</param>
        public PauseForm(PauseAction action)
        {
            InitializeComponent();
            this.helpTopic = Pause.HelpTopic;
            this.action = action;
            foreach (Variable variable in GraphManager.Project.Variables)
                this.AddVariable(variable);
        }

        #region Private methods

        protected override void LoadSettings()
        {
            if (this.action.TimeVariable == null)
                this.cbTime.SelectedIndex = 0;
            else
                this.cbTime.SelectedItem = this.action.TimeVariable.Name;
            this.nudTime.Value = this.action.TimeValue;
        }

        protected override  void AddVariable(Variable variable)
        {
            this.cbTime.Items.Add(variable.Name);
        }

        protected override void  SaveSettings()
        {
            Variable timeVariable = null;
            decimal timeValue = 1;
            if (this.cbTime.SelectedIndex != 0)
                timeVariable = GraphManager.GetVariable(this.cbTime.SelectedItem.ToString());
            else
                timeValue = this.nudTime.Value;
            this.action.UpdateSettings(timeVariable, timeValue);
        }

        #endregion

        #region Methods of controlling the form

        /// <summary>
        /// Occurs when the time ComboBox is changed from selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbTime.SelectedIndex)
            {
                case 0:
                    //Selected "Constant Value"
                    this.nudTime.Enabled = true;
                    break;
                case 1:
                    //Selected "Create New variable"
                    this.nudTime.Enabled = false;
                    NewVariableForm newVariableForm = new NewVariableForm();
                    if (DialogResult.OK == newVariableForm.ShowDialog())
                    {
                        //The new variable is created, added to this form and selected with the ComboBox
                        GraphManager.AddVariable(newVariableForm.VariableCreated);
                        this.AddVariable(newVariableForm.VariableCreated);
                        this.cbTime.SelectedItem = newVariableForm.VariableCreated.Name;
                    }
                    else
                        //If the variable has not been created an Undo of the control is produced to replace the previous value
                        this.cbTime.Undo();
                    break;
                default:
                    //Selected a variable "xxxx"
                    this.nudTime.Enabled = false;
                    break;
            }
        }

        #endregion

        private void NudTime_ValueChanged(object sender, EventArgs e)
        {
            if ((this.nudTime.Value % 0.05M) != 0)
                this.nudTime.Value = (int)(this.nudTime.Value / 0.05M) * 0.05M;
        }

    }
}
