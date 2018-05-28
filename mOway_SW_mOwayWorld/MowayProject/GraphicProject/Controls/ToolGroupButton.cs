using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.Actions;

namespace Moway.Project.GraphicProject.Controls
{
    public partial class ToolGroupButton : ToolButton
    {
        #region Attributes

        /// <summary>
        /// List of actions that includes the Virtual action button
        /// </summary>
        private List<Tool> tools = new List<Tool>();
        /// <summary>
        /// Graphical parameters of the group of actions in which it is
        /// </summary>
        private CategoryColorSettings groupSettings;
        /// <summary>
        /// Group panel to display the corresponding tools
        /// </summary>
        private ToolGroupPanel groupPanel;
        /// <summary>
        /// Timer to improve the automatic opening and closing effect of the panel
        /// </summary>
        private Timer tGroupButton = new Timer();

        #endregion

        #region Events

        /// <summary>
        /// Event that tells the container to display the subactions panel
        /// </summary>
        public event GroupPanelEventHandler ShowPanel;
        /// <summary>
        /// Event that tells the container to hide the subaction panel
        /// </summary>
        public event EventHandler ClosePanel;
        public new event ToolEventHandler InitInsert;
        public new event PointEventHandler DoInsert;
        public new event EventHandler CancelInsert;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="group">Virtual action with the data for the button</param>
        /// <param name="settings">Graphical parameters of the action Group</param>
        public ToolGroupButton(Group group, CategoryColorSettings settings)
            : base(settings)
        {
            InitializeComponent();

            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
                this.Font = new System.Drawing.Font("Sans", 8, System.Drawing.FontStyle.Regular);

            //A background image is loaded with the arrow
            this.BackgroundImage = Moway.Project.GraphicProject.Controls.GraphicResources.bgGroupButton;
            this.Text = group.Text;
            this.Image = group.Icon;
            //The timer is set for the effect of appearing in the subaction panel
            this.tGroupButton.Tick += new EventHandler(tGroupButton_Tick);
            //The group's graphical parameters are saved
            this.groupSettings = settings;
        }

        #region Public methods

        /// <summary>
        /// Adds an action to the list of actions
        /// </summary>
        /// <param name="_action"></param>
        public void AddTool(Tool tool)
        {
            this.tools.Add(tool);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Creates the Subactions panel and generates the corresponding events
        /// </summary>
        private void CreateGroupPanel()
        {
            this.groupPanel = new ToolGroupPanel(this.tools, this.groupSettings);
            this.groupPanel.InitInsert += new ToolEventHandler(groupPanel_InitInsert);
            this.groupPanel.DoInsert += new PointEventHandler(groupPanel_DoInsert);
            this.groupPanel.CancelInsert += new EventHandler(groupPanel_CancelInsert);
            this.groupPanel.MouseEnter += new EventHandler(groupPanel_MouseEnter);
            this.groupPanel.MouseLeave += new EventHandler(groupPanel_MouseLeave);
            if (this.ShowPanel != null)
                this.ShowPanel(this, new GroupPanelEventArgs(this.groupPanel, this.PointToScreen(new Point(this.Width, 0))));
        }

        /// <summary>
        /// Removes the subaction panel
        /// </summary>
        private void RemoveGroupPanel()
        {
            if (this.ClosePanel != null)
                this.ClosePanel(this, new EventArgs());
            this.groupPanel.InitInsert -= this.groupPanel_InitInsert;
            this.groupPanel.DoInsert -= this.groupPanel_DoInsert;
            this.groupPanel.CancelInsert -= this.groupPanel_CancelInsert;
            this.groupPanel.MouseEnter -= this.groupPanel_MouseEnter;
            this.groupPanel.MouseLeave -= this.groupPanel_MouseLeave;
            this.groupPanel = null;
        }

        #endregion

        #region Control's own events

        /// <summary>
        /// End-of-timer event for the effects of displaying and hiding the subactions panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void tGroupButton_Tick(object sender, EventArgs e)
        {
            this.tGroupButton.Enabled = false;
            if (this.groupPanel == null)
                this.CreateGroupPanel();
            else
            {
                Point location = this.PointToClient(Cursor.Position);
                if ((location.X <= 0) || (location.X >= this.Width) || (location.Y <= 0) || (location.Y >= this.Height))
                {
                    this.BackColor = this.groupSettings.BackColor;
                    this.RemoveGroupPanel();
                }
            }
        }

        /// <summary>
        /// Click-On-button event. Displays the subactions panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupButton_Click(object sender, EventArgs e)
        {
            this.tGroupButton.Enabled = false;
            if (this.groupPanel == null)
                this.CreateGroupPanel();
        }

        /// <summary>
        /// Mouse input event in the control. Starts the timer to display the subaction panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = this.groupSettings.ActionButtonOverColor;
            if (this.groupPanel == null)
            {
                this.tGroupButton.Interval = 500;
                this.tGroupButton.Enabled = true;
            }
        }

        /// <summary>
        /// Control's mouse-out event. Starts the timer to hide the subaction panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupButton_MouseLeave(object sender, EventArgs e)
        {
            this.tGroupButton.Enabled = false;
            if (this.groupPanel != null)
            {
                this.tGroupButton.Interval = 100;
                this.tGroupButton.Enabled = true;
            }
            else
                this.BackColor = this.groupSettings.BackColor;
        }


        #endregion

        #region Events captured from the subaction panel

        /// <summary>
        /// An action selection event. Propagates to the container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="action"></param>
        void groupPanel_InitInsert(object sender, ToolEventArgs e)
        {
            if (this.InitInsert != null)
                this.InitInsert(this, e);
        }

        void groupPanel_DoInsert(object sender, PointEventArgs e)
        {
            this.RemoveGroupPanel();
            this.OnMouseLeave(new EventArgs());
            if (this.DoInsert != null)
                this.DoInsert(this,e);
        }

        void groupPanel_CancelInsert(object sender, EventArgs e)
        {
            if (this.CancelInsert != null)
                this.CancelInsert(this, e);
        }

        /// <summary>
        /// When you enter the mouse in the Subaction panel the button is displayed as continuously selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void groupPanel_MouseEnter(object sender, EventArgs e)
        {
            this.tGroupButton.Enabled = false;
            this.BackColor = this.groupSettings.ActionButtonOverColor;
        }

        /// <summary>
        /// When the mouse exits from the subaction panel, the button is deselected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void groupPanel_MouseLeave(object sender, EventArgs e)
        {
            this.tGroupButton.Interval = 250;
            this.tGroupButton.Enabled = true;
        }

        #endregion
    }
}
