using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;

using SdlDotNet.Graphics;

namespace Moway.Project.GraphicProject.Actions.Obstacle
{
    public partial class ObstacleForm : ActionForm
    {
        #region Attributes

        private ObstacleAction action;

        #endregion

        public ObstacleForm(ObstacleAction action)
        {
            InitializeComponent();
            this.helpTopic = Obstacle.HelpTopic;
this.action = action;
        }

        #region Private methods

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

        #endregion

        private void CbSensor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pbMoway.Image = this.pbMoway.InitialImage;
            Surface temp = new Surface(Obstacle.background);

            switch (this.cbLeft.SelectedIndex)
            {
                case (int)ObstacleState.Inactive:
                    temp.Blit(new Surface(Obstacle.no_cheq_left_side), new Point(7, 56));
                    break;
                case (int)ObstacleState.Detect:
                    temp.Blit(new Surface(Obstacle.obst_left_side), new Point(7, 56));
                    break;
                case (int)ObstacleState.NoDetect:
                    temp.Blit(new Surface(Obstacle.no_obst_left_side), new Point(7, 56));
                    break;
            }
            switch (this.cbUpperLeft.SelectedIndex)
            {
                case (int)ObstacleState.Inactive:
                    temp.Blit(new Surface(Obstacle.no_cheq_left_centr), new Point(20, 0));
                    break;
                case (int)ObstacleState.Detect:
                    temp.Blit(new Surface(Obstacle.obst_left_centr), new Point(20, 0));
                    break;
                case (int)ObstacleState.NoDetect:
                    temp.Blit(new Surface(Obstacle.no_obst_left_centr), new Point(20, 0));
                    break;
            }
            switch (this.cbUpperRight.SelectedIndex)
            {
                case (int)ObstacleState.Inactive:
                    temp.Blit(new Surface(Obstacle.no_cheq_right_centr), new Point(92, 0));
                    break;
                case (int)ObstacleState.Detect:
                    temp.Blit(new Surface(Obstacle.obst_right_centr), new Point(92, 0));
                    break;
                case (int)ObstacleState.NoDetect:
                    temp.Blit(new Surface(Obstacle.no_obst_right_centr), new Point(92, 0));
                    break;
            }
            switch (this.cbRight.SelectedIndex)
            {
                case (int)ObstacleState.Inactive:
                    temp.Blit(new Surface(Obstacle.no_cheq_right_side), new Point(126, 56));
                    break;
                case (int)ObstacleState.Detect:
                    temp.Blit(new Surface(Obstacle.obst_right_side), new Point(126, 56));
                    break;
                case (int)ObstacleState.NoDetect:
                    temp.Blit(new Surface(Obstacle.no_obst_right_side), new Point(126, 56));
                    break;
            }
            this.pbMoway.Blit(temp);

            //The message is generated
            this.GenerateMessage();

        }

        private void GenerateMessage()
        {
            if ((this.cbLeft.SelectedIndex == (int)ObstacleState.Inactive) && (this.cbUpperLeft.SelectedIndex == (int)ObstacleState.Inactive) && (this.cbRight.SelectedIndex == (int)ObstacleState.Inactive) && (this.cbUpperRight.SelectedIndex == (int)ObstacleState.Inactive))
                this.tbOutput.Text = ObstacleMessages.ALWAYS_TRUE;
            else
            {
                this.tbOutput.Text = ObstacleMessages.TRUE + " - " + ObstacleMessages.IF;
                bool requireOp = false;
                if (this.cbLeft.SelectedIndex != (int)ObstacleState.Inactive)
                {
                    this.tbOutput.Text += " ";
                    requireOp = true;
                    this.tbOutput.Text += ObstacleMessages.LEFT_SIDE_SENSOR + " ";
                    if (this.cbLeft.SelectedIndex == (int)ObstacleState.Detect)
                        this.tbOutput.Text += ObstacleMessages.DETECT;
                    else
                        this.tbOutput.Text += ObstacleMessages.NOT_DETECT;
                }
                if (this.cbUpperLeft.SelectedIndex != (int)ObstacleState.Inactive)
                {
                    if (requireOp)
                        if (this.rbAnd.Checked)
                            this.tbOutput.Text += " " + ObstacleMessages.AND + " ";
                        else
                            this.tbOutput.Text += " " + ObstacleMessages.OR + " ";
                    else
                    {
                        this.tbOutput.Text += " ";
                        requireOp = true;
                    }
                    this.tbOutput.Text += ObstacleMessages.LEFT_CENTRAL_SENSOR + " ";
                    if (this.cbUpperLeft.SelectedIndex == (int)ObstacleState.Detect)
                        this.tbOutput.Text += ObstacleMessages.DETECT;
                    else
                        this.tbOutput.Text += ObstacleMessages.NOT_DETECT;
                }
                if (this.cbUpperRight.SelectedIndex != (int)ObstacleState.Inactive)
                {
                    if (requireOp)
                        if (this.rbAnd.Checked)
                            this.tbOutput.Text += " " + ObstacleMessages.AND + " ";
                        else
                            this.tbOutput.Text += " " + ObstacleMessages.OR + " ";
                    else
                    {
                        this.tbOutput.Text += " ";
                        requireOp = true;
                    }
                    this.tbOutput.Text += ObstacleMessages.RIGHT_CENTRAL_SENSOR + " ";
                    if (this.cbUpperRight.SelectedIndex == (int)ObstacleState.Detect)
                        this.tbOutput.Text += ObstacleMessages.DETECT;
                    else
                        this.tbOutput.Text += ObstacleMessages.NOT_DETECT;
                }
                if (this.cbRight.SelectedIndex != (int)ObstacleState.Inactive)
                {
                    if (requireOp)
                        if (this.rbAnd.Checked)
                            this.tbOutput.Text += " " + ObstacleMessages.AND + " ";
                        else
                            this.tbOutput.Text += " " + ObstacleMessages.OR + " ";
                    else
                    {
                        this.tbOutput.Text += " ";
                        requireOp = true;
                    }
                    this.tbOutput.Text += ObstacleMessages.RIGHT_SIDE_SENSOR + " ";
                    if (this.cbRight.SelectedIndex == (int)ObstacleState.Detect)
                        this.tbOutput.Text += ObstacleMessages.DETECT;
                    else
                        this.tbOutput.Text += ObstacleMessages.NOT_DETECT;
                }

                this.tbOutput.Text += ".\r\n" + ObstacleMessages.FALSE + " - " + ObstacleMessages.OTHERWISE;
            }
        }

        private void RbAnd_CheckedChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }       
    }
}
