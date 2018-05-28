using System;
using System.IO;
using System.Windows.Forms;

using Moway.Project;
using Moway.Template;

namespace Moway.Forms
{
    /// <summary>
    /// Form for the creation of a new project
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class NewProjectForm : MowayForm
    {
        #region Properties

        /// <summary>
        /// Name of the new project
        /// </summary>
        public string ProjectName { get { return this.tbName.Text; } }
        /// <summary>
        /// Path of the new project
        /// </summary>
        public string ProjectPath { get { return this.tbLocation.Text; } }
        /// <summary>
        /// Type of the new project
        /// </summary>
        public ProjectType ProjectType
        {
            get
            {
                if (this.rbActivity.Checked)
                    return ProjectType.Graphical;
                else if (this.rbProgC.Checked)
                    return ProjectType.Code_C;
                else
                    return ProjectType.Code_Asm;
            }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public NewProjectForm():
            base()
        {
            InitializeComponent();

            //The initial directory is set where to save the file
            this.folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;
            this.tbLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        #region Form Events

        /// <summary>
        /// Creating a new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCreate_Click(object sender, EventArgs e)
        {
            //It is valid that the name of the project is not empty
            if (this.tbName.Text == "")
            {
                MowayMessageBox.Show(NewProjectMessages.MISSING_PATH, NewProjectMessages.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Project Path validated
            if (this.tbLocation.Text == "")
            {
                MowayMessageBox.Show(NewProjectMessages.MISSING_NAME, NewProjectMessages.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //It checks if the project already exists, it is consulted and the old one is deleted if yes
            if (File.Exists(this.tbLocation.Text + "\\" + this.tbName.Text + ".mpj"))
                if (DialogResult.No == MowayMessageBox.Show(NewProjectMessages.PROJECT_EXISTS_1 + " " + this.tbName.Text + NewProjectMessages.PROJECT_EXISTS_2 + "\r\n" + NewProjectMessages.REPLACE_PROJECT, NewProjectMessages.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return;
                else
                {
                    File.Delete(this.tbLocation.Text + "\\" + this.tbName.Text + ".mpj");
                    Directory.Delete(this.tbLocation.Text + "\\" + this.tbName.Text + "-files", true);
                }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Cancellation of the creation of a new project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Modifying the path of the project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BBrowser_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
                this.tbLocation.Text = folderBrowserDialog.SelectedPath;
        }

        #endregion
    }
}
