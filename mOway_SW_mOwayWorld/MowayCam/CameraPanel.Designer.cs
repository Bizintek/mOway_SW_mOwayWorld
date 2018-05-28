﻿namespace Moway.Camera
{
    partial class CameraPanel
    {
        /// <summary> 
        /// Variable of the required designer.
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
        /// Method necessary to support the Designer.It can not be modified
        ///  the content of the method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bStop = new Moway.Template.Controls.MowayButton();
            this.bPlay = new Moway.Template.Controls.MowayButton();
            this.lDevice = new System.Windows.Forms.Label();
            this.pbCamera = new System.Windows.Forms.PictureBox();
            this.cbDevice = new Moway.Template.Controls.MowayComboBox();
            this.bBrowser = new Moway.Template.Controls.MowayButton();
            this.tbLocation = new Moway.Template.Controls.MowayTextBox();
            this.tbName = new Moway.Template.Controls.MowayTextBox();
            this.lName = new System.Windows.Forms.Label();
            this.lLocation = new System.Windows.Forms.Label();
            this.bCapture = new Moway.Template.Controls.MowayButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bRefresh = new Moway.Template.Controls.MowayButton();
            this.toolTip = new Moway.Template.Controls.MowayToolTip();
            this.cbAutoincremental = new Moway.Template.Controls.MowayCheckBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.camTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = null;
            this.panel1.AccessibleName = null;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.panel1.BackgroundImage = null;
            this.panel1.Font = null;
            this.panel1.Name = "panel1";
            this.toolTip.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // bStop
            // 
            this.bStop.AccessibleDescription = null;
            this.bStop.AccessibleName = null;
            resources.ApplyResources(this.bStop, "bStop");
            this.bStop.BackgroundImage = null;
            this.bStop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bStop.Name = "bStop";
            this.toolTip.SetToolTip(this.bStop, resources.GetString("bStop.ToolTip"));
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.BStop_Click);
            // 
            // bPlay
            // 
            this.bPlay.AccessibleDescription = null;
            this.bPlay.AccessibleName = null;
            resources.ApplyResources(this.bPlay, "bPlay");
            this.bPlay.BackgroundImage = null;
            this.bPlay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bPlay.Name = "bPlay";
            this.toolTip.SetToolTip(this.bPlay, resources.GetString("bPlay.ToolTip"));
            this.bPlay.UseVisualStyleBackColor = true;
            this.bPlay.Click += new System.EventHandler(this.BPlay_Click);
            // 
            // lDevice
            // 
            this.lDevice.AccessibleDescription = null;
            this.lDevice.AccessibleName = null;
            resources.ApplyResources(this.lDevice, "lDevice");
            this.lDevice.Font = null;
            this.lDevice.Name = "lDevice";
            this.toolTip.SetToolTip(this.lDevice, resources.GetString("lDevice.ToolTip"));
            // 
            // pbCamera
            // 
            this.pbCamera.AccessibleDescription = null;
            this.pbCamera.AccessibleName = null;
            resources.ApplyResources(this.pbCamera, "pbCamera");
            this.pbCamera.BackColor = System.Drawing.Color.Black;
            this.pbCamera.Font = null;
            this.pbCamera.ImageLocation = null;
            this.pbCamera.Name = "pbCamera";
            this.pbCamera.TabStop = false;
            this.toolTip.SetToolTip(this.pbCamera, resources.GetString("pbCamera.ToolTip"));
            // 
            // cbDevice
            // 
            this.cbDevice.AccessibleDescription = null;
            this.cbDevice.AccessibleName = null;
            resources.ApplyResources(this.cbDevice, "cbDevice");
            this.cbDevice.BackColor = System.Drawing.Color.White;
            this.cbDevice.BackgroundImage = null;
            this.cbDevice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDevice.DropDownHeight = 100;
            this.cbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Name = "cbDevice";
            this.toolTip.SetToolTip(this.cbDevice, resources.GetString("cbDevice.ToolTip"));
            // 
            // bBrowser
            // 
            this.bBrowser.AccessibleDescription = null;
            this.bBrowser.AccessibleName = null;
            resources.ApplyResources(this.bBrowser, "bBrowser");
            this.bBrowser.BackgroundImage = null;
            this.bBrowser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(132)))), ((int)(((byte)(132)))));
            this.bBrowser.Name = "bBrowser";
            this.toolTip.SetToolTip(this.bBrowser, resources.GetString("bBrowser.ToolTip"));
            this.bBrowser.UseVisualStyleBackColor = true;
            this.bBrowser.Click += new System.EventHandler(this.BBrowser_Click);
            // 
            // tbLocation
            // 
            this.tbLocation.AccessibleDescription = null;
            this.tbLocation.AccessibleName = null;
            resources.ApplyResources(this.tbLocation, "tbLocation");
            this.tbLocation.BackColor = System.Drawing.SystemColors.Window;
            this.tbLocation.BackgroundImage = null;
            this.tbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = true;
            this.toolTip.SetToolTip(this.tbLocation, resources.GetString("tbLocation.ToolTip"));
            // 
            // tbName
            // 
            this.tbName.AccessibleDescription = null;
            this.tbName.AccessibleName = null;
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.BackgroundImage = null;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Name = "tbName";
            this.toolTip.SetToolTip(this.tbName, resources.GetString("tbName.ToolTip"));
            // 
            // lName
            // 
            this.lName.AccessibleDescription = null;
            this.lName.AccessibleName = null;
            resources.ApplyResources(this.lName, "lName");
            this.lName.Font = null;
            this.lName.Name = "lName";
            this.toolTip.SetToolTip(this.lName, resources.GetString("lName.ToolTip"));
            // 
            // lLocation
            // 
            this.lLocation.AccessibleDescription = null;
            this.lLocation.AccessibleName = null;
            resources.ApplyResources(this.lLocation, "lLocation");
            this.lLocation.Font = null;
            this.lLocation.Name = "lLocation";
            this.toolTip.SetToolTip(this.lLocation, resources.GetString("lLocation.ToolTip"));
            // 
            // bCapture
            // 
            this.bCapture.AccessibleDescription = null;
            this.bCapture.AccessibleName = null;
            resources.ApplyResources(this.bCapture, "bCapture");
            this.bCapture.BackgroundImage = null;
            this.bCapture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bCapture.Name = "bCapture";
            this.toolTip.SetToolTip(this.bCapture, resources.GetString("bCapture.ToolTip"));
            this.bCapture.UseVisualStyleBackColor = true;
            this.bCapture.Click += new System.EventHandler(this.BCapture_Click);
            // 
            // panel2
            // 
            this.panel2.AccessibleDescription = null;
            this.panel2.AccessibleName = null;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.panel2.BackgroundImage = null;
            this.panel2.Font = null;
            this.panel2.Name = "panel2";
            this.toolTip.SetToolTip(this.panel2, resources.GetString("panel2.ToolTip"));
            // 
            // bRefresh
            // 
            this.bRefresh.AccessibleDescription = null;
            this.bRefresh.AccessibleName = null;
            resources.ApplyResources(this.bRefresh, "bRefresh");
            this.bRefresh.BackgroundImage = null;
            this.bRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bRefresh.FlatAppearance.BorderSize = 0;
            this.bRefresh.Name = "bRefresh";
            this.toolTip.SetToolTip(this.bRefresh, resources.GetString("bRefresh.ToolTip"));
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.BRefresh_Click);
            // 
            // cbAutoincremental
            // 
            this.cbAutoincremental.AccessibleDescription = null;
            this.cbAutoincremental.AccessibleName = null;
            resources.ApplyResources(this.cbAutoincremental, "cbAutoincremental");
            this.cbAutoincremental.BackgroundImage = null;
            this.cbAutoincremental.Checked = true;
            this.cbAutoincremental.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoincremental.Name = "cbAutoincremental";
            this.toolTip.SetToolTip(this.cbAutoincremental, resources.GetString("cbAutoincremental.ToolTip"));
            this.cbAutoincremental.UseVisualStyleBackColor = true;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.AccessibleDescription = null;
            this.videoSourcePlayer1.AccessibleName = null;
            resources.ApplyResources(this.videoSourcePlayer1, "videoSourcePlayer1");
            this.videoSourcePlayer1.BackgroundImage = null;
            this.videoSourcePlayer1.Font = null;
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.toolTip.SetToolTip(this.videoSourcePlayer1, resources.GetString("videoSourcePlayer1.ToolTip"));
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // folderBrowserDialog
            // 
            resources.ApplyResources(this.folderBrowserDialog, "folderBrowserDialog");
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // CameraPanel
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.cbAutoincremental);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bCapture);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.bBrowser);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lLocation);
            this.Controls.Add(this.pbCamera);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bPlay);
            this.Controls.Add(this.lDevice);
            this.Name = "CameraPanel";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.CameraPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Moway.Template.Controls.MowayButton bStop;
        private Moway.Template.Controls.MowayButton bPlay;
        private System.Windows.Forms.Label lDevice;
        private System.Windows.Forms.PictureBox pbCamera;
        private Moway.Template.Controls.MowayComboBox cbDevice;
        private Moway.Template.Controls.MowayButton bBrowser;
        private Moway.Template.Controls.MowayTextBox tbLocation;
        private Moway.Template.Controls.MowayTextBox tbName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lLocation;
        private Moway.Template.Controls.MowayButton bCapture;
        private System.Windows.Forms.Panel panel2;
        private Moway.Template.Controls.MowayButton bRefresh;
        private Moway.Template.Controls.MowayToolTip toolTip;
        private Moway.Template.Controls.MowayCheckBox cbAutoincremental;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Timer camTimer;


    }
}
