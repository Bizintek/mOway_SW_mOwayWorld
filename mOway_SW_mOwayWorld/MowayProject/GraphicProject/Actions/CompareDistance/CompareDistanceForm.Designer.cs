namespace Moway.Project.GraphicProject.Actions.CompareDistance
{
    partial class CompareDistanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareDistanceForm));
            this.gbSettings = new Moway.Template.Controls.MowayGroupBox();
            this.lValueHelp = new System.Windows.Forms.Label();
            this.cbOperator = new Moway.Template.Controls.MowayComboBox();
            this.lDistance = new System.Windows.Forms.Label();
            this.cbCompareVariable = new Moway.Template.Controls.MowayComboBox();
            this.nudCompareValue = new Moway.Template.Controls.MowayNumericUpDown();
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
            this.gbSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbSettings.Controls.Add(this.lValueHelp);
            this.gbSettings.Controls.Add(this.cbOperator);
            this.gbSettings.Controls.Add(this.lDistance);
            this.gbSettings.Controls.Add(this.cbCompareVariable);
            this.gbSettings.Controls.Add(this.nudCompareValue);
            resources.ApplyResources(this.gbSettings, "gbSettings");
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.TabStop = false;
            // 
            // lValueHelp
            // 
            resources.ApplyResources(this.lValueHelp, "lValueHelp");
            this.lValueHelp.Name = "lValueHelp";
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
            // lDistance
            // 
            resources.ApplyResources(this.lDistance, "lDistance");
            this.lDistance.Name = "lDistance";
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
            255,
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
            // lOuput
            // 
            resources.ApplyResources(this.lOuput, "lOuput");
            this.lOuput.Name = "lOuput";
            // 
            // tbOutput
            // 
            this.tbOutput.BackColor = System.Drawing.Color.White;
            this.tbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbOutput, "tbOutput");
            this.tbOutput.Name = "tbOutput";
            // 
            // CompareDistanceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.lOuput);
            this.Controls.Add(this.tbOutput);
            this.Name = "CompareDistanceForm";
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
        private System.Windows.Forms.Label lDistance;
        private Moway.Template.Controls.MowayComboBox cbOperator;
        private System.Windows.Forms.Label lOuput;
        private System.Windows.Forms.Label tbOutput;
        private Moway.Template.Controls.MowayComboBox cbCompareVariable;
        private Moway.Template.Controls.MowayNumericUpDown nudCompareValue;
        private System.Windows.Forms.Label lValueHelp;
    }
}