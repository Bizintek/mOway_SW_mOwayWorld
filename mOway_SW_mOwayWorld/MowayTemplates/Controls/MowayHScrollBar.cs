﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Horizontal scroll bar for MOwayWorld
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayHScrollBar : UserControl
    {
        #region Attributes

        /// <summary>
        /// Indicates whether the thumb is selected
        /// </summary>
        private bool thumbSelect = false;
        /// <summary>
        /// Saves the displacement between the position of the thumb and the position of the mouse
        /// </summary>
        private Point thumbMouseDisplacement;
        /// <summary>
        /// Timer to create the effect of button pressed continuously
        /// </summary>
        private Timer tScrollTimer = new Timer();
        /// <summary>
        /// Value of the ScrollBar
        /// </summary>
        private int value = 0;
        /// <summary>
        /// Maximum value for the ScrollBar
        /// </summary>
        private int maximumValue = 10;
        /// <summary>
        /// Change the value of the ScrollBar by clicking the buttons
        /// </summary>
        private int smallChange = 1;
        /// <summary>
        /// Change the value of the ScrollBar by clicking on the background of the bar
        /// </summary>
        private int largeChange = 5;

        #endregion

        #region Properties

        /// <summary>
        /// Value of the ScrollBar
        /// </summary>
        public int Value
        {
            get
            {
                if (this.Enabled)
                    return this.value;
                else
                    return 0;
            }
            set
            {
                if ((this.value != value) && (value <= this.maximumValue) && (value >= 0))
                {
                    this.value = value;
                    this.thumb.Location = this.CalculeThumbLocation(this.value);
                    if (this.ValueChanged != null)
                        this.ValueChanged(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// Maximum value for the ScrollBar
        /// </summary>
        public int MaximumValue
        {
            get { return this.maximumValue; }
            set
            {
                this.maximumValue = value;
                //It must update both the value of the scroll and the position of the thumb
                if (this.value > this.maximumValue)
                    this.value = this.maximumValue;
                this.thumb.Location = this.CalculeThumbLocation(this.value);
                if (this.ValueChanged != null)
                    this.ValueChanged(this, new EventArgs());
                if (this.ValueChanged != null)
                    this.ValueChanged(this, new EventArgs());
            }
        }
        /// <summary>
        /// Change the value of the ScrollBar by clicking the buttons
        /// </summary>
        public int SmallChange
        {
            get { return this.smallChange; }
            set { this.smallChange = value; }
        }
        /// <summary>
        /// Change the value of the ScrollBar by clicking on the background of the bar
        /// </summary>
        public int LargeChange
        {
            get { return this.largeChange; }
            set { this.largeChange = value; }
        }
        /// <summary>
        /// Enabling Control (redefined)
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                if (base.Enabled != value)
                {
                    base.Enabled = value;
                    //Set the status of the buttons and the thumb
                    this.leftButton.Enabled = this.Enabled;
                    this.rightButton.Enabled = this.Enabled;
                    this.thumb.Visible = this.Enabled;
                    if (this.ValueChanged != null)
                        this.ValueChanged(this, new EventArgs());
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Value of the ScrollBar change event
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayHScrollBar()
        {
            InitializeComponent();
            this.tScrollTimer.Tick += new EventHandler(TScrollTimer_Tick);
        }

        #region Redefining methods

        /// <summary>
        /// In the Resize event it must be recalculated the position of the thumb
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.maximumValue!= 0)
                this.thumb.Location = this.CalculeThumbLocation(this.value);
        }

        #endregion

        #region Graphic events

        /// <summary>
        /// Timer Tick event to generate the consecutive clicks of the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TScrollTimer_Tick(object sender, EventArgs e)
        {
            //The previous value is saved to make change only when there are actually
            int presentValue = this.value;
            //The value is updated depending on the button pressed
            if (this.leftButton.Focused)
            {
                this.value -= this.smallChange;
                if (this.value < 0)
                    this.value = 0;
            }
            else if (this.rightButton.Focused)
            {
                this.value += this.smallChange;
                if (this.value > this.maximumValue)
                    this.value = this.maximumValue;
            }
            //If the value of the scroll has been changed, the thumb is repositioned and the event is generated
            if (this.value != presentValue)
            {
                this.thumb.Location = this.CalculeThumbLocation(this.value);
                this.tScrollTimer.Interval = ScrollButton.WAIT_INTERVAL_TIME;
                if (this.ValueChanged != null)
                    this.ValueChanged(this, new EventArgs());
            }
            else
                //Otherwise, the timer is disabled
                this.tScrollTimer.Enabled = false;
        }

        /// <summary>
        /// Occurs when we click on the background of the scroll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HorizontalScroll_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((e.X > 19) && (e.X < this.thumb.Location.X))
                {
                    this.value -= this.largeChange;
                    if (this.value < 0)
                        this.value = 0;
                    this.thumb.Location = this.CalculeThumbLocation(this.value);
                }
                else if ((e.X < (this.Width - 19)) && (e.X > (this.thumb.Location.X + this.thumb.Width)))
                {
                    this.value += this.largeChange;
                    if (this.value > this.maximumValue)
                        this.value = this.maximumValue;
                    this.thumb.Location = this.CalculeThumbLocation(this.value);
                }
                if (this.ValueChanged != null)
                    this.ValueChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Down Event for left button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int presentValue = this.value;
                this.value -= this.smallChange;
                if (this.value < 0)
                    this.value = 0;
                if (this.value != presentValue)
                {
                    this.thumb.Location = this.CalculeThumbLocation(this.value);
                    this.tScrollTimer.Interval = ScrollButton.WAIT_INITIAL_TIME;
                    this.tScrollTimer.Enabled = true;
                    if (this.ValueChanged != null)
                        this.ValueChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Up event for left button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.tScrollTimer.Enabled = false;
        }

        /// <summary>
        /// Down event for the right button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int presentValue = this.value;
                this.value += this.smallChange;
                if (this.value > this.maximumValue)
                    this.value = this.maximumValue;
                if (this.value != presentValue)
                {
                    this.thumb.Location = this.CalculeThumbLocation(this.value);
                    this.tScrollTimer.Interval = ScrollButton.WAIT_INTERVAL_TIME;
                    this.tScrollTimer.Enabled = true;
                    if (this.ValueChanged != null)
                        this.ValueChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Up event for right button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.tScrollTimer.Enabled = false;
        }

        /// <summary>
        /// Down event for the thumb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thumb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.thumbMouseDisplacement = e.Location;
                this.thumbSelect = true;
            }
        }

        /// <summary>
        /// Up event for the thumb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thumb_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.thumbSelect = false;
        }

        /// <summary>
        /// Movement event for the thumb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thumb_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.thumbSelect)
            {
                int xLocation = this.thumb.Location.X + e.X - this.thumbMouseDisplacement.X;
                if (xLocation < 19)
                    this.value = 0;
                else if (xLocation > ((this.Width - 19) - this.thumb.Width))
                    this.value = this.maximumValue;
                else
                    this.value = ((xLocation - 19) * this.maximumValue) / (this.Width - this.thumb.Width - 38);
                this.thumb.Location = this.CalculeThumbLocation(this.value);
                if (this.ValueChanged != null)
                    this.ValueChanged(this, new EventArgs());
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Calculates the position of the thumb based on a given value
        /// </summary>
        /// <param name="value">Value of the Scroll</param>
        /// <returns>Thumb position</returns>
        private Point CalculeThumbLocation(int value)
        {
            //It is necessary to calculate the position well for the maximum value
            double availableHeight = this.Width - this.thumb.Width - 38;
            return new Point(Convert.ToInt32(((availableHeight / this.maximumValue) * this.value) + 19), 2);
        }

        #endregion
    }
}
