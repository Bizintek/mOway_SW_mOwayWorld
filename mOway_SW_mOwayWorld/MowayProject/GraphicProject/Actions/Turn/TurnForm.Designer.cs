namespace Moway.Project.GraphicProject.Actions.Turn
{
    partial class TurnForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TurnForm));
            this.gbFlowchart = new Moway.Template.Controls.MowayGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFinishCommands = new Moway.Template.Controls.MowayCheckBox();
            this.rbContiniously = new Moway.Template.Controls.MowayRadioButton();
            this.rbDistance = new Moway.Template.Controls.MowayRadioButton();
            this.cbTime = new Moway.Template.Controls.MowayComboBox();
            this.cbDistance = new Moway.Template.Controls.MowayComboBox();
            this.nudTime = new Moway.Template.Controls.MowayNumericUpDown();
            this.nudDistance = new Moway.Template.Controls.MowayNumericUpDown();
            this.rbTime = new Moway.Template.Controls.MowayRadioButton();
            this.lTimeRange = new System.Windows.Forms.Label();
            this.lDistanceRange = new System.Windows.Forms.Label();
            this.pTurnDirection = new System.Windows.Forms.Panel();
            this.rbRight = new Moway.Template.Controls.MowayRadioButton();
            this.rbLeft = new Moway.Template.Controls.MowayRadioButton();
            this.pDirection = new System.Windows.Forms.Panel();
            this.rbForward = new Moway.Template.Controls.MowayRadioButton();
            this.rbBackward = new Moway.Template.Controls.MowayRadioButton();
            this.cbRadius = new Moway.Template.Controls.MowayComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lTurnDirection = new System.Windows.Forms.Label();
            this.pbLockMove = new System.Windows.Forms.PictureBox();
            this.lDirection = new System.Windows.Forms.Label();
            this.cbSpeed = new Moway.Template.Controls.MowayComboBox();
            this.lSpeedRange = new System.Windows.Forms.Label();
            this.lRadius = new System.Windows.Forms.Label();
            this.nudSpeed = new Moway.Template.Controls.MowayNumericUpDown();
            this.lSpeed = new System.Windows.Forms.Label();
            this.nudRadius = new Moway.Template.Controls.MowayNumericUpDown();
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.gbFlowchart.SuspendLayout();
            this.pTurnDirection.SuspendLayout();
            this.pDirection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).BeginInit();
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
            // gbFlowchart
            // 
            resources.ApplyResources(this.gbFlowchart, "gbFlowchart");
            this.gbFlowchart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbFlowchart.Controls.Add(this.label1);
            this.gbFlowchart.Controls.Add(this.cbFinishCommands);
            this.gbFlowchart.Controls.Add(this.rbContiniously);
            this.gbFlowchart.Controls.Add(this.rbDistance);
            this.gbFlowchart.Controls.Add(this.cbTime);
            this.gbFlowchart.Controls.Add(this.cbDistance);
            this.gbFlowchart.Controls.Add(this.nudTime);
            this.gbFlowchart.Controls.Add(this.nudDistance);
            this.gbFlowchart.Controls.Add(this.rbTime);
            this.gbFlowchart.Controls.Add(this.lTimeRange);
            this.gbFlowchart.Controls.Add(this.lDistanceRange);
            this.gbFlowchart.Name = "gbFlowchart";
            this.gbFlowchart.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbFinishCommands
            // 
            resources.ApplyResources(this.cbFinishCommands, "cbFinishCommands");
            this.cbFinishCommands.Name = "cbFinishCommands";
            this.cbFinishCommands.UseVisualStyleBackColor = true;
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
            // lDistanceRange
            // 
            resources.ApplyResources(this.lDistanceRange, "lDistanceRange");
            this.lDistanceRange.Name = "lDistanceRange";
            // 
            // pTurnDirection
            // 
            this.pTurnDirection.Controls.Add(this.rbRight);
            this.pTurnDirection.Controls.Add(this.rbLeft);
            resources.ApplyResources(this.pTurnDirection, "pTurnDirection");
            this.pTurnDirection.Name = "pTurnDirection";
            // 
            // rbRight
            // 
            resources.ApplyResources(this.rbRight, "rbRight");
            this.rbRight.Checked = true;
            this.rbRight.Name = "rbRight";
            this.rbRight.TabStop = true;
            this.rbRight.UseVisualStyleBackColor = true;
            // 
            // rbLeft
            // 
            resources.ApplyResources(this.rbLeft, "rbLeft");
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.UseVisualStyleBackColor = true;
            // 
            // pDirection
            // 
            this.pDirection.Controls.Add(this.rbForward);
            this.pDirection.Controls.Add(this.rbBackward);
            resources.ApplyResources(this.pDirection, "pDirection");
            this.pDirection.Name = "pDirection";
            // 
            // rbForward
            // 
            resources.ApplyResources(this.rbForward, "rbForward");
            this.rbForward.Checked = true;
            this.rbForward.Name = "rbForward";
            this.rbForward.TabStop = true;
            this.rbForward.UseVisualStyleBackColor = true;
            // 
            // rbBackward
            // 
            resources.ApplyResources(this.rbBackward, "rbBackward");
            this.rbBackward.Name = "rbBackward";
            this.rbBackward.UseVisualStyleBackColor = true;
            // 
            // cbRadius
            // 
            this.cbRadius.BackColor = System.Drawing.Color.White;
            this.cbRadius.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRadius.DropDownHeight = 100;
            this.cbRadius.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbRadius, "cbRadius");
            this.cbRadius.FormattingEnabled = true;
            this.cbRadius.Items.AddRange(new object[] {
            resources.GetString("cbRadius.Items"),
            resources.GetString("cbRadius.Items1")});
            this.cbRadius.Name = "cbRadius";
            this.cbRadius.SelectedIndexChanged += new System.EventHandler(this.CbRadius_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lTurnDirection
            // 
            resources.ApplyResources(this.lTurnDirection, "lTurnDirection");
            this.lTurnDirection.Name = "lTurnDirection";
            // 
            // pbLockMove
            // 
            resources.ApplyResources(this.pbLockMove, "pbLockMove");
            this.pbLockMove.Name = "pbLockMove";
            this.pbLockMove.TabStop = false;
            // 
            // lDirection
            // 
            resources.ApplyResources(this.lDirection, "lDirection");
            this.lDirection.Name = "lDirection";
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
            // lSpeedRange
            // 
            resources.ApplyResources(this.lSpeedRange, "lSpeedRange");
            this.lSpeedRange.Name = "lSpeedRange";
            // 
            // lRadius
            // 
            resources.ApplyResources(this.lRadius, "lRadius");
            this.lRadius.Name = "lRadius";
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
            99,
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
            this.nudSpeed.ValueChanged += new System.EventHandler(this.NudSpeed_ValueChanged);
            // 
            // lSpeed
            // 
            resources.ApplyResources(this.lSpeed, "lSpeed");
            this.lSpeed.Name = "lSpeed";
            // 
            // nudRadius
            // 
            this.nudRadius.BackColor = System.Drawing.Color.White;
            this.nudRadius.DecimalPlaces = 0;
            resources.ApplyResources(this.nudRadius, "nudRadius");
            this.nudRadius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRadius.Maximum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.nudRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRadius.Name = "nudRadius";
            this.nudRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRadius.ValueChanged += new System.EventHandler(this.NudRadius_ValueChanged);
            // 
            // gbCommands
            // 
            resources.ApplyResources(this.gbCommands, "gbCommands");
            this.gbCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbCommands.Controls.Add(this.nudRadius);
            this.gbCommands.Controls.Add(this.lSpeed);
            this.gbCommands.Controls.Add(this.nudSpeed);
            this.gbCommands.Controls.Add(this.lRadius);
            this.gbCommands.Controls.Add(this.lSpeedRange);
            this.gbCommands.Controls.Add(this.cbSpeed);
            this.gbCommands.Controls.Add(this.lDirection);
            this.gbCommands.Controls.Add(this.pbLockMove);
            this.gbCommands.Controls.Add(this.lTurnDirection);
            this.gbCommands.Controls.Add(this.label2);
            this.gbCommands.Controls.Add(this.cbRadius);
            this.gbCommands.Controls.Add(this.pDirection);
            this.gbCommands.Controls.Add(this.pTurnDirection);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // TurnForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbFlowchart);
            this.Controls.Add(this.gbCommands);
            this.Name = "TurnForm";
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.gbFlowchart, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.gbFlowchart.ResumeLayout(false);
            this.gbFlowchart.PerformLayout();
            this.pTurnDirection.ResumeLayout(false);
            this.pTurnDirection.PerformLayout();
            this.pDirection.ResumeLayout(false);
            this.pDirection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).EndInit();
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbFlowchart;
        private Moway.Template.Controls.MowayCheckBox cbFinishCommands;
        private Moway.Template.Controls.MowayRadioButton rbContiniously;
        private Moway.Template.Controls.MowayRadioButton rbDistance;
        private Moway.Template.Controls.MowayComboBox cbTime;
        private Moway.Template.Controls.MowayComboBox cbDistance;
        private Moway.Template.Controls.MowayNumericUpDown nudTime;
        private Moway.Template.Controls.MowayNumericUpDown nudDistance;
        private Moway.Template.Controls.MowayRadioButton rbTime;
        private System.Windows.Forms.Label lTimeRange;
        private System.Windows.Forms.Label lDistanceRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pTurnDirection;
        private Moway.Template.Controls.MowayRadioButton rbRight;
        private Moway.Template.Controls.MowayRadioButton rbLeft;
        private System.Windows.Forms.Panel pDirection;
        private Moway.Template.Controls.MowayRadioButton rbForward;
        private Moway.Template.Controls.MowayRadioButton rbBackward;
        private Moway.Template.Controls.MowayComboBox cbRadius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lTurnDirection;
        private System.Windows.Forms.PictureBox pbLockMove;
        private System.Windows.Forms.Label lDirection;
        private Moway.Template.Controls.MowayComboBox cbSpeed;
        private System.Windows.Forms.Label lSpeedRange;
        private System.Windows.Forms.Label lRadius;
        private Moway.Template.Controls.MowayNumericUpDown nudSpeed;
        private System.Windows.Forms.Label lSpeed;
        private Moway.Template.Controls.MowayNumericUpDown nudRadius;
        private Moway.Template.Controls.MowayGroupBox gbCommands;
    }
}