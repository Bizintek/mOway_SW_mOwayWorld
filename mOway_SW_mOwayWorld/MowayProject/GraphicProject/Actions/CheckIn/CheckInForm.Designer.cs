namespace Moway.Project.GraphicProject.Actions.CheckIn
{
    partial class CheckInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInForm));
            this.gbSettings = new Moway.Template.Controls.MowayGroupBox();
            this.rbLine5 = new Moway.Template.Controls.MowayRadioButton();
            this.rbLine1 = new Moway.Template.Controls.MowayRadioButton();
            this.rbLine2 = new Moway.Template.Controls.MowayRadioButton();
            this.rbLine3 = new Moway.Template.Controls.MowayRadioButton();
            this.rbLine4 = new Moway.Template.Controls.MowayRadioButton();
            this.rbLine0 = new Moway.Template.Controls.MowayRadioButton();
            this.cbOperator = new Moway.Template.Controls.MowayComboBox();
            this.cbLineValue = new Moway.Template.Controls.MowayComboBox();
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
            this.gbSettings.Controls.Add(this.rbLine5);
            this.gbSettings.Controls.Add(this.rbLine1);
            this.gbSettings.Controls.Add(this.rbLine2);
            this.gbSettings.Controls.Add(this.rbLine3);
            this.gbSettings.Controls.Add(this.rbLine4);
            this.gbSettings.Controls.Add(this.rbLine0);
            this.gbSettings.Controls.Add(this.cbOperator);
            this.gbSettings.Controls.Add(this.cbLineValue);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.TabStop = false;
            // 
            // rbLine5
            // 
            resources.ApplyResources(this.rbLine5, "rbLine5");
            this.rbLine5.Name = "rbLine5";
            this.rbLine5.UseVisualStyleBackColor = true;
            // 
            // rbLine1
            // 
            resources.ApplyResources(this.rbLine1, "rbLine1");
            this.rbLine1.Name = "rbLine1";
            this.rbLine1.UseVisualStyleBackColor = true;
            // 
            // rbLine2
            // 
            resources.ApplyResources(this.rbLine2, "rbLine2");
            this.rbLine2.Name = "rbLine2";
            this.rbLine2.UseVisualStyleBackColor = true;
            // 
            // rbLine3
            // 
            resources.ApplyResources(this.rbLine3, "rbLine3");
            this.rbLine3.Name = "rbLine3";
            this.rbLine3.UseVisualStyleBackColor = true;
            // 
            // rbLine4
            // 
            resources.ApplyResources(this.rbLine4, "rbLine4");
            this.rbLine4.Name = "rbLine4";
            this.rbLine4.UseVisualStyleBackColor = true;
            // 
            // rbLine0
            // 
            resources.ApplyResources(this.rbLine0, "rbLine0");
            this.rbLine0.Checked = true;
            this.rbLine0.Name = "rbLine0";
            this.rbLine0.TabStop = true;
            this.rbLine0.UseVisualStyleBackColor = true;
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
            // cbLineValue
            // 
            this.cbLineValue.BackColor = System.Drawing.Color.White;
            this.cbLineValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLineValue.DropDownHeight = 100;
            this.cbLineValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLineValue, "cbLineValue");
            this.cbLineValue.FormattingEnabled = true;
            this.cbLineValue.Items.AddRange(new object[] {
            resources.GetString("cbLineValue.Items"),
            resources.GetString("cbLineValue.Items1")});
            this.cbLineValue.Name = "cbLineValue";
            // 
            // CheckInForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbSettings);
            this.Name = "CheckInForm";
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
        private Moway.Template.Controls.MowayComboBox cbOperator;
        private Moway.Template.Controls.MowayComboBox cbLineValue;
        private Moway.Template.Controls.MowayRadioButton rbLine5;
        private Moway.Template.Controls.MowayRadioButton rbLine1;
        private Moway.Template.Controls.MowayRadioButton rbLine2;
        private Moway.Template.Controls.MowayRadioButton rbLine3;
        private Moway.Template.Controls.MowayRadioButton rbLine4;
        private Moway.Template.Controls.MowayRadioButton rbLine0;

    }
}