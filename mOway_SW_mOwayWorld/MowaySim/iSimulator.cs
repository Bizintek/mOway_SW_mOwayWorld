using System;
using System.Collections.Generic;
using System.Text;

namespace Moway.Simulator
{
    /// <summary>
    /// State of the simulation
    /// </summary>
    public enum SimState { Inactive, Running, Pause, Stop }

    /// <summary>
    /// Interface to comply with any simulator that is implemented
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public interface ISimulator
    {
        #region Properties

        /// <summary>
        /// Simulator status
        /// </summary>
        SimState State { get; }
        /// <summary>
        /// Simulated MOway model
        /// </summary>
        MowayModel MowayModel { get; }

        #endregion

        #region Events

        /// <summary>
        /// Change of Simulator status
        /// </summary>
        event EventHandler StateChanged;
        event EventHandler SimulationFinished;

        #endregion

        #region Methods

        /// <summary>
        /// Start the simulation in normal mode
        /// </summary>
        void Run();
        /// <summary>
        /// Start Simulation in animation mode
        /// </summary>
        void Animate();
        /// <summary>
        /// Pause the simulation
        /// </summary>
        void Pause();
        /// <summary>
        /// Reset the simulation
        /// </summary>
        void Reset();
        /// <summary>
        /// Simulate an action entering a subroutine if it were the case
        /// </summary>
        void StepIn();
        /// <summary>
        /// Simulate an action without entering a subroutine if the case
        /// </summary>
        void StepOver();

        #endregion
    }
}
