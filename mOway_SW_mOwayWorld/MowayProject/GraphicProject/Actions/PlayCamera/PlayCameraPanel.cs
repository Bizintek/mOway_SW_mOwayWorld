using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.PlayCamera
{
    public partial class PlayCameraPanel : ActionPanel
    {
        #region Attributes

        private PlayCameraAction action;

        #endregion

        public PlayCameraPanel(PlayCameraAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.nudFrequency.Value = this.action.Channel;
        }

        protected override void SaveSettings()
        {
            this.action.UpdateSettings((int)this.nudFrequency.Value);
        }

        private void NudFrequency_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
