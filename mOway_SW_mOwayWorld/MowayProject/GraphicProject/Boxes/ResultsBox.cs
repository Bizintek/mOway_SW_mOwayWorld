using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Template;
using Moway.Template.Controls;
using Moway.Project.GraphicProject.CodeGenerator;

namespace Moway.Project.GraphicProject.Boxes
{
    public partial class ResultsBox : MowayBox
    {
        #region Constants

        /// <summary>
        /// Step for vertical scrollbar
        /// </summary>
        private int VSCROLL_STEP = 24;

        #endregion

        private List<ErrorListViewItem> errors = new List<ErrorListViewItem>();
        private ErrorListViewItem itemSelected = null;

        public event EventHandler BoxClosed;

        public ResultsBox()
        {
            InitializeComponent();
        }

        public void ShowErrors(List<DiagramError> errors)
        {
            int i = 0;
            foreach (DiagramError error in errors)
            {
                ErrorListViewItem item = new ErrorListViewItem(error);
                item.Size = new Size(this.pItems.Width-2, 18);
                item.Location = new Point(1, i * 19 + 1);
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                item.ItemSelected += new EventHandler(Item_ItemSelected);
                this.errors.Add(item);
                this.pItems.Controls.Add(item);
                i++;
            }
            this.pItems.Size = new Size(this.pItems.Width, i * 19 + 1);
        }

        void Item_ItemSelected(object sender, EventArgs e)
        {
            if (this.itemSelected != null)
                this.itemSelected.Deselect();
            this.itemSelected = (ErrorListViewItem)sender;
        }

        public void Clear()
        {
            foreach (ErrorListViewItem item in this.errors)
                this.pItems.Controls.Remove(item);
            this.errors.Clear();
            this.itemSelected = null;
            this.pItems.Size = new Size(this.pItems.Width, 20);
        }

        private void PContainer_Click(object sender, EventArgs e)
        {
            if (this.itemSelected != null)
            {
                this.itemSelected.Deselect();
                this.itemSelected = null;
            }
        }

        private void PItems_SizeChanged(object sender, EventArgs e)
        {
            if (this.pItems.Height > this.pContainer.Height)
            {
                this.verticalScrollBar.Enabled = true;
                this.verticalScrollBar.MaximumValue = ((this.pItems.Height - this.pContainer.Height) / VSCROLL_STEP) + 1;

            }
            else
                this.verticalScrollBar.Enabled = false;
        }

        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            this.pItems.Location = new Point(this.pItems.Location.X, -(this.pItems.Height - this.pContainer.Height) * this.verticalScrollBar.Value / this.verticalScrollBar.MaximumValue);
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (this.BoxClosed != null)
                this.BoxClosed(this, new EventArgs());
        }
    }
}
