using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Vertical Separator for toolbar
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class ToolBarSeparator : Panel, IToolBarItem
    {
        #region Constants

        private const int SEPARATOR_WIDTH = 1;

        #endregion

        #region Properties

        /// <summary>
        /// Overwrites the Size method so that it is always 1px wide
        /// </summary>
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = new Size(SEPARATOR_WIDTH, value.Height); }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public ToolBarSeparator()
        {
            InitializeComponent();
        }
    }
}
