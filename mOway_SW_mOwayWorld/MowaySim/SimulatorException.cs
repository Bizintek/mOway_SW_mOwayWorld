using System;

namespace Moway.Simulator
{
    /// <summary>
    /// Simulator exception
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class SimulatorException : Exception
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message"></param>
        public SimulatorException(string message) : base(message) { }
    }
}
