using System;
using System.Collections;

namespace Moway.Project.GraphicProject.DiagramLayout.Elements
{
    public class End : Element
    {
        #region Atributos

        private ArrayList previous = new ArrayList();

        #endregion

        #region Propiedades

        public ArrayList Previous { get { return (ArrayList)this.previous.Clone(); } }
        public bool HasPrevious { get { return (this.previous.Count == 0) ? false : true; } }
        public Element Next { get { throw new DiagramException("Inaccessible property"); } }
        public bool HasNext { get { throw new DiagramException("Inaccessible property"); } }

        #endregion

        public End()
        {
        }

        public bool IsCorrect()
        {
            if (this.previous.Count > 0)
                return true;
            return false;
        }
    }
}
