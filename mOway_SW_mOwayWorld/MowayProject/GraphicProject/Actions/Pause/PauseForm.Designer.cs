namespace Moway.Project.GraphicProject.Actions.Pause
{
    partial class PauseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PauseForm));
            this.mowayGroupBox1 = new Moway.Template.Controls.MowayGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTime = new Moway.Template.Controls.MowayComboBox();
            this.nudTime = new Moway.Template.Controls.MowayNumericUpDown();
            this.lTimeRange = new System.Windows.Forms.Label();
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
            this.mowayGroupBox1.Controls.Add(this.label1);
            this.mowayGroupBox1.Controls.Add(this.cbTime);
            this.mowayGroupBox1.Controls.Add(this.nudTime);
            this.mowayGroupBox1.Controls.Add(this.lTimeRange);
            this.mowayGroupBox1.Name = "mowayGroupBox1";
            this.mowayGroupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbTime
            // 
            this.cbTime.BackColor = System.Drawing.Color.White;
            this.cbTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTime.DropDownHeight = 100;
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbTime, "cbTime");
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Items.AddRange(new object[] {
            resources.GetString("cbTime.Items"),
            resources.GetString("cbTime.Items1")});
            this.cbTime.Name = "cbTime";
            this.cbTime.SelectedIndexChanged += new System.EventHandler(this.CbTime_SelectedIndexChanged);
            // 
            // nudTime
            // 
            this.nudTime.BackColor = System.Drawing.Color.White;
            this.nudTime.DecimalPlaces = 2;
            resources.ApplyResources(this.nudTime, "nudTime");
            this.nudTime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudTime.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudTime.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.nudTime.Name = "nudTime";
            this.nudTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTime.ValueChanged += new System.EventHandler(this.NudTime_ValueChanged);
            // 
            // lTimeRange
            // 
            resources.ApplyResources(this.lTimeRange, "lTimeRange");
            this.lTimeRange.Name = "lTimeRange";
            // 
            // PauseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.mowayGroupBox1);
            this.Name = "PauseForm";
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.mowayGroupBox1, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.mowayGroupBox1.ResumeLayout(false);
            this.mowayGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox mowayGroupBox1;
        private Moway.Template.Controls.MowayComboBox cbTime;
        private Moway.Template.Controls.MowayNumericUpDown nudTime;
        private System.Windows.Forms.Label lTimeRange;
        private System.Windows.Forms.Label label1;
    }
}