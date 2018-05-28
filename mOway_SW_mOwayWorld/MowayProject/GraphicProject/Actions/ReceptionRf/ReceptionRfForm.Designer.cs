namespace Moway.Project.GraphicProject.Actions.ReceptionRf
{
    partial class ReceptionRfForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceptionRfForm));
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbDirection = new Moway.Template.Controls.MowayComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lAssign = new System.Windows.Forms.Label();
            this.lData7 = new System.Windows.Forms.Label();
            this.cbVariable7 = new Moway.Template.Controls.MowayComboBox();
            this.lData6 = new System.Windows.Forms.Label();
            this.cbVariable6 = new Moway.Template.Controls.MowayComboBox();
            this.lData5 = new System.Windows.Forms.Label();
            this.cbVariable5 = new Moway.Template.Controls.MowayComboBox();
            this.lData4 = new System.Windows.Forms.Label();
            this.cbVariable4 = new Moway.Template.Controls.MowayComboBox();
            this.lData3 = new System.Windows.Forms.Label();
            this.cbVariable3 = new Moway.Template.Controls.MowayComboBox();
            this.lData2 = new System.Windows.Forms.Label();
            this.cbVariable2 = new Moway.Template.Controls.MowayComboBox();
            this.lData0 = new System.Windows.Forms.Label();
            this.cbVariable0 = new Moway.Template.Controls.MowayComboBox();
            this.cbVariable1 = new Moway.Template.Controls.MowayComboBox();
            this.lData1 = new System.Windows.Forms.Label();
            this.lOuput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.Label();
            this.gbCommands.SuspendLayout();
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
            // gbCommands
            // 
            resources.ApplyResources(this.gbCommands, "gbCommands");
            this.gbCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gbCommands.Controls.Add(this.label8);
            this.gbCommands.Controls.Add(this.label9);
            this.gbCommands.Controls.Add(this.cbDirection);
            this.gbCommands.Controls.Add(this.label7);
            this.gbCommands.Controls.Add(this.label6);
            this.gbCommands.Controls.Add(this.label5);
            this.gbCommands.Controls.Add(this.label4);
            this.gbCommands.Controls.Add(this.label3);
            this.gbCommands.Controls.Add(this.label2);
            this.gbCommands.Controls.Add(this.label1);
            this.gbCommands.Controls.Add(this.lAssign);
            this.gbCommands.Controls.Add(this.lData7);
            this.gbCommands.Controls.Add(this.cbVariable7);
            this.gbCommands.Controls.Add(this.lData6);
            this.gbCommands.Controls.Add(this.cbVariable6);
            this.gbCommands.Controls.Add(this.lData5);
            this.gbCommands.Controls.Add(this.cbVariable5);
            this.gbCommands.Controls.Add(this.lData4);
            this.gbCommands.Controls.Add(this.cbVariable4);
            this.gbCommands.Controls.Add(this.lData3);
            this.gbCommands.Controls.Add(this.cbVariable3);
            this.gbCommands.Controls.Add(this.lData2);
            this.gbCommands.Controls.Add(this.cbVariable2);
            this.gbCommands.Controls.Add(this.lData0);
            this.gbCommands.Controls.Add(this.cbVariable0);
            this.gbCommands.Controls.Add(this.cbVariable1);
            this.gbCommands.Controls.Add(this.lData1);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // cbDirection
            // 
            this.cbDirection.BackColor = System.Drawing.Color.White;
            this.cbDirection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDirection.DropDownHeight = 100;
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbDirection, "cbDirection");
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Items.AddRange(new object[] {
            resources.GetString("cbDirection.Items"),
            resources.GetString("cbDirection.Items1")});
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            // lAssign
            // 
            resources.ApplyResources(this.lAssign, "lAssign");
            this.lAssign.Name = "lAssign";
            // 
            // lData7
            // 
            resources.ApplyResources(this.lData7, "lData7");
            this.lData7.Name = "lData7";
            // 
            // cbVariable7
            // 
            this.cbVariable7.BackColor = System.Drawing.Color.White;
            this.cbVariable7.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable7.DropDownHeight = 100;
            this.cbVariable7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable7, "cbVariable7");
            this.cbVariable7.FormattingEnabled = true;
            this.cbVariable7.Items.AddRange(new object[] {
            resources.GetString("cbVariable7.Items"),
            resources.GetString("cbVariable7.Items1")});
            this.cbVariable7.Name = "cbVariable7";
            this.cbVariable7.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // lData6
            // 
            resources.ApplyResources(this.lData6, "lData6");
            this.lData6.Name = "lData6";
            // 
            // cbVariable6
            // 
            this.cbVariable6.BackColor = System.Drawing.Color.White;
            this.cbVariable6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable6.DropDownHeight = 100;
            this.cbVariable6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable6, "cbVariable6");
            this.cbVariable6.FormattingEnabled = true;
            this.cbVariable6.Items.AddRange(new object[] {
            resources.GetString("cbVariable6.Items"),
            resources.GetString("cbVariable6.Items1")});
            this.cbVariable6.Name = "cbVariable6";
            this.cbVariable6.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // lData5
            // 
            resources.ApplyResources(this.lData5, "lData5");
            this.lData5.Name = "lData5";
            // 
            // cbVariable5
            // 
            this.cbVariable5.BackColor = System.Drawing.Color.White;
            this.cbVariable5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable5.DropDownHeight = 100;
            this.cbVariable5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable5, "cbVariable5");
            this.cbVariable5.FormattingEnabled = true;
            this.cbVariable5.Items.AddRange(new object[] {
            resources.GetString("cbVariable5.Items"),
            resources.GetString("cbVariable5.Items1")});
            this.cbVariable5.Name = "cbVariable5";
            this.cbVariable5.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // lData4
            // 
            resources.ApplyResources(this.lData4, "lData4");
            this.lData4.Name = "lData4";
            // 
            // cbVariable4
            // 
            this.cbVariable4.BackColor = System.Drawing.Color.White;
            this.cbVariable4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable4.DropDownHeight = 100;
            this.cbVariable4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable4, "cbVariable4");
            this.cbVariable4.FormattingEnabled = true;
            this.cbVariable4.Items.AddRange(new object[] {
            resources.GetString("cbVariable4.Items"),
            resources.GetString("cbVariable4.Items1")});
            this.cbVariable4.Name = "cbVariable4";
            this.cbVariable4.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // lData3
            // 
            resources.ApplyResources(this.lData3, "lData3");
            this.lData3.Name = "lData3";
            // 
            // cbVariable3
            // 
            this.cbVariable3.BackColor = System.Drawing.Color.White;
            this.cbVariable3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable3.DropDownHeight = 100;
            this.cbVariable3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable3, "cbVariable3");
            this.cbVariable3.FormattingEnabled = true;
            this.cbVariable3.Items.AddRange(new object[] {
            resources.GetString("cbVariable3.Items"),
            resources.GetString("cbVariable3.Items1")});
            this.cbVariable3.Name = "cbVariable3";
            this.cbVariable3.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // lData2
            // 
            resources.ApplyResources(this.lData2, "lData2");
            this.lData2.Name = "lData2";
            // 
            // cbVariable2
            // 
            this.cbVariable2.BackColor = System.Drawing.Color.White;
            this.cbVariable2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable2.DropDownHeight = 100;
            this.cbVariable2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable2, "cbVariable2");
            this.cbVariable2.FormattingEnabled = true;
            this.cbVariable2.Items.AddRange(new object[] {
            resources.GetString("cbVariable2.Items"),
            resources.GetString("cbVariable2.Items1")});
            this.cbVariable2.Name = "cbVariable2";
            this.cbVariable2.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // lData0
            // 
            resources.ApplyResources(this.lData0, "lData0");
            this.lData0.Name = "lData0";
            // 
            // cbVariable0
            // 
            this.cbVariable0.BackColor = System.Drawing.Color.White;
            this.cbVariable0.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable0.DropDownHeight = 100;
            this.cbVariable0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable0, "cbVariable0");
            this.cbVariable0.FormattingEnabled = true;
            this.cbVariable0.Items.AddRange(new object[] {
            resources.GetString("cbVariable0.Items"),
            resources.GetString("cbVariable0.Items1")});
            this.cbVariable0.Name = "cbVariable0";
            this.cbVariable0.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // cbVariable1
            // 
            this.cbVariable1.BackColor = System.Drawing.Color.White;
            this.cbVariable1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVariable1.DropDownHeight = 100;
            this.cbVariable1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbVariable1, "cbVariable1");
            this.cbVariable1.FormattingEnabled = true;
            this.cbVariable1.Items.AddRange(new object[] {
            resources.GetString("cbVariable1.Items"),
            resources.GetString("cbVariable1.Items1")});
            this.cbVariable1.Name = "cbVariable1";
            this.cbVariable1.SelectedIndexChanged += new System.EventHandler(this.cbGeneral_SelectedIndexChanged);
            // 
            // lData1
            // 
            resources.ApplyResources(this.lData1, "lData1");
            this.lData1.Name = "lData1";
            // 
            // lOuput
            // 
            resources.ApplyResources(this.lOuput, "lOuput");
            this.lOuput.Name = "lOuput";
            // 
            // tbOutput
            // 
            resources.ApplyResources(this.tbOutput, "tbOutput");
            this.tbOutput.BackColor = System.Drawing.Color.White;
            this.tbOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbOutput.Name = "tbOutput";
            // 
            // ReceptionRfForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lOuput);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.gbCommands);
            this.Name = "ReceptionRfForm";
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.tbOutput, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.lOuput, 0);
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private System.Windows.Forms.Label lData7;
        private Moway.Template.Controls.MowayComboBox cbVariable7;
        private System.Windows.Forms.Label lData6;
        private Moway.Template.Controls.MowayComboBox cbVariable6;
        private System.Windows.Forms.Label lData5;
        private Moway.Template.Controls.MowayComboBox cbVariable5;
        private System.Windows.Forms.Label lData4;
        private Moway.Template.Controls.MowayComboBox cbVariable4;
        private System.Windows.Forms.Label lData3;
        private Moway.Template.Controls.MowayComboBox cbVariable3;
        private System.Windows.Forms.Label lData2;
        private Moway.Template.Controls.MowayComboBox cbVariable2;
        private System.Windows.Forms.Label lData0;
        private Moway.Template.Controls.MowayComboBox cbVariable0;
        private Moway.Template.Controls.MowayComboBox cbVariable1;
        private System.Windows.Forms.Label lData1;
        private System.Windows.Forms.Label lAssign;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Moway.Template.Controls.MowayComboBox cbDirection;
        private System.Windows.Forms.Label lOuput;
        private System.Windows.Forms.Label tbOutput;
    }
}