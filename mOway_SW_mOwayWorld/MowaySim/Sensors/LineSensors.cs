using System;

namespace Moway.Simulator.Sensors
{
    /// <summary>
    /// It represents the line sensors of the simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class LineSensors
    {
        #region Constants

        /// <summary>
        /// Maximum margin for the white line
        /// </summary>
        public const decimal MAX_LINE_WHITE = 20;
        /// <summary>
        /// Minimum margin for black line
        /// </summary>
        public const decimal MIN_LINE_BLACK = 230;

        #endregion

        #region Attributes

        /// <summary>
        /// Left Line Sensor
        /// </summary>
        private byte leftSensor = 0;
        /// <summary>
        /// Right Line Sensor
        /// </summary>
        private byte rightSensor = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Left Line Sensor
        /// </summary>
        public int LeftSensor { get { return this.leftSensor; } }
        /// <summary>
        /// Right Line Sensor
        /// </summary>
        public int RightSensor { get { return this.rightSensor; } }

        #endregion

        internal LineSensors() { }

        #region Public methods

        /// <summary>
        /// Updates the status of simulated MOway line sensors
        /// </summary>
        /// <param name="leftSensor">Left Sensor</param>
        /// <param name="rightSensor">Right Sensor</param>
        public void UpdateLineSensors(byte leftSensor, byte rightSensor)
        {
            this.leftSensor = leftSensor;
            this.rightSensor = rightSensor;
        }

        #endregion

        #region Internal methods

        /// <summary>
        /// Reset the status of the sensors
        /// </summary>
        internal void Reset()
        {
            this.leftSensor = 0;
            this.rightSensor = 0;
        }

        #endregion
    }
}
