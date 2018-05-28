namespace Moway.Project.GraphicProject.Actions.Line
{
    partial class LineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineForm));
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.pbRightLine = new System.Windows.Forms.PictureBox();
            this.pbLeftLine = new System.Windows.Forms.PictureBox();
            this.pbLockMove = new System.Windows.Forms.PictureBox();
            this.lLeft = new System.Windows.Forms.Label();
            this.cbLeft = new Moway.Template.Controls.MowayComboBox();
            this.cbRight = new Moway.Template.Controls.MowayComboBox();
            this.lRight = new System.Windows.Forms.Label();
            this.rbAnd = new Moway.Template.Controls.MowayRadioButton();
            this.rbOr = new Moway.Template.Controls.MowayRadioButton();
            this.lOuput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.Label();
            this.gbCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).BeginInit();
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
            this.gbCommands.Controls.Add(this.pbRightLine);
            this.gbCommands.Controls.Add(this.pbLeftLine);
            this.gbCommands.Controls.Add(this.pbLockMove);
            this.gbCommands.Controls.Add(this.lLeft);
            this.gbCommands.Controls.Add(this.cbLeft);
            this.gbCommands.Controls.Add(this.cbRight);
            this.gbCommands.Controls.Add(this.lRight);
            this.gbCommands.Controls.Add(this.rbAnd);
            this.gbCommands.Controls.Add(this.rbOr);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // pbRightLine
            // 
            this.pbRightLine.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pbRightLine, "pbRightLine");
            this.pbRightLine.Name = "pbRightLine";
            this.pbRightLine.TabStop = false;
            // 
            // pbLeftLine
            // 
            this.pbLeftLine.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pbLeftLine, "pbLeftLine");
            this.pbLeftLine.Name = "pbLeftLine";
            this.pbLeftLine.TabStop = false;
            // 
            // pbLockMove
            // 
            resources.ApplyResources(this.pbLockMove, "pbLockMove");
            this.pbLockMove.Name = "pbLockMove";
            this.pbLockMove.TabStop = false;
            // 
            // lLeft
            // 
            resources.ApplyResources(this.lLeft, "lLeft");
            this.lLeft.Name = "lLeft";
            // 
            // cbLeft
            // 
            this.cbLeft.BackColor = System.Drawing.Color.White;
            this.cbLeft.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLeft.DropDownHeight = 100;
            this.cbLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbLeft, "cbLeft");
            this.cbLeft.FormattingEnabled = true;
            this.cbLeft.Items.AddRange(new object[] {
            resources.GetString("cbLeft.Items"),
            resources.GetString("cbLeft.Items1"),
            resources.GetString("cbLeft.Items2")});
            this.cbLeft.Name = "cbLeft";
            this.cbLeft.SelectedIndexChanged += new System.EventHandler(this.CbLeft_SelectedIndexChanged);
            // 
            // cbRight
            // 
            this.cbRight.BackColor = System.Drawing.Color.White;
            this.cbRight.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRight.DropDownHeight = 100;
            this.cbRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbRight, "cbRight");
            this.cbRight.FormattingEnabled = true;
            this.cbRight.Items.AddRange(new object[] {
            resources.GetString("cbRight.Items"),
            resources.GetString("cbRight.Items1"),
            resources.GetString("cbRight.Items2")});
            this.cbRight.Name = "cbRight";
            this.cbRight.SelectedIndexChanged += new System.EventHandler(this.CbRight_SelectedIndexChanged);
            // 
            // lRight
            // 
            resources.ApplyResources(this.lRight, "lRight");
            this.lRight.Name = "lRight";
            // 
            // rbAnd
            // 
            resources.ApplyResources(this.rbAnd, "rbAnd");
            this.rbAnd.Checked = true;
            this.rbAnd.Name = "rbAnd";
            this.rbAnd.TabStop = true;
            this.rbAnd.UseVisualStyleBackColor = true;
            this.rbAnd.CheckedChanged += new System.EventHandler(this.RbAnd_CheckedChanged);
            // 
            // rbOr
            // 
            resources.ApplyResources(this.rbOr, "rbOr");
            this.rbOr.Name = "rbOr";
            this.rbOr.UseVisualStyleBackColor = true;
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
            // LineForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lOuput);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.gbCommands);
            this.Name = "LineForm";
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.tbOutput, 0);
            this.Controls.SetChildIndex(this.lOuput, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private System.Windows.Forms.Label lOuput;
        private System.Windows.Forms.Label tbOutput;
        private Moway.Template.Controls.MowayRadioButton rbOr;
        private Moway.Template.Controls.MowayRadioButton rbAnd;
        private System.Windows.Forms.Label lLeft;
        private Moway.Template.Controls.MowayComboBox cbLeft;
        private Moway.Template.Controls.MowayComboBox cbRight;
        private System.Windows.Forms.Label lRight;
        private System.Windows.Forms.PictureBox pbRightLine;
        private System.Windows.Forms.PictureBox pbLeftLine;
        private System.Windows.Forms.PictureBox pbLockMove;

    }
}