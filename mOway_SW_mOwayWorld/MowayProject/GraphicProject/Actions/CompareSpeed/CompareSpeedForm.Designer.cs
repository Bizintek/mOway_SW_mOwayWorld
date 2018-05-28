namespace Moway.Project.GraphicProject.Actions.CompareSpeed
{
    partial class CompareSpeedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareSpeedForm));
            this.gbSettings = new Moway.Template.Controls.MowayGroupBox();
            this.rbRightSpeed = new Moway.Template.Controls.MowayRadioButton();
            this.rbLeftSpeed = new Moway.Template.Controls.MowayRadioButton();
            this.cbCompareVariable = new Moway.Template.Controls.MowayComboBox();
            this.cbOperator = new Moway.Template.Controls.MowayComboBox();
            this.nudCompareValue = new Moway.Template.Controls.MowayNumericUpDown();
            this.lValueHelp = new System.Windows.Forms.Label();
            this.lOuput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.Label();
            this.gbSettings.SuspendLayout();
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
            // gbSettings
            // 
            resources.ApplyResources(this.gbSettings, "gbSettings");
            this.gbSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbSettings.Controls.Add(this.rbRightSpeed);
            this.gbSettings.Controls.Add(this.rbLeftSpeed);
            this.gbSettings.Controls.Add(this.cbCompareVariable);
            this.gbSettings.Controls.Add(this.cbOperator);
            this.gbSettings.Controls.Add(this.nudCompareValue);
            this.gbSettings.Controls.Add(this.lValueHelp);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.TabStop = false;
            // 
            // rbRightSpeed
            // 
            resources.ApplyResources(this.rbRightSpeed, "rbRightSpeed");
            this.rbRightSpeed.Checked = true;
            this.rbRightSpeed.Name = "rbRightSpeed";
            this.rbRightSpeed.TabStop = true;
            this.rbRightSpeed.UseVisualStyleBackColor = true;
            this.rbRightSpeed.CheckedChanged += new System.EventHandler(this.BSpeed_CheckedChanged);
            // 
            // rbLeftSpeed
            // 
            resources.ApplyResources(this.rbLeftSpeed, "rbLeftSpeed");
            this.rbLeftSpeed.Name = "rbLeftSpeed";
            this.rbLeftSpeed.TabStop = true;
            this.rbLeftSpeed.UseVisualStyleBackColor = true;
            this.rbLeftSpeed.CheckedChanged += new System.EventHandler(this.BSpeed_CheckedChanged);
            // 
            // cbCompareVariable
            // 
            this.cbCompareVariable.BackColor = System.Drawing.Color.White;
            this.cbCompareVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCompareVariable.DropDownHeight = 100;
            this.cbCompareVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbCompareVariable, "cbCompareVariable");
            this.cbCompareVariable.FormattingEnabled = true;
            this.cbCompareVariable.Items.AddRange(new object[] {
            resources.GetString("cbCompareVariable.Items"),
            resources.GetString("cbCompareVariable.Items1")});
            this.cbCompareVariable.Name = "cbCompareVariable";
            this.cbCompareVariable.SelectedIndexChanged += new System.EventHandler(this.CbCompareVariable_SelectedIndexChanged);
            // 
            // cbOperator
            // 
            this.cbOperator.BackColor = System.Drawing.Color.White;
            this.cbOperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOperator.DropDownHeight = 100;
            this.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbOperator, "cbOperator");
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Items.AddRange(new object[] {
            resources.GetString("cbOperator.Items"),
            resources.GetString("cbOperator.Items1"),
            resources.GetString("cbOperator.Items2"),
            resources.GetString("cbOperator.Items3"),
            resources.GetString("cbOperator.Items4"),
            resources.GetString("cbOperator.Items5")});
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.SelectedIndexChanged += new System.EventHandler(this.CbOperator_SelectedIndexChanged);
            // 
            // nudCompareValue
            // 
            this.nudCompareValue.BackColor = System.Drawing.Color.White;
            this.nudCompareValue.DecimalPlaces = 0;
            resources.ApplyResources(this.nudCompareValue, "nudCompareValue");
            this.nudCompareValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompareValue.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudCompareValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudCompareValue.Name = "nudCompareValue";
            this.nudCompareValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCompareValue.ValueChanged += new System.EventHandler(this.NudCompareValue_ValueChanged);
            // 
            // lValueHelp
            // 
            resources.ApplyResources(this.lValueHelp, "lValueHelp");
            this.lValueHelp.Name = "lValueHelp";
            // 
            // lOuput
            // 
            resources.ApplyResources(this.lOuput, "lOuput");
            this.lOuput.Name = "lOuput";
            // 
            // tbOutput
            // 
            resources.ApplyResources(this.tbOutput, "tbOutput");
            this.tbOutput.BackColor = System.Drawing.Color.White;
            this.tbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOutput.Name = "tbOutput";
            // 
            // CompareSpeedForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.lOuput);
            this.Controls.Add(this.tbOutput);
            this.Name = "CompareSpeedForm";
            this.Controls.SetChildIndex(this.tbOutput, 0);
            this.Controls.SetChildIndex(this.lOuput, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.gbSettings, 0);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbSettings;
        private Moway.Template.Controls.MowayComboBox cbOperator;
        private System.Windows.Forms.Label lOuput;
        private System.Windows.Forms.Label tbOutput;
        private Moway.Template.Controls.MowayComboBox cbCompareVariable;
        private Moway.Template.Controls.MowayNumericUpDown nudCompareValue;
        private Moway.Template.Controls.MowayRadioButton rbRightSpeed;
        private Moway.Template.Controls.MowayRadioButton rbLeftSpeed;
        private System.Windows.Forms.Label lValueHelp;
    }
}