using System;

using Moway.Simulator;

namespace Moway.Project
{
    /// <summary>
    /// Delegate for change of Simulator status
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public delegate void SimStateEventHandler(object sender, SimStateEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    public class SimStateEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Simulator status
        /// </summary>
        private SimState state;

        #endregion

        #region Properties

        /// <summary>
        /// Simulator status
        /// </summary>
        public SimState State { get { return this.state; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="state">Simulator status</param>
        public SimStateEventArgs(SimState state)
        {
            this.state = state;
        }
    }
}
