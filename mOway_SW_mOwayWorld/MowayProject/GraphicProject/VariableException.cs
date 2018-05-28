using System;

namespace Moway.Project.GraphicProject
{
    /// <summary>
    /// Specific exception for the variables of a graphic project
    /// </summary>
    /// <LastRevision>17.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class VariableException : Exception
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message">Exception message</param>
        public VariableException(string message)
            : base(message)
        { }
    }
}
