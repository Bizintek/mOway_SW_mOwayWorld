using System;

namespace Moway.Project
{
    /// <summary>
    /// Operations-specific exception
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class OperationException : Exception
    {
        #region Attributes

        /// <summary>
        /// Exception operation
        /// </summary>
        private Operation operation;

        #endregion

        #region Properties

        /// <summary>
        /// Exception operation
        /// </summary>
        public Operation Operation { get { return this.operation; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="operation">Exception operation</param>
        /// <param name="message">Exception menssage</param>
        public OperationException(Operation operation, string message)
            : base(message)
        {
            this.operation = operation;
        }
    }
}
