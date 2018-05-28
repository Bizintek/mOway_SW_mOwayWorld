using System;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public delegate void CursorEventHandler(object sender, CursorEventArgs e);

    public class CursorEventArgs: EventArgs
    {
        #region Atributos

        private Cursor cursor;

        #endregion

        #region Propiedades

        public Cursor Cursor { get { return this.cursor; } }

        #endregion

        public CursorEventArgs(Cursor cursor)
        {
            this.cursor = cursor;
        }
    }
}
