namespace Moway.Project.GraphicProject.Actions.Lights
{
    partial class LightsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightsForm));
            this.gbCommands = new Moway.Template.Controls.MowayGroupBox();
            this.pbTop = new System.Windows.Forms.PictureBox();
            this.pbBrake = new System.Windows.Forms.PictureBox();
            this.pbFront = new System.Windows.Forms.PictureBox();
            this.pbLockMove = new System.Windows.Forms.PictureBox();
            this.lFront = new System.Windows.Forms.Label();
            this.lBrake = new System.Windows.Forms.Label();
            this.cbFront = new Moway.Template.Controls.MowayComboBox();
            this.lTopGreen = new System.Windows.Forms.Label();
            this.lTopRed = new System.Windows.Forms.Label();
            this.cbTopGreen = new Moway.Template.Controls.MowayComboBox();
            this.cbTopRed = new Moway.Template.Controls.MowayComboBox();
            this.cbBrake = new Moway.Template.Controls.MowayComboBox();
            this.pbTopImages = new System.Windows.Forms.ImageList(this.components);
            this.tBlink = new System.Windows.Forms.Timer(this.components);
            this.gbCommands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBrake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFront)).BeginInit();
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
            this.gbCommands.Controls.Add(this.pbTop);
            this.gbCommands.Controls.Add(this.pbBrake);
            this.gbCommands.Controls.Add(this.pbFront);
            this.gbCommands.Controls.Add(this.pbLockMove);
            this.gbCommands.Controls.Add(this.lFront);
            this.gbCommands.Controls.Add(this.lBrake);
            this.gbCommands.Controls.Add(this.cbFront);
            this.gbCommands.Controls.Add(this.lTopGreen);
            this.gbCommands.Controls.Add(this.lTopRed);
            this.gbCommands.Controls.Add(this.cbTopGreen);
            this.gbCommands.Controls.Add(this.cbTopRed);
            this.gbCommands.Controls.Add(this.cbBrake);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.TabStop = false;
            // 
            // pbTop
            // 
            this.pbTop.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.pbTop, "pbTop");
            this.pbTop.Name = "pbTop";
            this.pbTop.TabStop = false;
            // 
            // pbBrake
            // 
            resources.ApplyResources(this.pbBrake, "pbBrake");
            this.pbBrake.Name = "pbBrake";
            this.pbBrake.TabStop = false;
            // 
            // pbFront
            // 
            resources.ApplyResources(this.pbFront, "pbFront");
            this.pbFront.Name = "pbFront";
            this.pbFront.TabStop = false;
            // 
            // pbLockMove
            // 
            resources.ApplyResources(this.pbLockMove, "pbLockMove");
            this.pbLockMove.Name = "pbLockMove";
            this.pbLockMove.TabStop = false;
            // 
            // lFront
            // 
            resources.ApplyResources(this.lFront, "lFront");
            this.lFront.Name = "lFront";
            // 
            // lBrake
            // 
            resources.ApplyResources(this.lBrake, "lBrake");
            this.lBrake.Name = "lBrake";
            // 
            // cbFront
            // 
            this.cbFront.BackColor = System.Drawing.Color.White;
            this.cbFront.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFront.DropDownHeight = 100;
            this.cbFront.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbFront, "cbFront");
            this.cbFront.FormattingEnabled = true;
            this.cbFront.Items.AddRange(new object[] {
            resources.GetString("cbFront.Items"),
            resources.GetString("cbFront.Items1"),
            resources.GetString("cbFront.Items2"),
            resources.GetString("cbFront.Items3")});
            this.cbFront.Name = "cbFront";
            this.cbFront.SelectedIndexChanged += new System.EventHandler(this.cbFront_SelectedIndexChanged);
            // 
            // lTopGreen
            // 
            resources.ApplyResources(this.lTopGreen, "lTopGreen");
            this.lTopGreen.Name = "lTopGreen";
            // 
            // lTopRed
            // 
            resources.ApplyResources(this.lTopRed, "lTopRed");
            this.lTopRed.Name = "lTopRed";
            // 
            // cbTopGreen
            // 
            this.cbTopGreen.BackColor = System.Drawing.Color.White;
            this.cbTopGreen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTopGreen.DropDownHeight = 100;
            this.cbTopGreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbTopGreen, "cbTopGreen");
            this.cbTopGreen.FormattingEnabled = true;
            this.cbTopGreen.Items.AddRange(new object[] {
            resources.GetString("cbTopGreen.Items"),
            resources.GetString("cbTopGreen.Items1"),
            resources.GetString("cbTopGreen.Items2"),
            resources.GetString("cbTopGreen.Items3")});
            this.cbTopGreen.Name = "cbTopGreen";
            this.cbTopGreen.SelectedIndexChanged += new System.EventHandler(this.cbTopGreen_SelectedIndexChanged);
            // 
            // cbTopRed
            // 
            this.cbTopRed.BackColor = System.Drawing.Color.White;
            this.cbTopRed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTopRed.DropDownHeight = 100;
            this.cbTopRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbTopRed, "cbTopRed");
            this.cbTopRed.FormattingEnabled = true;
            this.cbTopRed.Items.AddRange(new object[] {
            resources.GetString("cbTopRed.Items"),
            resources.GetString("cbTopRed.Items1"),
            resources.GetString("cbTopRed.Items2"),
            resources.GetString("cbTopRed.Items3")});
            this.cbTopRed.Name = "cbTopRed";
            this.cbTopRed.SelectedIndexChanged += new System.EventHandler(this.cbTopRed_SelectedIndexChanged);
            // 
            // cbBrake
            // 
            this.cbBrake.BackColor = System.Drawing.Color.White;
            this.cbBrake.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBrake.DropDownHeight = 100;
            this.cbBrake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbBrake, "cbBrake");
            this.cbBrake.FormattingEnabled = true;
            this.cbBrake.Items.AddRange(new object[] {
            resources.GetString("cbBrake.Items"),
            resources.GetString("cbBrake.Items1"),
            resources.GetString("cbBrake.Items2"),
            resources.GetString("cbBrake.Items3")});
            this.cbBrake.Name = "cbBrake";
            this.cbBrake.SelectedIndexChanged += new System.EventHandler(this.cbBrake_SelectedIndexChanged);
            // 
            // pbTopImages
            // 
            this.pbTopImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("pbTopImages.ImageStream")));
            this.pbTopImages.TransparentColor = System.Drawing.Color.Transparent;
            this.pbTopImages.Images.SetKeyName(0, "verde.png");
            this.pbTopImages.Images.SetKeyName(1, "rojo.png");
            this.pbTopImages.Images.SetKeyName(2, "verde-rojo.png");
            // 
            // tBlink
            // 
            this.tBlink.Interval = 250;
            this.tBlink.Tick += new System.EventHandler(this.tBlink_Tick);
            // 
            // LightsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbCommands);
            this.Name = "LightsForm";
            this.Controls.SetChildIndex(this.bSave, 0);
            this.Controls.SetChildIndex(this.bCancel, 0);
            this.Controls.SetChildIndex(this.gbCommands, 0);
            this.Controls.SetChildIndex(this.lFormDescription, 0);
            this.Controls.SetChildIndex(this.pFormSeparator, 0);
            this.Controls.SetChildIndex(this.llHelp, 0);
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBrake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLockMove)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Moway.Template.Controls.MowayGroupBox gbCommands;
        private System.Windows.Forms.Label lFront;
        private System.Windows.Forms.Label lTopGreen;
        private Moway.Template.Controls.MowayComboBox cbFront;
        private System.Windows.Forms.Label lBrake;
        private System.Windows.Forms.Label lTopRed;
        private Moway.Template.Controls.MowayComboBox cbTopRed;
        private Moway.Template.Controls.MowayComboBox cbTopGreen;
        private Moway.Template.Controls.MowayComboBox cbBrake;
        private System.Windows.Forms.ImageList pbTopImages;
        private System.Windows.Forms.Timer tBlink;
        private System.Windows.Forms.PictureBox pbTop;
        private System.Windows.Forms.PictureBox pbBrake;
        private System.Windows.Forms.PictureBox pbFront;
        private System.Windows.Forms.PictureBox pbLockMove;
    }
}