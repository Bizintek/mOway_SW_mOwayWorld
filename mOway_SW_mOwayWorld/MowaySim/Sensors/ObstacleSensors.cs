using System;

namespace Moway.Simulator.Sensors
{
    /// <summary>
    /// It represents the obstacle sensors of the simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class ObstacleSensors
    {
        #region Constants

        /// <summary>
        /// Obstacle detection margin
        /// </summary>
        public const decimal MIN_OBSTACLE = 128;

        #endregion

        #region Attributes

        /// <summary>
        /// Left Central obstacle Sensor
        /// </summary>
        private byte leftCentralSensor = 0;
        /// <summary>
        /// Left Side obstacles Sensor
        /// </summary>
        private byte leftSideSensor = 0;
        /// <summary>
        /// Right Central obstacle Sensor
        /// </summary>
        private byte rightCentralSensor = 0;
        /// <summary>
        /// Right Side obstacle Sensor
        /// </summary>
        private byte rightSideSensor = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Left Central obstacle Sensor
        /// </summary>
        public byte LeftCentralSensor { get { return this.leftCentralSensor; } }
        /// <summary>
        /// Left Side obstacles Sensor
        /// </summary>
        public byte LeftSideSensor { get { return this.leftSideSensor; } }
        /// <summary>
        /// Right Central obstacle Sensor
        /// </summary>
        public byte RightCentralSensor { get { return this.rightCentralSensor; } }
        /// <summary>
        /// Right Side obstacle Sensor
        /// </summary>
        public byte RightSideSensor { get { return this.rightSideSensor; } }

        #endregion

        internal ObstacleSensors() { }

        #region Public methods
        /// <summary>
        /// Updates the status of simulated mOway obstacle sensors
        /// </summary>
        /// <param name="leftCentralSensor">Left Central Sensor</param>
        /// <param name="leftSideSensor">Left Side Sensor</param>
        /// <param name="rightCentralSensor">Right Central Sensor</param>
        /// <param name="rightSideSensor">Right Side Sensor</param>
        public void UpdateObstacleSensors(byte leftCentralSensor, byte leftSideSensor, byte rightCentralSensor, byte rightSideSensor)
        {
            this.leftCentralSensor = leftCentralSensor;
            this.leftSideSensor = leftSideSensor;
            this.rightCentralSensor = rightCentralSensor;
            this.rightSideSensor = rightSideSensor;
        }

        #endregion

        #region Internal methods

        /// <summary>
        /// Reset Obstacle Sensors
        /// </summary>
        internal void Reset()
        {
            this.leftCentralSensor = 0;
            this.leftSideSensor = 0;
            this.rightCentralSensor = 0;
            this.rightSideSensor = 0;
        }

        #endregion
    }
}
