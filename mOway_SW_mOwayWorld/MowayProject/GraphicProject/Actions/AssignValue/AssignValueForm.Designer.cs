namespace Moway.Project.GraphicProject.Actions.AssignValue
{
    partial class AssignValueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignValueForm));
            this.gbSettings = new Moway.Template.Controls.MowayGroupBox();
            this.cbVariable = new Moway.Template.Controls.MowayComboBox();
            this.lVariable = new System.Windows.Forms.Label();
            this.cbAsignVariable = new Moway.Template.Controls.MowayComboBox();
            this.lAssign = new System.Windows.Forms.Label();
            this.lHelp = new System.Windows.Forms.Label();
            this.nudValue = new Moway.Template.Controls.MowayNumericUpDown();
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
            this.gbSettings.Controls.Add(this.cbVariable);
            this.gbSettings.Controls.Add(this.lVariable);
            this.gbSettings.Controls.Add(this.cbAsignVariable);
            this.gbSettings.Controls.Add(this.lAssign);
            this.gbSettings.Controls.Add(this.lHelp);
            this.gbSettings.Controls.Add(this.nudValue);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.TabStop = false;
            // 
            // cbVariable
            // 
            this.cbVariable.BackColor = System.Drawing.Color.White;
            this.cbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable.DropDownHeight = 100;
            this.cbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable, "cbVariable");
            this.cbVariable.FormattingEnabled = true;
            this.cbVariable.Items.AddRange(new object[] {
            resources.GetString("cbVariable.Items"),
            resources.GetString("cbVariable.Items1")});
            this.cbVariable.Name = "cbVariable";
            this.cbVariable.SelectedIndexChanged += new System.EventHandler(this.CbVariable_SelectedIndexChanged);
            // 
            // lVariable
            // 
            resources.ApplyResources(this.lVariable, "lVariable");
            this.lVariable.Name = "lVariable";
            // 
            // cbAsignVariable
            // 
            this.cbAsignVariable.BackColor = System.Drawing.Color.White;
            this.cbAsignVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAsignVariable.DropDownHeight = 100;
            this.cbAsignVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbAsignVariable, "cbAsignVariable");
            this.cbAsignVariable.FormattingEnabled = true;
            this.cbAsignVariable.Items.AddRange(new object[] {
            resources.GetString("cbAsignVariable.Items")});
            this.cbAsignVariable.Name = "cbAsignVariable";
            this.cbAsignVariable.SelectedIndexChanged += new System.EventHandler(this.CbAsignVariable_SelectedIndexChanged);
            // 
            // lAssign
            // 
            resources.ApplyResources(this.lAssign, "lAssign");
            this.lAssign.Name = "lAssign";
            // 
            // lHelp
            // 
            this.lHelp.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lHelp, "lHelp");
            this.lHelp.Name = "lHelp";
            // 
            // nudValue
            // 
            this.nudValue.BackColor = System.Drawing.Color.White;
            this.nudValue.DecimalPlaces = 0;
            resources.ApplyResources(this.nudValue, "nudValue");
            this.nudValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudValue.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudValue.Name = "nudValue";
            this.nudValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AssignValueForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbSettings);
            this.Name = "AssignValueForm";
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
        private System.Windows.Forms.Label lAssign;
        private System.Windows.Forms.Label lHelp;
        private Moway.Template.Controls.MowayComboBox cbAsignVariable;
        private System.Windows.Forms.Label lVariable;
        private Moway.Template.Controls.MowayComboBox cbVariable;
        private Moway.Template.Controls.MowayNumericUpDown nudValue;
    }
}