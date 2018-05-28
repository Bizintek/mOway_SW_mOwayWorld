namespace Moway.Template
{
    partial class MowayMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MowayMessageBox));
            this.boxIcons = new System.Windows.Forms.ImageList(this.components);
            this.lBoxMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbBoxIcon = new System.Windows.Forms.PictureBox();
            this.bAbort = new Moway.Template.Controls.MowayButton();
            this.bIgnore = new Moway.Template.Controls.MowayButton();
            this.bRetry = new Moway.Template.Controls.MowayButton();
            this.bNo = new Moway.Template.Controls.MowayButton();
            this.cbShowAgain = new Moway.Template.Controls.MowayCheckBox();
            this.bYes = new Moway.Template.Controls.MowayButton();
            this.bCancel = new Moway.Template.Controls.MowayButton();
            this.bOk = new Moway.Template.Controls.MowayButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // boxIcons
            // 
            this.boxIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("boxIcons.ImageStream")));
            this.boxIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.boxIcons.Images.SetKeyName(0, "Information.png");
            this.boxIcons.Images.SetKeyName(1, "Error.png");
            this.boxIcons.Images.SetKeyName(2, "Warning.png");
            this.boxIcons.Images.SetKeyName(3, "Question.png");
            // 
            // lBoxMessage
            // 
            this.lBoxMessage.AccessibleDescription = null;
            this.lBoxMessage.AccessibleName = null;
            resources.ApplyResources(this.lBoxMessage, "lBoxMessage");
            this.lBoxMessage.Font = null;
            this.lBoxMessage.Name = "lBoxMessage";
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = null;
            this.panel1.Controls.Add(this.pbBoxIcon);
            this.panel1.Controls.Add(this.lBoxMessage);
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            // 
            // pbBoxIcon
            // 
            this.pbBoxIcon.AccessibleDescription = null;
            this.pbBoxIcon.AccessibleName = null;
            resources.ApplyResources(this.pbBoxIcon, "pbBoxIcon");
            this.pbBoxIcon.BackgroundImage = null;
            this.pbBoxIcon.Font = null;
            this.pbBoxIcon.ImageLocation = null;
            this.pbBoxIcon.Name = "pbBoxIcon";
            this.pbBoxIcon.TabStop = false;
            // 
            // bAbort
            // 
            this.bAbort.AccessibleDescription = null;
            this.bAbort.AccessibleName = null;
            resources.ApplyResources(this.bAbort, "bAbort");
            this.bAbort.BackgroundImage = null;
            this.bAbort.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bAbort.Name = "bAbort";
            this.bAbort.UseVisualStyleBackColor = true;
            this.bAbort.Click += new System.EventHandler(this.BAbort_Click);
            // 
            // bIgnore
            // 
            this.bIgnore.AccessibleDescription = null;
            this.bIgnore.AccessibleName = null;
            resources.ApplyResources(this.bIgnore, "bIgnore");
            this.bIgnore.BackgroundImage = null;
            this.bIgnore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bIgnore.Name = "bIgnore";
            this.bIgnore.UseVisualStyleBackColor = true;
            this.bIgnore.Click += new System.EventHandler(this.BIgnore_Click);
            // 
            // bRetry
            // 
            this.bRetry.AccessibleDescription = null;
            this.bRetry.AccessibleName = null;
            resources.ApplyResources(this.bRetry, "bRetry");
            this.bRetry.BackgroundImage = null;
            this.bRetry.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bRetry.Name = "bRetry";
            this.bRetry.UseVisualStyleBackColor = true;
            this.bRetry.Click += new System.EventHandler(this.BRetry_Click);
            // 
            // bNo
            // 
            this.bNo.AccessibleDescription = null;
            this.bNo.AccessibleName = null;
            resources.ApplyResources(this.bNo, "bNo");
            this.bNo.BackgroundImage = null;
            this.bNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bNo.Name = "bNo";
            this.bNo.UseVisualStyleBackColor = true;
            this.bNo.Click += new System.EventHandler(this.BNo_Click);
            // 
            // cbShowAgain
            // 
            this.cbShowAgain.AccessibleDescription = null;
            this.cbShowAgain.AccessibleName = null;
            resources.ApplyResources(this.cbShowAgain, "cbShowAgain");
            this.cbShowAgain.BackgroundImage = null;
            this.cbShowAgain.Name = "cbShowAgain";
            this.cbShowAgain.UseVisualStyleBackColor = true;
            // 
            // bYes
            // 
            this.bYes.AccessibleDescription = null;
            this.bYes.AccessibleName = null;
            resources.ApplyResources(this.bYes, "bYes");
            this.bYes.BackgroundImage = null;
            this.bYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bYes.Name = "bYes";
            this.bYes.UseVisualStyleBackColor = true;
            this.bYes.Click += new System.EventHandler(this.BYes_Click);
            // 
            // bCancel
            // 
            this.bCancel.AccessibleDescription = null;
            this.bCancel.AccessibleName = null;
            resources.ApplyResources(this.bCancel, "bCancel");
            this.bCancel.BackgroundImage = null;
            this.bCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bCancel.Name = "bCancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // bOk
            // 
            this.bOk.AccessibleDescription = null;
            this.bOk.AccessibleName = null;
            resources.ApplyResources(this.bOk, "bOk");
            this.bOk.BackgroundImage = null;
            this.bOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bOk.Name = "bOk";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.BOk_Click);
            // 
            // MowayMessageBox
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.BackgroundImage = null;
            this.Controls.Add(this.bAbort);
            this.Controls.Add(this.bIgnore);
            this.Controls.Add(this.bRetry);
            this.Controls.Add(this.bNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbShowAgain);
            this.Controls.Add(this.bYes);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MowayMessageBox";
            this.ShowInTaskbar = false;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBoxIcon;
        private System.Windows.Forms.ImageList boxIcons;
        private System.Windows.Forms.Label lBoxMessage;
        private Moway.Template.Controls.MowayButton bYes;
        private Moway.Template.Controls.MowayButton bOk;
        private Moway.Template.Controls.MowayCheckBox cbShowAgain;
        private System.Windows.Forms.Panel panel1;
        private Moway.Template.Controls.MowayButton bNo;
        private Moway.Template.Controls.MowayButton bCancel;
        private Moway.Template.Controls.MowayButton bRetry;
        private Moway.Template.Controls.MowayButton bIgnore;
        private Moway.Template.Controls.MowayButton bAbort;
    }
}