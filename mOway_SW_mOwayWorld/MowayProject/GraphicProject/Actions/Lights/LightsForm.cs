using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.Lights
{
    public partial class LightsForm : ActionForm
    {
        #region Attributes

        private LightsAction action;

        #endregion

        public LightsForm(LightsAction action)
        {
            InitializeComponent();
            this.helpTopic = Lights.HelpTopic;

            //The action is saved in order to save the changes
            this.action = action;
        }

        #region Private methods

        protected override void LoadSettings()
        {
            this.cbFront.SelectedIndex = (int)this.action.FrontLight;
            this.cbBrake.SelectedIndex = (int)this.action.BrakeLight;
            this.cbTopGreen.SelectedIndex = (int)this.action.TopGreenLight;
            this.cbTopRed.SelectedIndex = (int)this.action.TopRedLight;
        }

        protected override void SaveSettings()
        {
            LightState frontLight = (LightState)Enum.ToObject(typeof(LightState), this.cbFront.SelectedIndex);
            LightState breakLight = (LightState)Enum.ToObject(typeof(LightState), this.cbBrake.SelectedIndex);
            LightState topGreenLight = (LightState)Enum.ToObject(typeof(LightState), this.cbTopGreen.SelectedIndex);
            LightState topRedLight = (LightState)Enum.ToObject(typeof(LightState), this.cbTopRed.SelectedIndex); 

            this.action.UpdateSettings(frontLight, breakLight, topGreenLight, topRedLight);
        }

        #endregion

        private void cbFront_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbFront.SelectedIndex == (int)LightState.On)
                this.pbFront.Visible = true;
            else if (this.cbFront.SelectedIndex == (int)LightState.Blink)
            {
                this.pbFront.Visible = true;
                this.tBlink.Enabled = true;
            }
            else
                this.pbFront.Visible = false;
        }

        private void cbBrake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbBrake.SelectedIndex == (int)LightState.On)
                this.pbBrake.Visible = true;
            else if (this.cbBrake.SelectedIndex == (int)LightState.Blink)
            {
                this.pbBrake.Visible = true;
                this.tBlink.Enabled = true;
            }
            else
                this.pbBrake.Visible = false;
        }

        private void cbTopGreen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int imageCounter = -1;
            if ((this.cbTopGreen.SelectedIndex == (int)LightState.On) || (this.cbTopGreen.SelectedIndex == (int)LightState.Blink))
                imageCounter += 1;
            if (this.cbTopRed.SelectedIndex == (int)LightState.On)
                imageCounter += 2;
            if (imageCounter != -1)
            {
                this.pbTop.Visible = true;
                this.pbTop.BackgroundImage = this.pbTopImages.Images[imageCounter];
            }
            else
                this.pbTop.Visible = false;
            if (this.cbTopGreen.SelectedIndex == (int)LightState.Blink)
                this.tBlink.Enabled = true;
        }
        
        private void cbTopRed_SelectedIndexChanged(object sender, EventArgs e)
        {
            int imageCounter = -1;
            if (this.cbTopGreen.SelectedIndex == (int)LightState.On)
                imageCounter += 1;
            if ((this.cbTopRed.SelectedIndex == (int)LightState.On) || (this.cbTopRed.SelectedIndex == (int)LightState.Blink))
                imageCounter += 2;
            if (imageCounter != -1)
            {
                this.pbTop.Visible = true;
                this.pbTop.BackgroundImage = this.pbTopImages.Images[imageCounter];
            }
            else
                this.pbTop.Visible = false;
            if (this.cbTopRed.SelectedIndex == (int)LightState.Blink)
                this.tBlink.Enabled = true;
        }

        private void tBlink_Tick(object sender, EventArgs e)
        {
            this.tBlink.Enabled = false;
            if (this.cbFront.SelectedIndex == (int)LightState.Blink)
                this.pbFront.Visible = false;
            if (this.cbBrake.SelectedIndex == (int)LightState.Blink)
                this.pbBrake.Visible = false;
            if (this.cbTopGreen.SelectedIndex == (int)LightState.Blink)
            {
                if (this.cbTopRed.SelectedIndex == (int)LightState.On)
                    this.pbTop.BackgroundImage = this.pbTopImages.Images[1];
                else
                    this.pbTop.Visible = false;
            }
            if (this.cbTopRed.SelectedIndex == (int)LightState.Blink)
            {
                if (this.cbTopGreen.SelectedIndex == (int)LightState.On)
                    this.pbTop.BackgroundImage = this.pbTopImages.Images[0];
                else
                    this.pbTop.Visible = false;
            }
        }

    }
}
