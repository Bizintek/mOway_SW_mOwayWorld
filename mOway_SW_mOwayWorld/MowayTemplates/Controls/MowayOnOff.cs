using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Selector between two options for the MOwayWorld
    /// </summary>
    /// <LastRevision>25.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class MowayOnOff : UserControl
    {
        #region Constants

        /// <summary>
        /// Control height
        /// </summary>
        private const int ON_OFF_HEIGHT = 50;

        #endregion

        #region Attributes

        /// <summary>
        /// State of the control of OnOff
        /// </summary>
        private bool state = true;

        #endregion

        #region Properties

        /// <summary>
        /// State of the control of OnOff (On=true, Off=false)
        /// </summary>
        public bool State
        {
            set
            {
                if (this.state != value)
                {
                    this.state = value;
                    if (this.state)
                    {
                        this.bOn.Selected = true;
                        this.bOff.Selected = false;
                    }
                    else
                    {
                        this.bOn.Selected = false;
                        this.bOff.Selected = true;
                    }
                    if (this.StateChanged != null)
                        this.StateChanged(this, new EventArgs());
                }
            }
            get { return this.state; }
        }
        /// <summary>
        /// This property is redefined so that the height is always the same
        /// </summary>
        public new Size Size
        {
            set { base.Size = new Size(value.Width, ON_OFF_HEIGHT); }
            get { return base.Size; }
        }
        /// <summary>
        /// Text for the On label
        /// </summary>
        public string OnText
        {
            set { this.bOn.Text = value; }
            get { return this.bOn.Text; }
        }
        /// <summary>
        /// Text for the Off label
        /// </summary>
        public string OffText
        {
            set { this.bOff.Text = value; }
            get { return this.bOff.Text; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the control state changes
        /// </summary>
        public event EventHandler StateChanged;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public MowayOnOff()
        {
            InitializeComponent();
        }

        #region Redefining methods

        /// <summary>
        /// Draws the edge of the control
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF)
            {
                Graphics graph = this.CreateGraphics();
                graph.DrawRectangle(new Pen(new SolidBrush(MowayColors.Border), 2), base.ClientRectangle);
            }
        }

        #endregion

        #region Control events

        /// <summary>
        /// Activating the On option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOn_Click(object sender, EventArgs e)
        {
            if (!this.state)
            {
                this.state = true;
                this.bOn.Selected = true;
                this.bOff.Selected = false;
                if (this.StateChanged != null)
                    this.StateChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// Activating the Off option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BOff_Click(object sender, EventArgs e)
        {
            if (this.state)
            {
                this.state = false;
                this.bOn.Selected = false;
                this.bOff.Selected = true;
                if (this.StateChanged != null)
                    this.StateChanged(this, new EventArgs());
            }
        }

        #endregion
    }
}