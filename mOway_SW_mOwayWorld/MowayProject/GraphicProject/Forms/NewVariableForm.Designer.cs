namespace Moway.Project.GraphicProject.Forms
{
    partial class NewVariableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewVariableForm));
            this.bCancel = new Moway.Template.Controls.MowayButton();
            this.bCreate = new Moway.Template.Controls.MowayButton();
            this.lVariable = new System.Windows.Forms.Label();
            this.tbVariable = new Moway.Template.Controls.MowayTextBox();
            this.nudValue = new Moway.Template.Controls.MowayNumericUpDown();
            this.lInitValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pFormSeparator
            // 
            resources.ApplyResources(this.pFormSeparator, "pFormSeparator");
            // 
            // lFormDescription
            // 
            resources.ApplyResources(this.lFormDescription, "lFormDescription");
            // 
            // bCancel
            // 
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bCancel.Name = "bCancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // bCreate
            // 
            resources.ApplyResources(this.bCreate, "bCreate");
            this.bCreate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bCreate.Name = "bCreate";
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.BCreate_Click);
            // 
            // lVariable
            // 
            resources.ApplyResources(this.lVariable, "lVariable");
            this.lVariable.Name = "lVariable";
            // 
            // tbVariable
            // 
            this.tbVariable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbVariable, "tbVariable");
            this.tbVariable.Name = "tbVariable";
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
            0,
            0,
            0,
            0});
            // 
            // lInitValue
            // 
            resources.ApplyResources(this.lInitValue, "lInitValue");
            this.lInitValue.Name = "lInitValue";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // NewVariableForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lInitValue);
            this.Controls.Add(this.nudValue);
            this.Controls.Add(this.tbVariable);
            this.Controls.Add(this.lVariable);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bCreate);
            this.Name = "NewVariableForm";
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.bCreate, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lVariable, 0);
            this.Controls.SetChildIndex(this.tbVariable, 0);
            this.Controls.SetChildIndex(this.nudValue, 0);
            this.Controls.SetChildIndex(this.lInitValue, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayButton bCancel;
        private Moway.Template.Controls.MowayButton bCreate;
        private System.Windows.Forms.Label lVariable;
        private Moway.Template.Controls.MowayTextBox tbVariable;
        private Moway.Template.Controls.MowayNumericUpDown nudValue;
        private System.Windows.Forms.Label lInitValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}