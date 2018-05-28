using System;

namespace Moway.Simulator.Outputs
{
    /// <summary>
    /// Represents the sound module of the simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Sound
    {
        #region Attributes

        /// <summary>
        /// MOway Sound Status
        /// </summary>
        private DigitalState state = DigitalState.Off;
        /// <summary>
        /// MOway Sound Frequency
        /// </summary>
        private decimal frequency = 244.14M;

        #endregion

        #region Properties

        /// <summary>
        /// MOway Sound Status
        /// </summary>
        public DigitalState State { get { return this.state; } }
        /// <summary>
        /// MOway Sound Frequency
        /// </summary>
        public decimal Frequency { get { return this.frequency; } }

        #endregion

        #region Events

        /// <summary>
        /// Event by change of State and/or frequency of the sound of the MOway
        /// </summary>
        public event EventHandler SoundChanged;

        #endregion

        internal Sound() { }

        /// <summary>
        /// Update the sound of the MOway
        /// </summary>
        /// <param name="state"> MOway Sound Status</param>
        /// <param name="frequency">MOway Sound Frequency</param>
        public void UpdateSound(DigitalState state, decimal frequency)
        {
            if ((this.state != state) || (this.frequency != frequency))
            {
                this.state = state;
                this.frequency = frequency;
                if (this.SoundChanged != null)
                    this.SoundChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Reset the sound of the MOway
        /// </summary>
        internal void Reset()
        {
            if (this.state != DigitalState.Off)
            {
                this.state = DigitalState.Off;
                if (this.SoundChanged != null)
                    this.SoundChanged(this, new EventArgs());
            }
        }
    }
}
