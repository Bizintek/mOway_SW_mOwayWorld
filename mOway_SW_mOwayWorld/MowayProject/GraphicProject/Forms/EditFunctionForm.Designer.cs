namespace Moway.Project.GraphicProject.Forms
{
    partial class EditFunctionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFunctionForm));
            this.bCancel = new Moway.Template.Controls.MowayButton();
            this.bUpdate = new Moway.Template.Controls.MowayButton();
            this.lName = new System.Windows.Forms.Label();
            this.tbName = new Moway.Template.Controls.MowayTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbYes = new Moway.Template.Controls.MowayRadioButton();
            this.lInitDiagram = new System.Windows.Forms.Label();
            this.rbNo = new Moway.Template.Controls.MowayRadioButton();
            this.tbDescription = new Moway.Template.Controls.MowayTextBox();
            this.lDescription = new System.Windows.Forms.Label();
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
            // bUpdate
            // 
            resources.ApplyResources(this.bUpdate, "bUpdate");
            this.bUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.BCreate_Click);
            // 
            // lName
            // 
            resources.ApplyResources(this.lName, "lName");
            this.lName.Name = "lName";
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // rbYes
            // 
            resources.ApplyResources(this.rbYes, "rbYes");
            this.rbYes.Name = "rbYes";
            this.rbYes.TabStop = true;
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // lInitDiagram
            // 
            resources.ApplyResources(this.lInitDiagram, "lInitDiagram");
            this.lInitDiagram.Name = "lInitDiagram";
            // 
            // rbNo
            // 
            resources.ApplyResources(this.rbNo, "rbNo");
            this.rbNo.Name = "rbNo";
            this.rbNo.TabStop = true;
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // tbDescription
            // 
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            // 
            // lDescription
            // 
            resources.ApplyResources(this.lDescription, "lDescription");
            this.lDescription.Name = "lDescription";
            // 
            // EditFunctionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lDescription);
            this.Controls.Add(this.rbNo);
            this.Controls.Add(this.lInitDiagram);
            this.Controls.Add(this.rbYes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bUpdate);
            this.Name = "EditFunctionForm";
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.bUpdate, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lName, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.rbYes, 0);
            this.Controls.SetChildIndex(this.lInitDiagram, 0);
            this.Controls.SetChildIndex(this.rbNo, 0);
            this.Controls.SetChildIndex(this.lDescription, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayButton bCancel;
        private Moway.Template.Controls.MowayButton bUpdate;
        private System.Windows.Forms.Label lName;
        private Moway.Template.Controls.MowayTextBox tbName;
        private System.Windows.Forms.Label label1;
        private Moway.Template.Controls.MowayRadioButton rbYes;
        private System.Windows.Forms.Label lInitDiagram;
        private Moway.Template.Controls.MowayRadioButton rbNo;
        private Moway.Template.Controls.MowayTextBox tbDescription;
        private System.Windows.Forms.Label lDescription;
    }
}