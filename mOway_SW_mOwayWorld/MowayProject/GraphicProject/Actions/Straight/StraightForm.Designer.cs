namespace Moway.Project.GraphicProject.Actions.Straight
{
    partial class StraightForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StraightForm));
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.lSpeed = new System.Windows.Forms.Label();
            this.rbForward = new Moway.Template.Controls.MowayRadioButton();
            this.nudSpeed = new Moway.Template.Controls.MowayNumericUpDown();
            this.lSpeedRange = new System.Windows.Forms.Label();
            this.rbBackward = new Moway.Template.Controls.MowayRadioButton();
            this.cbSpeed = new Moway.Template.Controls.MowayComboBox();
            this.lDirection = new System.Windows.Forms.Label();
            this.pbLockMove = new System.Windows.Forms.PictureBox();
            this.gbFlowchart = new Moway.Template.Controls.MowayGroupBox();
            this.lFlowchart = new System.Windows.Forms.Label();
            this.rbContiniously = new Moway.Template.Controls.MowayRadioButton();
            this.rbDistance = new Moway.Template.Controls.MowayRadioButton();
            this.cbTime = new Moway.Template.Controls.MowayComboBox();
            this.cbDistance = new Moway.Template.Controls.MowayComboBox();
            this.nudTime = new Moway.Template.Controls.MowayNumericUpDown();
            this.nudDistance = new Moway.Template.Controls.MowayNumericUpDown();
            this.rbTime = new Moway.Template.Controls.MowayRadioButton();
            this.lTimeRange = new System.Windows.Forms.Label();
            this.cbFinishCommands = new Moway.Template.Controls.MowayCheckBox();
            this.lDistanceRange = new System.Windows.Forms.Label();
            this.gbCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).BeginInit();
            this.gbFlowchart.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bSave.Image = global::Moway.Project.Properties.Resources.save;
            resources.ApplyResources(this.bSave, "bSave");
            // 
            // bCancel
            // 
            this.bCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bCancel.Image = global::Moway.Project.Properties.Resources.cancel;
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
            this.gbCommands.Controls.Add(this.lSpeed);
            this.gbCommands.Controls.Add(this.rbForward);
            this.gbCommands.Controls.Add(this.nudSpeed);
            this.gbCommands.Controls.Add(this.lSpeedRange);
            this.gbCommands.Controls.Add(this.rbBackward);
            this.gbCommands.Controls.Add(this.cbSpeed);
            this.gbCommands.Controls.Add(this.lDirection);
            this.gbCommands.Controls.Add(this.pbLockMove);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // lSpeed
            // 
            resources.ApplyResources(this.lSpeed, "lSpeed");
            this.lSpeed.Name = "lSpeed";
            // 
            // rbForward
            // 
            resources.ApplyResources(this.rbForward, "rbForward");
            this.rbForward.Checked = true;
            this.rbForward.Name = "rbForward";
            this.rbForward.TabStop = true;
            this.rbForward.UseVisualStyleBackColor = true;
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
            0,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lSpeedRange
            // 
            resources.ApplyResources(this.lSpeedRange, "lSpeedRange");
            this.lSpeedRange.Name = "lSpeedRange";
            // 
            // rbBackward
            // 
            resources.ApplyResources(this.rbBackward, "rbBackward");
            this.rbBackward.Name = "rbBackward";
            this.rbBackward.UseVisualStyleBackColor = true;
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
            // lDirection
            // 
            resources.ApplyResources(this.lDirection, "lDirection");
            this.lDirection.Name = "lDirection";
            // 
            // pbLockMove
            // 
            resources.ApplyResources(this.pbLockMove, "pbLockMove");
            this.pbLockMove.Name = "pbLockMove";
            this.pbLockMove.TabStop = false;
            // 
            // gbFlowchart
            // 
            resources.ApplyResources(this.gbFlowchart, "gbFlowchart");
            this.gbFlowchart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbFlowchart.Controls.Add(this.lFlowchart);
            this.gbFlowchart.Controls.Add(this.rbContiniously);
            this.gbFlowchart.Controls.Add(this.rbDistance);
            this.gbFlowchart.Controls.Add(this.cbTime);
            this.gbFlowchart.Controls.Add(this.cbDistance);
            this.gbFlowchart.Controls.Add(this.nudTime);
            this.gbFlowchart.Controls.Add(this.nudDistance);
            this.gbFlowchart.Controls.Add(this.rbTime);
            this.gbFlowchart.Controls.Add(this.lTimeRange);
            this.gbFlowchart.Controls.Add(this.cbFinishCommands);
            this.gbFlowchart.Controls.Add(this.lDistanceRange);
            this.gbFlowchart.Name = "gbFlowchart";
            this.gbFlowchart.TabStop = false;
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
            // rbDistance
            // 
            resources.ApplyResources(this.rbDistance, "rbDistance");
            this.rbDistance.Name = "rbDistance";
            this.rbDistance.UseVisualStyleBackColor = true;
            this.rbDistance.CheckedChanged += new System.EventHandler(this.RbDistance_CheckedChanged);
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
            // cbDistance
            // 
            this.cbDistance.BackColor = System.Drawing.Color.White;
            this.cbDistance.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDistance.DropDownHeight = 100;
            this.cbDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbDistance, "cbDistance");
            this.cbDistance.FormattingEnabled = true;
            this.cbDistance.Items.AddRange(new object[] {
            resources.GetString("cbDistance.Items"),
            resources.GetString("cbDistance.Items1")});
            this.cbDistance.Name = "cbDistance";
            this.cbDistance.SelectedIndexChanged += new System.EventHandler(this.CbDistance_SelectedIndexChanged);
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
            // nudDistance
            // 
            this.nudDistance.BackColor = System.Drawing.Color.White;
            this.nudDistance.DecimalPlaces = 1;
            resources.ApplyResources(this.nudDistance, "nudDistance");
            this.nudDistance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudDistance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            65536});
            this.nudDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudDistance.Name = "nudDistance";
            this.nudDistance.Value = new decimal(new int[] {
            1,
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
            // cbFinishCommands
            // 
            resources.ApplyResources(this.cbFinishCommands, "cbFinishCommands");
            this.cbFinishCommands.Name = "cbFinishCommands";
            this.cbFinishCommands.UseVisualStyleBackColor = true;
            // 
            // lDistanceRange
            // 
            resources.ApplyResources(this.lDistanceRange, "lDistanceRange");
            this.lDistanceRange.Name = "lDistanceRange";
            // 
            // StraightForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbFlowchart);
            this.Controls.Add(this.gbCommands);
            this.Name = "StraightForm";
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.gbFlowchart, 0);
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).EndInit();
            this.gbFlowchart.ResumeLayout(false);
            this.gbFlowchart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private Moway.Template.Controls.MowayGroupBox gbFlowchart;
        private System.Windows.Forms.Label lTimeRange;
        private Moway.Template.Controls.MowayComboBox cbTime;
        private Moway.Template.Controls.MowayNumericUpDown nudTime;
        private Moway.Template.Controls.MowayRadioButton rbDistance;
        private Moway.Template.Controls.MowayRadioButton rbTime;
        private Moway.Template.Controls.MowayRadioButton rbContiniously;
        private System.Windows.Forms.Label lDistanceRange;
        private Moway.Template.Controls.MowayComboBox cbDistance;
        private Moway.Template.Controls.MowayNumericUpDown nudDistance;
        private System.Windows.Forms.PictureBox pbLockMove;
        private System.Windows.Forms.Label lFlowchart;
        private Moway.Template.Controls.MowayCheckBox cbFinishCommands;
        private System.Windows.Forms.Label lSpeed;
        private Moway.Template.Controls.MowayRadioButton rbForward;
        private Moway.Template.Controls.MowayNumericUpDown nudSpeed;
        private System.Windows.Forms.Label lSpeedRange;
        private Moway.Template.Controls.MowayRadioButton rbBackward;
        private Moway.Template.Controls.MowayComboBox cbSpeed;
        private System.Windows.Forms.Label lDirection;

    }
}