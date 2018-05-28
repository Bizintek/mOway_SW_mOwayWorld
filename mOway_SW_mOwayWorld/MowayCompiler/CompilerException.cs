using System;

namespace Moway.Compiler
{
    /// <summary>
    /// Specific exception for the compiler
    /// </summary>
    /// <LastRevision>24.09.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class CompilerException : Exception
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message">Exception message</param>
        public CompilerException(string message)
            : base(message)
        {
        }
    }
}
