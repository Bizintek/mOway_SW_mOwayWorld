﻿namespace Moway.Project.GraphicProject.Actions.AssignTime
{
    partial class AssignTimePanel
    {
        /// <summary> 
        /// Variable of the designer required.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean the resources that are being used.
        /// </summary>
        /// <param name="disposing">true if the managed resources should be removed; false otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code generated by the Component Designer

        /// <summary> 
        /// Method necessary to support the Designer. It can not be modified 
        /// the content of the method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssignTimePanel));
            this.lVariable = new System.Windows.Forms.Label();
            this.cbAssignVariable = new Moway.Template.Controls.MowayComboBox();
            this.SuspendLayout();
            // 
            // lActionName
            // 
            resources.ApplyResources(this.lActionName, "lActionName");
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
            this.cbAssignVariable.Name = "cbAssignVariable";
            this.cbAssignVariable.SelectedIndexChanged += new System.EventHandler(this.CbAssignVariable_SelectedIndexChanged);
            // 
            // AssignTimePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lVariable);
            this.Controls.Add(this.cbAssignVariable);
            this.Name = "AssignTimePanel";
            resources.ApplyResources(this, "$this");
            this.Controls.SetChildIndex(this.lActionName, 0);
            this.Controls.SetChildIndex(this.cbAssignVariable, 0);
            this.Controls.SetChildIndex(this.lVariable, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lVariable;
        private Moway.Template.Controls.MowayComboBox cbAssignVariable;
    }
}
