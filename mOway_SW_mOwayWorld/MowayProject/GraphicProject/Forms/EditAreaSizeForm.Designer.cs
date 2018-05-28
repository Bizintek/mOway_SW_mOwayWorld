namespace Moway.Project.GraphicProject.Forms
{
    partial class EditAreaSizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAreaSizeForm));
            this.cbSize = new Moway.Template.Controls.MowayComboBox();
            this.rbVertical = new Moway.Template.Controls.MowayRadioButton();
            this.lSize = new System.Windows.Forms.Label();
            this.lOrientation = new System.Windows.Forms.Label();
            this.rbHorizontal = new Moway.Template.Controls.MowayRadioButton();
            this.bCancel = new Moway.Template.Controls.MowayButton();
            this.bUpdate = new Moway.Template.Controls.MowayButton();
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
            // cbSize
            // 
            this.cbSize.BackColor = System.Drawing.Color.White;
            this.cbSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSize.DropDownHeight = 100;
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbSize, "cbSize");
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            resources.GetString("cbSize.Items"),
            resources.GetString("cbSize.Items1")});
            this.cbSize.Name = "cbSize";
            // 
            // rbVertical
            // 
            resources.ApplyResources(this.rbVertical, "rbVertical");
            this.rbVertical.Name = "rbVertical";
            this.rbVertical.TabStop = true;
            this.rbVertical.UseVisualStyleBackColor = true;
            // 
            // lSize
            // 
            resources.ApplyResources(this.lSize, "lSize");
            this.lSize.Name = "lSize";
            // 
            // lOrientation
            // 
            resources.ApplyResources(this.lOrientation, "lOrientation");
            this.lOrientation.Name = "lOrientation";
            // 
            // rbHorizontal
            // 
            resources.ApplyResources(this.rbHorizontal, "rbHorizontal");
            this.rbHorizontal.Name = "rbHorizontal";
            this.rbHorizontal.TabStop = true;
            this.rbHorizontal.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bCancel.Name = "bCancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // bUpdate
            // 
            resources.ApplyResources(this.bUpdate, "bUpdate");
            this.bUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.BUpdate_Click);
            // 
            // EditAreaSizeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.rbHorizontal);
            this.Controls.Add(this.lOrientation);
            this.Controls.Add(this.rbVertical);
            this.Controls.Add(this.cbSize);
            this.Controls.Add(this.lSize);
            this.Name = "EditAreaSizeForm";
            this.Controls.SetChildIndex(this.lSize, 0);
            this.Controls.SetChildIndex(this.cbSize, 0);
            this.Controls.SetChildIndex(this.rbVertical, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.lOrientation, 0);
            this.Controls.SetChildIndex(this.rbHorizontal, 0);
            this.Controls.SetChildIndex(this.bUpdate, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayComboBox cbSize;
        private Moway.Template.Controls.MowayRadioButton rbVertical;
        private System.Windows.Forms.Label lSize;
        private System.Windows.Forms.Label lOrientation;
        private Moway.Template.Controls.MowayRadioButton rbHorizontal;
        private Moway.Template.Controls.MowayButton bCancel;
        private Moway.Template.Controls.MowayButton bUpdate;
    }
}