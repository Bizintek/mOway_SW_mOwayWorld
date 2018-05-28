using System;
using System.Windows.Forms;

namespace Moway.Template
{
    /// <summary>
    /// Base for the creation of boxes for MOway World
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayBox : UserControl
    {
        #region Properties

        /// <summary>
        /// Control title
        /// </summary>
        public string Tittle { set { this.lTittle.Text = value; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayBox()
        {
            InitializeComponent();
        }
    }
}
