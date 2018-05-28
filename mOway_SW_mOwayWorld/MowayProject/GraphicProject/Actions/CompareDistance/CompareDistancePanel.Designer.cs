﻿namespace Moway.Project.GraphicProject.Actions.CompareDistance
{
    partial class CompareDistancePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareDistancePanel));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbOperator = new Moway.Template.Controls.MowayComboBox();
            this.cbCompareVariable = new Moway.Template.Controls.MowayComboBox();
            this.nudCompareValue = new Moway.Template.Controls.MowayNumericUpDown();
            this.lValueHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lActionName
            // 
            resources.ApplyResources(this.lActionName, "lActionName");
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // cbCompareVariable
            // 
            this.cbCompareVariable.BackColor = System.Drawing.Color.White;
            this.cbCompareVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCompareVariable.DropDownHeight = 100;
            this.cbCompareVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbCompareVariable, "cbCompareVariable");
            this.cbCompareVariable.FormattingEnabled = true;
            this.cbCompareVariable.Items.AddRange(new object[] {
            resources.GetString("cbCompareVariable.Items")});
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
            // lValueHelp
            // 
            resources.ApplyResources(this.lValueHelp, "lValueHelp");
            this.lValueHelp.Name = "lValueHelp";
            // 
            // CompareDistancePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lValueHelp);
            this.Controls.Add(this.nudCompareValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbOperator);
            this.Controls.Add(this.cbCompareVariable);
            resources.ApplyResources(this, "$this");
            this.Name = "CompareDistancePanel";
            this.Controls.SetChildIndex(this.lActionName, 0);
            this.Controls.SetChildIndex(this.cbCompareVariable, 0);
            this.Controls.SetChildIndex(this.cbOperator, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.nudCompareValue, 0);
            this.Controls.SetChildIndex(this.lValueHelp, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Moway.Template.Controls.MowayComboBox cbOperator;
        private Moway.Template.Controls.MowayComboBox cbCompareVariable;
        private Moway.Template.Controls.MowayNumericUpDown nudCompareValue;
        private System.Windows.Forms.Label lValueHelp;
    }
}
