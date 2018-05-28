using System;
using System.Drawing;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Delegate for the events of a group panel
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PointEventHandler(object sender, PointEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>27.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class PointEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Point of the position
        /// </summary>
        private Point point;

        #endregion

        #region Properties

        /// <summary>
        /// Point of the position
        /// </summary>
        public Point Point { get { return this.point; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="point">Point of the position</param>
        public PointEventArgs(Point point)
        {
            this.point = point;
        }
    }
}
