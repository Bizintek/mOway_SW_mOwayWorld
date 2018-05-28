using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;

namespace Moway.Project.GraphicProject.Forms
{
    public partial class EditVariableForm : MowayForm
    {
        #region Attributes

        private Variable variable;

        #endregion

        #region Properties

        public Variable VariableUpdated { get { return this.variable; } }

        #endregion

        public EditVariableForm(Variable variable)
        {
            InitializeComponent();

            this.variable = variable;
            this.tbVariable.Text = variable.Name;
            this.nudValue.Value = variable.InitValue;

            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
            {
                this.Font = new System.Drawing.Font("Sans", 8.25F, System.Drawing.FontStyle.Regular);
                this.lFormDescription.Location = new Point(22, 15);
                this.lFormDescription.Size = new Size(330, 30);
                this.pFormSeparator.Location = new Point(7, 50);
                this.pFormSeparator.Size = new Size(360, 3);
                this.lVariable.Location = new Point(75, 70);
                this.tbVariable.Location = new Point(75, 93);
                this.bUpdate.Location = new Point(70, 140);
                this.bUpdate.Size = new Size(85, 27);
                this.bCancel.Location = new Point(120, 140);
                this.bCancel.Size = new Size(85, 27);
            }
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            if (!Variable.Validate(this.tbVariable.Text))
                MowayMessageBox.Show(VariablesMessages.NAME_ERROR + "\r\n" + VariablesMessages.NAME_CONDITIONS, VariablesMessages.EDIT_VARIABLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Variable.IsKeyword(this.tbVariable.Text))
                MowayMessageBox.Show(VariablesMessages.NAME_KEYWORD, VariablesMessages.EDIT_VARIABLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if ((this.variable.Name != this.tbVariable.Text) && (GraphManager.ConstainVariable(this.tbVariable.Text)))
                MowayMessageBox.Show(VariablesMessages.VARIABLE_EXISTS, VariablesMessages.EDIT_VARIABLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                GraphManager.UpdateVariable(this.variable, this.tbVariable.Text, (byte)this.nudValue.Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
