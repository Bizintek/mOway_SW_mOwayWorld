using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;

namespace Moway.Project.GraphicProject.Forms
{
    internal partial class ProjectPropertiesForm : MowayForm
    {
        #region Attributes

        private GraphProject project;

        #endregion

        public ProjectPropertiesForm(GraphProject project)
        {
            InitializeComponent();
            this.project = project;
            this.tbProjectName.Text = this.project.Name;
            this.tbOwner.Text = this.project.Owner;
            this.tbComments.Text = this.project.Comments;
            if (this.project.Language == Language.C)
                this.rbC.Checked = true;
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            Language language = Language.Assembler;
            if (this.rbC.Checked)
                language = Language.C;
            this.project.UpdateSettings(this.tbOwner.Text, this.tbComments.Text, language);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
