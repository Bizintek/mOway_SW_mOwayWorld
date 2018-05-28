using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Selection button for toolbar
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class ToolBarButtonSelector : ToolBarButton
    {
        #region Attributes

        /// <summary>
        /// Button selection Status
        /// </summary>
        private bool selected = false;
        /// <summary>
        /// Indicates whether or not the deselection event is generated
        /// </summary>
        private bool noEventDeselect = false;

        #endregion

        #region Properties

        public new bool Enabled
        {
            get { return base.Enabled; }
            set { if (base.Enabled != value)
                base.Enabled = value; 
                if ((base.enabled) && (this.Selected))
                {
                    this.BackgroundImage = ToolBarGraphics.bg_normal_selected;
                    base.ImageIndex = 3;
                }
            }
        }
        /// <summary>
        /// Selection state of the button
        /// </summary>
        public bool Selected
        {
            set
            {
                if (this.selected != value)
                {
                    this.selected = value;
                    if (!this.selected)
                    {
                        this.BackgroundImage = ToolBarGraphics.bg_normal;
                        base.ImageIndex = 0;
                    }
                    else
                    {
                        this.BackgroundImage = ToolBarGraphics.bg_normal_selected;
                        base.ImageIndex = 3;
                    }
                }
            }
            get { return this.selected; }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when button selection status changes
        /// </summary>
        public event EventHandler SelectedChanged;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public ToolBarButtonSelector()
        {
        }

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="imageList">List of button images</param>
        /// <param name="toolTipText">ToolTip for the button</param>
        /// <param name="selected">Selection state of the button</param>
        public ToolBarButtonSelector(ImageList imageList, string toolTipText, bool selected)
            : base(imageList, toolTipText)
        {
            InitializeComponent();
            this.selected = selected;
            if (this.selected)
            {
                this.BackgroundImage = ToolBarGraphics.bg_normal_selected;
                base.ImageIndex = 3;
            }
        }

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="imageList">List of button images</param>
        /// <param name="toolTipText">ToolTip for the button</param>
        /// <param name="selected">Selection state of the button</param>
        /// <param name="noEventDeselect">Indicates whether the button generates event when deselected</param>
        public ToolBarButtonSelector(ImageList imageList, string toolTipText, bool selected, bool noEventDeselect)
            : base(imageList, toolTipText)
        {
            InitializeComponent();
            this.selected = selected;
            this.noEventDeselect = noEventDeselect;
            if (this.selected)
            {
                this.BackgroundImage = ToolBarGraphics.bg_normal_selected;
                base.ImageIndex = 3;
            }
        }

        #region Control events

        /// <summary>
        /// Overwrites the action of clicking on the button for the redeployment of the 
        /// Selected Property
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            if (this.enabled)
            {
                if (!this.selected)
                {
                    if (this.SelectedChanged != null)
                        this.SelectedChanged(this, new EventArgs());
                    this.selected = true;
                }
                else
                    if (!this.noEventDeselect)
                    {
                        if (this.SelectedChanged != null)
                            this.SelectedChanged(this, new EventArgs());
                        this.selected = false;
                    }
            }
        }

        /// <summary>
        /// Generates the effect when the mouse enters the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ToolBarButton_MouseEnter(object sender, EventArgs e)
        {
            if (enabled)
                if (!this.selected)
            {
                this.BackgroundImage = ToolBarGraphics.bg_over;
                base.ImageIndex = 0;
            }
                else
            {
                this.BackgroundImage = ToolBarGraphics.bg_over_selected;
                base.ImageIndex = 3;
            }
        }

        /// <summary>
        /// Generates the effect when the mouse comes out of the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ToolBarButton_MouseLeave(object sender, EventArgs e)
        {
            if (enabled)
            {
                if (!this.selected)
                {
                    this.BackgroundImage = ToolBarGraphics.bg_normal;
                    base.ImageIndex = 0;
                }
                else
                {
                    this.BackgroundImage = ToolBarGraphics.bg_normal_selected;
                    base.ImageIndex = 3;
                }
            }
        }

        /// <summary>
        /// Generates the effect when the mouse is pressed over the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ToolBarButton_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (enabled))
            {
                if (!this.selected)
                {
                    this.BackgroundImage = ToolBarGraphics.bg_down;
                    base.ImageIndex = 1;
                }
                else
                {
                    this.BackgroundImage = ToolBarGraphics.bg_down_selected;
                    base.ImageIndex = 4;
                }
            }
        }

        /// <summary>
        /// Generates the effect when the mouse is pushed over the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ToolBarButton_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (enabled) && (this.RectangleToScreen(this.ClientRectangle).Contains(Control.MousePosition)))
            {
                if (!this.selected)
                {
                    this.BackgroundImage = ToolBarGraphics.bg_over;
                    base.ImageIndex = 0;
                }
                else
                {
                    this.BackgroundImage = ToolBarGraphics.bg_over_selected;
                    base.ImageIndex = 3;
                }
            }
        }

        #endregion
    }
}
