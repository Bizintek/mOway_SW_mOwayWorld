namespace Moway.Project.GraphicProject.Forms
{
    partial class ViewCodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCodeForm));
            this.tbCode = new Moway.Template.Controls.MowayTextBox();
            this.bClose = new Moway.Template.Controls.MowayButton();
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
            // tbCode
            // 
            resources.ApplyResources(this.tbCode, "tbCode");
            this.tbCode.BackColor = System.Drawing.SystemColors.Window;
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Name = "tbCode";
            this.tbCode.ReadOnly = true;
            // 
            // bClose
            // 
            resources.ApplyResources(this.bClose, "bClose");
            this.bClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bClose.Name = "bClose";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // ViewCodeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.tbCode);
            this.Name = "ViewCodeForm";
            this.Load += new System.EventHandler(this.ViewCodeForm_Load);
            this.Controls.SetChildIndex(this.tbCode, 0);
            this.Controls.SetChildIndex(this.bClose, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayTextBox tbCode;
        private Moway.Template.Controls.MowayButton bClose;
    }
}