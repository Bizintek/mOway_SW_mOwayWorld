using System;
using System.IO;

using Moway.Simulator;

namespace Moway.Project.GraphicProject.DiagramLayout.Elements
{
    /// <summary>
    /// Outputs of a conditional action
    /// </summary>
    public enum ConditionalOut { True, False }

    /// <summary>
    /// Represents an action of Conditional type
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class Conditional : Element
    {
        #region Attributes

        /// <summary>
        /// True next element
        /// </summary>
        private Element nextTrue = null;
        /// <summary>
        /// False next element
        /// </summary>
        private Element nextFalse = null;

        #endregion

        #region Properties

        /// <summary>
        /// Next item (Inaccessible property)
        /// </summary>
        public override Element Next { get { throw new DiagramException("Inaccesible property"); } }
        /// <summary>
        /// Indicates if the element has a next assigned (Unapproachable property)
        /// </summary>
        public override bool HasNext { get { throw new DiagramException("Inaccesible property"); } }
        /// <summary>
        /// True next element
        /// </summary>
        public Element NextTrue { get { return this.nextTrue; } }
        /// <summary>
        /// Indicates whether the element has a real next assigned
        /// </summary>
        public bool HasNextTrue { get { return (this.nextTrue == null) ? false : true; } }
        /// <summary>
        /// False next element
        /// </summary>
        public Element NextFalse { get { return this.nextFalse; } }
        /// <summary>
        /// Indicates whether the element has a real next assigned
        /// </summary>
        public bool HasNextFalse { get { return (this.nextFalse == null) ? false : true; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public Conditional() { }

        #region Public methods

        /// <summary>
        /// Check if the item is connected correctly inside the diagram
        /// </summary>
        /// <returns>True if the item is correct, False otherwise</returns>
        public override bool IsCorrect()
        {
            if ((this.nextTrue != null) && (this.nextFalse != null) && (this.previous.Count > 0))
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
        /// Remove the element next
        /// </summary>
        /// <param name="element">Element to eliminate</param>
        public override void RemoveNext(Element element)
        {
            if ((this.nextTrue != element) && (this.nextFalse != element))
                throw new DiagramException("The element isn't the next");
            if (this.nextTrue == element)
                this.nextTrue = null;
            else
                this.nextFalse = null;
        }

        /// <summary>
        /// Assign a following element
        /// </summary>
        /// <param name="element">Element to assign</param>
        /// <param name="nextOut">Output to which to assign it (true or false)</param>
        public void AddNext(Element element, ConditionalOut nextOut)
        {
            if (nextOut == ConditionalOut.True)
                this.AddNextTrue(element);
            else
                this.AddNextFalse(element);
        }

        /// <summary>
        /// Generates the Asm code for this element
        /// </summary>
        /// <param name="writer">File to write about</param>
        /// <param name="labelFalse">Label needed to indicate the output false</param>
        public virtual void WriteCode(StreamWriter writer, string labelFalse)
        {
            throw new DiagramException("WriteCode method undefined");
        }

        /// <summary>
        /// Simulates the execution of a conditional.
        /// </summary>
        /// <param name="mowayModel">Simulation context of the mOway</param>
        /// <returns>Returns the output through which the program should follow</returns>
        public virtual new bool Simulate(MowayModel mowayModel)
        {
            throw new DiagramException("Simulate mehotd undefined");
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Assign a following element to the true output
        /// </summary>
        /// <param name="element">Element to assign</param>
        private void AddNextTrue(Element element)
        {
            if (this.nextTrue == null)
                this.nextTrue = element;
            else
                throw new DiagramException("The next true output should be null");
        }

        /// <summary>
        /// Assign a following element to the false output
        /// </summary>
        /// <param name="element">Element to assign</param>
        private void AddNextFalse(Element element)
        {
            if (this.nextFalse == null)
                this.nextFalse = element;
            else
                throw new DiagramException("The next false output should be null");
        }

        #endregion
    }
}
