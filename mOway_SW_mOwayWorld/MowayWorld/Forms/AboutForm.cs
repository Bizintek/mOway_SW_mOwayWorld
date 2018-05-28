using System;
using System.Windows.Forms;

using Moway.Template;

namespace Moway.Forms
{
    /// <summary>
    /// Window about
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class AboutForm : MowayForm
    {
        /// <summary>
        /// Builder
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        #region Form Events

        /// <summary>
        /// Press Close button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Click on the License link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\LICENSE.txt");
            }
            catch { }
        }

        /// <summary>
        /// Click on the Web link
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.moway-robot.com/index.php?lang=en");
            }
            catch { }
        }

        #endregion
    }
}
