using System;
using System.Collections.Generic;

namespace Moway.Project.GraphicProject.DiagramLayout.Elements
{
    /// <summary>
    /// Represents a startup-type action
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class Start : Element
    {
        #region Properties

        /// <summary>
        /// List of previous items (inaccessible property)
        /// </summary>
        public override List<Element> Previous { get { throw new DiagramException("Inaccesible property"); } }
        /// <summary>
        /// Indicates whether the element has any previous element(inaccessible property)
        /// </summary>
        public override bool HasPrevious{ get { throw new DiagramException("Inaccesible property"); } }
        /// <summary>
        /// Indicates whether the item has more than one previous item (inaccessible property)
        /// </summary>
        public override bool MoreThan1Prev{ get { throw new DiagramException("Inaccesible property"); } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public Start() { }

        #region Public methods

        /// <summary>
        /// Check if the element is connected correctly inside the diagram
        /// </summary>
        /// <returns>True if the item is correct, False otherwise</returns>
        public override bool IsCorrect()
        {
            if (this.next != null)
                return true;
            return false;
        }

        /// <summary>
        /// Assign a previous element (Inaccessible method)
        /// </summary>
        /// <param name="element">Element to assign</param>
        public override void AddPrevious(Element element)
        {
            throw new DiagramException("Inaccessible method");
        }

        /// <summary>
        /// Remove a previous element(Inaccessible method)
        /// </summary>
        /// <param name="element">Element to eliminate</param>
        public override void RemovePrevious(Element element)
        {
            throw new DiagramException("Inaccessible method");
        }

        #endregion
    }
}
