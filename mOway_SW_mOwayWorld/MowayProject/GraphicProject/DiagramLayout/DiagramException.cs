using System;

namespace Moway.Project.GraphicProject.DiagramLayout
{
    /// <summary>
    /// Specific exception for functions / diagrams
    /// </summary>
    /// <LastRevision>18.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class DiagramException : Exception
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message">Exception message</param>
        public DiagramException(string message)
            : base(message)
        {
        }
    }
}
