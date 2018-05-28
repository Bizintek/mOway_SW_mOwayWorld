using System;

using Moway.Template.Controls;

namespace Moway.Project
{
    /// <summary>
    /// Delegate for events with shared dashboards for a project
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public delegate void SharePanelEventHandler(object sender, SharePanelEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class SharePanelEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Shared Box Panel
        /// </summary>
        private SharePanel panel;

        #endregion

        #region Properties

        /// <summary>
        /// Shared Box Panel
        /// </summary>
        public SharePanel Panel { get { return this.panel; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="panel">Shared Box Panel</param>
        public SharePanelEventArgs(SharePanel panel)
        {
            this.panel = panel;
        }
    }
}
