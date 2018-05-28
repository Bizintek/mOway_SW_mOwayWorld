using System;
using System.Drawing;

using Moway.Project.GraphicProject.Actions;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Delegate for the tool events
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ToolEventHandler(object sender, ToolEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class ToolEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Tools
        /// </summary>
        private Tool tool;
        /// <summary>
        /// Group panel space(if any)
        /// </summary>
        private Rectangle rectangle = new Rectangle(0, 0, 0, 0);

        #endregion

        #region Properties

        /// <summary>
        /// Tool
        /// </summary>
        public Tool Tool { get { return this.tool; } }
        /// <summary>
        /// Group panel space(if any)
        /// </summary>
        public Rectangle Rectangle { get { return this.rectangle; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="tool">Tool</param>
        public ToolEventArgs(Tool tool)
            : base()
        {
            this.tool = tool;
        }

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="tool">Tool</param>
        /// <param name="rectangle">Group panel space</param>
        public ToolEventArgs(Tool tool, Rectangle rectangle)
            : base()
        {
            this.tool = tool;
            this.rectangle = rectangle;
        }
    }
}
