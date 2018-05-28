namespace Moway.Project.GraphicProject.Actions.Free
{
    partial class FreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FreeForm));
            this.gbSettings = new Moway.Template.Controls.MowayGroupBox();
            this.pLeftMove = new System.Windows.Forms.Panel();
            this.lLeftSpeed = new System.Windows.Forms.Label();
            this.rbLeftForward = new Moway.Template.Controls.MowayRadioButton();
            this.nudLeftSpeed = new Moway.Template.Controls.MowayNumericUpDown();
            this.lLelftSpeedHelp = new System.Windows.Forms.Label();
            this.rbLeftBackward = new Moway.Template.Controls.MowayRadioButton();
            this.cbLeftSpeed = new Moway.Template.Controls.MowayComboBox();
            this.lLeftDirection = new System.Windows.Forms.Label();
            this.pRightMove = new System.Windows.Forms.Panel();
            this.lRightSpeed = new System.Windows.Forms.Label();
            this.rbRightForward = new Moway.Template.Controls.MowayRadioButton();
            this.nudRightSpeed = new Moway.Template.Controls.MowayNumericUpDown();
            this.lRIghtSpeedHelp = new System.Windows.Forms.Label();
            this.cbRightSpeed = new Moway.Template.Controls.MowayComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbRightBackward = new Moway.Template.Controls.MowayRadioButton();
            this.pbFreeMove = new System.Windows.Forms.PictureBox();
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
            this.gbSettings.SuspendLayout();
            this.pLeftMove.SuspendLayout();
            this.pRightMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFreeMove)).BeginInit();
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
            // gbSettings
            // 
            resources.ApplyResources(this.gbSettings, "gbSettings");
            this.gbSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbSettings.Controls.Add(this.pLeftMove);
            this.gbSettings.Controls.Add(this.pRightMove);
            this.gbSettings.Controls.Add(this.pbFreeMove);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.TabStop = false;
            // 
            // pLeftMove
            // 
            this.pLeftMove.Controls.Add(this.lLeftSpeed);
            this.pLeftMove.Controls.Add(this.rbLeftForward);
            this.pLeftMove.Controls.Add(this.nudLeftSpeed);
            this.pLeftMove.Controls.Add(this.lLelftSpeedHelp);
            this.pLeftMove.Controls.Add(this.rbLeftBackward);
            this.pLeftMove.Controls.Add(this.cbLeftSpeed);
            this.pLeftMove.Controls.Add(this.lLeftDirection);
            resources.ApplyResources(this.pLeftMove, "pLeftMove");
            this.pLeftMove.Name = "pLeftMove";
            // 
            // lLeftSpeed
            // 
            resources.ApplyResources(this.lLeftSpeed, "lLeftSpeed");
            this.lLeftSpeed.Name = "lLeftSpeed";
            // 
            // rbLeftForward
            // 
            resources.ApplyResources(this.rbLeftForward, "rbLeftForward");
            this.rbLeftForward.Checked = true;
            this.rbLeftForward.Name = "rbLeftForward";
            this.rbLeftForward.TabStop = true;
            this.rbLeftForward.UseVisualStyleBackColor = true;
            // 
            // nudLeftSpeed
            // 
            this.nudLeftSpeed.BackColor = System.Drawing.Color.White;
            this.nudLeftSpeed.DecimalPlaces = 0;
            resources.ApplyResources(this.nudLeftSpeed, "nudLeftSpeed");
            this.nudLeftSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLeftSpeed.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudLeftSpeed.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLeftSpeed.Name = "nudLeftSpeed";
            this.nudLeftSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lLelftSpeedHelp
            // 
            resources.ApplyResources(this.lLelftSpeedHelp, "lLelftSpeedHelp");
            this.lLelftSpeedHelp.Name = "lLelftSpeedHelp";
            // 
            // rbLeftBackward
            // 
            resources.ApplyResources(this.rbLeftBackward, "rbLeftBackward");
            this.rbLeftBackward.Name = "rbLeftBackward";
            this.rbLeftBackward.UseVisualStyleBackColor = true;
            // 
            // cbLeftSpeed
            // 
            this.cbLeftSpeed.BackColor = System.Drawing.Color.White;
            this.cbLeftSpeed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLeftSpeed.DropDownHeight = 100;
            this.cbLeftSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLeftSpeed, "cbLeftSpeed");
            this.cbLeftSpeed.FormattingEnabled = true;
            this.cbLeftSpeed.Items.AddRange(new object[] {
            resources.GetString("cbLeftSpeed.Items"),
            resources.GetString("cbLeftSpeed.Items1")});
            this.cbLeftSpeed.Name = "cbLeftSpeed";
            this.cbLeftSpeed.SelectedIndexChanged += new System.EventHandler(this.CbLeftSpeed_SelectedIndexChanged);
            // 
            // lLeftDirection
            // 
            resources.ApplyResources(this.lLeftDirection, "lLeftDirection");
            this.lLeftDirection.Name = "lLeftDirection";
            // 
            // pRightMove
            // 
            this.pRightMove.Controls.Add(this.lRightSpeed);
            this.pRightMove.Controls.Add(this.rbRightForward);
            this.pRightMove.Controls.Add(this.nudRightSpeed);
            this.pRightMove.Controls.Add(this.lRIghtSpeedHelp);
            this.pRightMove.Controls.Add(this.cbRightSpeed);
            this.pRightMove.Controls.Add(this.label5);
            this.pRightMove.Controls.Add(this.rbRightBackward);
            resources.ApplyResources(this.pRightMove, "pRightMove");
            this.pRightMove.Name = "pRightMove";
            // 
            // lRightSpeed
            // 
            resources.ApplyResources(this.lRightSpeed, "lRightSpeed");
            this.lRightSpeed.Name = "lRightSpeed";
            // 
            // rbRightForward
            // 
            resources.ApplyResources(this.rbRightForward, "rbRightForward");
            this.rbRightForward.Checked = true;
            this.rbRightForward.Name = "rbRightForward";
            this.rbRightForward.TabStop = true;
            this.rbRightForward.UseVisualStyleBackColor = true;
            // 
            // nudRightSpeed
            // 
            this.nudRightSpeed.BackColor = System.Drawing.Color.White;
            this.nudRightSpeed.DecimalPlaces = 0;
            resources.ApplyResources(this.nudRightSpeed, "nudRightSpeed");
            this.nudRightSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRightSpeed.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudRightSpeed.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRightSpeed.Name = "nudRightSpeed";
            this.nudRightSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lRIghtSpeedHelp
            // 
            resources.ApplyResources(this.lRIghtSpeedHelp, "lRIghtSpeedHelp");
            this.lRIghtSpeedHelp.Name = "lRIghtSpeedHelp";
            // 
            // cbRightSpeed
            // 
            this.cbRightSpeed.BackColor = System.Drawing.Color.White;
            this.cbRightSpeed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRightSpeed.DropDownHeight = 100;
            this.cbRightSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbRightSpeed, "cbRightSpeed");
            this.cbRightSpeed.FormattingEnabled = true;
            this.cbRightSpeed.Items.AddRange(new object[] {
            resources.GetString("cbRightSpeed.Items"),
            resources.GetString("cbRightSpeed.Items1")});
            this.cbRightSpeed.Name = "cbRightSpeed";
            this.cbRightSpeed.SelectedIndexChanged += new System.EventHandler(this.CbRightSpeed_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // rbRightBackward
            // 
            resources.ApplyResources(this.rbRightBackward, "rbRightBackward");
            this.rbRightBackward.Name = "rbRightBackward";
            this.rbRightBackward.UseVisualStyleBackColor = true;
            // 
            // pbFreeMove
            // 
            resources.ApplyResources(this.pbFreeMove, "pbFreeMove");
            this.pbFreeMove.Name = "pbFreeMove";
            this.pbFreeMove.TabStop = false;
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
            // FreeForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbFlowchart);
            this.Controls.Add(this.gbSettings);
            this.HelpButton = true;
            this.Name = "FreeForm";
            this.Controls.SetChildIndex(this.gbSettings, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.gbFlowchart, 0);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.pLeftMove.ResumeLayout(false);
            this.pLeftMove.PerformLayout();
            this.pRightMove.ResumeLayout(false);
            this.pRightMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFreeMove)).EndInit();
            this.gbFlowchart.ResumeLayout(false);
            this.gbFlowchart.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbSettings;
        private System.Windows.Forms.PictureBox pbFreeMove;
        private System.Windows.Forms.Panel pLeftMove;
        private System.Windows.Forms.Label lLeftSpeed;
        private Moway.Template.Controls.MowayRadioButton rbLeftForward;
        private Moway.Template.Controls.MowayNumericUpDown nudLeftSpeed;
        private System.Windows.Forms.Label lLelftSpeedHelp;
        private Moway.Template.Controls.MowayRadioButton rbLeftBackward;
        private Moway.Template.Controls.MowayComboBox cbLeftSpeed;
        private System.Windows.Forms.Label lLeftDirection;
        private System.Windows.Forms.Panel pRightMove;
        private System.Windows.Forms.Label lRightSpeed;
        private Moway.Template.Controls.MowayRadioButton rbRightForward;
        private Moway.Template.Controls.MowayNumericUpDown nudRightSpeed;
        private System.Windows.Forms.Label lRIghtSpeedHelp;
        private Moway.Template.Controls.MowayRadioButton rbRightBackward;
        private Moway.Template.Controls.MowayComboBox cbRightSpeed;
        private System.Windows.Forms.Label label5;
        private Moway.Template.Controls.MowayGroupBox gbFlowchart;
        private Moway.Template.Controls.MowayCheckBox cbFinishCommands;
        private System.Windows.Forms.Label lFlowchart;
        private Moway.Template.Controls.MowayRadioButton rbContiniously;
        private Moway.Template.Controls.MowayRadioButton rbDistance;
        private Moway.Template.Controls.MowayComboBox cbTime;
        private Moway.Template.Controls.MowayComboBox cbDistance;
        private Moway.Template.Controls.MowayNumericUpDown nudTime;
        private Moway.Template.Controls.MowayNumericUpDown nudDistance;
        private Moway.Template.Controls.MowayRadioButton rbTime;
        private System.Windows.Forms.Label lTimeRange;
        private System.Windows.Forms.Label lDistanceRange;

    }
}