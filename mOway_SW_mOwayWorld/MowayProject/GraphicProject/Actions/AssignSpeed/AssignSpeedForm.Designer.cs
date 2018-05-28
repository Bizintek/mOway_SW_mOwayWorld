namespace Moway.Project.GraphicProject.Actions.AssignSpeed
{
    partial class AssignSpeedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignSpeedForm));
            this.gbSettings = new Moway.Template.Controls.MowayGroupBox();
            this.lVariable = new System.Windows.Forms.Label();
            this.cbAssignVariable = new Moway.Template.Controls.MowayComboBox();
            this.lAssign = new System.Windows.Forms.Label();
            this.lHelp = new System.Windows.Forms.Label();
            this.rbRightSpeed = new Moway.Template.Controls.MowayRadioButton();
            this.rbLeftSpeed = new Moway.Template.Controls.MowayRadioButton();
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
            this.gbSettings.Controls.Add(this.lVariable);
            this.gbSettings.Controls.Add(this.cbAssignVariable);
            this.gbSettings.Controls.Add(this.lAssign);
            this.gbSettings.Controls.Add(this.lHelp);
            this.gbSettings.Controls.Add(this.rbRightSpeed);
            this.gbSettings.Controls.Add(this.rbLeftSpeed);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.TabStop = false;
            // 
            // lVariable
            // 
            resources.ApplyResources(this.lVariable, "lVariable");
            this.lVariable.Name = "lVariable";
            // 
            // cbAssignVariable
            // 
            this.cbAssignVariable.BackColor = System.Drawing.Color.White;
            this.cbAssignVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbAssignVariable.DropDownHeight = 100;
            this.cbAssignVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbAssignVariable, "cbAssignVariable");
            this.cbAssignVariable.FormattingEnabled = true;
            this.cbAssignVariable.Items.AddRange(new object[] {
            resources.GetString("cbAssignVariable.Items")});
            this.cbAssignVariable.Name = "cbAssignVariable";
            this.cbAssignVariable.SelectedIndexChanged += new System.EventHandler(this.CbAssignVariable_SelectedIndexChanged);
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
            // rbRightSpeed
            // 
            resources.ApplyResources(this.rbRightSpeed, "rbRightSpeed");
            this.rbRightSpeed.Checked = true;
            this.rbRightSpeed.Name = "rbRightSpeed";
            this.rbRightSpeed.TabStop = true;
            this.rbRightSpeed.UseVisualStyleBackColor = true;
            // 
            // rbLeftSpeed
            // 
            resources.ApplyResources(this.rbLeftSpeed, "rbLeftSpeed");
            this.rbLeftSpeed.Name = "rbLeftSpeed";
            this.rbLeftSpeed.TabStop = true;
            this.rbLeftSpeed.UseVisualStyleBackColor = true;
            // 
            // AssignSpeedForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbSettings);
            this.Name = "AssignSpeedForm";
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.gbSettings, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbSettings;
        private System.Windows.Forms.Label lAssign;
        private Moway.Template.Controls.MowayComboBox cbAssignVariable;
        private System.Windows.Forms.Label lVariable;
        private Moway.Template.Controls.MowayRadioButton rbRightSpeed;
        private Moway.Template.Controls.MowayRadioButton rbLeftSpeed;
        private System.Windows.Forms.Label lHelp;
    }
}