using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.Controls;
using Moway.Template.Controls;

namespace Moway.Project.GraphicProject.Forms
{
    public partial class VariablesForm : MowayForm
    {
        #region Constants

        private int HSCROLL_STEP = 24;

        #endregion

        #region Attributes

        private SortedList<string, VariableListViewItem> variables = new SortedList<string, VariableListViewItem>();
        private VariableListViewItem itemSelected = null;

        #endregion

        public VariablesForm()
        {
            InitializeComponent();
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VariablesForm_Load(object sender, EventArgs e)
        {
            foreach (Variable variable in GraphManager.Project.Variables)
            {
                VariableListViewItem item = new VariableListViewItem(variable);
                item.Size = new Size(this.pItems.Width - 2, 18);
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                item.ItemSelected += new EventHandler(Item_ItemSelected);
                this.variables.Add(variable.Name, item);
                this.pItems.Controls.Add(item);
            }
            this.UpdateItems();
        }

        void Item_ItemSelected(object sender, EventArgs e)
        {
            if (this.itemSelected != (VariableListViewItem)sender)
            {
                if (this.itemSelected != null)
                    this.itemSelected.Deselect();
                this.itemSelected = (VariableListViewItem)sender;
                this.bEdit.Enabled = true;
                this.bRemove.Enabled = true;
            }
        }

        private void UpdateItems()
        {
            int i = 0;
            for (; i < this.variables.Count; i++)
                this.variables.Values[i].Location = new Point(1, i * 19 + 1);
            this.pItems.Size = new Size(this.pItems.Width, i * 19 + 1);
        }

        private void BNew_Click(object sender, EventArgs e)
        {
            NewVariableForm newVariableForm = new NewVariableForm();
            if (DialogResult.OK == newVariableForm.ShowDialog())
            {
                GraphManager.AddVariable(newVariableForm.VariableCreated);
                VariableListViewItem item = new VariableListViewItem(newVariableForm.VariableCreated);
                item.Size = new Size(this.pItems.Width - 2, 18);
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                item.ItemSelected += new EventHandler(Item_ItemSelected);
                this.variables.Add(newVariableForm.VariableCreated.Name, item);
                this.pItems.Controls.Add(item);
                this.UpdateItems();
            }
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            Variable variable = GraphManager.GetVariable(this.itemSelected.Text);
            EditVariableForm editVariableForm = new EditVariableForm(variable);
            if (DialogResult.OK == editVariableForm.ShowDialog())
            {
                this.itemSelected.Update(variable.Name, variable.InitValue);
                this.UpdateItems();
            }
        }

        private void BRemove_Click(object sender, EventArgs e)
        {
            if (GraphManager.RemoveVariable(this.itemSelected.Text))
            {
                this.pItems.Controls.Remove(itemSelected);
                this.variables.Remove(itemSelected.Text);
                this.UpdateItems();
                this.itemSelected = null;
                this.bEdit.Enabled = false;
                this.bRemove.Enabled = false;
            }
            else
                MowayMessageBox.Show(VariablesMessages.VARIABLE_IN_USE, VariablesMessages.DELETE_VARIABLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PContainer_Click(object sender, EventArgs e)
        {
            if (this.itemSelected != null)
            {
                this.itemSelected.Deselect();
                this.itemSelected = null;
                this.bEdit.Enabled = false;
                this.bRemove.Enabled = false;
            }
        }

        private void PItems_SizeChanged(object sender, EventArgs e)
        {
            if (this.pItems.Height > this.pContainer.Height)
            {
                this.verticalScrollBar.Enabled = true;
                this.verticalScrollBar.MaximumValue = ((this.pItems.Height - this.pContainer.Height) / HSCROLL_STEP) + 1;

            }
            else
                this.verticalScrollBar.Enabled = false;
        }

        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            this.pItems.Location = new Point(this.pItems.Location.X, -(this.pItems.Height - this.pContainer.Height) * this.verticalScrollBar.Value / this.verticalScrollBar.MaximumValue);
        }
    }
}
