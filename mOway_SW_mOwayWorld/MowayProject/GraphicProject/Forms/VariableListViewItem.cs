using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

using Moway.Template;

namespace Moway.Project.GraphicProject.Forms
{
    public partial class VariableListViewItem : UserControl
    {
        #region Attributes

        private bool selected = false;

        #endregion

        #region Properties

        public override string Text { get { return this.lName.Text; } }

        #endregion

        #region Events

        public event EventHandler ItemSelected;

        #endregion

        public VariableListViewItem(Variable variable)
        {
            InitializeComponent();
            this.lName.Text = variable.Name;
            this.lInitValue.Text = variable.InitValue.ToString();
        }

        private void VariableItem_Click(object sender, EventArgs e)
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

        public void Update(string name, byte initValue)
        {
            this.lName.Text = name;
            this.lInitValue.Text = initValue.ToString();
        }
    }
}
