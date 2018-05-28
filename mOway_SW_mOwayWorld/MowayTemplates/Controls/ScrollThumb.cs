using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Represents the scroll bar of a scroll
    /// </summary>
    internal partial class ScrollThumb : Button
    {
        public ScrollThumb()
        {
            InitializeComponent();
            //To avoid the focus effect
            this.SetStyle(ControlStyles.Selectable, false);
        }

        /// <summary>
        /// Update the BackColor of the button when pressed with the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollThumb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.BackColor = Color.FromArgb(220, 220, 220);
        }

        /// <summary>
        /// Update the BackColor of the button when pressed with the mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrollThumb_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.BackColor = Color.FromArgb(207, 207, 207);
        }

        /// <summary>
        /// Event that paints the button (overwritten)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.ClipRectangle);
        }
    }
}
