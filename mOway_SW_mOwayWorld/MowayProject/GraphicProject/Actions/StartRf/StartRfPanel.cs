using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.StartRf
{
    public partial class StartRfPanel : ActionPanel
    {
        #region Attributes

        private StartRfAction action;

        #endregion

        public StartRfPanel(StartRfAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.nudDirection.Value = this.action.Direction;
            this.nudChanel.Value = this.action.Chanel;
        }

        protected override void SaveSettings()
        {
            int direction = (int)this.nudDirection.Value;
            int chanel = (int)this.nudChanel.Value;
            this.action.UpdateSettings(direction, chanel);
        }

        private void NudDirection_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void NudChanel_ValueChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}