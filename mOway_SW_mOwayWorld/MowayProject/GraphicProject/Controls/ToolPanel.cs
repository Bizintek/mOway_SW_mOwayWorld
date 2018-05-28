using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Actions;

namespace Moway.Project.GraphicProject.Controls
{
    /// <summary>
    /// Represents the panel that includes a group of tools
    /// </summary>
    public partial class ToolPanel : UserControl
    {
        #region Constants

        private const int INIT_X = 4;
        private const int INIT_Y = 28;
        public const int BUTTON_SEPARATION = 28;

        #endregion

        #region Attributes

        /// <summary>
        /// Color of the border. It is necessary to keep it for the redraw
        /// </summary>
        private Color borderColor;
        /// <summary>
        /// Location of the container for the calculation of the absolute position of the GroupButtons
        /// </summary>
        private Point parentLocation;

        #endregion

        #region Events

        /// <summary>
        /// Selection event of one of the actions
        /// </summary>
        public event ToolEventHandler InitInsert;
        public event PointEventHandler DoInsert;
        public event EventHandler CancelInsert;
        public event GroupPanelEventHandler ShowPanel;
        public event EventHandler ClosePanel;

        #endregion

        /// <summary>
        /// Group Panel Builder
        /// </summary>
        /// <param name="category">Group to which it represents</param>
        /// <param name="tools">List of actions of the group</param>
        /// <param name="parentLocation">Location of the container</param>
        public ToolPanel(Category category, List<Tool> tools, Point parentLocation)
        {
            InitializeComponent();
            this.BackColor = category.GuiSetting.BackColor;
            this.borderColor = category.GuiSetting.BorderColor;
            //The category title and background color are set
            this.lCategory.Text = category.Label;
            this.lCategory.BackColor = category.GuiSetting.BorderColor;
            //To avoid the focus effect
            this.SetStyle(ControlStyles.UserPaint, true);
            //The position of the container is saved
            this.parentLocation = parentLocation;
            //The action buttons are created
            int toolLevel1Counter = 0;
            Hashtable groupButtons = new Hashtable();
            foreach (Tool tool in tools)
            {
                //Check whether the action should be contained in a group
                Group group = Group.GetGroup(tool.Group);
                if (group == null)
                {
                    //A normal tool button is created
                    ToolButton toolButton = new ToolButton(tool, category.GuiSetting);
                    toolButton.InitInsert += new ToolEventHandler(toolButton_InitInsert);
                    toolButton.DoInsert += new PointEventHandler(toolButton_DoInsert);
                    toolButton.CancelInsert += new EventHandler(toolButton_CancelInsert);
                    toolButton.Location = new Point(INIT_X, INIT_Y + (toolLevel1Counter * BUTTON_SEPARATION));
                    this.toolTip.SetToolTip(toolButton, tool.ToolTipText);
                    this.Controls.Add(toolButton);
                    toolLevel1Counter++;
                }
                else
                {
                    //Check if the group button already exists
                    ToolGroupButton groupButton = (ToolGroupButton)groupButtons[group];
                    if (groupButton == null)
                    {
                        //Creates a new button group and is saved so that it does not create two equal
                        groupButton = new ToolGroupButton(group, category.GuiSetting);
                        groupButtons.Add(group, groupButton);
                        groupButton.InitInsert += new ToolEventHandler(toolButton_InitInsert);
                        groupButton.DoInsert += new PointEventHandler(toolButton_DoInsert);
                        groupButton.CancelInsert += new EventHandler(toolButton_CancelInsert);
                        groupButton.ShowPanel += new GroupPanelEventHandler(button_ShowPanel);
                        groupButton.ClosePanel += new EventHandler(button_ClosePanel);
                        //The tool is added to the group
                        groupButton.AddTool(tool);
                        groupButton.Location = new Point(INIT_X, INIT_Y + (toolLevel1Counter * BUTTON_SEPARATION));
                        this.toolTip.SetToolTip(groupButton, group.ToolTipText);
                        this.Controls.Add(groupButton);
                        toolLevel1Counter++;
                    }
                    else
                        //A new action is added to the group button
                        groupButton.AddTool(tool);
                }
            }
            this.Size = new Size(this.Width, INIT_Y + 3 + (toolLevel1Counter * BUTTON_SEPARATION));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Paints the edge of the control
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(this.borderColor), 4), new Rectangle(new Point(0, 0), this.Size));
            //Paints the background of the header
            e.Graphics.FillRectangle(new SolidBrush(this.borderColor), new Rectangle(new Point(0, 0), new Size(this.Size.Width, 26)));
        }

        #region Events start, perform, or cancel a insert operation

        void toolButton_InitInsert(object sender, ToolEventArgs e)
        {
            if (this.InitInsert != null)
                this.InitInsert(this, e);
        }

        void toolButton_DoInsert(object sender, PointEventArgs e)
        {
            if (this.DoInsert != null)
                this.DoInsert(this, e);
        }

        void toolButton_CancelInsert(object sender, EventArgs e)
        {
            if (this.CancelInsert != null)
                this.CancelInsert(this, e);
        }

        #endregion

        #region Events to show and hide a subaction panel

        void button_ShowPanel(object sender, GroupPanelEventArgs e)
        {
            if (this.ShowPanel != null)
                this.ShowPanel(this, e);
        }

        void button_ClosePanel(object sender, EventArgs e)
        {
            if (this.ClosePanel != null)
                this.ClosePanel(this, e);
            this.Refresh(); //If you don't put this it leaves a drawn line
        }

        #endregion
    }
}
