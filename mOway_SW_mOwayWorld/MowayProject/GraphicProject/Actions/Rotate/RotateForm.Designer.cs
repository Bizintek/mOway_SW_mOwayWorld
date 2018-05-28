namespace Moway.Project.GraphicProject.Actions.Rotate
{
    partial class RotateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotateForm));
            this.gbFlowchart = new Moway.Template.Controls.MowayGroupBox();
            this.cbFinishCommands = new Moway.Template.Controls.MowayCheckBox();
            this.lFlowchart = new System.Windows.Forms.Label();
            this.rbContiniously = new Moway.Template.Controls.MowayRadioButton();
            this.rbAngle = new Moway.Template.Controls.MowayRadioButton();
            this.cbTime = new Moway.Template.Controls.MowayComboBox();
            this.cbAngle = new Moway.Template.Controls.MowayComboBox();
            this.nudTime = new Moway.Template.Controls.MowayNumericUpDown();
            this.nudAngle = new Moway.Template.Controls.MowayNumericUpDown();
            this.rbTime = new Moway.Template.Controls.MowayRadioButton();
            this.lTimeRange = new System.Windows.Forms.Label();
            this.lAngleRange = new System.Windows.Forms.Label();
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.lSpeed = new System.Windows.Forms.Label();
            this.rbRotateCenter = new Moway.Template.Controls.MowayRadioButton();
            this.nudSpeed = new Moway.Template.Controls.MowayNumericUpDown();
            this.lSpeedRange = new System.Windows.Forms.Label();
            this.rbRotateWheel = new Moway.Template.Controls.MowayRadioButton();
            this.lRotation = new System.Windows.Forms.Label();
            this.cbRotateCenter = new Moway.Template.Controls.MowayComboBox();
            this.cbRotateWheel = new Moway.Template.Controls.MowayComboBox();
            this.cbSpeed = new Moway.Template.Controls.MowayComboBox();
            this.pbLockMove = new System.Windows.Forms.PictureBox();
            this.gbFlowchart.SuspendLayout();
            this.gbCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).BeginInit();
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
            // gbFlowchart
            // 
            resources.ApplyResources(this.gbFlowchart, "gbFlowchart");
            this.gbFlowchart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbFlowchart.Controls.Add(this.cbFinishCommands);
            this.gbFlowchart.Controls.Add(this.lFlowchart);
            this.gbFlowchart.Controls.Add(this.rbContiniously);
            this.gbFlowchart.Controls.Add(this.rbAngle);
            this.gbFlowchart.Controls.Add(this.cbTime);
            this.gbFlowchart.Controls.Add(this.cbAngle);
            this.gbFlowchart.Controls.Add(this.nudTime);
            this.gbFlowchart.Controls.Add(this.nudAngle);
            this.gbFlowchart.Controls.Add(this.rbTime);
            this.gbFlowchart.Controls.Add(this.lTimeRange);
            this.gbFlowchart.Controls.Add(this.lAngleRange);
            this.gbFlowchart.Name = "gbFlowchart";
            this.gbFlowchart.TabStop = false;
            // 
            // cbFinishCommands
            // 
            resources.ApplyResources(this.cbFinishCommands, "cbFinishCommands");
            this.cbFinishCommands.Name = "cbFinishCommands";
            this.cbFinishCommands.UseVisualStyleBackColor = true;
            // 
            // lFlowchart
            // 
            resources.ApplyResources(this.lFlowchart, "lFlowchart");
            this.lFlowchart.Name = "lFlowchart";
            // 
            // rbContiniously
            // 
            resources.ApplyResources(this.rbContiniously, "rbContiniously");
            this.rbContiniously.Checked = true;
            this.rbContiniously.Name = "rbContiniously";
            this.rbContiniously.TabStop = true;
            this.rbContiniously.UseVisualStyleBackColor = true;
            this.rbContiniously.CheckedChanged += new System.EventHandler(this.RbContiniously_CheckedChanged);
            // 
            // rbAngle
            // 
            resources.ApplyResources(this.rbAngle, "rbAngle");
            this.rbAngle.Name = "rbAngle";
            this.rbAngle.UseVisualStyleBackColor = true;
            this.rbAngle.CheckedChanged += new System.EventHandler(this.RbAngle_CheckedChanged);
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
            // cbAngle
            // 
            this.cbAngle.BackColor = System.Drawing.Color.White;
            this.cbAngle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAngle.DropDownHeight = 100;
            this.cbAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbAngle, "cbAngle");
            this.cbAngle.FormattingEnabled = true;
            this.cbAngle.Items.AddRange(new object[] {
            resources.GetString("cbAngle.Items"),
            resources.GetString("cbAngle.Items1")});
            this.cbAngle.Name = "cbAngle";
            this.cbAngle.SelectedIndexChanged += new System.EventHandler(this.CbAngle_SelectedIndexChanged);
            // 
            // nudTime
            // 
            this.nudTime.BackColor = System.Drawing.Color.White;
            this.nudTime.DecimalPlaces = 1;
            resources.ApplyResources(this.nudTime, "nudTime");
            this.nudTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTime.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            65536});
            this.nudTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudTime.Name = "nudTime";
            this.nudTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // nudAngle
            // 
            this.nudAngle.BackColor = System.Drawing.Color.White;
            this.nudAngle.DecimalPlaces = 1;
            resources.ApplyResources(this.nudAngle, "nudAngle");
            this.nudAngle.Increment = new decimal(new int[] {
            36,
            0,
            0,
            65536});
            this.nudAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nudAngle.Minimum = new decimal(new int[] {
            36,
            0,
            0,
            65536});
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.Value = new decimal(new int[] {
            36,
            0,
            0,
            65536});
            // 
            // rbTime
            // 
            resources.ApplyResources(this.rbTime, "rbTime");
            this.rbTime.Name = "rbTime";
            this.rbTime.UseVisualStyleBackColor = true;
            this.rbTime.CheckedChanged += new System.EventHandler(this.RbTime_CheckedChanged);
            // 
            // lTimeRange
            // 
            resources.ApplyResources(this.lTimeRange, "lTimeRange");
            this.lTimeRange.Name = "lTimeRange";
            // 
            // lAngleRange
            // 
            resources.ApplyResources(this.lAngleRange, "lAngleRange");
            this.lAngleRange.Name = "lAngleRange";
            // 
            // gbCommands
            // 
            resources.ApplyResources(this.gbCommands, "gbCommands");
            this.gbCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbCommands.Controls.Add(this.lSpeed);
            this.gbCommands.Controls.Add(this.rbRotateCenter);
            this.gbCommands.Controls.Add(this.nudSpeed);
            this.gbCommands.Controls.Add(this.lSpeedRange);
            this.gbCommands.Controls.Add(this.rbRotateWheel);
            this.gbCommands.Controls.Add(this.lRotation);
            this.gbCommands.Controls.Add(this.cbRotateCenter);
            this.gbCommands.Controls.Add(this.cbRotateWheel);
            this.gbCommands.Controls.Add(this.cbSpeed);
            this.gbCommands.Controls.Add(this.pbLockMove);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // lSpeed
            // 
            resources.ApplyResources(this.lSpeed, "lSpeed");
            this.lSpeed.Name = "lSpeed";
            // 
            // rbRotateCenter
            // 
            resources.ApplyResources(this.rbRotateCenter, "rbRotateCenter");
            this.rbRotateCenter.Checked = true;
            this.rbRotateCenter.Name = "rbRotateCenter";
            this.rbRotateCenter.TabStop = true;
            this.rbRotateCenter.UseVisualStyleBackColor = true;
            // 
            // nudSpeed
            // 
            this.nudSpeed.BackColor = System.Drawing.Color.White;
            this.nudSpeed.DecimalPlaces = 0;
            resources.ApplyResources(this.nudSpeed, "nudSpeed");
            this.nudSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeed.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lSpeedRange
            // 
            resources.ApplyResources(this.lSpeedRange, "lSpeedRange");
            this.lSpeedRange.Name = "lSpeedRange";
            // 
            // rbRotateWheel
            // 
            resources.ApplyResources(this.rbRotateWheel, "rbRotateWheel");
            this.rbRotateWheel.Name = "rbRotateWheel";
            this.rbRotateWheel.UseVisualStyleBackColor = true;
            this.rbRotateWheel.CheckedChanged += new System.EventHandler(this.RbRotateWheel_CheckedChanged);
            // 
            // lRotation
            // 
            resources.ApplyResources(this.lRotation, "lRotation");
            this.lRotation.Name = "lRotation";
            // 
            // cbRotateCenter
            // 
            this.cbRotateCenter.BackColor = System.Drawing.Color.White;
            this.cbRotateCenter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRotateCenter.DropDownHeight = 100;
            this.cbRotateCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbRotateCenter, "cbRotateCenter");
            this.cbRotateCenter.FormattingEnabled = true;
            this.cbRotateCenter.Items.AddRange(new object[] {
            resources.GetString("cbRotateCenter.Items"),
            resources.GetString("cbRotateCenter.Items1")});
            this.cbRotateCenter.Name = "cbRotateCenter";
            // 
            // cbRotateWheel
            // 
            this.cbRotateWheel.BackColor = System.Drawing.Color.White;
            this.cbRotateWheel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRotateWheel.DropDownHeight = 100;
            this.cbRotateWheel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbRotateWheel, "cbRotateWheel");
            this.cbRotateWheel.FormattingEnabled = true;
            this.cbRotateWheel.Items.AddRange(new object[] {
            resources.GetString("cbRotateWheel.Items"),
            resources.GetString("cbRotateWheel.Items1"),
            resources.GetString("cbRotateWheel.Items2"),
            resources.GetString("cbRotateWheel.Items3")});
            this.cbRotateWheel.Name = "cbRotateWheel";
            // 
            // cbSpeed
            // 
            this.cbSpeed.BackColor = System.Drawing.Color.White;
            this.cbSpeed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSpeed.DropDownHeight = 100;
            this.cbSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbSpeed, "cbSpeed");
            this.cbSpeed.FormattingEnabled = true;
            this.cbSpeed.Items.AddRange(new object[] {
            resources.GetString("cbSpeed.Items"),
            resources.GetString("cbSpeed.Items1")});
            this.cbSpeed.Name = "cbSpeed";
            this.cbSpeed.SelectedIndexChanged += new System.EventHandler(this.CbSpeed_SelectedIndexChanged);
            // 
            // pbLockMove
            // 
            resources.ApplyResources(this.pbLockMove, "pbLockMove");
            this.pbLockMove.Name = "pbLockMove";
            this.pbLockMove.TabStop = false;
            // 
            // RotateForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbFlowchart);
            this.Controls.Add(this.gbCommands);
            this.Name = "RotateForm";
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.gbFlowchart, 0);
            this.gbFlowchart.ResumeLayout(false);
            this.gbFlowchart.PerformLayout();
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbFlowchart;
        private Moway.Template.Controls.MowayCheckBox cbFinishCommands;
        private System.Windows.Forms.Label lFlowchart;
        private Moway.Template.Controls.MowayRadioButton rbContiniously;
        private Moway.Template.Controls.MowayRadioButton rbAngle;
        private Moway.Template.Controls.MowayComboBox cbTime;
        private Moway.Template.Controls.MowayComboBox cbAngle;
        private Moway.Template.Controls.MowayNumericUpDown nudTime;
        private Moway.Template.Controls.MowayNumericUpDown nudAngle;
        private Moway.Template.Controls.MowayRadioButton rbTime;
        private System.Windows.Forms.Label lTimeRange;
        private System.Windows.Forms.Label lAngleRange;
        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private System.Windows.Forms.Label lSpeed;
        private Moway.Template.Controls.MowayRadioButton rbRotateCenter;
        private Moway.Template.Controls.MowayNumericUpDown nudSpeed;
        private System.Windows.Forms.Label lSpeedRange;
        private Moway.Template.Controls.MowayRadioButton rbRotateWheel;
        private Moway.Template.Controls.MowayComboBox cbSpeed;
        private System.Windows.Forms.Label lRotation;
        private System.Windows.Forms.PictureBox pbLockMove;
        private Moway.Template.Controls.MowayComboBox cbRotateWheel;
        private Moway.Template.Controls.MowayComboBox cbRotateCenter;
    }
}