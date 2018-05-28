using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;
using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Controls
{
    public partial class GraphTabButton : Moway.Template.Controls.TabButton
    {
        #region Delegates

        private delegate void RefreshCallback();

        #endregion

        #region Attributes

        private int index;

        #endregion

        #region Properties

        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

        public new bool Selected
        {
            set
            {
                this.selected = value;
                if (this.selected)
                {
                    this.Font = new Font(this.Font, FontStyle.Bold);
                    this.BackgroundImage = Project.GraphicProject.Controls.GraphicResources.bgTabSelected;
                    if (this.TabSelected != null)
                        this.TabSelected(this, new EventArgs());
                    if (this.InvokeRequired)
                        this.Invoke(new RefreshCallback(this.BringToFront), new object[] { });
                    else
                        this.BringToFront();
                }
                else
                {
                    this.Font = new Font(this.Font, FontStyle.Regular);
                    this.BackgroundImage = null;
                }
                if (this.InvokeRequired)
                    this.Invoke(new RefreshCallback(this.Refresh), new object[] { });
                else
                    this.Refresh();
            }
        }

        #endregion

        #region Events

        public event EventHandler TabSelected;
        public event EventHandler ChangeTabName;
        public event EventHandler RemoveTab;

        #endregion

        public GraphTabButton()
            :base()
        {
            InitializeComponent();
            if (System.Environment.OSVersion.Platform == PlatformID.Unix)
            {
				this.Size = new Size(127,27);
				this.Font = new System.Drawing.Font("Sans", 8.25F, System.Drawing.FontStyle.Regular);
			}
        }

        public GraphTabButton(string text, bool removeEnabled)
            :base(text)
        {
            InitializeComponent();
            this.miDelete.Enabled = removeEnabled;
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (!this.selected)
                this.Selected = true;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!this.selected)
                this.Selected = true;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if ((mevent.Button == MouseButtons.Middle) && (this.RemoveTab != null))
            {
                if (!this.selected)
                    this.Selected = true;
                this.RemoveTab(this, new EventArgs());
            }
        }

        private void MiChangeName_Click(object sender, EventArgs e)
        {
            if (this.ChangeTabName != null)
                this.ChangeTabName(this, new EventArgs());
        }

        private void MiRemove_Click(object sender, EventArgs e)
        {
            if (this.RemoveTab != null)
                this.RemoveTab(this, new EventArgs());
        }
    }
}
