namespace Moway.Project.GraphicProject.Actions
{
    partial class ActionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionForm));
            this.bSave = new Moway.Template.Controls.MowayButton();
            this.bCancel = new Moway.Template.Controls.MowayButton();
            this.llHelp = new System.Windows.Forms.LinkLabel();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // pFormSeparator
            // 
            this.helpProvider.SetShowHelp(this.pFormSeparator, ((bool)(resources.GetObject("pFormSeparator.ShowHelp"))));
            resources.ApplyResources(this.pFormSeparator, "pFormSeparator");
            // 
            // lFormDescription
            // 
            resources.ApplyResources(this.lFormDescription, "lFormDescription");
            this.helpProvider.SetShowHelp(this.lFormDescription, ((bool)(resources.GetObject("lFormDescription.ShowHelp"))));
            // 
            // bSave
            // 
            resources.ApplyResources(this.bSave, "bSave");
            this.bSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bSave.Image = global::Moway.Project.Properties.Resources.save;
            this.bSave.Name = "bSave";
            this.helpProvider.SetShowHelp(this.bSave, ((bool)(resources.GetObject("bSave.ShowHelp"))));
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // bCancel
            // 
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bCancel.Image = global::Moway.Project.Properties.Resources.cancel;
            this.bCancel.Name = "bCancel";
            this.helpProvider.SetShowHelp(this.bCancel, ((bool)(resources.GetObject("bCancel.ShowHelp"))));
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // llHelp
            // 
            resources.ApplyResources(this.llHelp, "llHelp");
            this.llHelp.Name = "llHelp";
            this.helpProvider.SetShowHelp(this.llHelp, ((bool)(resources.GetObject("llHelp.ShowHelp"))));
            this.llHelp.TabStop = true;
            this.llHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlHelp_LinkClicked);
            // 
            // helpProvider
            // 
            resources.ApplyResources(this.helpProvider, "helpProvider");
            // 
            // ActionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.llHelp);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Name = "ActionForm";
            this.helpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.ActionForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ActionForm_KeyUp);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected Moway.Template.Controls.MowayButton bSave;
        protected Moway.Template.Controls.MowayButton bCancel;
        protected System.Windows.Forms.LinkLabel llHelp;
        private System.Windows.Forms.HelpProvider helpProvider;

    }
}