using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Delegate for the events of a group panel
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void GroupPanelEventHandler(object sender, GroupPanelEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class GroupPanelEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Group panel
        /// </summary>
        private Panel groupPanel;
        /// <summary>
        /// Location on the group panel screen
        /// </summary>
        private Point screenLocation;

        #endregion

        #region Properties

        /// <summary>
        /// Group panel
        /// </summary>
        public Panel GroupPanel { get { return this.groupPanel; } }
        /// <summary>
        /// Location on the group panel screen
        /// </summary>
        public Point ScreenLocation { get { return this.screenLocation; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="groupPanel">Group panel</param>
        public GroupPanelEventArgs(Panel groupPanel)
            : base()
        {
            this.groupPanel = groupPanel;
        }

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="groupPanel">Group panel</param>
        /// <param name="screenLocation">Location on the group panel screen</param>
        public GroupPanelEventArgs(Panel groupPanel, Point screenLocation)
            : base()
        {
            this.groupPanel = groupPanel;
            this.screenLocation = screenLocation;
        }
    }
}
