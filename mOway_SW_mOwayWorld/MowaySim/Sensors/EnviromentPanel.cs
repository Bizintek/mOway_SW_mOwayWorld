using System;
using System.Windows.Forms;

namespace Moway.Simulator.Sensors
{
    /// <summary>
    /// Environment Panel for simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class EnviromentPanel : ModulePanel
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="mowayModel">Simulation model of the MOway</param>
        internal EnviromentPanel(MowayModel mowayModel)
            : base(mowayModel)
        {
            InitializeComponent();
            //Updates the values of the sensors
            this.nudBrightness.Value = mowayModel.Brightness;
            this.nudTemperature.Value = mowayModel.Temperature;
            this.nudNoise.Value = mowayModel.NoiseLevel;
        }

        #region Public methods

        /// <summary>
        /// Generates the name of the panel
        /// </summary>
        /// <returns>Panel name</returns>
        public override string ToString()
        {
            return EnviromentMessages.NAME;
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Change in Brihgtness value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudBrightness_ValueChanged(object sender, EventArgs e)
        {
            this.mowayModel.UpdateBrightness((byte)this.nudBrightness.Value);
        }

        /// <summary>
        /// Change in Temperature value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudTemperature_ValueChanged(object sender, EventArgs e)
        {
            this.mowayModel.UpdateTemperature(this.nudTemperature.Value);
        }

        /// <summary>
        /// Change in Noise value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudNoise_ValueChanged(object sender, EventArgs e)
        {
            this.mowayModel.UpdateNoiseLevel((byte)this.nudNoise.Value);
        }

        #endregion
    }
}
