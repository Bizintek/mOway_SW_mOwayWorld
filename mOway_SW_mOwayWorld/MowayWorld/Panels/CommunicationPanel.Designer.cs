﻿namespace Moway.Panels
{
    partial class CommunicationPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommunicationPanel));
            this.lDirection = new System.Windows.Forms.Label();
            this.lChannel = new System.Windows.Forms.Label();
            this.nudDirection = new Moway.Template.Controls.MowayNumericUpDown();
            this.nudChannel = new Moway.Template.Controls.MowayNumericUpDown();
            this.bStart = new Moway.Template.Controls.MowayButton();
            this.bStop = new Moway.Template.Controls.MowayButton();
            this.tbData0 = new Moway.Template.Controls.MowayTextBox();
            this.tbData7 = new Moway.Template.Controls.MowayTextBox();
            this.tbData6 = new Moway.Template.Controls.MowayTextBox();
            this.tbData5 = new Moway.Template.Controls.MowayTextBox();
            this.tbData4 = new Moway.Template.Controls.MowayTextBox();
            this.tbData3 = new Moway.Template.Controls.MowayTextBox();
            this.tbData2 = new Moway.Template.Controls.MowayTextBox();
            this.tbData1 = new Moway.Template.Controls.MowayTextBox();
            this.nudReceptorDir = new Moway.Template.Controls.MowayNumericUpDown();
            this.lReceptorDir = new System.Windows.Forms.Label();
            this.bSend = new Moway.Template.Controls.MowayButton();
            this.lTransmiterData = new System.Windows.Forms.Label();
            this.lbMessages = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lSendState = new System.Windows.Forms.Label();
            this.tSendState = new System.Windows.Forms.Timer(this.components);
            this.bClear = new Moway.Template.Controls.MowayButton();
            this.bDelete = new Moway.Template.Controls.MowayButton();
            this.toolTip = new Moway.Template.Controls.MowayToolTip();
            this.l0 = new System.Windows.Forms.Label();
            this.l7 = new System.Windows.Forms.Label();
            this.lRfusbConfig = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lDirection
            // 
            this.lDirection.AccessibleDescription = null;
            this.lDirection.AccessibleName = null;
            resources.ApplyResources(this.lDirection, "lDirection");
            this.lDirection.Font = null;
            this.lDirection.Name = "lDirection";
            this.toolTip.SetToolTip(this.lDirection, resources.GetString("lDirection.ToolTip"));
            // 
            // lChannel
            // 
            this.lChannel.AccessibleDescription = null;
            this.lChannel.AccessibleName = null;
            resources.ApplyResources(this.lChannel, "lChannel");
            this.lChannel.Font = null;
            this.lChannel.Name = "lChannel";
            this.toolTip.SetToolTip(this.lChannel, resources.GetString("lChannel.ToolTip"));
            // 
            // nudDirection
            // 
            this.nudDirection.AccessibleDescription = null;
            this.nudDirection.AccessibleName = null;
            resources.ApplyResources(this.nudDirection, "nudDirection");
            this.nudDirection.BackColor = System.Drawing.Color.White;
            this.nudDirection.BackgroundImage = null;
            this.nudDirection.DecimalPlaces = 0;
            this.nudDirection.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDirection.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudDirection.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDirection.Name = "nudDirection";
            this.toolTip.SetToolTip(this.nudDirection, resources.GetString("nudDirection.ToolTip"));
            this.nudDirection.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudChannel
            // 
            this.nudChannel.AccessibleDescription = null;
            this.nudChannel.AccessibleName = null;
            resources.ApplyResources(this.nudChannel, "nudChannel");
            this.nudChannel.BackColor = System.Drawing.Color.White;
            this.nudChannel.BackgroundImage = null;
            this.nudChannel.DecimalPlaces = 0;
            this.nudChannel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudChannel.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.nudChannel.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudChannel.Name = "nudChannel";
            this.toolTip.SetToolTip(this.nudChannel, resources.GetString("nudChannel.ToolTip"));
            this.nudChannel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // bStart
            // 
            this.bStart.AccessibleDescription = null;
            this.bStart.AccessibleName = null;
            resources.ApplyResources(this.bStart, "bStart");
            this.bStart.BackgroundImage = null;
            this.bStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bStart.Name = "bStart";
            this.toolTip.SetToolTip(this.bStart, resources.GetString("bStart.ToolTip"));
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.BStart_Click);
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
            // tbData0
            // 
            this.tbData0.AccessibleDescription = null;
            this.tbData0.AccessibleName = null;
            resources.ApplyResources(this.tbData0, "tbData0");
            this.tbData0.BackgroundImage = null;
            this.tbData0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData0.Name = "tbData0";
            this.toolTip.SetToolTip(this.tbData0, resources.GetString("tbData0.ToolTip"));
            this.tbData0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // tbData7
            // 
            this.tbData7.AccessibleDescription = null;
            this.tbData7.AccessibleName = null;
            resources.ApplyResources(this.tbData7, "tbData7");
            this.tbData7.BackgroundImage = null;
            this.tbData7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData7.Name = "tbData7";
            this.toolTip.SetToolTip(this.tbData7, resources.GetString("tbData7.ToolTip"));
            this.tbData7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // tbData6
            // 
            this.tbData6.AccessibleDescription = null;
            this.tbData6.AccessibleName = null;
            resources.ApplyResources(this.tbData6, "tbData6");
            this.tbData6.BackgroundImage = null;
            this.tbData6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData6.Name = "tbData6";
            this.toolTip.SetToolTip(this.tbData6, resources.GetString("tbData6.ToolTip"));
            this.tbData6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // tbData5
            // 
            this.tbData5.AccessibleDescription = null;
            this.tbData5.AccessibleName = null;
            resources.ApplyResources(this.tbData5, "tbData5");
            this.tbData5.BackgroundImage = null;
            this.tbData5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData5.Name = "tbData5";
            this.toolTip.SetToolTip(this.tbData5, resources.GetString("tbData5.ToolTip"));
            this.tbData5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // tbData4
            // 
            this.tbData4.AccessibleDescription = null;
            this.tbData4.AccessibleName = null;
            resources.ApplyResources(this.tbData4, "tbData4");
            this.tbData4.BackgroundImage = null;
            this.tbData4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData4.Name = "tbData4";
            this.toolTip.SetToolTip(this.tbData4, resources.GetString("tbData4.ToolTip"));
            this.tbData4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // tbData3
            // 
            this.tbData3.AccessibleDescription = null;
            this.tbData3.AccessibleName = null;
            resources.ApplyResources(this.tbData3, "tbData3");
            this.tbData3.BackgroundImage = null;
            this.tbData3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData3.Name = "tbData3";
            this.toolTip.SetToolTip(this.tbData3, resources.GetString("tbData3.ToolTip"));
            this.tbData3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // tbData2
            // 
            this.tbData2.AccessibleDescription = null;
            this.tbData2.AccessibleName = null;
            resources.ApplyResources(this.tbData2, "tbData2");
            this.tbData2.BackgroundImage = null;
            this.tbData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData2.Name = "tbData2";
            this.toolTip.SetToolTip(this.tbData2, resources.GetString("tbData2.ToolTip"));
            this.tbData2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // tbData1
            // 
            this.tbData1.AccessibleDescription = null;
            this.tbData1.AccessibleName = null;
            resources.ApplyResources(this.tbData1, "tbData1");
            this.tbData1.BackgroundImage = null;
            this.tbData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbData1.Name = "tbData1";
            this.toolTip.SetToolTip(this.tbData1, resources.GetString("tbData1.ToolTip"));
            this.tbData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbData_KeyPress);
            // 
            // nudReceptorDir
            // 
            this.nudReceptorDir.AccessibleDescription = null;
            this.nudReceptorDir.AccessibleName = null;
            resources.ApplyResources(this.nudReceptorDir, "nudReceptorDir");
            this.nudReceptorDir.BackColor = System.Drawing.Color.White;
            this.nudReceptorDir.BackgroundImage = null;
            this.nudReceptorDir.DecimalPlaces = 0;
            this.nudReceptorDir.Increment = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudReceptorDir.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudReceptorDir.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudReceptorDir.Name = "nudReceptorDir";
            this.toolTip.SetToolTip(this.nudReceptorDir, resources.GetString("nudReceptorDir.ToolTip"));
            this.nudReceptorDir.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lReceptorDir
            // 
            this.lReceptorDir.AccessibleDescription = null;
            this.lReceptorDir.AccessibleName = null;
            resources.ApplyResources(this.lReceptorDir, "lReceptorDir");
            this.lReceptorDir.Font = null;
            this.lReceptorDir.Name = "lReceptorDir";
            this.toolTip.SetToolTip(this.lReceptorDir, resources.GetString("lReceptorDir.ToolTip"));
            // 
            // bSend
            // 
            this.bSend.AccessibleDescription = null;
            this.bSend.AccessibleName = null;
            resources.ApplyResources(this.bSend, "bSend");
            this.bSend.BackgroundImage = null;
            this.bSend.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bSend.Name = "bSend";
            this.toolTip.SetToolTip(this.bSend, resources.GetString("bSend.ToolTip"));
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.BSend_Click);
            // 
            // lTransmiterData
            // 
            this.lTransmiterData.AccessibleDescription = null;
            this.lTransmiterData.AccessibleName = null;
            resources.ApplyResources(this.lTransmiterData, "lTransmiterData");
            this.lTransmiterData.Font = null;
            this.lTransmiterData.Name = "lTransmiterData";
            this.toolTip.SetToolTip(this.lTransmiterData, resources.GetString("lTransmiterData.ToolTip"));
            // 
            // lbMessages
            // 
            this.lbMessages.AccessibleDescription = null;
            this.lbMessages.AccessibleName = null;
            resources.ApplyResources(this.lbMessages, "lbMessages");
            this.lbMessages.BackgroundImage = null;
            this.lbMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMessages.Font = null;
            this.lbMessages.FormattingEnabled = true;
            this.lbMessages.Name = "lbMessages";
            this.toolTip.SetToolTip(this.lbMessages, resources.GetString("lbMessages.ToolTip"));
            this.lbMessages.SelectedIndexChanged += new System.EventHandler(this.LbMessages_SelectedIndexChanged);
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
            // lSendState
            // 
            this.lSendState.AccessibleDescription = null;
            this.lSendState.AccessibleName = null;
            resources.ApplyResources(this.lSendState, "lSendState");
            this.lSendState.Font = null;
            this.lSendState.Name = "lSendState";
            this.toolTip.SetToolTip(this.lSendState, resources.GetString("lSendState.ToolTip"));
            // 
            // tSendState
            // 
            this.tSendState.Interval = 5000;
            this.tSendState.Tick += new System.EventHandler(this.TSendState_Tick);
            // 
            // bClear
            // 
            this.bClear.AccessibleDescription = null;
            this.bClear.AccessibleName = null;
            resources.ApplyResources(this.bClear, "bClear");
            this.bClear.BackgroundImage = null;
            this.bClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bClear.FlatAppearance.BorderSize = 0;
            this.bClear.Name = "bClear";
            this.toolTip.SetToolTip(this.bClear, resources.GetString("bClear.ToolTip"));
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.BClear_Click);
            // 
            // bDelete
            // 
            this.bDelete.AccessibleDescription = null;
            this.bDelete.AccessibleName = null;
            resources.ApplyResources(this.bDelete, "bDelete");
            this.bDelete.BackgroundImage = null;
            this.bDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bDelete.FlatAppearance.BorderSize = 0;
            this.bDelete.Name = "bDelete";
            this.toolTip.SetToolTip(this.bDelete, resources.GetString("bDelete.ToolTip"));
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.BDelete_Click);
            // 
            // l0
            // 
            this.l0.AccessibleDescription = null;
            this.l0.AccessibleName = null;
            resources.ApplyResources(this.l0, "l0");
            this.l0.Name = "l0";
            this.toolTip.SetToolTip(this.l0, resources.GetString("l0.ToolTip"));
            // 
            // l7
            // 
            this.l7.AccessibleDescription = null;
            this.l7.AccessibleName = null;
            resources.ApplyResources(this.l7, "l7");
            this.l7.Name = "l7";
            this.toolTip.SetToolTip(this.l7, resources.GetString("l7.ToolTip"));
            // 
            // lRfusbConfig
            // 
            this.lRfusbConfig.AccessibleDescription = null;
            this.lRfusbConfig.AccessibleName = null;
            resources.ApplyResources(this.lRfusbConfig, "lRfusbConfig");
            this.lRfusbConfig.Name = "lRfusbConfig";
            this.toolTip.SetToolTip(this.lRfusbConfig, resources.GetString("lRfusbConfig.ToolTip"));
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // CommunicationPanel
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.BackgroundImage = null;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lRfusbConfig);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.lSendState);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbMessages);
            this.Controls.Add(this.lTransmiterData);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.lReceptorDir);
            this.Controls.Add(this.nudReceptorDir);
            this.Controls.Add(this.tbData1);
            this.Controls.Add(this.tbData2);
            this.Controls.Add(this.tbData3);
            this.Controls.Add(this.tbData4);
            this.Controls.Add(this.tbData5);
            this.Controls.Add(this.tbData6);
            this.Controls.Add(this.tbData7);
            this.Controls.Add(this.tbData0);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.nudChannel);
            this.Controls.Add(this.lChannel);
            this.Controls.Add(this.lDirection);
            this.Controls.Add(this.nudDirection);
            this.Controls.Add(this.l0);
            this.Controls.Add(this.l7);
            this.Name = "CommunicationPanel";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lDirection;
        private System.Windows.Forms.Label lChannel;
        private Moway.Template.Controls.MowayNumericUpDown nudDirection;
        private Moway.Template.Controls.MowayNumericUpDown nudChannel;
        private Moway.Template.Controls.MowayButton bStart;
        private Moway.Template.Controls.MowayButton bStop;
        private Moway.Template.Controls.MowayTextBox tbData0;
        private Moway.Template.Controls.MowayTextBox tbData7;
        private Moway.Template.Controls.MowayTextBox tbData6;
        private Moway.Template.Controls.MowayTextBox tbData5;
        private Moway.Template.Controls.MowayTextBox tbData4;
        private Moway.Template.Controls.MowayTextBox tbData3;
        private Moway.Template.Controls.MowayTextBox tbData2;
        private Moway.Template.Controls.MowayTextBox tbData1;
        private Moway.Template.Controls.MowayNumericUpDown nudReceptorDir;
        private System.Windows.Forms.Label lReceptorDir;
        private Moway.Template.Controls.MowayButton bSend;
        private System.Windows.Forms.Label lTransmiterData;
        private System.Windows.Forms.ListBox lbMessages;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lSendState;
        private System.Windows.Forms.Timer tSendState;
        private Moway.Template.Controls.MowayButton bClear;
        private Moway.Template.Controls.MowayButton bDelete;
        private Moway.Template.Controls.MowayToolTip toolTip;
        private System.Windows.Forms.Label l0;
        private System.Windows.Forms.Label l7;
        private System.Windows.Forms.Label lRfusbConfig;
        private System.Windows.Forms.Label label1;
    }
}
