using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Represents the scroll bar of a TrackBar
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    internal partial class TrackThumb : Button
    {
        #region Properties

        /// <summary>
        /// Control room
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                if (this.Enabled)
                    this.BackColor = Color.FromArgb(153, 153, 153);
                else
                    this.BackColor = Color.FromArgb(207, 207, 207);
            }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public TrackThumb()
        {
            InitializeComponent();
            //To avoid the focus effect
            this.SetStyle(ControlStyles.Selectable, false);
        }

        #region Graphic events

        /// <summary>
        /// Update the BackColor of the button when pressed with the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollThumb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.BackColor = Color.FromArgb(166, 166, 166);
        }

        /// <summary>
        /// Update the BackColor of the button when the mouse is released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollThumb_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.BackColor = Color.FromArgb(153, 153, 153);
        }

        /// <summary>
        /// Event that paints the button (overwritten)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.ClipRectangle);
        }

        #endregion
    }
}
