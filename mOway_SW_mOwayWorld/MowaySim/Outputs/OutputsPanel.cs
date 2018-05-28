using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Simulator.Outputs
{
    /// <summary>
    /// Output device Panel for simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class OutputsPanel : ModulePanel
    {
        /// <summary>
        /// Builder of the panel of output devices
        /// </summary>
        /// <param name="mowayModel"></param>
        public OutputsPanel(MowayModel mowayModel):base(mowayModel)
        {
            InitializeComponent();
            //Events are recorded
            this.mowayModel.Movement.DistanceChanged += new EventHandler(Movement_DistanceChanged);
            this.mowayModel.Movement.MovementChanged += new EventHandler(Movement_MovementChanged);
            this.mowayModel.Lights.LightsChanged += new EventHandler(Lights_LightsChanged);
            this.mowayModel.Sound.SoundChanged += new EventHandler(Sound_SoundChanged);
        }

        #region Public methods

        /// <summary>
        /// Generates the name of the panel
        /// </summary>
        /// <returns>Panel name</returns>
        public override string ToString()
        {
            return Outputs.OutputsMessages.NAME;
        }

        #endregion

        #region Events of MowayModel

        /// <summary>
        /// Updated in the panel the part of the movements of the mOway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Movement_MovementChanged(object sender, EventArgs e)
        {
            //The method must be invoked to run on the correct thread
            if (this.tbDistance.InvokeRequired)
                this.Invoke(new EventHandler(this.Movement_MovementChanged), new object[] { sender, e });
            else
            {
                //Updates the status of the wheel left
                if (this.mowayModel.Movement.LeftWheelSpeed == 0)
                {
                    //If the wheel is stopped, the forward indicator is hidden and the backward indicator is plugged
                    this.pbLeftWheelForward.Visible = false;
                    this.pbLeftWheelHide.Visible = true;
                    this.pbLeftWheelHide.Location = new Point(54, 93);
                }
                else
                    if (this.mowayModel.Movement.LeftWheelDirection == Direction.Forward)
                    {
                        //If the address is forward, the forward indicator is set and displayed
                        this.pbLeftWheelForward.Visible = true;
                        this.pbLeftWheelForward.Size = new Size(15, 9 + this.mowayModel.Movement.LeftWheelSpeed * 40 / 100);
                        this.pbLeftWheelForward.Location = new Point(54, 94 - this.pbLeftWheelForward.Height);
                        //The backward indicator is hidden (leaving the boundary line visible)
                        this.pbLeftWheelHide.Visible = true;
                        this.pbLeftWheelHide.Location = new Point(54, 94);
                    }
                    else
                    {
                        //If the direction is backward, the forward indicator is hidden and...
                        this.pbLeftWheelForward.Visible = false;
                        //Set and Display backward indicator
                        this.pbLeftWheelBackward.Size = new Size(15, 49 - this.mowayModel.Movement.LeftWheelSpeed * 40 / 100);
                        this.pbLeftWheelBackward.Location = new Point(54, 94 + this.mowayModel.Movement.LeftWheelSpeed * 40 / 100);
                        this.pbLeftWheelHide.Visible = false;
                    }
                //Updates the status of the wheel right
                if (this.mowayModel.Movement.RightWheelSpeed == 0)
                {
                    //If the wheel is stopped, the forward indicator is hidden and the backward indicator is plugged
                    this.pbRightWheelForward.Visible = false;
                    this.pbRightWheelHide.Visible = true;
                    this.pbRightWheelHide.Location = new Point(152, 93);
                }
                else
                    if (this.mowayModel.Movement.RightWheelDirection == Direction.Forward)
                    {
                        //If the address is forward, the forward indicator is set and displayed
                        this.pbRightWheelForward.Visible = true;
                        this.pbRightWheelForward.Size = new Size(15, 9 + this.mowayModel.Movement.RightWheelSpeed * 40 / 100);
                        this.pbRightWheelForward.Location = new Point(152, 94 - this.pbRightWheelForward.Height);
                        //The backward indicator is hidden (leaving the boundary line visible)
                        this.pbRightWheelHide.Visible = true;
                        this.pbRightWheelHide.Location = new Point(152, 94);
                    }
                    else
                    {
                        //If the direction is backward, the forward indicator is hidden and...
                        this.pbRightWheelForward.Visible = false;
                        //Set and Display backward indicator
                        this.pbRightWheelBackward.Size = new Size(15, 49 - this.mowayModel.Movement.RightWheelSpeed * 40 / 100);
                        this.pbRightWheelBackward.Location = new Point(152, 94 + this.mowayModel.Movement.RightWheelSpeed * 40 / 100);
                        this.pbRightWheelHide.Visible = false;
                    }
            }
        }

        /// <summary>
        /// Updates the value of the distance travelled by the mOway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Movement_DistanceChanged(object sender, EventArgs e)
        {
            //The method must be invoked to run on the correct thread
            if (this.tbDistance.InvokeRequired)
                this.Invoke(new EventHandler(this.Movement_DistanceChanged), new object[] { sender, e });
            else
                //It updates the distance in centimeters
                this.tbDistance.Text = this.mowayModel.Movement.Distance.ToString("0.0") + " cm.";
        }

        /// <summary>
        /// Updates the status of the lights of the mOway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Lights_LightsChanged(object sender, EventArgs e)
        {
            //The method must be invoked to run on the correct thread
            if (this.tbDistance.InvokeRequired)
                this.Invoke(new EventHandler(this.Lights_LightsChanged), new object[] { sender, e });
            else
            {
                //Front Led
                if (this.mowayModel.Lights.FrontLight == DigitalState.On)
                    this.pbFrontLight.Visible = true;
                else
                    this.pbFrontLight.Visible = false;
                ///Tops Lights
                if ((this.mowayModel.Lights.TopGreenLight == DigitalState.On) || (this.mowayModel.Lights.TopRedLight == DigitalState.On))
                {
                    this.pbTopLights.Visible = true;
                    if (this.mowayModel.Lights.TopGreenLight == DigitalState.On)
                        if (this.mowayModel.Lights.TopRedLight == DigitalState.On)
                            this.pbTopLights.Image = this.topLightsImages.Images[2];
                        else
                            this.pbTopLights.Image = this.topLightsImages.Images[0];
                    else
                        this.pbTopLights.Image = this.topLightsImages.Images[1];
                }
                else
                    this.pbTopLights.Visible = false;
                //Brake Light
                if (this.mowayModel.Lights.BrakeLight == DigitalState.On)
                    this.pbBrakeLight.Visible = true;
                else
                    this.pbBrakeLight.Visible = false;
            }
        }

        /// <summary>
        /// Updates the status and the value of the sound produced by the mOway
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Sound_SoundChanged(object sender, EventArgs e)
        {
            //The method must be invoked to run on the correct thread
            if (this.tbDistance.InvokeRequired)
                this.Invoke(new EventHandler(this.Sound_SoundChanged), new object[] { sender, e });
            else
            {
                if (this.mowayModel.Sound.State == DigitalState.On)
                {
                    //If the sound is on, the corresponding image is shown and the frequency
                    this.pbSound.Image = OutputsGraphics.soundOn;
                    this.lFrequency.Text = this.mowayModel.Sound.Frequency.ToString();
                }
                else
                {
                    //If the sound is off the image is hidden and the frequency is erased
                    this.pbSound.Image = null;
                    this.lFrequency.Text = "";
                }
            }
        }

        #endregion
    }
}
