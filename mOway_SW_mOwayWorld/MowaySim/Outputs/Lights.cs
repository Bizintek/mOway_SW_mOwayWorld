using System;

namespace Moway.Simulator.Outputs
{
    /// <summary>
    /// Represents the MOway light module simulated
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Lights
    {
        #region Attributes

        /// <summary>
        /// Front Light status
        /// </summary>
        private DigitalState frontLight = DigitalState.Off;
        /// <summary>
        /// Brake Light Status
        /// </summary>
        private DigitalState brakeLight = DigitalState.Off;
        /// <summary>
        /// Green Top Light Status
        /// </summary>
        private DigitalState topGreenLight = DigitalState.Off;
        /// <summary>
        /// Red Top Light Status
        /// </summary>
        private DigitalState topRedLight = DigitalState.Off;

        #endregion

        #region Properties

        /// <summary>
        /// Front Light status
        /// </summary>
        public DigitalState FrontLight { get { return this.frontLight; } }
        /// <summary>
        /// Brake Light Status
        /// </summary>
        public DigitalState BrakeLight { get { return this.brakeLight; } }
        /// <summary>
        ///  Green Top Light Status
        /// </summary>
        public DigitalState TopGreenLight { get { return this.topGreenLight; } }
        /// <summary>
        /// Red Top Light Status
        /// </summary>
        public DigitalState TopRedLight { get { return this.topRedLight; } }

        #endregion

        #region Events

        /// <summary>
        /// State Change event of any of the lights
        /// </summary>
        public event EventHandler LightsChanged;

        #endregion

        internal Lights() { }

        /// <summary>
        /// Updates the status of the MOway lights
        /// </summary>
        /// <param name="frontLight">Front Light</param>
        /// <param name="brakeLight">Brake Light</param>
        /// <param name="topGreenLight">Green Top Light</param>
        /// <param name="topRedLight">Red Top Light</param>
        public void UpdateLights(DigitalState frontLight, DigitalState brakeLight, DigitalState topGreenLight, DigitalState topRedLight)
        {
            if ((this.frontLight != frontLight) || (this.brakeLight != brakeLight) || (this.topGreenLight != topGreenLight) || (this.topRedLight != topRedLight))
            {
                this.frontLight = frontLight;
                this.brakeLight = brakeLight;
                this.topGreenLight = topGreenLight;
                this.topRedLight = topRedLight;
                if (this.LightsChanged != null)
                    this.LightsChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Reset the MOway Lights
        /// </summary>
        internal void Reset()
        {
            if ((this.frontLight != DigitalState.Off) || (this.brakeLight != DigitalState.Off) || (this.topGreenLight != DigitalState.Off) || (this.topRedLight != DigitalState.Off))
            {
                this.frontLight = DigitalState.Off;
                this.brakeLight = DigitalState.Off;
                this.topGreenLight = DigitalState.Off;
                this.topRedLight = DigitalState.Off;
                if (this.LightsChanged != null)
                    this.LightsChanged(this, new EventArgs());
            }
        }
    }
}
