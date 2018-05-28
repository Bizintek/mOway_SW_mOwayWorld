using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// TextBox customized for mOwayWorld
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayTextBox : TextBox
    {
        /// <summary>
        /// Builder
        /// </summary>
        public MowayTextBox()
        {
            InitializeComponent();
        }

        #region Redefining methods

        /// <summary>
        /// Paints the edges of the control
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF)
            {
                Graphics graph = this.CreateGraphics();
                graph.DrawRectangle(new Pen(new SolidBrush(MowayColors.Border), 2), base.ClientRectangle);
            }
        }

        #endregion
    }
}
