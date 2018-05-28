using System;
using System.Windows.Forms;

namespace Moway.Simulator.Sensors
{
    /// <summary>
    /// Accelerometer Panel for simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class AccelerometerPanel : ModulePanel
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="mowayModel">Simulation Model of the mOway</param>
        internal AccelerometerPanel(MowayModel mowayModel)
            : base(mowayModel)
        {
            InitializeComponent();
            //Updates the values of the sensors
            this.nudXAxis.Value = mowayModel.Accelerometer.XAxisValue;
            this.nudYAxis.Value = mowayModel.Accelerometer.YAxisValue;
            this.nudZAxis.Value = mowayModel.Accelerometer.ZAxisValue;
        }

        #region Public methods

        /// <summary>
        /// Generates the name of the panel
        /// </summary>
        /// <returns>Panel name</returns>
        public override string ToString()
        {
            return AccelerometerMessages.NAME;
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Change of value of some of the axes of the Accelerometer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudAxis_ValueChanged(object sender, EventArgs e)
        {
            this.mowayModel.Accelerometer.UpdateAccelerometer(this.nudXAxis.Value, this.nudYAxis.Value, this.nudZAxis.Value);
        }

        #endregion
    }
}
