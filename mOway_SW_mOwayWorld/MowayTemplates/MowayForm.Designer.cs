namespace Moway.Template
{
    partial class MowayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MowayForm));
            this.pFormSeparator = new System.Windows.Forms.Panel();
            this.lFormDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pFormSeparator
            // 
            this.pFormSeparator.AccessibleDescription = null;
            this.pFormSeparator.AccessibleName = null;
            resources.ApplyResources(this.pFormSeparator, "pFormSeparator");
            this.pFormSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.pFormSeparator.BackgroundImage = null;
            this.pFormSeparator.Font = null;
            this.pFormSeparator.Name = "pFormSeparator";
            // 
            // lFormDescription
            // 
            this.lFormDescription.AccessibleDescription = null;
            this.lFormDescription.AccessibleName = null;
            resources.ApplyResources(this.lFormDescription, "lFormDescription");
            this.lFormDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lFormDescription.Name = "lFormDescription";
            // 
            // MowayForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BackgroundImage = null;
            this.Controls.Add(this.pFormSeparator);
            this.Controls.Add(this.lFormDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MowayForm";
            this.ShowInTaskbar = false;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MowayForm_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pFormSeparator;
        protected System.Windows.Forms.Label lFormDescription;




    }
}