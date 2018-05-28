using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Actions;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// It represents to the emergent panel that shows tools
    /// </summary>
    public partial class ToolGroupPanel : Panel
    {
        #region Constants

        private const int INIT_X = 4;
        private const int INIT_Y = 4;
        private const int BUTTON_WIDTH = 144;

        #endregion

        #region Attributes

        /// <summary>
        /// A border color is saved for panel redraw
        /// </summary>
        private Color borderColor;

        #endregion

        #region Events
        
        public event ToolEventHandler InitInsert;
        public event PointEventHandler DoInsert;
        public event EventHandler CancelInsert;
        /// <summary>
        /// Indicates whether the mouse is or is not inside the panel
        /// </summary>
        public bool mouseInto = false;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="tools">List of tools to display in the panel</param>
        /// <param name="settings">Configuration of the group for the visual part</param>
        public ToolGroupPanel(List<Tool> tools, CategoryColorSettings settings)
        {
            InitializeComponent();
            this.BackColor = settings.BackColor;
            this.borderColor = settings.ActionButtonOverColor;
            //To avoid the effect of the button being selected
            this.SetStyle(ControlStyles.UserPaint, true);
            //Shows 1 button for each tool
            for (int i = 0; i < tools.Count; i++)
            {
                ToolButton button = new ToolButton(tools[i], settings);
                button.InitInsert += new ToolEventHandler(Button_InitInsert );
                button.DoInsert += new PointEventHandler(Button_DoInsert);
                button.CancelInsert += new EventHandler(Button_CancelInsert);
                button.MouseEnter += new EventHandler(Button_MouseEnter);
                button.MouseLeave += new EventHandler(Button_MouseLeave);
                button.Location = new Point(INIT_X, INIT_Y + (i * ToolPanel.BUTTON_SEPARATION));
                button.Size = new Size(BUTTON_WIDTH, button.Height);
                this.toolTip.SetToolTip(button, tools[i].ToolTipText);
                this.Controls.Add(button);
            }
            //The size of the panel is dynamically calculated
            this.Size = new Size(this.Width, INIT_Y+3 + (tools.Count * ToolPanel.BUTTON_SEPARATION));
        }

        /// <summary>
        /// Redirects the action selection event of the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button_InitInsert(object sender, ToolEventArgs e)
        {
            if (this.InitInsert != null)
                this.InitInsert(this, new ToolEventArgs(e.Tool, this.Parent.RectangleToScreen(this.Bounds)));
        }

        /// <summary>
        /// Redirects the action selection event of the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button_DoInsert(object sender, PointEventArgs e)
        {
            if (this.DoInsert != null)
                this.DoInsert(this, e);
        }

        void Button_CancelInsert(object sender, EventArgs e)
        {
            if (this.CancelInsert != null)
                this.CancelInsert(this, e);
        }


        /// <summary>
        /// Redirects the MouseLeave event from the buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button_MouseLeave(object sender, EventArgs e)
        {
            if (this.mouseInto)
            {
                Point position = this.PointToClient(Cursor.Position);
                if ((position.X < 0) || (position.X > this.Width) || (position.Y < 0) || (position.Y > this.Height))
                    this.OnMouseLeave(new EventArgs());
            }
        }

        /// <summary>
        /// Redirects the MouseEnter event from the buttonsv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Button_MouseEnter(object sender, EventArgs e)
        {
            if (!this.mouseInto)
                this.OnMouseEnter(new EventArgs());
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.mouseInto = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.mouseInto = false;
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Reimplements the painting method to paint a border
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.borderColor), 4), e.ClipRectangle);
        }
    }
}
