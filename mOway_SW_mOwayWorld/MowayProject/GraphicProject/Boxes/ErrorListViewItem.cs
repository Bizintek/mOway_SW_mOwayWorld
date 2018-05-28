using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Project.GraphicProject.CodeGenerator;
using Moway.Template;

namespace Moway.Project.GraphicProject.Boxes
{
    public partial class ErrorListViewItem : UserControl
    {
        private bool selected = false;
        private DiagramError error;

        public DiagramError Error { get { return this.error; } }

        public event EventHandler ItemSelected;

        public ErrorListViewItem(DiagramError error)
        {
            InitializeComponent();
            this.error = error;
            this.pbIcon.Image = this.imageList.Images[(int)this.error.Type];
            this.lDescription.Text = this.error.Message;
            this.lDiagram.Text = this.error.Diagram.Name;
        }

        private void DiagramErrorItem_Click(object sender, EventArgs e)
        {
            if (!this.selected)
            {
                this.selected = true;
                this.BackColor = MowayColors.Selection;
                if (this.ItemSelected != null)
                    this.ItemSelected(this, new EventArgs());
            }
        }

        public void Deselect()
        {
            this.selected = false;
            this.BackColor = SystemColors.Window;
        }
    }
}
