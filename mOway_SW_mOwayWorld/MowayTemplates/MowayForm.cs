using System;
using System.Windows.Forms;

namespace Moway.Template
{
    /// <summary>
    /// Form for mOway World with the main characteristics
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayForm : Form
    {
        public MowayForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when a key is pressed.
        /// By default, with the ' escape ' key, the form is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void MowayForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
