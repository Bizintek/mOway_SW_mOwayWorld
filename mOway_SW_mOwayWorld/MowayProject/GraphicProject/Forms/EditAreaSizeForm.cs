using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.GraphLayout;

namespace Moway.Project.GraphicProject.Forms
{
    public partial class EditAreaSizeForm : MowayForm
    {
        #region Attributes

        private GraphDiagram graphDiagram;

        #endregion

        public EditAreaSizeForm(GraphDiagram graphDiagram)
        {
            InitializeComponent();
            this.graphDiagram = graphDiagram;
            switch (this.graphDiagram.AreaFormat)
            {
                case AreaFormat.A3_Vertical:
                    this.cbSize.SelectedIndex = 0;
                    this.rbVertical.Checked = true;
                    break;
                case AreaFormat.A3_Horizontal:
                    this.cbSize.SelectedIndex = 0;
                    this.rbHorizontal.Checked = true;
                    break;
                case AreaFormat.A4_Vertical:
                    this.cbSize.SelectedIndex = 1;
                    this.rbVertical.Checked = true;
                    break;
                case AreaFormat.A4_Horizontal:
                    this.cbSize.SelectedIndex = 1;
                    this.rbHorizontal.Checked = true;
                    break;
            }
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbSize.SelectedIndex == 0)
                    if (this.rbVertical.Checked)
                        graphDiagram.ChangeSize(AreaFormat.A3_Vertical);
                    else
                        graphDiagram.ChangeSize(AreaFormat.A3_Horizontal);
                else
                    if (this.rbVertical.Checked)
                        graphDiagram.ChangeSize(AreaFormat.A4_Vertical);
                    else
                        graphDiagram.ChangeSize(AreaFormat.A4_Horizontal);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MowayMessageBox.Show(AreaSizeMessages.ERROR_AREA_SIZE, AreaSizeMessages.TITTLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
