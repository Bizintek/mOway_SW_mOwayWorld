namespace Moway.Project.GraphicProject.Actions.StartRf
{
    partial class StartRfForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartRfForm));
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lRange0 = new System.Windows.Forms.Label();
            this.nudChanel = new Moway.Template.Controls.MowayNumericUpDown();
            this.nudDirection = new Moway.Template.Controls.MowayNumericUpDown();
            this.lDirection = new System.Windows.Forms.Label();
            this.lChanel = new System.Windows.Forms.Label();
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
            this.gbCommands.Controls.Add(this.label1);
            this.gbCommands.Controls.Add(this.lRange0);
            this.gbCommands.Controls.Add(this.nudChanel);
            this.gbCommands.Controls.Add(this.nudDirection);
            this.gbCommands.Controls.Add(this.lDirection);
            this.gbCommands.Controls.Add(this.lChanel);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lRange0
            // 
            resources.ApplyResources(this.lRange0, "lRange0");
            this.lRange0.Name = "lRange0";
            // 
            // nudChanel
            // 
            this.nudChanel.BackColor = System.Drawing.Color.White;
            this.nudChanel.DecimalPlaces = 0;
            resources.ApplyResources(this.nudChanel, "nudChanel");
            this.nudChanel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudChanel.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.nudChanel.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudChanel.Name = "nudChanel";
            this.nudChanel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudDirection
            // 
            this.nudDirection.BackColor = System.Drawing.Color.White;
            this.nudDirection.DecimalPlaces = 0;
            resources.ApplyResources(this.nudDirection, "nudDirection");
            this.nudDirection.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDirection.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudDirection.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDirection.Name = "nudDirection";
            this.nudDirection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lDirection
            // 
            resources.ApplyResources(this.lDirection, "lDirection");
            this.lDirection.Name = "lDirection";
            // 
            // lChanel
            // 
            resources.ApplyResources(this.lChanel, "lChanel");
            this.lChanel.Name = "lChanel";
            // 
            // StartRfForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbCommands);
            this.Name = "StartRfForm";
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private Moway.Template.Controls.MowayNumericUpDown nudChanel;
        private System.Windows.Forms.Label lChanel;
        private Moway.Template.Controls.MowayNumericUpDown nudDirection;
        private System.Windows.Forms.Label lDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lRange0;

    }
}