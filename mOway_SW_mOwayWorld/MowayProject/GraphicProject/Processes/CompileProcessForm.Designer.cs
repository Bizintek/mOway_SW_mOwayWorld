namespace Moway.Project.GraphicProject.Processes
{
    partial class CompileProcessForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompileProcessForm));
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.lCheckDiagram = new System.Windows.Forms.Label();
            this.lGenerateCode = new System.Windows.Forms.Label();
            this.lCompileCode = new System.Windows.Forms.Label();
            this.pbCheckDiagram = new System.Windows.Forms.PictureBox();
            this.pbGenerateCode = new System.Windows.Forms.PictureBox();
            this.pbCompileCode = new System.Windows.Forms.PictureBox();
            this.opTimer = new System.Windows.Forms.Timer(this.components);
            this.bClose = new Moway.Template.Controls.MowayButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerateCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompileCode)).BeginInit();
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
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "StatusLoading.png");
            this.icons.Images.SetKeyName(1, "StatusOK.png");
            this.icons.Images.SetKeyName(2, "StatusError.png");
            this.icons.Images.SetKeyName(3, "StatusWarning.png");
            // 
            // lCheckDiagram
            // 
            resources.ApplyResources(this.lCheckDiagram, "lCheckDiagram");
            this.lCheckDiagram.Name = "lCheckDiagram";
            // 
            // lGenerateCode
            // 
            resources.ApplyResources(this.lGenerateCode, "lGenerateCode");
            this.lGenerateCode.Name = "lGenerateCode";
            // 
            // lCompileCode
            // 
            resources.ApplyResources(this.lCompileCode, "lCompileCode");
            this.lCompileCode.Name = "lCompileCode";
            // 
            // pbCheckDiagram
            // 
            resources.ApplyResources(this.pbCheckDiagram, "pbCheckDiagram");
            this.pbCheckDiagram.Name = "pbCheckDiagram";
            this.pbCheckDiagram.TabStop = false;
            // 
            // pbGenerateCode
            // 
            resources.ApplyResources(this.pbGenerateCode, "pbGenerateCode");
            this.pbGenerateCode.Name = "pbGenerateCode";
            this.pbGenerateCode.TabStop = false;
            // 
            // pbCompileCode
            // 
            resources.ApplyResources(this.pbCompileCode, "pbCompileCode");
            this.pbCompileCode.Name = "pbCompileCode";
            this.pbCompileCode.TabStop = false;
            // 
            // opTimer
            // 
            this.opTimer.Interval = 500;
            this.opTimer.Tick += new System.EventHandler(this.OpTimer_Tick);
            // 
            // bClose
            // 
            resources.ApplyResources(this.bClose, "bClose");
            this.bClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bClose.Name = "bClose";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // CompileProcessForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.pbCompileCode);
            this.Controls.Add(this.pbGenerateCode);
            this.Controls.Add(this.pbCheckDiagram);
            this.Controls.Add(this.lCompileCode);
            this.Controls.Add(this.lGenerateCode);
            this.Controls.Add(this.lCheckDiagram);
            this.Name = "CompileProcessForm";
            this.Controls.SetChildIndex(this.lCheckDiagram, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.lGenerateCode, 0);
            this.Controls.SetChildIndex(this.lCompileCode, 0);
            this.Controls.SetChildIndex(this.pbCheckDiagram, 0);
            this.Controls.SetChildIndex(this.pbGenerateCode, 0);
            this.Controls.SetChildIndex(this.pbCompileCode, 0);
            this.Controls.SetChildIndex(this.bClose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbCheckDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerateCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompileCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.Label lCheckDiagram;
        private System.Windows.Forms.Label lGenerateCode;
        private System.Windows.Forms.Label lCompileCode;
        private System.Windows.Forms.PictureBox pbCheckDiagram;
        private System.Windows.Forms.PictureBox pbGenerateCode;
        private System.Windows.Forms.PictureBox pbCompileCode;
        private System.Windows.Forms.Timer opTimer;
        private Moway.Template.Controls.MowayButton bClose;
    }
}