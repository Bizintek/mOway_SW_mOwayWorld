using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Forms;

namespace Moway.Project.GraphicProject.Actions.PlayCamera
{
    public partial class PlayCameraForm : ActionForm
    {
        #region Attributes

        private PlayCameraAction action;

        #endregion

        public PlayCameraForm(PlayCameraAction action)
        {
            InitializeComponent();
            this.helpTopic = PlayCamera.HelpTopic;

            //The action is saved in order to save the changes
            this.action = action;
        }

        #region Private methods

        protected override void LoadSettings()
        {
            this.nudFrequency.Value = this.action.Channel;
        }

        protected override void SaveSettings()
        {
            this.action.UpdateSettings((int)this.nudFrequency.Value);
        }

        #endregion

    }
}
