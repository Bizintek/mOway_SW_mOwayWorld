using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Delegate for size events
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void SizeEventHandler(object sender, SizeEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class SizeEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Size
        /// </summary>
        private Size size;

        #endregion

        #region Properties

        /// <summary>
        /// Size
        /// </summary>
        public Size Size { get { return this.size; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="size">Size</param>
        public SizeEventArgs(Size size)
            : base()
        {
            this.size = size;
        }
    }
}
