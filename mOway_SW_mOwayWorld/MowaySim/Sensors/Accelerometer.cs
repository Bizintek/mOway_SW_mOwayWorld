using System;

namespace Moway.Simulator.Sensors
{
    /// <summary>
    /// Represents the simulated MOway accelerometer
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Accelerometer
    {
        #region Attributes

        /// <summary>
        /// Accelerometer X-axis
        /// </summary>
        private decimal xAxisValue = 0;
        /// <summary>
        /// Accelerometer Y-axis
        /// </summary>
        private decimal yAxisValue = 0;
        /// <summary>
        /// Accelerometer Z-axis
        /// </summary>
        private decimal zAxisValue = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Accelerometer X-axis
        /// </summary>
        public decimal XAxisValue { get { return this.xAxisValue; } }
        /// <summary>
        /// Accelerometer Y-axis
        /// </summary>
        public decimal YAxisValue { get { return this.yAxisValue; } }
        /// <summary>
        /// Accelerometer Z-axis
        /// </summary>
        public decimal ZAxisValue { get { return this.zAxisValue; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        internal Accelerometer() { }

        #region Public methods

        /// <summary>
        /// Updates the state of the accelerometer
        /// </summary>
        /// <param name="xAxisValue">Accelerometer X-axis</param>
        /// <param name="yAxisValue">Accelerometer Y-axis</param>
        /// <param name="zAxisValue">Accelerometer Z-axis</param>
        public void UpdateAccelerometer(decimal xAxisValue, decimal yAxisValue, decimal zAxisValue)
        {
            this.xAxisValue = xAxisValue;
            this.yAxisValue = yAxisValue;
            this.zAxisValue = zAxisValue;
        }

        #endregion

        #region Internal methods

        /// <summary>
        /// Reset the Accelerometer
        /// </summary>
        internal void Reset()
        {
            this.xAxisValue = 0;
            this.yAxisValue = 0;
            this.zAxisValue = 0;
        }

        #endregion
    }
}
