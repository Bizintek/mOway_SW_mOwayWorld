using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Panel with a 2px edge around
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class PanelBorder : Panel
    {
        /// <summary>
        /// Builder
        /// </summary>
        public PanelBorder()
        {
            InitializeComponent();
        }

        #region Redefining methods

        /// <summary>
        /// Paints the edge to the panel
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(MowayColors.Border), 4), e.ClipRectangle);
        }

        #endregion
    }
}
