namespace Moway.Project.GraphicProject.Actions.Reset
{
    partial class ResetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetForm));
            this.mowayGroupBox1 = new Moway.Template.Controls.MowayGroupBox();
            this.cbDistance = new Moway.Template.Controls.MowayCheckBox();
            this.cbTime = new Moway.Template.Controls.MowayCheckBox();
            this.mowayGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            resources.ApplyResources(this.bSave, "bSave");
            // 
            // bCancel
            // 
            this.bCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            resources.ApplyResources(this.bCancel, "bCancel");
            // 
            // llHelp
            // 
            resources.ApplyResources(this.llHelp, "llHelp");
            // 
            // pFormSeparator
            // 
            resources.ApplyResources(this.pFormSeparator, "pFormSeparator");
            // 
            // lFormDescription
            // 
            resources.ApplyResources(this.lFormDescription, "lFormDescription");
            // 
            // mowayGroupBox1
            // 
            resources.ApplyResources(this.mowayGroupBox1, "mowayGroupBox1");
            this.mowayGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.mowayGroupBox1.Controls.Add(this.cbDistance);
            this.mowayGroupBox1.Controls.Add(this.cbTime);
            this.mowayGroupBox1.Name = "mowayGroupBox1";
            this.mowayGroupBox1.TabStop = false;
            // 
            // cbDistance
            // 
            resources.ApplyResources(this.cbDistance, "cbDistance");
            this.cbDistance.Name = "cbDistance";
            this.cbDistance.UseVisualStyleBackColor = true;
            // 
            // cbTime
            // 
            resources.ApplyResources(this.cbTime, "cbTime");
            this.cbTime.Name = "cbTime";
            this.cbTime.UseVisualStyleBackColor = true;
            // 
            // ResetForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.mowayGroupBox1);
            this.Name = "ResetForm";
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.mowayGroupBox1, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.mowayGroupBox1.ResumeLayout(false);
            this.mowayGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox mowayGroupBox1;
        private Moway.Template.Controls.MowayCheckBox cbTime;
        private Moway.Template.Controls.MowayCheckBox cbDistance;
    }
}