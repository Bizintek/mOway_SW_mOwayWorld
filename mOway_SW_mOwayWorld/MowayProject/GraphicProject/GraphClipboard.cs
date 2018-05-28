using System;
using System.Collections.Generic;

using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject
{
    public class GraphClipboard
    {
        #region Attributes

        private List<GraphElement> elements = null;

        #endregion

        #region Properties

        public bool IsEmpty
        {
            get
            {
                if (this.elements == null)
                    return true;
                else
                    return false;
            }
        }

        #endregion

        #region Events

        public event EventHandler ClipboardChanged;

        #endregion

        public GraphClipboard() { }

        #region Public methods

        public void SetElements(List<GraphElement> elements)
        {
            this.elements = elements;
            if (this.ClipboardChanged != null)
                this.ClipboardChanged(this, new EventArgs());
        }

        public List<GraphElement> GetElements()
        {
            if (this.elements == null)
                throw new ClipboardException("Clipboard is empty");
            return this.elements;
        }

        public void Clear()
        {
            this.elements = null;
            if (this.ClipboardChanged != null)
                this.ClipboardChanged(this, new EventArgs());
        }

        #endregion
    }
}
