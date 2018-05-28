using System;
using System.IO;
using System.Collections;

namespace Moway.Project.GraphicProject.DiagramLayout.Elements
{
    /// <summary>
    /// Represents an arrow-type action
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Arrow : Element
    {
        /// <summary>
        /// Builder
        /// </summary>
        public Arrow() { }

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

        /// <summary>
        /// Create an element clone
        /// </summary>
        /// <returns>Cloned element</returns>
        public override Element Clone()
        {
            return new Arrow();
        }

        /// <summary>
        /// Generates the Asm code for this element (inaccessible method)
        /// </summary>
        /// <param name="writer">File to write about</param>
        public override void WriteCode(StreamWriter writer)
        {
            throw new DiagramException("Inaccessible Method");
        }

        #endregion
    }
}
