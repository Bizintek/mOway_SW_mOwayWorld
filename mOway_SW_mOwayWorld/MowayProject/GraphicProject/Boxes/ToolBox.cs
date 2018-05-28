using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Controls;
using Moway.Project.GraphicProject.Actions;
using Moway.Template;

namespace Moway.Project.GraphicProject.Boxes
{
    /// <summary>
    /// Represents the action box for a graphic project
    /// </summary>
    public partial class ToolBox : MowayBox
    {
        #region Constants

        private const int PANEL_MARGIN = 2;
        private const int GROUPPANEL_MARGIN = 5;
        private const int VSCROLL_STEP = 20;

        #endregion

        #region Attributes

        /// <summary>
        /// List of group panels for the application
        /// </summary>
        private List<ToolPanel> toolPanels = new List<ToolPanel>();
        private Panel toolGroupPanel = null;

        #endregion

        #region Events

        /// <summary>
        /// Selection event of one of the actions
        /// </summary>
        public event ToolEventHandler InitInsert;
        public event PointEventHandler DoInsert;
        public event EventHandler CancelInsert;

        #endregion

        #region Properties

        public Rectangle ToolsPanelScreenRectangle
        {
            get
            {
                if (this.toolGroupPanel == null)
                    return new Rectangle(0, 0, 0, 0);
                else
                    return this.Parent.RectangleToScreen(new Rectangle(this.toolGroupPanel.Location, this.toolGroupPanel.Size));
            }
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        public ToolBox()
            : base()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

            //Panels are created based on the categories defined
            List<Category> categories = Category.GetCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                ToolPanel toolPanel = new ToolPanel(categories[i], ActionFactory.GetToolsAction(categories[i].Name), this.Location);
                //The panel is placed based on the previous
                try
                {
                    toolPanel.Location = new Point(0, this.toolPanels[i - 1].Bottom + PANEL_MARGIN);
                }
                catch
                {
                    //If it is the first one skips the exception and it is placed in the initial position
                    toolPanel.Location = new Point(0, 0);
                }
                toolPanel.InitInsert += new ToolEventHandler(toolsPanel_InitInsert);
                toolPanel.DoInsert += new PointEventHandler(toolsPanel_DoInsert);
                toolPanel.CancelInsert += new EventHandler(toolPanel_CancelInsert);
                toolPanel.ShowPanel +=new GroupPanelEventHandler(toolPanel_ShowPanel);
                toolPanel.ClosePanel += new EventHandler(toolPanel_ClosePanel);
                this.pContainer.Controls.Add(toolPanel);
                this.toolPanels.Add(toolPanel);
            }

        }

        private void pContainer_SizeChanged(object sender, EventArgs e)
        {
            if (this.toolPanels[this.toolPanels.Count - 1].Bottom <= this.pContainer.Height)
            {
                this.vScrollBar.Enabled = false;
                if (this.toolPanels[0].Top != 0)
                    for (int i = 0; i < this.toolPanels.Count; i++)
                        try
                        {
                            toolPanels[i].Location = new Point(0, this.toolPanels[i - 1].Bottom + PANEL_MARGIN);
                        }
                        catch
                        {
                            toolPanels[i].Location = new Point(0, 0);
                        }
            }
            else
            {
                int diff = (this.toolPanels[this.toolPanels.Count - 1].Bottom - this.toolPanels[0].Top) - this.pContainer.Height;
                this.vScrollBar.Enabled = true;
                this.vScrollBar.MaximumValue = (diff / VSCROLL_STEP) + 1;
            }

        }

        void toolPanel_ClosePanel(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(toolGroupPanel);
            this.toolGroupPanel = null;
        }

        void toolPanel_ShowPanel(object sender, GroupPanelEventArgs e)
        {
            this.toolGroupPanel = e.GroupPanel;
            e.GroupPanel.Location = this.Parent.PointToClient(e.ScreenLocation);
            if (e.GroupPanel.Bottom > this.Parent.ClientRectangle.Height -5)
                e.GroupPanel.Location = new Point(e.GroupPanel.Location.X, this.Parent.ClientRectangle.Height - e.GroupPanel.Height - 5);
            this.Parent.Controls.Add(e.GroupPanel);
            e.GroupPanel.BringToFront();
        }

        #region Group Panel Events

        /// <summary>
        /// An action selection event. Propagates to the container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="action"></param>
        void toolsPanel_InitInsert(object sender, ToolEventArgs e)
        {
            if (this.InitInsert != null)
                this.InitInsert(this, e);
        }

        void toolsPanel_DoInsert(object sender, PointEventArgs e)
        {
            if (this.DoInsert != null)
                this.DoInsert(this, e);
        }

        void toolPanel_CancelInsert(object sender, EventArgs e)
        {
            if (this.CancelInsert != null)
                this.CancelInsert(this, e);
        }

        #endregion

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            int diff = (this.toolPanels[this.toolPanels.Count - 1].Bottom - this.toolPanels[0].Top) - this.pContainer.Height;
            int xInitial = (diff * this.vScrollBar.Value) / this.vScrollBar.MaximumValue;
            for (int i = 0; i < this.toolPanels.Count; i++)
            {
                try
                {
                    toolPanels[i].Location = new Point(0, this.toolPanels[i - 1].Bottom + PANEL_MARGIN);
                }
                catch
                {
                    toolPanels[i].Location = new Point(0, -xInitial);
                }
            }
        }
    }
}
