namespace Moway.Project.GraphicProject.Forms
{
    partial class VariablesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VariablesForm));
            this.bClose = new Moway.Template.Controls.MowayButton();
            this.lVariable = new System.Windows.Forms.Label();
            this.bNew = new Moway.Template.Controls.MowayButton();
            this.bRemove = new Moway.Template.Controls.MowayButton();
            this.toolTip = new Moway.Template.Controls.MowayToolTip();
            this.bEdit = new Moway.Template.Controls.MowayButton();
            this.pVariablesListView = new System.Windows.Forms.Panel();
            this.pContainer = new System.Windows.Forms.Panel();
            this.pItems = new System.Windows.Forms.Panel();
            this.lInitValue = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.verticalScrollBar = new Moway.Template.Controls.MowayVScrollBar();
            this.pVariablesListView.SuspendLayout();
            this.pContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pFormSeparator
            // 
            resources.ApplyResources(this.pFormSeparator, "pFormSeparator");
            // 
            // lFormDescription
            // 
            resources.ApplyResources(this.lFormDescription, "lFormDescription");
            // 
            // bClose
            // 
            resources.ApplyResources(this.bClose, "bClose");
            this.bClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bClose.Name = "bClose";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // lVariable
            // 
            resources.ApplyResources(this.lVariable, "lVariable");
            this.lVariable.Name = "lVariable";
            // 
            // bNew
            // 
            this.bNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            resources.ApplyResources(this.bNew, "bNew");
            this.bNew.Name = "bNew";
            this.toolTip.SetToolTip(this.bNew, resources.GetString("bNew.ToolTip"));
            this.bNew.UseVisualStyleBackColor = true;
            this.bNew.Click += new System.EventHandler(this.BNew_Click);
            // 
            // bRemove
            // 
            resources.ApplyResources(this.bRemove, "bRemove");
            this.bRemove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bRemove.Name = "bRemove";
            this.toolTip.SetToolTip(this.bRemove, resources.GetString("bRemove.ToolTip"));
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.BRemove_Click);
            // 
            // bEdit
            // 
            resources.ApplyResources(this.bEdit, "bEdit");
            this.bEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bEdit.Name = "bEdit";
            this.toolTip.SetToolTip(this.bEdit, resources.GetString("bEdit.ToolTip"));
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.BEdit_Click);
            // 
            // pVariablesListView
            // 
            this.pVariablesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.pVariablesListView.Controls.Add(this.pContainer);
            this.pVariablesListView.Controls.Add(this.lInitValue);
            this.pVariablesListView.Controls.Add(this.lName);
            this.pVariablesListView.Controls.Add(this.verticalScrollBar);
            resources.ApplyResources(this.pVariablesListView, "pVariablesListView");
            this.pVariablesListView.Name = "pVariablesListView";
            // 
            // pContainer
            // 
            resources.ApplyResources(this.pContainer, "pContainer");
            this.pContainer.BackColor = System.Drawing.SystemColors.Window;
            this.pContainer.Controls.Add(this.pItems);
            this.pContainer.Name = "pContainer";
            this.pContainer.Click += new System.EventHandler(this.PContainer_Click);
            // 
            // pItems
            // 
            resources.ApplyResources(this.pItems, "pItems");
            this.pItems.Name = "pItems";
            this.pItems.SizeChanged += new System.EventHandler(this.PItems_SizeChanged);
            // 
            // lInitValue
            // 
            resources.ApplyResources(this.lInitValue, "lInitValue");
            this.lInitValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lInitValue.Name = "lInitValue";
            // 
            // lName
            // 
            resources.ApplyResources(this.lName, "lName");
            this.lName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.lName.Name = "lName";
            // 
            // verticalScrollBar
            // 
            resources.ApplyResources(this.verticalScrollBar, "verticalScrollBar");
            this.verticalScrollBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.verticalScrollBar.LargeChange = 5;
            this.verticalScrollBar.MaximumValue = 10;
            this.verticalScrollBar.Name = "verticalScrollBar";
            this.verticalScrollBar.SmallChange = 1;
            this.verticalScrollBar.Value = 0;
            this.verticalScrollBar.ValueChanged += new System.EventHandler(this.VerticalScrollBar_ValueChanged);
            // 
            // VariablesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pVariablesListView);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.bNew);
            this.Controls.Add(this.lVariable);
            this.Controls.Add(this.bClose);
            this.Name = "VariablesForm";
            this.Load += new System.EventHandler(this.VariablesForm_Load);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.bClose, 0);
            this.Controls.SetChildIndex(this.lVariable, 0);
            this.Controls.SetChildIndex(this.bNew, 0);
            this.Controls.SetChildIndex(this.bRemove, 0);
            this.Controls.SetChildIndex(this.bEdit, 0);
            this.Controls.SetChildIndex(this.pVariablesListView, 0);
            this.pVariablesListView.ResumeLayout(false);
            this.pContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayButton bClose;
        private System.Windows.Forms.Label lVariable;
        private Moway.Template.Controls.MowayButton bNew;
        private Moway.Template.Controls.MowayButton bRemove;
        private Moway.Template.Controls.MowayToolTip toolTip;
        private Moway.Template.Controls.MowayButton bEdit;
        private System.Windows.Forms.Panel pVariablesListView;
        private Moway.Template.Controls.MowayVScrollBar verticalScrollBar;
        private System.Windows.Forms.Label lInitValue;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.Panel pItems;
    }
}