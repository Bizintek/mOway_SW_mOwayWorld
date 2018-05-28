using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SdlDotNet.Graphics;
using SdlDotNet.Windows;

using Moway.Project.GraphicProject.Controls;
using Moway.Template;
using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Boxes
{
    public partial class WorkBox : MowayBox
    {
        #region Delegates

        public delegate void SelectTabButtonCallback(string functionName);

        #endregion

        #region Constants

        private const int MAX_TAB_PAGES = 5;
        private const int HSCROLL_STEP = 40;
        private const int VSCROLL_STEP = 40;

        #endregion

        #region Attributes

        private List<GraphTabButton> tabButtons = new List<GraphTabButton>();
        private GraphTabButton tabButtonSelected = null;

        private Surface presentSurface = null;
        private Point surfaceDisplacement = new Point(0, 0);

        private MouseEventArgs mouseMoveEventArgs;
        private bool mouseIntoWorkArea = false;
        private List<Rectangle> rectanglesIntoWorkArea = new List<Rectangle>();

        #endregion

        #region Properties

        public Rectangle WorkAreaRectangle { get { return this.graphArea.RectangleToClient(new Rectangle(this.graphArea.PointToScreen(this.graphArea.Location), this.graphArea.Size)); } }
        public int HorizontalScrollValue { get { return this.horizontalScroll.Value; } }
        public int VerticalScrollValue { get { return this.verticalScroll.Value; } }

        #endregion

        #region Events

        public event EventHandler CreateTabPage;
        public event GraphTabButtonEventHandler RenameTabPage;
        public event GraphTabButtonEventHandler RemoveTabPage;
        public event GraphTabButtonEventHandler TabPageSelected;

        public event EventHandler ScrollValuesChanged;

        public event EventHandler WorkAreaMouseEnter;
        public event EventHandler WorkAreaMouseLeave;
        public event MouseEventHandler WorkAreaMouseMove;
        public event MouseEventHandler WorkAreaMouseUp;
        public event MouseEventHandler WorkAreaMouseDown;
        public event MouseEventHandler WorkAreaDoubleClick;

        #endregion

        public WorkBox()
        {
            InitializeComponent();
   
            this.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            this.MouseWheel += new MouseEventHandler(WorkBox_MouseWheel);
        }

        void WorkBox_MouseWheel(object sender, MouseEventArgs e)
        {
            Point cursorPosition = this.graphArea.PointToClient(Cursor.Position);
            if ((cursorPosition.X > 0) && (cursorPosition.Y > 0) && (cursorPosition.X < this.graphArea.Width) && (cursorPosition.Y < this.graphArea.Height))
                if (Control.ModifierKeys == Keys.Control)
                    if ((this.horizontalScroll.Enabled) && (e.Delta < 0))
                        this.horizontalScroll.Value++;
                    else
                        this.horizontalScroll.Value--;
                else
                    if ((this.verticalScroll.Enabled) && (e.Delta < 0))
                        this.verticalScroll.Value++;
                    else
                        this.verticalScroll.Value--;
        }

        #region Special methods for insert operation

        public void EnableMouseEvents(Rectangle rectangle)
        {
            this.mouseMoveEventArgs = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
            this.graphAreaTimer.Enabled = true;
            if (!rectangle.IsEmpty)
                this.rectanglesIntoWorkArea.Add(this.graphArea.RectangleToClient(rectangle));
        }

        public void DisableMouseEvents()
        {
            this.graphAreaTimer.Enabled = false;
            this.rectanglesIntoWorkArea.Clear();
        }

        #endregion

        /// <summary>
        /// Timer to take care of launching the corresponding mouse events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphAreaTimer_Tick(object sender, EventArgs e)
        {
            Point cursorPosition = this.graphArea.PointToClient(Cursor.Position);
            if ((cursorPosition.X < 0) || (cursorPosition.Y < 0) || (cursorPosition.X > this.graphArea.Width) || (cursorPosition.Y > this.graphArea.Height) || ((this.rectanglesIntoWorkArea.Count != 0) && (this.rectanglesIntoWorkArea[0].Contains(cursorPosition))))
            {
                if (this.mouseIntoWorkArea == true)
                {
                    if (this.WorkAreaMouseLeave != null)
                        this.WorkAreaMouseLeave(this, new EventArgs());
                    this.mouseIntoWorkArea = false;
                }
            }
            else
            {
                if (this.mouseIntoWorkArea == false)
                {
                    if (this.WorkAreaMouseEnter != null)
                        this.WorkAreaMouseEnter(this, new EventArgs());
                    this.mouseIntoWorkArea = true;
                }
            }
            if ((this.mouseMoveEventArgs.Location.X != cursorPosition.X) || (this.mouseMoveEventArgs.Location.Y != cursorPosition.Y))
            {
                this.mouseMoveEventArgs = new MouseEventArgs(this.mouseMoveEventArgs.Button, 0, cursorPosition.X, cursorPosition.Y, 0);
                if (this.WorkAreaMouseMove != null)
                    this.WorkAreaMouseMove(this, new MouseEventArgs(this.mouseMoveEventArgs.Button, 0, this.mouseMoveEventArgs.X - this.surfaceDisplacement.X, this.mouseMoveEventArgs.Y - this.surfaceDisplacement.Y, 0));
            }
        }

        #region Events to control the effect of TabControl

        private void TabButtonPlus_Click(object sender, EventArgs e)
        {
            if (this.CreateTabPage != null)
                this.CreateTabPage(this, new EventArgs());
        }

        void Button_TabSelected(object sender, EventArgs e)
        {
            if (this.tabButtonSelected != null)
                this.tabButtonSelected.Selected = false;
            for (int i = this.tabButtons.IndexOf(this.tabButtonSelected) - 1; i >= 0; i--)
                if (this.tabButtons[i] != sender)
                    this.tabButtons[i].BringToFront();
            this.tabButtonSelected = (GraphTabButton)sender;
            if (this.TabPageSelected != null)
                this.TabPageSelected(this, new GraphTabButtonEventArgs(this.tabButtonSelected));
        }
        
        void Button_ChangeTabName(object sender, EventArgs e)
        {
            if (this.RenameTabPage != null)
                this.RenameTabPage(this, new GraphTabButtonEventArgs((GraphTabButton)sender));
        }

        void Button_RemoveTab(object sender, EventArgs e)
        {
            if (this.RemoveTabPage != null)
                this.RemoveTabPage(this, new GraphTabButtonEventArgs((GraphTabButton)sender));
        }

        #endregion

        #region Public methods

        public void SelectTabButton(string functionName)
        {
            if ((this.tabButtonSelected != null) && (this.tabButtonSelected.InvokeRequired))
                this.Invoke(new SelectTabButtonCallback(this.SelectTabButton), new object[] { functionName });
            else
            {
                GraphTabButton tempTabButton = null;
                foreach (GraphTabButton tabButton in this.tabButtons)
                    if (tabButton.Text == functionName)
                    {
                        tempTabButton = tabButton;
                        break;
                    }
                if (this.tabButtonSelected != tempTabButton)
                {
                    if (tempTabButton == null)
                        throw new ProjectException("This function don't exists");
                    tempTabButton.Selected = true;
                }
            }
        }

        private void CalculeScrollValues()
        {
            if (this.presentSurface.Width <= this.graphArea.Width)
                this.horizontalScroll.Enabled = false;
            else
            {
                this.horizontalScroll.Enabled = true;
                int diff = this.presentSurface.Width - this.graphArea.Width;
                this.horizontalScroll.MaximumValue = diff / HSCROLL_STEP + 1;
            }
            if (this.presentSurface.Height <= this.graphArea.Height)
                this.verticalScroll.Enabled = false;
            else
            {
                this.verticalScroll.Enabled = true;
                int diff = this.presentSurface.Height - this.graphArea.Height;
                this.verticalScroll.MaximumValue = diff / VSCROLL_STEP+1;
            }
        }

        public void UpdateScrollValues(int vScrollValue, int hScrollValue)
        {
            this.verticalScroll.Value = vScrollValue;
            this.horizontalScroll.Value = hScrollValue;
        }

        public void UpdateSurface(Surface surface)
        {
            //For the first time it is updated
            if ((this.presentSurface == null) || (this.presentSurface.Width != surface.Width) || (this.presentSurface.Height != surface.Height))
            {
                this.presentSurface = surface;
                this.CalculeScrollValues();
            }
            else
                this.presentSurface = surface;
            this.UpdateSurface();
        }

        public void ChangeCursor(Cursor cursor)
        {
            this.graphArea.Cursor = cursor;
        }

        public void ChangeContextMenu(ContextMenu menu)
        {
            this.graphArea.ContextMenu = menu;
        }

        public void AddTabButton(string name, bool removeEnabled, bool selected)
        {
            GraphTabButton button = new GraphTabButton(name, removeEnabled);
            button.Index = this.tabButtons.Count;
            button.TabSelected += new EventHandler(Button_TabSelected);
            button.RemoveTab += new EventHandler(Button_RemoveTab);
            button.ChangeTabName += new EventHandler(Button_ChangeTabName);
            button.Location = this.tabButtonPlus.Location;
            this.tabButtonPlus.Location = new Point(this.tabButtonPlus.Location.X + 128, 35);
            this.Controls.Add(button);
            this.tabButtons.Add(button);
            button.Selected = selected;
            if (selected)
            {
                this.tabButtonSelected = button;
                this.tabButtonSelected.BringToFront();
            }
            else
                for (int i = this.tabButtons.Count - 1; i >= 0; i--)
                    this.tabButtons[i].BringToFront();
            if (this.tabButtons.Count >= MAX_TAB_PAGES)
                this.tabButtonPlus.Enabled = false;
            this.verticalScroll.Value = 0;
            this.horizontalScroll.Value = 0;
        }

        public void RemoveAllTabButtons()
        {
            this.tabButtonSelected = null;
            foreach (GraphTabButton button in this.tabButtons)
            {
                this.Controls.Remove(button);
                button.TabSelected -= this.Button_TabSelected;
                button.RemoveTab -= this.Button_RemoveTab;
                button.ChangeTabName -= this.Button_ChangeTabName;
            }
            this.tabButtons.Clear();
            this.tabButtonPlus.Location = new Point(14, 35);
            this.tabButtonPlus.Enabled = true;
        }

        public void RemoveSelectedTabButton()
        {
            this.tabButtons.Remove(this.tabButtonSelected);
            this.Controls.Remove(this.tabButtonSelected);
            this.tabButtonSelected.TabSelected -= this.Button_TabSelected;
            this.tabButtonSelected.RemoveTab -= this.Button_RemoveTab;
            this.tabButtonSelected.ChangeTabName -= this.Button_ChangeTabName;
            for (int i = 0; i < this.tabButtons.Count; i++)
            {
                ((GraphTabButton)this.tabButtons[i]).Index = i;
                ((GraphTabButton)this.tabButtons[i]).Location = new Point(14 + (i * 128), 35);
            }
            this.tabButtonPlus.Location = new Point(14 + (this.tabButtons.Count * 128), 35);
            ((GraphTabButton)this.tabButtons[this.tabButtonSelected.Index - 1]).Selected = true;
            this.tabButtonPlus.Enabled = true;
        }

        public void ChangeSelectedTabButtonName(string name)
        {
            this.tabButtonSelected.Text = name;
        }

        #endregion

        #region Mouse events on the GrapArea

        private void GraphArea_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseMoveEventArgs = e;
            if (this.WorkAreaMouseDown != null)
                this.WorkAreaMouseDown(this, new MouseEventArgs(e.Button, e.Clicks, e.X - this.surfaceDisplacement.X, e.Y - this.surfaceDisplacement.Y, e.Delta));
        }

        private void GraphArea_MouseEnter(object sender, EventArgs e)
        {
            this.mouseIntoWorkArea = true;
            if (this.WorkAreaMouseEnter != null)
                this.WorkAreaMouseEnter(this, e);
        }

        private void GraphArea_MouseLeave(object sender, EventArgs e)
        {
            this.mouseIntoWorkArea = false;
            this.graphAreaTimer.Enabled = false;
            if (this.WorkAreaMouseLeave != null)
                this.WorkAreaMouseLeave(this, e);
        }

        private void GraphArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (!this.graphAreaTimer.Enabled)
            {
                this.graphAreaTimer.Enabled = true;
                this.mouseMoveEventArgs = e;
                if (this.WorkAreaMouseMove != null)
                    this.WorkAreaMouseMove(this, new MouseEventArgs(this.mouseMoveEventArgs.Button, 0, this.mouseMoveEventArgs.X - this.surfaceDisplacement.X, this.mouseMoveEventArgs.Y - this.surfaceDisplacement.Y, 0));
            }
        }

        private void GraphArea_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.WorkAreaMouseUp != null)
                this.WorkAreaMouseUp(this, new MouseEventArgs(e.Button, e.Clicks, e.X - this.surfaceDisplacement.X, e.Y - this.surfaceDisplacement.Y, e.Delta));
            this.mouseMoveEventArgs = new MouseEventArgs(MouseButtons.None, 0, e.X, e.Y, 0);
        }

        private void GraphArea_SizeChanged(object sender, EventArgs e)
        {
            if (this.presentSurface != null)
            {
                this.UpdateSurface();
                this.CalculeScrollValues();
            }
        }

        private void GraphArea_DoubleClick(object sender, EventArgs e)
        {
            Point cursorPosition = this.graphArea.PointToClient(Cursor.Position);
            if (this.WorkAreaDoubleClick != null)
                this.WorkAreaDoubleClick(this, new MouseEventArgs(MouseButtons.Left, 2, cursorPosition.X - this.surfaceDisplacement.X, cursorPosition.Y - this.surfaceDisplacement.Y, 0));
        }

        #endregion

        #region Events for the displacement of scrolls

        private void VerticalScroll_ValueChanged(object sender, EventArgs e)
        {
            this.surfaceDisplacement = new Point(this.surfaceDisplacement.X, -((((this.presentSurface.Height - this.graphArea.Height) * this.verticalScroll.Value) / this.verticalScroll.MaximumValue) / 18) * 18);
            if (this.ScrollValuesChanged != null)
                this.ScrollValuesChanged(this, new EventArgs());
            this.UpdateSurface();
        }

        private void HorizontalScroll_ValueChanged(object sender, EventArgs e)
        {
            this.surfaceDisplacement = new Point(-((((this.presentSurface.Width - this.graphArea.Width) * this.horizontalScroll.Value) / this.horizontalScroll.MaximumValue) / 16) * 16, this.surfaceDisplacement.Y);
            if (this.ScrollValuesChanged != null)
                this.ScrollValuesChanged(this, new EventArgs());
            this.UpdateSurface();
        }

        private void UpdateSurface()
        {
            Surface tempSurface = new Surface(this.graphArea.Size);
            tempSurface.Fill(Color.FromArgb(217, 224, 228));
            tempSurface.Blit(this.presentSurface, this.surfaceDisplacement);
            this.graphArea.Blit(tempSurface);
        }

        #endregion

        private void GraphArea_Click(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
