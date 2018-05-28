namespace Moway.Forms
{
    partial class NewProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.rbActivity = new System.Windows.Forms.RadioButton();
            this.rbProgAsm = new System.Windows.Forms.RadioButton();
            this.rbProgC = new System.Windows.Forms.RadioButton();
            this.lLocation = new System.Windows.Forms.Label();
            this.bCancel = new Moway.Template.Controls.MowayButton();
            this.bCreate = new Moway.Template.Controls.MowayButton();
            this.lName = new System.Windows.Forms.Label();
            this.tbName = new Moway.Template.Controls.MowayTextBox();
            this.gbNewProject = new Moway.Template.Controls.MowayGroupBox();
            this.tbLocation = new Moway.Template.Controls.MowayTextBox();
            this.bBrowser = new Moway.Template.Controls.MowayButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.gbNewProject.SuspendLayout();
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
            // rbActivity
            // 
            resources.ApplyResources(this.rbActivity, "rbActivity");
            this.rbActivity.Checked = true;
            this.rbActivity.Name = "rbActivity";
            this.rbActivity.TabStop = true;
            this.rbActivity.UseVisualStyleBackColor = true;
            // 
            // rbProgAsm
            // 
            resources.ApplyResources(this.rbProgAsm, "rbProgAsm");
            this.rbProgAsm.Name = "rbProgAsm";
            this.rbProgAsm.UseVisualStyleBackColor = true;
            // 
            // rbProgC
            // 
            resources.ApplyResources(this.rbProgC, "rbProgC");
            this.rbProgC.Name = "rbProgC";
            this.rbProgC.UseVisualStyleBackColor = true;
            // 
            // lLocation
            // 
            resources.ApplyResources(this.lLocation, "lLocation");
            this.lLocation.Name = "lLocation";
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
            // gbNewProject
            // 
            this.gbNewProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbNewProject.Controls.Add(this.rbActivity);
            this.gbNewProject.Controls.Add(this.rbProgAsm);
            this.gbNewProject.Controls.Add(this.rbProgC);
            resources.ApplyResources(this.gbNewProject, "gbNewProject");
            this.gbNewProject.Name = "gbNewProject";
            this.gbNewProject.TabStop = false;
            // 
            // tbLocation
            // 
            this.tbLocation.BackColor = System.Drawing.SystemColors.Window;
            this.tbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.tbLocation, "tbLocation");
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = true;
            // 
            // bBrowser
            // 
            this.bBrowser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            resources.ApplyResources(this.bBrowser, "bBrowser");
            this.bBrowser.Name = "bBrowser";
            this.bBrowser.UseVisualStyleBackColor = true;
            this.bBrowser.Click += new System.EventHandler(this.BBrowser_Click);
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // NewProjectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.bBrowser);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.gbNewProject);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.lLocation);
            this.Name = "NewProjectForm";
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.lLocation, 0);
            this.Controls.SetChildIndex(this.bCreate, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lName, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.gbNewProject, 0);
            this.Controls.SetChildIndex(this.tbLocation, 0);
            this.Controls.SetChildIndex(this.bBrowser, 0);
            this.gbNewProject.ResumeLayout(false);
            this.gbNewProject.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbActivity;
        private System.Windows.Forms.RadioButton rbProgAsm;
        private System.Windows.Forms.RadioButton rbProgC;
        private System.Windows.Forms.Label lLocation;
        private Moway.Template.Controls.MowayButton bCreate;
        private Moway.Template.Controls.MowayButton bCancel;
        private System.Windows.Forms.Label lName;
        private Moway.Template.Controls.MowayTextBox tbName;
        private Moway.Template.Controls.MowayGroupBox gbNewProject;
        private Moway.Template.Controls.MowayTextBox tbLocation;
        private Moway.Template.Controls.MowayButton bBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;

    }
}