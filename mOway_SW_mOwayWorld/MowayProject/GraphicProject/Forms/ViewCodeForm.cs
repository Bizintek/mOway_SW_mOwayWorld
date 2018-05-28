using System;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;

namespace Moway.Project.GraphicProject.Forms
{
    /// <summary>
    /// Form to display of the source code of a project
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class ViewCodeForm : MowayForm
    {
        #region Attributes

        /// <summary>
        /// Code File
        /// </summary>
        private string asmFile;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="asmFile">Code File</param>
        public ViewCodeForm(string asmFile)
        {
            InitializeComponent();
            this.asmFile = asmFile;
        }

        #region Form Events

        /// <summary>
        /// Close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Load the code file in the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewCodeForm_Load(object sender, EventArgs e)
        {
            //The file is loaded in the window
            try
            {
                StreamReader reader = new StreamReader(this.asmFile);
                do
                {
                    string line = reader.ReadLine();
                    this.tbCode.Text += line + "\r\n";
                }
                while (!reader.EndOfStream);
                reader.Close();
            }
            catch
            {
                MowayMessageBox.Show("Can't load source code file.\r\nYou must generate the program code before clicking on Program mOway.", "Code Display", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion
    }
}
