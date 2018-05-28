using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// ComboBox customized for mOwayWorld
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayComboBox : ComboBox
    {
        #region Attributes

        /// <summary>
        /// Saves the previously selected item so that you can undo the control
        /// </summary>
        private int previousSelectedIndex = -1;
        /// <summary>
        /// Saves the currently selected item so that you can undo the control
        /// </summary>
        private int presentSelectedIndex = -1;

        #endregion

        #region Properties

        /// <summary>
        /// The Enabled property is rewritten to be able to specify the background color
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                if (base.Enabled)
                    this.BackColor = Color.White;
                else
                    this.BackColor = SystemColors.Control;
            }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayComboBox()
        {
            InitializeComponent();
        }

        #region Public methods

        /// <summary>
        /// Undo the last selection of items
        /// </summary>
        public void Undo()
        {
            this.SelectedIndex = this.previousSelectedIndex;
        }

        #endregion

        #region Rewritten methods

        /// <summary>
        /// It is generated when the selected items change.
        /// It updates the selection indexes to be able to do the Undo
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            this.previousSelectedIndex = this.presentSelectedIndex;
            this.presentSelectedIndex = this.SelectedIndex;
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Paints the appearance of the control
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF)
            {
                Graphics graph = this.CreateGraphics();
                if (!this.Enabled)
                    graph.DrawRectangle(new Pen(new SolidBrush(MowayColors.DisableBackControl), 3), new Rectangle(2, 2, this.Width - 21, this.Height - 4));
                graph.DrawRectangle(new Pen(new SolidBrush(MowayColors.Border), 2), base.ClientRectangle);
                graph.DrawLine(new Pen(new SolidBrush(MowayColors.Border), 1), new Point(this.Width - 18, 0), new Point(this.Width - 18, this.Height));
                graph.FillRectangle(new SolidBrush(Color.FromArgb(193, 193, 193)), new Rectangle(new Point(this.Width - 17, 1), new Size(16, 20)));

                GraphicsPath pth = new GraphicsPath();
                PointF topLeft = new PointF(this.Width - 12.5F, 9.5F);
                PointF topRight = new PointF(this.Width- 5.5F, 9.5F);
                PointF bottom = new PointF(this.Width - 9, 13);
                pth.AddLine(topLeft, topRight);
                pth.AddLine(topRight, bottom);

                graph.SmoothingMode = SmoothingMode.HighQuality;

                if (this.Enabled)
                    graph.FillPath(new SolidBrush(Color.Black), pth);
                else
                    graph.FillPath(new SolidBrush(Color.FromArgb(97, 97, 97)), pth);

            }
        }

        /// <summary>
        /// Paints the items in the control
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                if (!this.Enabled)
                {
                    e.Graphics.FillRectangle(new SolidBrush(MowayColors.DisableBackControl), e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, new SolidBrush(MowayColors.DisableText), e.Bounds);
                }
                else if (!this.Focused)
                {
                    e.Graphics.FillRectangle(new SolidBrush(MowayColors.BackControl), e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, new SolidBrush(MowayColors.Text), e.Bounds);
                }
                else if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                {
                    e.Graphics.FillRectangle(new SolidBrush(MowayColors.BackControl), e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, new SolidBrush(MowayColors.Text), e.Bounds);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(MowayColors.Selection), e.Bounds);
                    e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, new SolidBrush(MowayColors.Text), e.Bounds);
                }
                e.DrawFocusRectangle();
            }
        }

        #endregion
    }
}
