using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Lights
{
    public partial class LightsPanel : ActionPanel
    {
        #region Attributes

        private LightsAction action;

        #endregion

        public LightsPanel(LightsAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.cbFront.SelectedIndex = (int)this.action.FrontLight;
            this.cbBreak.SelectedIndex = (int)this.action.BrakeLight;
            this.cbTopGreen.SelectedIndex = (int)this.action.TopGreenLight;
            this.cbTopRed.SelectedIndex = (int)this.action.TopRedLight;
        }

        protected override void SaveSettings()
        {
            LightState frontLight = (LightState)Enum.ToObject(typeof(LightState), this.cbFront.SelectedIndex);
            LightState breakLight = (LightState)Enum.ToObject(typeof(LightState), this.cbBreak.SelectedIndex);
            LightState topGreenLight = (LightState)Enum.ToObject(typeof(LightState), this.cbTopGreen.SelectedIndex);
            LightState topRedLight = (LightState)Enum.ToObject(typeof(LightState), this.cbTopRed.SelectedIndex);

            this.action.UpdateSettings(frontLight, breakLight, topGreenLight, topRedLight);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

    }
}
