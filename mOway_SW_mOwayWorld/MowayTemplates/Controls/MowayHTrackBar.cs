using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// TrackBar horizontal customized for mOwayWorld
    /// </summary>
    /// <LastRevision>25.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayHTrackBar : UserControl
    {
        #region Constants

        /// <summary>
        /// Maximum height for the contro
        /// </summary>
        private const int TRACK_HEIGHT = 12;

        #endregion

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
        /// Value of the TrackBar
        /// </summary>
        private int value = 0;
        /// <summary>
        /// Minimum value for TrackBar
        /// </summary>
        private int minimumValue = 0;
        /// <summary>
        /// Maximum value for the TrackBar
        /// </summary>
        private int maximumValue = 10;

        #endregion

        #region Properties

        /// <summary>
        /// This property is redefined so that the height is always the same
        /// </summary>
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = new Size(value.Width, TRACK_HEIGHT); }
        }
        /// <summary>
        /// This property is redefined because you have to update the background color of the thumb
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                if (this.Enabled)
                    this.thumb.BackColor = MowayColors.Border;
                else
                    this.thumb.BackColor = MowayColors.DisableBorder;
            }
        }
        /// <summary>
        /// Value of the TrackBar
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
                if ((this.value != value) && (value <= this.maximumValue) && (value >= this.minimumValue))
                {
                    this.value = value;
                    if (this.ValueChanged != null)
                        this.ValueChanged(this, new EventArgs());
                }
                this.thumb.Location = this.CalculeThumbLocation(this.value);
            }
        }
        /// <summary>
        /// Minimum value for TrackBar
        /// </summary>
        public int MinimumValue
        {
            get { return this.minimumValue; }
            set
            {
                if (value < this.maximumValue)
                {
                    this.minimumValue = value;
                    //It must update both the value of the scroll and the position of the thumb
                    if (this.value < this.minimumValue)
                    {
                        this.value = this.minimumValue;
                        if (this.ValueChanged != null)
                            this.ValueChanged(this, new EventArgs());
                    }
                    this.thumb.Location = this.CalculeThumbLocation(this.value);
                }
            }
        }
        /// <summary>
        /// Maximum value for the TrackBar
        /// </summary>
        public int MaximumValue
        {
            get { return this.maximumValue; }
            set
            {
                if (value > this.minimumValue)
                {
                    this.maximumValue = value;
                    //It must update both the value of the TrackBar as the Thumb position
                    if (this.value > this.maximumValue)
                    {
                        this.value = this.maximumValue;
                        if (this.ValueChanged != null)
                            this.ValueChanged(this, new EventArgs());
                    }
                    this.thumb.Location = this.CalculeThumbLocation(this.value);
                }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the value represented by the TrackBar changes
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayHTrackBar()
        {
            InitializeComponent();
        }

        #region Redefining methods

        /// <summary>
        /// This method is rewritten to paint the top and bottom lines
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.Enabled)
            {
                e.Graphics.DrawLine(new Pen(new SolidBrush(MowayColors.Border), 3), new Point(0, 0), new Point(this.Width, 0));
                e.Graphics.DrawLine(new Pen(new SolidBrush(MowayColors.Border), 3), new Point(0, this.Height - 1), new Point(this.Width, this.Height - 1));
            }
            else
            {
                e.Graphics.DrawLine(new Pen(new SolidBrush(MowayColors.DisableBorder), 3), new Point(0, 0), new Point(this.Width, 0));
                e.Graphics.DrawLine(new Pen(new SolidBrush(MowayColors.DisableBorder), 3), new Point(0, this.Height - 1), new Point(this.Width, this.Height - 1));
            }
        }

        #endregion

        #region Control events

        /// <summary>
        /// Down Event for left button del ratón
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
        /// Event of movement of the mouse on the thumb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thumb_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.thumbSelect)
            {
                int xLocation = this.thumb.Location.X + e.X - this.thumbMouseDisplacement.X;
                if (xLocation > this.Width - this.thumb.Width)
                    this.value = this.maximumValue;
                else if (xLocation < 0)
                    this.value = this.minimumValue;
                else
                    this.value = ((xLocation * (this.maximumValue - this.minimumValue)) / (this.Width - this.thumb.Width)) + this.minimumValue;
                this.thumb.Location = this.CalculeThumbLocation(this.value);
                if (this.ValueChanged != null)
                    this.ValueChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Left mouse button release event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Thumb_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.thumbSelect = false;
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
            double availableWidth = this.Width - this.thumb.Width;
            return new Point(Convert.ToInt32((availableWidth / (this.maximumValue - this.minimumValue)) * (this.value - this.minimumValue)), 3);
        }

        #endregion
    }
}
