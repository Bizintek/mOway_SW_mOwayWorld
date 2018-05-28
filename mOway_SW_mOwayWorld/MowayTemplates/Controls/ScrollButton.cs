using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Represents each one of the buttons in a scroll
    /// </summary>
    internal partial class ScrollButton : Button
    {
        #region Constants

        /// <summary>
        /// Initial timeout to make consecutive clicks
        /// </summary>
        public const int WAIT_INITIAL_TIME = 500;
        /// <summary>
        /// Timeout for consecutive click intervals
        /// </summary>
        public const int WAIT_INTERVAL_TIME = 100;

        #endregion

        #region Properties

        /// <summary>
        /// Button enabling (overwritten property)
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                //It updates the background color of the button
                if (value)
                    this.BackColor = Color.FromArgb(207, 207, 207);
                else
                    this.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public ScrollButton()
        {
            InitializeComponent();
            //To avoid the focus effect
            this.SetStyle(ControlStyles.Selectable, false);
        }
    }
}
