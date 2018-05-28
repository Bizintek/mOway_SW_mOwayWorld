using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Selection button for MowayOnOff control
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    internal partial class OnOffButton : Button
    {
        #region Attributes

        /// <summary>
        /// Indicates if the button is selected
        /// </summary>
        private bool selected = false;

        #endregion

        #region Properties

        /// <summary>
        /// Indicates whether the control is selected
        /// </summary>
        public bool Selected
        {
            set
            {
                this.selected = value;
                this.UpdateButton();
            }
            get { return this.selected; }
        }

        #endregion

        public OnOffButton()
        {
            InitializeComponent();
            //To avoid the effect of focus
            this.SetStyle(ControlStyles.Selectable, false);
        }

        #region Private methods

        /// <summary>
        /// Update the colors of the control
        /// </summary>
        private void UpdateButton()
        {
            if (this.selected)
            {
                this.ForeColor = MowayColors.Text;
                this.BackColor = Color.FromArgb(207, 207, 207);
                this.FlatAppearance.MouseOverBackColor = Color.FromArgb(207, 207, 207);
                this.FlatAppearance.MouseDownBackColor = Color.FromArgb(207, 207, 207);
            }
            else
            {
                this.ForeColor = MowayColors.DisableText;
                this.BackColor = Color.FromArgb(255, 255, 255);
                this.FlatAppearance.MouseOverBackColor = Color.FromArgb(222, 222, 222);
                this.FlatAppearance.MouseDownBackColor = Color.FromArgb(222, 222, 222);
            }
        }

        #endregion
    }
}
