using System;

using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.DiagramLayout;

namespace Moway.Project.GraphicProject.CodeGenerator
{
    /// <summary>
    /// Type of error in the diagram
    /// </summary>
    public enum ErrorType { Error, Warning, Message }

    /// <summary>
    /// It represents a diagram error with all the error information
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>    
    public class DiagramError
    {
        #region Attributes

        /// <summary>
        /// Type of error
        /// </summary>
        private ErrorType type;
        /// <summary>
        /// Diagram where the error is found
        /// </summary>
        private Diagram diagram;
        /// <summary>
        /// Element where the error is found
        /// </summary>
        private Element element;
        /// <summary>
        /// Error message
        /// </summary>
        private string message;

        #endregion

        #region Properties

        /// <summary>
        /// Type of error
        /// </summary>
        public ErrorType Type { get { return this.type; } }
        /// <summary>
        /// Diagram where the error is found
        /// </summary>
        public Diagram Diagram { get { return this.diagram; } }
        /// <summary>
        /// Element where the error is found
        /// </summary>
        public Element Element { get { return this.element; } }
        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get { return this.message; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="type">Type of error</param>
        /// <param name="diagram">Diagram where the error is found</param>
        /// <param name="element">Element where the error is found</param>
        /// <param name="message">Error message</param>
        public DiagramError(ErrorType type, Diagram diagram, Element element, string message)
        {
            this.type = type;
            this.diagram = diagram;
            this.element = element;
            this.message = message;
        }
    }
}
