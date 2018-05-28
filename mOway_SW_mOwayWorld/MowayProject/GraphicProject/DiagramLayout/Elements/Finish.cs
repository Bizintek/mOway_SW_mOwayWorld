using System;

namespace Moway.Project.GraphicProject.DiagramLayout.Elements
{
    /// <summary>
    /// Represents an end-type action
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class Finish : Element
    {
        #region Properties

        /// <summary>
        /// Next item (Inaccessible property)
        /// </summary>
        public override Element Next { get { throw new DiagramException("Inaccessible property"); } }
        /// <summary>
        /// Indicates if the element has a next assigned(Unapproachable property)
        /// </summary>
        public override bool HasNext { get { throw new DiagramException("Inaccessible property"); } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public Finish()
        {
        }
 
        #region Public methods

        /// <summary>
        /// Check if the element is connected correctly inside the diagram
        /// </summary>
        /// <returns>True if the item is correct, False otherwise</returns>
        public override bool IsCorrect()
        {
            if (this.previous.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// Assign a following element (inaccessible method)
        /// </summary>
        /// <param name="element">Element to assign</param>
        public override void AddNext(Element element)
        {
            throw new DiagramException("Inaccessible method");
        }

        /// <summary>
        /// Remove the next element (inaccessible method)
        /// </summary>
        /// <param name="element">Element to eliminate</param>
        public override void RemoveNext(Element element)
        {
            throw new DiagramException("Inaccessible method");
        }

        #endregion
    }
}
