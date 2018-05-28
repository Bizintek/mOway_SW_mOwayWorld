using System;

namespace Moway.Project.GraphicProject.DiagramLayout.Elements
{
    /// <summary>
    /// Represents a module-type action
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class Module : Element
    {
        /// <summary>
        /// Builder
        /// </summary>
        public Module() { }

        #region Public methods

        /// <summary>
        /// Check if the element is connected correctly inside the diagram
        /// </summary>
        /// <returns>True if the item is correct, False otherwise</returns>
        public override bool IsCorrect()
        {
            if ((this.next != null) && (this.previous.Count > 0))
                return true;
            return false;
        }

        #endregion
    }
}
