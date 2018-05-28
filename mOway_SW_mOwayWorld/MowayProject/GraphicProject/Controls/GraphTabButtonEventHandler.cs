using System;
using System.Windows.Forms;

using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Delegate for graphical TabButton events
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GraphTabButtonEventHandler(object sender, GraphTabButtonEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class GraphTabButtonEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Button
        /// </summary>
        private GraphTabButton button;

        #endregion

        #region Properties

        /// <summary>
        /// Button
        /// </summary>
        public GraphTabButton Button { get { return this.button; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="button">Button</param>
        public GraphTabButtonEventArgs(GraphTabButton button)
            : base()
        {
            this.button = button;
        }
    }
}
