using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Simulator
{
    /// <summary>
    /// Simulator module Panel; Where to inherit when making a panel
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class ModulePanel : UserControl
    {
        #region Constants

        /// <summary>
        /// Width of the panel
        /// </summary>
        private const int PANEL_WIDTH = 220;
        /// <summary>
        /// Height of the panel
        /// </summary>
        private const int PANEL_HEIGHT = 410;

        #endregion

        #region Attributes

        /// <summary>
        /// Model of the mOway simulated
        /// </summary>
        protected MowayModel mowayModel;

        #endregion

        #region Properties

        /// <summary>
        /// Panel Size
        /// </summary>
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = new Size(PANEL_WIDTH, PANEL_HEIGHT); }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public ModulePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="mowayModel">Model of the mOway simulated</param>
        internal ModulePanel(MowayModel mowayModel)
        {
            InitializeComponent();
            this.mowayModel = mowayModel;
        }
    }
}
