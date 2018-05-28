using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.Actions.Line
{
    public partial class LineForm : ActionForm
    {
        #region Attributes

        private LineAction action;

        #endregion

        public LineForm(LineAction action)
        {
            InitializeComponent();
            this.helpTopic = Line.HelpTopic;

            //The action is saved in order to save the changes
            this.action = action;
        }

        #region Private methods

        protected override void LoadSettings()
        {
            this.cbLeft.SelectedIndex = (int)this.action.LeftSensor;
            this.cbRight.SelectedIndex = (int)this.action.RightSensor;

            if (this.action.Operation == LogicOp.Or)
                this.rbOr.Checked = true;
        }

        protected override void SaveSettings()
        {
            LineState left = (LineState)Enum.ToObject(typeof(LineState), this.cbLeft.SelectedIndex);
            LineState right = (LineState)Enum.ToObject(typeof(LineState), this.cbRight.SelectedIndex);

            LogicOp operation = LogicOp.And;
            if (this.rbOr.Checked)
                operation = LogicOp.Or;

            this.action.UpdateSettings(left, right, operation);
        }

        #endregion

        private void CbLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbLeft.SelectedIndex)
            {
                case (int)LineState.Inactive:
                    this.pbLeftLine.Image = Line.leftGrey;
                    break;
                case (int)LineState.Black:
                    this.pbLeftLine.Image = Line.leftBlack;
                    break;
                case (int)LineState.White:
                    this.pbLeftLine.Image = Line.leftWhite;
                    break;
            }
            this.GenerateMessage();
        }

        private void CbRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbRight.SelectedIndex)
            {
                case (int)LineState.Inactive:
                    this.pbRightLine.Image = Line.rightGrey;
                    break;
                case (int)LineState.Black:
                    this.pbRightLine.Image = Line.rightBlack;
                    break;
                case (int)LineState.White:
                    this.pbRightLine.Image = Line.rightWhite;
                    break;
            }
            this.GenerateMessage();
        }

        private void GenerateMessage()
        {
            if ((this.cbLeft.SelectedIndex == (int)LineState.Inactive) && (this.cbRight.SelectedIndex == (int)LineState.Inactive))
                this.tbOutput.Text = LineMessages.ALWAYS_TRUE;
            else
            {
                this.tbOutput.Text = LineMessages.TRUE + " - " + LineMessages.IF;
                bool requireOp = false;
                if (this.cbLeft.SelectedIndex != (int)LineState.Inactive)
                {
                    this.tbOutput.Text += " ";
                    requireOp = true;
                    this.tbOutput.Text += LineMessages.LEFT_SENSOR + " ";
                    if (this.cbLeft.SelectedIndex == (int)LineState.White)
                        this.tbOutput.Text += LineMessages.DETECT_WHITE;
                    else
                        this.tbOutput.Text += LineMessages.DETECT_BLACK;
                }
                if (this.cbRight.SelectedIndex != (int)LineState.Inactive)
                {
                    if (requireOp)
                        if (this.rbAnd.Checked)
                            this.tbOutput.Text += " " + LineMessages.AND + " ";
                        else
                            this.tbOutput.Text += " " + LineMessages.OR + " ";
                    else
                    {
                        this.tbOutput.Text += " ";
                        requireOp = true;
                    }
                    this.tbOutput.Text += LineMessages.RIGHT_SENSOR + " ";
                    if (this.cbRight.SelectedIndex == (int)LineState.White)
                        this.tbOutput.Text += LineMessages.DETECT_WHITE;
                    else
                        this.tbOutput.Text += LineMessages.DETECT_BLACK;
                }

                this.tbOutput.Text += ".\r\n" + LineMessages.FALSE + " - " + LineMessages.OTHERWISE;
            }
        }

        private void RbAnd_CheckedChanged(object sender, EventArgs e)
        {
            this.GenerateMessage();
        }

    }
}
