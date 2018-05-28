using System;

namespace Moway.Project.GraphicProject.CodeGenerator
{
    /// <summary>
    /// Specific exception for the code generator
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class GeneratorException : Exception
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message"> Exception message</param>
        public GeneratorException(string message)
            : base(message)
        {
        }
    }
}
