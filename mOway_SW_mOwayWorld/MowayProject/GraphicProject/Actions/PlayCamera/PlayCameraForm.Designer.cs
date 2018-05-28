namespace Moway.Project.GraphicProject.Actions.PlayCamera
{
    partial class PlayCameraForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayCameraForm));
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.lFrequency = new System.Windows.Forms.Label();
            this.nudFrequency = new Moway.Template.Controls.MowayNumericUpDown();
            this.lfrequencyMargin = new System.Windows.Forms.Label();
            this.gbCommands.SuspendLayout();
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
            // gbCommands
            // 
            resources.ApplyResources(this.gbCommands, "gbCommands");
            this.gbCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbCommands.Controls.Add(this.lFrequency);
            this.gbCommands.Controls.Add(this.nudFrequency);
            this.gbCommands.Controls.Add(this.lfrequencyMargin);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // lFrequency
            // 
            resources.ApplyResources(this.lFrequency, "lFrequency");
            this.lFrequency.Name = "lFrequency";
            // 
            // nudFrequency
            // 
            this.nudFrequency.BackColor = System.Drawing.Color.White;
            this.nudFrequency.DecimalPlaces = 0;
            resources.ApplyResources(this.nudFrequency, "nudFrequency");
            this.nudFrequency.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrequency.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFrequency.Name = "nudFrequency";
            this.nudFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lfrequencyMargin
            // 
            resources.ApplyResources(this.lfrequencyMargin, "lfrequencyMargin");
            this.lfrequencyMargin.Name = "lfrequencyMargin";
            // 
            // PlayCameraForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbCommands);
            this.Name = "PlayCameraForm";
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private System.Windows.Forms.Label lFrequency;
        private Moway.Template.Controls.MowayNumericUpDown nudFrequency;
        private System.Windows.Forms.Label lfrequencyMargin;
    }
}