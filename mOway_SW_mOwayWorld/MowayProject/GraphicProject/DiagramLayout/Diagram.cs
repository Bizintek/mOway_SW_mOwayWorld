using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.Actions.Start;
using Moway.Project.GraphicProject.Actions.Call;

namespace Moway.Project.GraphicProject.DiagramLayout
{
    /// <summary>
    /// Represents a function / diagram in the graphic project
    /// </summary>
    /// <LastRevision>17.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>

    public class Diagram
    {
        #region Attributes

        /// <summary>
        /// Function Name
        /// </summary>
        private string name;
        /// <summary>
        /// Description of the function
        /// </summary>
        private string description;
        /// <summary>
        /// Start element of the diagram
        /// </summary>
        private Elements.Start start;
        /// <summary>
        /// List of elements that the diagram contains
        /// </summary>
        private List<Element> elements = new List<Element>();
        /// <summary>
        /// Indicates whether this function is main(false) or auxiliary(true)
        /// </summary>
        private bool isFunction;

        #endregion

        #region Properties

        /// <summary>
        /// Function Name
        /// </summary>
        public string Name { get { return this.name; } }
        /// <summary>
        /// Descripción de la funcion
        /// </summary>
        public string Description { get { return this.description; } }
        /// <summary>
        /// Start element of the diagram
        /// </summary>
        public Elements.Start Start { get { return this.start; } }
        /// <summary>
        /// Lista de elementos que contiene el diagrama
        /// </summary>
        public List<Element> Elements { get { return this.elements; } }
        /// <summary>
        /// Indicates whether this function is main(false) or auxiliary(true)
        /// </summary>
        public bool IsFunction { get { return this.isFunction; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public Diagram()
        {
        }

        /// <summary>
        ///  Builder of the Diagram class
        /// </summary>
        /// <param name="name">Function Name</param>
        /// <param name="start">Start element of the diagram</param>
        /// <param name="isFunction">Indicates whether this function is main(false) or auxiliary(true)</param>
        public Diagram(string name, string description, Elements.Start start, bool isFunction)
        {
            this.name = name;
            this.description = description;
            this.start = start;
            this.elements.Add(this.start);
            this.isFunction = isFunction;
        }

        #region Public methods

        /// <summary>
        /// Load the information to the diagram
        /// </summary>
        /// <param name="name">Function Name</param>
        /// <param name="start">Start element of the diagram</param>
        /// <param name="elements">List of elements that the diagram contains</param>
        /// <param name="isFunction">Indicates whether this function is main(false) or auxiliary(true)</param>
        public void LoadDiagram(string name, string description, Elements.Start start, List<Element> elements, bool isFunction)
        {
            if (!Diagram.Validate(name))
                throw new DiagramException("Function name is not valid");
            this.name = name;
            this.description = description;
            this.start = start;
            this.elements.Add(start);
            this.elements.AddRange(elements);
            this.isFunction = isFunction;
        }

        /// <summary>
        /// Rename a function
        /// </summary>
        /// <param name="name">Function Name</param>
        public void UpdateDiagram(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// Includes a new element in the diagram
        /// </summary>
        /// <param name="element">Element to include</param>
        public void AddElement(Element element)
        {
            this.elements.Add(element);
        }

        /// <summary>
        /// Includes a new group of elements in the diagram
        /// </summary>
        /// <param name="elements">Elements to include</param>
        public void AddElements(List<Element> elements)
        {
            this.elements.AddRange(elements);
        }

        /// <summary>
        /// Remove an element from the diagram
        /// </summary>
        /// <param name="element">Element to eliminate</param>
        public void RemoveElement(Element element)
        {
            this.elements.Remove(element);
        }

        /// <summary>
        /// Remove a group of elements from the diagram
        /// </summary>
        /// <param name="elements">Elements to eliminate</param>
        public void RemoveElements(List<Element> elements)
        {
            foreach (Element element in elements)
                this.elements.Remove(element);
        }

        /// <summary>
        /// Check if a variable is being used in a diagram
        /// </summary>
        /// <param name="variable">Variable to check</param>
        /// <returns>True in case it is used, False in the opposite case</returns>
        public bool VariableInUse(Variable variable)
        {
            foreach (Element element in this.elements)
                if (element.VariableUsed(variable))
                    return true;
            return false;
        }

        /// <summary>
        /// Check if a function is being used in a diagram
        /// </summary>
        /// <param name="function">Function to check</param>
        /// <returns>True in case it is used, False in the opposite case</returns>
        public bool FunctionInUse(Diagram function)
        {
            foreach (Element element in this.elements)
                if (element.FunctionUsed(function))
                    return true;
            return false;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validate a name of a function
        /// </summary>
        /// <param name="name">Name to validate</param>
        /// <returns>True if it is correct, False otherwise</returns>
        public static bool Validate(string name)
        {
            return Regex.IsMatch(name, @"^([a-zA-Z\d_]{4,12})$");
        }

        public static bool IsKeyword(string name)
        {
            try
            {
                StreamReader reader = new StreamReader(Application.StartupPath + "\\Keywords.txt");
                while (!reader.EndOfStream)
                {
                    string keyword = reader.ReadLine();
                    if (name.ToUpper() == keyword)
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                throw new VariableException("Can't open keyword file");
            }
        }

        #endregion
    }
}
