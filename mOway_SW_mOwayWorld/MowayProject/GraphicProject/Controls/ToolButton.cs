using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.Actions;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Represents a selection button for an action
    /// </summary>
    public partial class ToolButton : Button
    {
        #region Attributes

        /// <summary>
        /// Tool to which the button represents
        /// </summary>
        private Tool tool;

        #endregion

        #region Events

        /// <summary>
        /// Start the insert operation
        /// </summary>
        public event ToolEventHandler InitInsert;
        /// <summary>
        /// Performs the insert operation
        /// </summary>
        public event PointEventHandler DoInsert;
        /// <summary>
        /// Cancels the insert operation
        /// </summary>
        public event EventHandler CancelInsert;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="tool">Action the button represents</param>
        /// <param name="settings">Group settings for button colors</param>
        public ToolButton(Tool tool, CategoryColorSettings settings)
            : base()
        {
            InitializeComponent();
            //To fit the control to the Linux version
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                this.Font = new System.Drawing.Font("Sans", 8.25F, System.Drawing.FontStyle.Regular);

            //The appearance of the control is set
            this.BackColor = settings.BackColor;
            this.FlatAppearance.MouseOverBackColor = settings.ActionButtonOverColor;
            this.FlatAppearance.MouseDownBackColor = settings.ActionButtonOverColor;
            //To avoid the focus effect
            this.SetStyle(ControlStyles.Selectable, false);
            //Saves the action to which the button represents and displays the text and image
            this.tool = tool;
            this.Text = this.tool.Text;
            this.Image = this.tool.Icon;

        }

        /// <summary>
        /// Builder for the daughter GroupButton class
        /// </summary>
        /// <param name="settings">Group settings for button colors</param>
        protected ToolButton(CategoryColorSettings settings)
        {
            InitializeComponent();

            //To fit the control to the Linux version
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                this.Font = new System.Drawing.Font("Sans", 8.25F, System.Drawing.FontStyle.Regular);

            //The appearance of the control is set
            this.BackColor = settings.BackColor;
            this.FlatAppearance.MouseOverBackColor = settings.ActionButtonOverColor;
            this.FlatAppearance.MouseDownBackColor = settings.ActionButtonOverColor;
            //To avoid the focus effect
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// To avoid the effect of the focus on the button
        /// </summary>
        protected override bool ShowFocusCues { get { return false; } }

        /// <summary>
        /// Pressing the right mouse button launches the event to start the insert operation.
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if ((mevent.Button == MouseButtons.Left) && (this.InitInsert != null))
                    this.InitInsert(this, new ToolEventArgs(this.tool));
            else if (this.CancelInsert != null)
                    this.CancelInsert(this, new EventArgs());
        }

        /// <summary>
        /// Releasing the right mouse button launches the event to perform the insert operation
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if ((mevent.Button == MouseButtons.Left) && (this.DoInsert != null))
                this.DoInsert(this, new PointEventArgs(this.PointToScreen(mevent.Location)));
        }
    }
}
