using System;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Represents the specific button of the toolbar
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class ToolBarButton : Button, IToolBarItem
    {
        #region Attributes

        /// <summary>
        /// Fully Enabled property is redeployed
        /// </summary>
        protected bool enabled = true;

        #endregion

        #region Properties

        /// <summary>
        /// Text to display in the ToolTip for the button
        /// </summary>
        public string ToolTipText
        {
            set
            {
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(this, value);
            }
        }
        /// <summary>
        /// Enables or disables the button (overloaded property)
        /// </summary>
        public new bool Enabled
        {
            get { return this.enabled; }
            set
            {
                this.BackgroundImage = ToolBarGraphics.bg_normal;
                if (value)
                    base.ImageIndex = 0;
                else
                    base.ImageIndex = 2;
                this.enabled = value;
            }
        }
        /// <summary>
        /// Button Image index
        /// </summary>
        public new int ImageIndex
        {
            get { return base.ImageIndex; }
            set
            {
                if (this.enabled)
                    base.ImageIndex = value;
            }
        }
        /// <summary>
        /// To avoid the effect of the focus on the button
        /// </summary>
        protected override bool ShowFocusCues { get { return false; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public ToolBarButton()
        {
            InitializeComponent();
            //To avoid the effect of the focus
            this.SetStyle(ControlStyles.Selectable, false);
        }

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="_name">Name of the button</param>
        /// <param name="_toolTipText">ToolTip text</param>
        /// <param name="_buttonImages">Images for the button</param>
        public ToolBarButton(ImageList imageList, string toolTipText)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.Selectable, false);
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this, toolTipText);
            this.ImageList = imageList;
        }

        #region Control events

        /// <summary>
        /// Overwrites the action of clicking on the button for the redeployment of the 
        /// Enabled Property
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            if (this.enabled)
                base.OnClick(e);
        }

        /// <summary>
        /// Generates the effect when the mouse enters the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ToolBarButton_MouseEnter(object sender, EventArgs e)
        {
            if (enabled)
            {
                this.BackgroundImage = ToolBarGraphics.bg_over;
                base.ImageIndex = 0;
            }
        }

        /// <summary>
        /// Genera el efecto cuando sale el ratón del control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ToolBarButton_MouseLeave(object sender, EventArgs e)
        {
            if (enabled)
            {
                this.BackgroundImage = ToolBarGraphics.bg_normal;
                base.ImageIndex = 0;
            }
        }

        /// <summary>
        /// Generates the effect when the mouse is pressed over the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ToolBarButton_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (enabled))
            {
                this.BackgroundImage = ToolBarGraphics.bg_down;
                base.ImageIndex = 1;
            }
        }

        /// <summary>
        /// Generates the effect when the mouse is pushed over the control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ToolBarButton_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (enabled) && (this.RectangleToScreen(this.ClientRectangle).Contains(Control.MousePosition)))
            {
                this.BackgroundImage = ToolBarGraphics.bg_over;
                base.ImageIndex = 0;
            }
        }

        #endregion
    }
}
