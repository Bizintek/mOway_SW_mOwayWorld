using System;
using System.Windows.Forms;

using SdlDotNet.Graphics;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public delegate void GraphDrawingEventHandler(object sender, GraphDrawingEventArgs e);

    public class GraphDrawingEventArgs
    {
        #region Atributos

        private Surface surface;
        private Cursor cursor;
        private ContextMenu contextMenu;

        #endregion

        #region Propiedades

        public Surface Surface { get { return this.surface; } }
        public Cursor Cursor { get { return this.cursor; } }
        public ContextMenu ContextMenu { get { return this.contextMenu; } }

        #endregion

        public GraphDrawingEventArgs(Cursor cursor)
        {
            this.cursor = cursor;
        }

        public GraphDrawingEventArgs(Surface surface)
        {
            this.surface= surface;
        }

        public GraphDrawingEventArgs(ContextMenu contextMenu)
        {
            this.contextMenu = contextMenu;
        }
    }
}
