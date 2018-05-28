using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Template.Controls
{
    /// <summary>
    /// Selector for the panels of a ShareBox.
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class SharePanelSelector : Panel
    {
        #region Constants

        /// <summary>
        /// Height of the selector
        /// </summary>
        private const int BUTTON_HEIGHT = 30;
        /// <summary>
        /// Colors for the selector
        /// </summary>
        private readonly Color[] colors = new Color[] { Color.FromArgb(234, 234, 234), Color.FromArgb(250, 250, 250) };

        #endregion

        #region Attributes

        /// <summary>
        /// List of images for the selector
        /// </summary>
        private ImageList imageList;
        /// <summary>
        /// Selection state of the selector
        /// </summary>
        private bool selected = false;

        #endregion

        #region Properties

        /// <summary>
        /// Selector size
        /// </summary>
        public new Size Size
        {
            set { base.Size = new Size(value.Width, BUTTON_HEIGHT); }
            get { return base.Size; }
        }
        /// <summary>
        /// Selector text
        /// </summary>
        public new string Text
        {
            get { return this.lText.Text; }
            set{this.lText.Text = value;}
        }
        /// <summary>
        /// ToolTip for the selector
        /// </summary>
        public string ToolTip
        {
            set { this.toolTip.SetToolTip(this.lText, value); }
        }
        /// <summary>
        /// Images for the selector
        /// </summary>
        public ImageList ImageList
        {
            get { return this.imageList; }
            set { this.imageList = value; }
        }
        /// <summary>
        /// Selection state of the selector
        /// </summary>
        public bool Selected
        {
            get { return this.selected; }
            set
            {
                this.selected = value;
                try
                {
                    if (this.selected)
                    {
                        this.BackgroundImage = this.imageList.Images[0];
                        this.lText.BackColor = this.colors[0];
                        this.BringToFront();
                    }
                    else
                    {
                        this.BackgroundImage = this.imageList.Images[1];
                        this.lText.BackColor = this.colors[1];
                    }
                }
                catch { }
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the selector has been selected
        /// </summary>
        public event EventHandler SelectorSelected;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public SharePanelSelector()
        {
            InitializeComponent();
        }

        #region Control event

        /// <summary>
        /// Press on the selector label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LText_Click(object sender, EventArgs e)
        {
            //If the control is not selected, selects and launches the event
            if (!this.selected)
            {
                this.Selected = true;
                if (this.SelectorSelected != null)
                    this.SelectorSelected(this, new EventArgs());
            }
        }

        #endregion
    }
}
