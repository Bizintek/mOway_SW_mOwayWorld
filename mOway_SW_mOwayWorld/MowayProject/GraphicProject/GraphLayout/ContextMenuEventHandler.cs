using System;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public delegate void ContextMenuEventHandler(object sender, ContextMenuEventArgs e);

    public class ContextMenuEventArgs : EventArgs
    {
        #region Attributes

        private ContextMenu menu;

        #endregion

        #region Properties

        public ContextMenu Menu { get { return this.menu; } }

        #endregion

        public ContextMenuEventArgs(ContextMenu menu)
        {
            this.menu = menu;
        }
    }
}
