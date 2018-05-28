namespace Moway.Project.GraphicProject.Actions.Math
{
    partial class MathForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathForm));
            this.gbSettings = new Moway.Template.Controls.MowayGroupBox();
            this.cbResult = new Moway.Template.Controls.MowayComboBox();
            this.cbOperand = new Moway.Template.Controls.MowayComboBox();
            this.nudOperandValue = new Moway.Template.Controls.MowayNumericUpDown();
            this.cbOperator = new Moway.Template.Controls.MowayComboBox();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSave
            // 
            resources.ApplyResources(this.bSave, "bSave");
            this.bSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
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
            this.gbSettings.Controls.Add(this.cbResult);
            this.gbSettings.Controls.Add(this.cbOperand);
            this.gbSettings.Controls.Add(this.nudOperandValue);
            this.gbSettings.Controls.Add(this.cbOperator);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.TabStop = false;
            // 
            // cbResult
            // 
            this.cbResult.BackColor = System.Drawing.Color.White;
            this.cbResult.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbResult.DropDownHeight = 100;
            this.cbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbResult, "cbResult");
            this.cbResult.FormattingEnabled = true;
            this.cbResult.Items.AddRange(new object[] {
            resources.GetString("cbResult.Items")});
            this.cbResult.Name = "cbResult";
            this.cbResult.SelectedIndexChanged += new System.EventHandler(this.CbResult_SelectedIndexChanged);
            // 
            // cbOperand
            // 
            this.cbOperand.BackColor = System.Drawing.Color.White;
            this.cbOperand.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOperand.DropDownHeight = 100;
            this.cbOperand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbOperand, "cbOperand");
            this.cbOperand.FormattingEnabled = true;
            this.cbOperand.Items.AddRange(new object[] {
            resources.GetString("cbOperand.Items"),
            resources.GetString("cbOperand.Items1")});
            this.cbOperand.Name = "cbOperand";
            this.cbOperand.SelectedIndexChanged += new System.EventHandler(this.CbOperand_SelectedIndexChanged);
            // 
            // nudOperandValue
            // 
            this.nudOperandValue.BackColor = System.Drawing.Color.White;
            this.nudOperandValue.DecimalPlaces = 0;
            resources.ApplyResources(this.nudOperandValue, "nudOperandValue");
            this.nudOperandValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOperandValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudOperandValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudOperandValue.Name = "nudOperandValue";
            this.nudOperandValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            resources.GetString("cbOperator.Items1")});
            this.cbOperator.Name = "cbOperator";
            // 
            // MathForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbSettings);
            this.Name = "MathForm";
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.gbSettings, 0);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbSettings;
        private Moway.Template.Controls.MowayComboBox cbResult;
        private Moway.Template.Controls.MowayComboBox cbOperand;
        private Moway.Template.Controls.MowayNumericUpDown nudOperandValue;
        private Moway.Template.Controls.MowayComboBox cbOperator;
    }
}