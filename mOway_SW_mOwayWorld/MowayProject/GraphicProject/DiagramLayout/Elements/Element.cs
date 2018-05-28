using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;

using Moway.Simulator;

namespace Moway.Project.GraphicProject.DiagramLayout.Elements
{
    /// <summary>
    /// Represents an element. It's an abstract class
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public abstract class Element
    {
        #region Attributes

        /// <summary>
        /// Element key text
        /// </summary>
        protected string key;
        /// <summary>
        /// Next item
        /// </summary>
        protected Element next = null;
        /// <summary>
        /// List of previous items
        /// </summary>
        protected List<Element> previous = new List<Element>();

        #endregion

        #region Properties

        /// <summary>
        /// Element key texto
        /// </summary>
        public string Key { get { return this.key; } }
        /// <summary>
        /// List of previous items
        /// </summary>
        public virtual List<Element> Previous
        {
            get
            {
                List<Element> elements = new List<Element>();
                elements.AddRange(this.previous);
                return elements;
            }
        }
        /// <summary>
        /// Indicates if the element has any previous element
        /// </summary>
        public virtual bool HasPrevious { get { return (this.previous.Count == 0) ? false : true; } }
        /// <summary>
        /// Next item
        /// </summary>
        public virtual Element Next { get { return this.next; } }
        /// <summary>
        /// Indicates whether the item has a following item
        /// </summary>
        public virtual bool HasNext { get { return (this.next == null) ? false : true; } }
        /// <summary>
        /// Indicates if the item has more than one previous item
        /// </summary>
        public virtual bool MoreThan1Prev
        {
            get
            {
                return (this.previous.Count > 1);
            }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public Element() { }

        #region Abstract public methods

        /// <summary>
        /// Assign a following element
        /// </summary>
        /// <param name="element">Element to assign</param>
        public virtual void AddNext(Element element)
        {
            if (this.next != null)
                throw new DiagramException("The element already have next element");
            this.next = element;
        }

        /// <summary>
        /// Remove the element next
        /// </summary>
        /// <param name="element">Element to eliminate</param>
        public virtual void RemoveNext(Element element)
        {
            if (this.next != element)
                throw new DiagramException("The element isn't the next");
            this.next = null;
        }

        /// <summary>
        /// Assign a previous element
        /// </summary>
        /// <param name="element">Element to assign</param>
        public virtual void AddPrevious(Element element)
        {
            this.previous.Add(element);
        }

        /// <summary>
        /// Remove a previous item
        /// </summary>
        /// <param name="element">Element to eliminate</param>
        public virtual void RemovePrevious(Element element)
        {
            if (!this.previous.Contains(element))
                throw new DiagramException("The element isn't a previous");
            this.previous.Remove(element);
        }

        /// <summary>
        /// Check if a variable is in use in this element
        /// </summary>
        /// <param name="variable">Variable to check</param>
        /// <returns>True in case it is used, False otherwise</returns>
        public virtual bool VariableUsed(Variable variable)
        {
            return false;
        }

        /// <summary>
        /// Check if a function is used in this element
        /// </summary>
        /// <param name="function">Function to check</param>
        /// <returns>True in case it is used, False otherwise</returns>
        public virtual bool FunctionUsed(Diagram function)
        {
            return false;
        }

        /// <summary>
        /// Check if the element is connected correctly inside the diagram
        /// </summary>
        /// <returns>True if the item is correct, False otherwise</returns>
        public virtual bool IsCorrect()
        {
            throw new DiagramException("IsCorrect method undefined"); 
        }

        /// <summary>
        /// Create an element clone
        /// </summary>
        /// <returns> Cloned element</returns>
        public virtual Element Clone()
        {
            throw new DiagramException("Clone method undefined");
        }

        /// <summary>
        /// Generates the Asm code for this element
        /// </summary>
        /// <param name="writer">File to write about</param>
        public virtual void WriteCode(StreamWriter writer)
        {
            throw new DiagramException("WriteCode method undefined");
        }

        /// <summary>
        /// Simulates the execution of an element.
        /// </summary>
        /// <param name="mowayModel">Simulation context of the mOway</param>
        public virtual void Simulate(MowayModel mowayModel)
        {
            throw new DiagramException("Simulate method undefined");
        }

        /// <summary>
        /// Save the Properties of this element in a file
        /// </summary>
        /// <param name="file">File to save the Properties</param>
        public virtual void SaveInFile(XmlWriter file)
        {
            throw new DiagramException("SaveInDisk method undefined");
        }

        #endregion
    }
}
