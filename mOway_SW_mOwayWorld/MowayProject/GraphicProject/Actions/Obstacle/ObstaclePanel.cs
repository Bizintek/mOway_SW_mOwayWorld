using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Obstacle
{
    public partial class ObstaclePanel : ActionPanel
    {
        #region Attributes

        private ObstacleAction action;

        #endregion

        public ObstaclePanel(ObstacleAction action)
        {
            InitializeComponent();
            this.action = action;
        }

        protected override void LoadSettings()
        {
            this.cbUpperLeft.SelectedIndex = (int)this.action.UpperLeftSensor;
            this.cbLeft.SelectedIndex = (int)this.action.LeftSensor;
            this.cbUpperRight.SelectedIndex = (int)this.action.UpperRightSensor;
            this.cbRight.SelectedIndex = (int)this.action.RightSensor;

            if (this.action.Operation == LogicOp.Or)
                this.rbOr.Checked = true;
        }

        protected override void SaveSettings()
        {
            ObstacleState upperLeft = (ObstacleState)Enum.ToObject(typeof(ObstacleState), this.cbUpperLeft.SelectedIndex);
            ObstacleState left = (ObstacleState)Enum.ToObject(typeof(ObstacleState), this.cbLeft.SelectedIndex);
            ObstacleState upperRight = (ObstacleState)Enum.ToObject(typeof(ObstacleState), this.cbUpperRight.SelectedIndex);
            ObstacleState right = (ObstacleState)Enum.ToObject(typeof(ObstacleState), this.cbRight.SelectedIndex);

            LogicOp operation = LogicOp.And;
            if (this.rbOr.Checked)
                operation = LogicOp.Or;

            this.action.UpdateSettings(upperLeft, left, upperRight, right, operation);
        }

        private void CbSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }

        private void RbOperator_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoSave)
                this.SaveSettings();
        }
    }
}
