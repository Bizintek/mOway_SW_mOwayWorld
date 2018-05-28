using System;

namespace Moway.Project.GraphicProject
{
    /// <summary>
    /// Specific exception for graphic project clipboard
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class ClipboardException : Exception
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message">Exception message</param>
        public ClipboardException(string message)
            : base(message)
        { }
    }
}
