namespace Moway.Project.GraphicProject.Forms
{
    partial class ProjectPropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPropertiesForm));
            this.bCancel = new Moway.Template.Controls.MowayButton();
            this.bUpdate = new Moway.Template.Controls.MowayButton();
            this.lProjectName = new System.Windows.Forms.Label();
            this.tbProjectName = new Moway.Template.Controls.MowayTextBox();
            this.lLanguage = new System.Windows.Forms.Label();
            this.rbAssembler = new Moway.Template.Controls.MowayRadioButton();
            this.rbC = new Moway.Template.Controls.MowayRadioButton();
            this.tbOwner = new Moway.Template.Controls.MowayTextBox();
            this.lOwner = new System.Windows.Forms.Label();
            this.tbComments = new Moway.Template.Controls.MowayTextBox();
            this.lComments = new System.Windows.Forms.Label();
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
            // lProjectName
            // 
            resources.ApplyResources(this.lProjectName, "lProjectName");
            this.lProjectName.Name = "lProjectName";
            // 
            // tbProjectName
            // 
            this.tbProjectName.BackColor = System.Drawing.SystemColors.Window;
            this.tbProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbProjectName, "tbProjectName");
            this.tbProjectName.Name = "tbProjectName";
            this.tbProjectName.ReadOnly = true;
            this.tbProjectName.TabStop = false;
            // 
            // lLanguage
            // 
            resources.ApplyResources(this.lLanguage, "lLanguage");
            this.lLanguage.Name = "lLanguage";
            // 
            // rbAssembler
            // 
            resources.ApplyResources(this.rbAssembler, "rbAssembler");
            this.rbAssembler.Checked = true;
            this.rbAssembler.Name = "rbAssembler";
            this.rbAssembler.TabStop = true;
            this.rbAssembler.UseVisualStyleBackColor = true;
            // 
            // rbC
            // 
            resources.ApplyResources(this.rbC, "rbC");
            this.rbC.Name = "rbC";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // tbOwner
            // 
            this.tbOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbOwner, "tbOwner");
            this.tbOwner.Name = "tbOwner";
            // 
            // lOwner
            // 
            resources.ApplyResources(this.lOwner, "lOwner");
            this.lOwner.Name = "lOwner";
            // 
            // tbComments
            // 
            this.tbComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbComments, "tbComments");
            this.tbComments.Name = "tbComments";
            // 
            // lComments
            // 
            resources.ApplyResources(this.lComments, "lComments");
            this.lComments.Name = "lComments";
            // 
            // ProjectPropertiesForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tbComments);
            this.Controls.Add(this.lComments);
            this.Controls.Add(this.tbOwner);
            this.Controls.Add(this.lOwner);
            this.Controls.Add(this.rbC);
            this.Controls.Add(this.rbAssembler);
            this.Controls.Add(this.lLanguage);
            this.Controls.Add(this.tbProjectName);
            this.Controls.Add(this.lProjectName);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bUpdate);
            this.Name = "ProjectPropertiesForm";
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.bUpdate, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lProjectName, 0);
            this.Controls.SetChildIndex(this.tbProjectName, 0);
            this.Controls.SetChildIndex(this.lLanguage, 0);
            this.Controls.SetChildIndex(this.rbAssembler, 0);
            this.Controls.SetChildIndex(this.rbC, 0);
            this.Controls.SetChildIndex(this.lOwner, 0);
            this.Controls.SetChildIndex(this.tbOwner, 0);
            this.Controls.SetChildIndex(this.lComments, 0);
            this.Controls.SetChildIndex(this.tbComments, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Moway.Template.Controls.MowayButton bCancel;
        protected Moway.Template.Controls.MowayButton bUpdate;
        private System.Windows.Forms.Label lProjectName;
        private Moway.Template.Controls.MowayTextBox tbProjectName;
        private System.Windows.Forms.Label lLanguage;
        private Moway.Template.Controls.MowayRadioButton rbAssembler;
        private Moway.Template.Controls.MowayRadioButton rbC;
        private Moway.Template.Controls.MowayTextBox tbOwner;
        private System.Windows.Forms.Label lOwner;
        private Moway.Template.Controls.MowayTextBox tbComments;
        private System.Windows.Forms.Label lComments;
    }
}