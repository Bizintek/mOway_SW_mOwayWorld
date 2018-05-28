using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.Actions.Start;

namespace Moway.Project.GraphicProject.Forms
{
    public partial class EditFunctionForm : MowayForm
    {
        #region Attributes

        private Diagram diagram = null;

        #endregion

        #region Properties

        public Diagram DiagramUpdated { get { return this.diagram; } }

        #endregion

        public EditFunctionForm(Diagram diagram)
        {
            InitializeComponent();
            this.diagram = diagram;
            this.tbName.Text = this.diagram.Name;
            this.tbDescription.Text = this.diagram.Description;
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
            {
                this.Font = new System.Drawing.Font("Sans", 8.25F, System.Drawing.FontStyle.Regular);
                this.Size = new Size(480, 225);
                this.lFormDescription.Location = new Point(22, 15);
                this.lFormDescription.Size = new Size(430, 45);
                this.pFormSeparator.Location = new Point(7, 65);
                this.pFormSeparator.Size = new Size(450, 3);
                this.lName.Location = new Point(75, 85);
                this.tbName.Location = new Point(75, 108);
                this.bUpdate.Location = new Point(120, 155);
                this.bUpdate.Size = new Size(85, 27);
                this.bCancel.Location = new Point(270, 155);
                this.bCancel.Size = new Size(85, 27);
            }
        }

        private void BCreate_Click(object sender, EventArgs e)
        {
            //***ADDED: Added start-by-number check
            string strTemp = this.tbName.Text.Substring(0, 1);
            if (System.Text.RegularExpressions.Regex.IsMatch(strTemp, @"^([0-9\d_])$"))
                MowayMessageBox.Show(FunctionsMessages.NAME_ERROR + "\r\n" + FunctionsMessages.NAME_CONDITIONS, FunctionsMessages.NEW_FUNCTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Diagram.Validate(this.tbName.Text))
                MowayMessageBox.Show(FunctionsMessages.NAME_ERROR + "\r\n" + FunctionsMessages.NAME_CONDITIONS, FunctionsMessages.NEW_FUNCTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Diagram.IsKeyword(this.tbName.Text))
                MowayMessageBox.Show(FunctionsMessages.NAME_KEYWORD, FunctionsMessages.EDIT_FUNCTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if ((this.diagram.Name != this.tbName.Text) && (GraphManager.ConstainFunction(this.tbName.Text)))
                MowayMessageBox.Show(FunctionsMessages.FUNCTION_EXISTS, FunctionsMessages.NEW_FUNCTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                GraphManager.Project.UpdateFunction(this.diagram, this.tbName.Text, this.tbDescription.Text);
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
