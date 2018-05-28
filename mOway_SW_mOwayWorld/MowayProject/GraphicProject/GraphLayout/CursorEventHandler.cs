using System;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.GraphLayout
{
    public delegate void CursorEventHandler(object sender, CursorEventArgs e);

    public class CursorEventArgs : EventArgs
    {
        #region Attributes

        private Cursor cursor;

        #endregion

        #region Properties

        public Cursor Cursor { get { return this.cursor; } }

        #endregion

        public CursorEventArgs(Cursor cursor)
        {
            this.cursor = cursor;
        }
    }
}
