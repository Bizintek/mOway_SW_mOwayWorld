using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Selector for the controls of tabs
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class TabButton : Button
    {
        #region Attributes

        /// <summary>
        /// Selection state of the control
        /// </summary>
        protected bool selected = false;

        #endregion

        #region Properties

        /// <summary>
        ///Selection state of the control
        /// </summary>
        public bool Selected
        {
            get { return this.selected; }
            set { }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public TabButton()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, false);
        }

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="text">Text to display in the TabButton</param>
        public TabButton(string text)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, false);
            this.Text = text;
        }

        #region Redefining methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath Line = new GraphicsPath();
            if (this.selected)
            {
                Line.AddLines(new Point[] { new Point(0, this.Height), new Point(0, 0), new Point(this.Width - 10, 0), new Point(this.Width, 10), new Point(this.Width, this.Height), new Point(0, this.Height) });
                e.Graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(153, 153, 153)), 2), new Point[] { new Point(1, this.Height), new Point(1, 1), new Point(this.Width - 11, 1), new Point(this.Width - 1, 11), new Point(this.Width - 1, this.Height) });
            }
            else
            {
                Line.AddLines(new Point[] { new Point(0, this.Height), new Point(0, 2), new Point(this.Width - 10, 2), new Point(this.Width, 12), new Point(this.Width, this.Height), new Point(0, this.Height) });
                e.Graphics.DrawLines(new Pen(new SolidBrush(Color.FromArgb(180, 180, 180)), 2), new Point[] { new Point(1, this.Height - 1), new Point(1, 3), new Point(this.Width - 11, 3), new Point(this.Width - 1, 13), new Point(this.Width - 1, this.Height - 1) });
                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(153, 153, 153)), 2), new Point(0, this.Height - 1), new Point(this.Width, this.Height - 1));
            }
            this.Region = new Region(Line);
        }

        #endregion
    }
}
