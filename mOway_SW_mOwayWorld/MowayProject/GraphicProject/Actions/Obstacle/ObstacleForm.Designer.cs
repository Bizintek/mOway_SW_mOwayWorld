namespace Moway.Project.GraphicProject.Actions.Obstacle
{
    partial class ObstacleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObstacleForm));
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.pbMoway = new SdlDotNet.Windows.SurfaceControl();
            this.rbOr = new Moway.Template.Controls.MowayRadioButton();
            this.rbAnd = new Moway.Template.Controls.MowayRadioButton();
            this.lUpperLeft = new System.Windows.Forms.Label();
            this.cbUpperLeft = new Moway.Template.Controls.MowayComboBox();
            this.lLeft = new System.Windows.Forms.Label();
            this.cbLeft = new Moway.Template.Controls.MowayComboBox();
            this.cbUpperRight = new Moway.Template.Controls.MowayComboBox();
            this.cbRight = new Moway.Template.Controls.MowayComboBox();
            this.lUpperRight = new System.Windows.Forms.Label();
            this.lRight = new System.Windows.Forms.Label();
            this.lOuput = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.Label();
            this.gbCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoway)).BeginInit();
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
            this.gbCommands.Controls.Add(this.pbMoway);
            this.gbCommands.Controls.Add(this.rbOr);
            this.gbCommands.Controls.Add(this.rbAnd);
            this.gbCommands.Controls.Add(this.lUpperLeft);
            this.gbCommands.Controls.Add(this.cbUpperLeft);
            this.gbCommands.Controls.Add(this.lLeft);
            this.gbCommands.Controls.Add(this.cbLeft);
            this.gbCommands.Controls.Add(this.cbUpperRight);
            this.gbCommands.Controls.Add(this.cbRight);
            this.gbCommands.Controls.Add(this.lUpperRight);
            this.gbCommands.Controls.Add(this.lRight);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // pbMoway
            // 
            resources.ApplyResources(this.pbMoway, "pbMoway");
            this.pbMoway.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.pbMoway.BackColor = System.Drawing.Color.White;
            this.pbMoway.Name = "pbMoway";
            this.pbMoway.TabStop = false;
            // 
            // rbOr
            // 
            resources.ApplyResources(this.rbOr, "rbOr");
            this.rbOr.Name = "rbOr";
            this.rbOr.UseVisualStyleBackColor = true;
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
            // lUpperLeft
            // 
            resources.ApplyResources(this.lUpperLeft, "lUpperLeft");
            this.lUpperLeft.Name = "lUpperLeft";
            // 
            // cbUpperLeft
            // 
            this.cbUpperLeft.BackColor = System.Drawing.Color.White;
            this.cbUpperLeft.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUpperLeft.DropDownHeight = 100;
            this.cbUpperLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbUpperLeft, "cbUpperLeft");
            this.cbUpperLeft.FormattingEnabled = true;
            this.cbUpperLeft.Items.AddRange(new object[] {
            resources.GetString("cbUpperLeft.Items"),
            resources.GetString("cbUpperLeft.Items1"),
            resources.GetString("cbUpperLeft.Items2")});
            this.cbUpperLeft.Name = "cbUpperLeft";
            this.cbUpperLeft.SelectedIndexChanged += new System.EventHandler(this.CbSensor_SelectedIndexChanged);
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
            this.cbLeft.SelectedIndexChanged += new System.EventHandler(this.CbSensor_SelectedIndexChanged);
            // 
            // cbUpperRight
            // 
            this.cbUpperRight.BackColor = System.Drawing.Color.White;
            this.cbUpperRight.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUpperRight.DropDownHeight = 100;
            this.cbUpperRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbUpperRight, "cbUpperRight");
            this.cbUpperRight.FormattingEnabled = true;
            this.cbUpperRight.Items.AddRange(new object[] {
            resources.GetString("cbUpperRight.Items"),
            resources.GetString("cbUpperRight.Items1"),
            resources.GetString("cbUpperRight.Items2")});
            this.cbUpperRight.Name = "cbUpperRight";
            this.cbUpperRight.SelectedIndexChanged += new System.EventHandler(this.CbSensor_SelectedIndexChanged);
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
            this.cbRight.SelectedIndexChanged += new System.EventHandler(this.CbSensor_SelectedIndexChanged);
            // 
            // lUpperRight
            // 
            resources.ApplyResources(this.lUpperRight, "lUpperRight");
            this.lUpperRight.Name = "lUpperRight";
            // 
            // lRight
            // 
            resources.ApplyResources(this.lRight, "lRight");
            this.lRight.Name = "lRight";
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
            // ObstacleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.lOuput);
            this.Controls.Add(this.tbOutput);
            this.Controls.Add(this.gbCommands);
            this.Name = "ObstacleForm";
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.Controls.SetChildIndex(this.tbOutput, 0);
            this.Controls.SetChildIndex(this.lOuput, 0);
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoway)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private SdlDotNet.Windows.SurfaceControl pbMoway;
        private Moway.Template.Controls.MowayRadioButton rbOr;
        private Moway.Template.Controls.MowayRadioButton rbAnd;
        private System.Windows.Forms.Label lUpperLeft;
        private Moway.Template.Controls.MowayComboBox cbUpperLeft;
        private System.Windows.Forms.Label lLeft;
        private Moway.Template.Controls.MowayComboBox cbLeft;
        private Moway.Template.Controls.MowayComboBox cbUpperRight;
        private Moway.Template.Controls.MowayComboBox cbRight;
        private System.Windows.Forms.Label lUpperRight;
        private System.Windows.Forms.Label lRight;
        private System.Windows.Forms.Label lOuput;
        private System.Windows.Forms.Label tbOutput;

    }
}