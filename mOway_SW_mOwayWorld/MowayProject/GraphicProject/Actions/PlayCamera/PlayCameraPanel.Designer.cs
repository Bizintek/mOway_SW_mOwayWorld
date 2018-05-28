﻿namespace Moway.Project.GraphicProject.Actions.PlayCamera
{
    partial class PlayCameraPanel
    {
        /// <summary> 
        /// Variable of the designer required.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean the resources that are being used.
        /// </summary>
        /// <param name="disposing">true if the managed resources should be removed; false otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code generated by the Component Designer

        /// <summary> 
        /// Method necessary to support the Designer. It can not be modified 
        /// the content of the method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayCameraPanel));
            this.lFrequency = new System.Windows.Forms.Label();
            this.nudFrequency = new Moway.Template.Controls.MowayNumericUpDown();
            this.lfrequencyMargin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lActionName
            // 
            resources.ApplyResources(this.lActionName, "lActionName");
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
            this.nudFrequency.ValueChanged += new System.EventHandler(this.NudFrequency_ValueChanged);
            // 
            // lfrequencyMargin
            // 
            resources.ApplyResources(this.lfrequencyMargin, "lfrequencyMargin");
            this.lfrequencyMargin.Name = "lfrequencyMargin";
            // 
            // PlayCameraPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.nudFrequency);
            this.Controls.Add(this.lfrequencyMargin);
            this.Controls.Add(this.lFrequency);
            resources.ApplyResources(this, "$this");
            this.Name = "PlayCameraPanel";
            this.Controls.SetChildIndex(this.lFrequency, 0);
            this.Controls.SetChildIndex(this.lActionName, 0);
            this.Controls.SetChildIndex(this.lfrequencyMargin, 0);
            this.Controls.SetChildIndex(this.nudFrequency, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lFrequency;
        private Moway.Template.Controls.MowayNumericUpDown nudFrequency;
        private System.Windows.Forms.Label lfrequencyMargin;
    }
}