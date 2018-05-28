using System;

namespace Moway.Simulator.Registers
{
    /// <summary>
    /// Simulated MOway Log Event
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void RegisterEventHandler(object sender, RegisterEventArgs args);

    public class RegisterEventArgs
    {
        #region Attributes

        /// <summary>
        /// Log
        /// </summary>
        private Register register;

        #endregion

        #region Properties

        /// <summary>
        /// Log
        /// </summary>
        public Register Register { get { return this.register; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="register">Log</param>
        public RegisterEventArgs(Register register)
        {
            this.register = register;
        }
    }
}
