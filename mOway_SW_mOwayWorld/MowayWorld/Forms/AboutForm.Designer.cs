namespace Moway.Forms
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.bClose = new Moway.Template.Controls.MowayButton();
            this.lFramework = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLicense = new System.Windows.Forms.LinkLabel();
            this.linkWeb = new System.Windows.Forms.LinkLabel();
            this.lbVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.bClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bClose.Name = "bClose";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // lFramework
            // 
            resources.ApplyResources(this.lFramework, "lFramework");
            this.lFramework.Name = "lFramework";
            // 
            // lVersion
            // 
            resources.ApplyResources(this.lVersion, "lVersion");
            this.lVersion.Name = "lVersion";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // linkLicense
            // 
            resources.ApplyResources(this.linkLicense, "linkLicense");
            this.linkLicense.Name = "linkLicense";
            this.linkLicense.TabStop = true;
            this.linkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLicense_LinkClicked);
            // 
            // linkWeb
            // 
            resources.ApplyResources(this.linkWeb, "linkWeb");
            this.linkWeb.Name = "linkWeb";
            this.linkWeb.TabStop = true;
            this.linkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkWeb_LinkClicked);
            // 
            // lbVersion
            // 
            resources.ApplyResources(this.lbVersion, "lbVersion");
            this.lbVersion.Name = "lbVersion";
            // 
            // AboutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.linkWeb);
            this.Controls.Add(this.linkLicense);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.lVersion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lFramework);
            this.Name = "AboutForm";
            this.Controls.SetChildIndex(this.lFramework, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.lVersion, 0);
            this.Controls.SetChildIndex(this.bClose, 0);
            this.Controls.SetChildIndex(this.linkLicense, 0);
            this.Controls.SetChildIndex(this.linkWeb, 0);
            this.Controls.SetChildIndex(this.lbVersion, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayButton bClose;
        private System.Windows.Forms.Label lFramework;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLicense;
        private System.Windows.Forms.LinkLabel linkWeb;
        private System.Windows.Forms.Label lbVersion;
    }
}