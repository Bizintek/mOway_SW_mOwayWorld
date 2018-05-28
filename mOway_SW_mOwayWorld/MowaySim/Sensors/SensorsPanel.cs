using System;
using System.Windows.Forms;

namespace Moway.Simulator.Sensors
{
    /// <summary>
    /// Sensor Panel for simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class SensorsPanel : ModulePanel
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="mowayModel">Simulation model of the MOway</param>
        internal SensorsPanel(MowayModel mowayModel)
            : base(mowayModel)
        {
            InitializeComponent();
            //Updates the values of the sensors and the images
            this.nudLineLeftSensor.Value = this.mowayModel.LineSensors.LeftSensor;
            this.nudLineRightSensor.Value = this.mowayModel.LineSensors.RightSensor;
            this.nudObstacleLeftCentralSensor.Value = this.mowayModel.ObstacleSensors.LeftCentralSensor;
            this.nudObstacleLeftSideSensor.Value = this.mowayModel.ObstacleSensors.LeftSideSensor;
            this.nudObstacleRightCentralSensor.Value = this.mowayModel.ObstacleSensors.RightCentralSensor;
            this.nudObstacleRightSideSensor.Value = this.mowayModel.ObstacleSensors.RightSideSensor;
            this.pbLineLeft.Image = SensorsGraphics.leftWhite;
            this.pbLineRight.Image = SensorsGraphics.rightWhite;
        }

        #region Public methods

        /// <summary>
        /// Generates the name of the panel
        /// </summary>
        /// <returns>Panel name</returns>
        public override string ToString()
        {
            return SensorsMessages.NAME;
        }

        #endregion

        #region Form Events

        /// <summary>
        /// Change in the value of the left line sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudLineLeftSensor_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudLineLeftSensor.Value <= LineSensors.MAX_LINE_WHITE)
            {
                this.pbLineLeft.Image = SensorsGraphics.leftWhite;
                this.pbLineLeft.Visible = true;
            }
            else if (this.nudLineLeftSensor.Value >= LineSensors.MIN_LINE_BLACK)
            {
                this.pbLineLeft.Image = SensorsGraphics.leftBlack;
                this.pbLineLeft.Visible = true;
            }
            else
                this.pbLineLeft.Visible = false;
            this.mowayModel.LineSensors.UpdateLineSensors((byte)this.nudLineLeftSensor.Value, (byte)this.nudLineRightSensor.Value);
        }

        /// <summary>
        /// Change in the value of the right line sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudLineRightSensor_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudLineRightSensor.Value <= LineSensors.MAX_LINE_WHITE)
            {
                this.pbLineRight.Image = SensorsGraphics.rightWhite;
                this.pbLineRight.Visible = true;
            }
            else if (this.nudLineRightSensor.Value >= LineSensors.MIN_LINE_BLACK)
            {
                this.pbLineRight.Image = SensorsGraphics.rightBlack;
                this.pbLineRight.Visible = true;
            }
            else
                this.pbLineRight.Visible = false;
            this.mowayModel.LineSensors.UpdateLineSensors((byte)this.nudLineLeftSensor.Value, (byte)this.nudLineRightSensor.Value);
        }

        /// <summary>
        /// Change in the value of the left side obstacle sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudObstacleLeftSideSensor_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudObstacleLeftSideSensor.Value >= ObstacleSensors.MIN_OBSTACLE)
            {
                this.pbObstacleLeftSideSensor.Visible = true;
                this.pbObstacleLeftSideObstacle.Visible = true;
            }
            else
            {
                this.pbObstacleLeftSideSensor.Visible = false;
                this.pbObstacleLeftSideObstacle.Visible = false;
            }
            this.mowayModel.ObstacleSensors.UpdateObstacleSensors((byte)this.nudObstacleLeftCentralSensor.Value, (byte)this.nudObstacleLeftSideSensor.Value, (byte)this.nudObstacleRightCentralSensor.Value, (byte)this.nudObstacleRightSideSensor.Value);
        }

        /// <summary>
        /// Change in the value of the left central obstacle sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudObstacleLeftCentralSensor_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudObstacleLeftCentralSensor.Value >= ObstacleSensors.MIN_OBSTACLE)
            {
                this.pbObstacleLeftCentralSensor.Visible = true;
                this.pbObstacleLeftCentralObstacle.Visible = true;
            }
            else
            {
                this.pbObstacleLeftCentralSensor.Visible = false;
                this.pbObstacleLeftCentralObstacle.Visible = false;
            }
            this.mowayModel.ObstacleSensors.UpdateObstacleSensors((byte)this.nudObstacleLeftCentralSensor.Value, (byte)this.nudObstacleLeftSideSensor.Value, (byte)this.nudObstacleRightCentralSensor.Value, (byte)this.nudObstacleRightSideSensor.Value);
        }

        /// <summary>
        /// Change in the value of the right central obstacle sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudObstacleRightCentralSensor_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudObstacleRightCentralSensor.Value >= ObstacleSensors.MIN_OBSTACLE)
            {
                this.pbObstacleRightCentralSensor.Visible = true;
                this.pbObstacleRightCentralObstacle.Visible = true;
            }
            else
            {
                this.pbObstacleRightCentralSensor.Visible = false;
                this.pbObstacleRightCentralObstacle.Visible = false;
            }
            this.mowayModel.ObstacleSensors.UpdateObstacleSensors((byte)this.nudObstacleLeftCentralSensor.Value, (byte)this.nudObstacleLeftSideSensor.Value, (byte)this.nudObstacleRightCentralSensor.Value, (byte)this.nudObstacleRightSideSensor.Value);
        }

        /// <summary>
        /// Change in the value of the right side obstacle sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudObstacleRightSideSensor_ValueChanged(object sender, EventArgs e)
        {
            if (this.nudObstacleRightSideSensor.Value >= ObstacleSensors.MIN_OBSTACLE)
            {
                this.pbObstacleRightSideSensor.Visible = true;
                this.pbObstacleRightSideObstacle.Visible = true;
            }
            else
            {
                this.pbObstacleRightSideSensor.Visible = false;
                this.pbObstacleRightSideObstacle.Visible = false;
            }
            this.mowayModel.ObstacleSensors.UpdateObstacleSensors((byte)this.nudObstacleLeftCentralSensor.Value, (byte)this.nudObstacleLeftSideSensor.Value, (byte)this.nudObstacleRightCentralSensor.Value, (byte)this.nudObstacleRightSideSensor.Value);
        }

        #endregion
    }
}
