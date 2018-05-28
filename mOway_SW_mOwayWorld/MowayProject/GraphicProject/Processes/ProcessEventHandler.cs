using System;
using System.Collections.Generic;

using Moway.Project.GraphicProject.CodeGenerator;

namespace Moway.Project.GraphicProject.Processes
{
    /// <summary>
    /// Delegate for process events
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public delegate void ProcessEventHandler(object sender, ProcessEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class ProcessEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// List of errors for the process
        /// </summary>
        private List<DiagramError> errors;

        #endregion

        #region Properties

        /// <summary>
        /// Error lists for the process
        /// </summary>
        public List<DiagramError> Errors { get { return this.errors; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="errors">List of errors for the process</param>
        public ProcessEventArgs(List<DiagramError> errors)
        {
            this.errors = errors;
        }
    }
}
