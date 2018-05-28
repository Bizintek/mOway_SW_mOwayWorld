using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Reset
{
    public partial class ResetForm : ActionForm
    {
        #region Attributes

        private ResetAction action;            

        #endregion

        public ResetForm(ResetAction action)
        {
            InitializeComponent();
            this.helpTopic = Reset.HelpTopic;
this.action = action;
        }

        protected override void LoadSettings()
        {
            this.cbTime.Checked = this.action.ResetTime;
            this.cbDistance.Checked = this.action.ResetDistance;
        }

        protected override void SaveSettings()
        {
            bool resetTime = this.cbTime.Checked;
            bool resetDistance = this.cbDistance.Checked;
            this.action.UpdateSettings(resetTime, resetDistance);
        }
    }
}
