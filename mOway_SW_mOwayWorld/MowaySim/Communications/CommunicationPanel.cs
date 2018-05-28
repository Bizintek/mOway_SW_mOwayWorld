using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Moway.Simulator.Communications
{
    /// <summary>
    /// Communications Panel for the mOway simulated
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class CommunicationPanel : ModulePanel
    {
        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="mowayModel">Simulation Model of the mOway</param>
        internal CommunicationPanel(MowayModel mowayModel)
            : base(mowayModel)
        {
            InitializeComponent();
            //Logs the event of sent message
            this.mowayModel.Communication.MessageSend += new MessageEventHandler(Communication_MessageSend);
        }

        #region Events of MowayModel

        void Communication_MessageSend(object sender, MessageEventArgs e)
        {
            //If the communication channel is the correct...
            if (this.mowayModel.Communication.Channel == (byte)this.nudChannel.Value)
                //The method must be invoked to run on the correct thread
                if (this.lbMessages.InvokeRequired)
                    this.Invoke(new MessageEventHandler(this.Communication_MessageSend), new object[] { sender, e });
                else
                {
                    //The message is formatted to display it by the ListBox. Format: (direction) Data7, Data6, Data5, Data4, Data3, Data2, Data1, Data0
                    string message = "(" + e.Message.Direction + ") " + e.Message.Data[e.Message.Data.Length - 1];
                    for (int i = e.Message.Data.Length - 2; i >= 0; i--)
                        message += "," + e.Message.Data[i];
                    //It is loaded into the ListBox
                    this.lbMessages.Items.Insert(0, message);
                 //Enables the button to clean messages
                    this.bClear.Enabled = true;
                }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Generates the name of the panel
        /// </summary>
        /// <returns>Panel name</returns>
        public override string ToString()
        {
            return CommunicationMessages.NAME;
        }

        #endregion

        #region Events del formulario

        /// <summary>
        /// Sent a message to the mOway simulated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BSend_Click(object sender, EventArgs e)
        {
            //necessary to update the NumericUpDown in text mode
            this.bSend.Focus();
            //Resets the default status of the message label and displays
            this.lSendState.Text = CommunicationMessages.SENDING_MESSAGE;
            this.lSendState.Location = new Point(this.bSend.Left - this.lSendState.Width - 6, this.lSendState.Location.Y);
            this.lSendState.Visible = true;
            //It sends the message by calling the function of receiving message from model of mOway simulated
            int response = this.mowayModel.Communication.ReceiveMessage((byte)this.nudChannel.Value, (byte)this.nudDirection.Value, new byte[] {System.Convert.ToByte(this.tbData0.Text), 
                System.Convert.ToByte(this.tbData1.Text), System.Convert.ToByte(this.tbData2.Text), System.Convert.ToByte(this.tbData3.Text), 
                System.Convert.ToByte(this.tbData4.Text), System.Convert.ToByte(this.tbData5.Text), System.Convert.ToByte(this.tbData6.Text), 
                System.Convert.ToByte(this.tbData7.Text) });
            //Based on the response of the simulated MOway is shown a message or other
            switch (response)
            {
                case 0:
                    this.lSendState.Text = CommunicationMessages.MSG_SEND_OK;
                    break;
                case 1:
                    this.lSendState.Text = CommunicationMessages.MSG_SEND_ERROR;
                    break;
                case 2:
                    this.lSendState.Text = CommunicationMessages.MSG_ACK_ERROR;
                    break;
            }
            //The position is updated in the status message
            this.lSendState.Location = new Point(this.bSend.Left - this.lSendState.Width - 6, this.lSendState.Location.Y);
            //Timer is enabled which will make the message disappear after a certain time
            this.tSendState.Enabled = true;
        }

        /// <summary>
        /// The list of received messages is cleaned
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BClear_Click(object sender, EventArgs e)
        {
            //Clears all messages in the ListBox of messages
            this.lbMessages.Items.Clear();
            //Clear button is disabled
            this.bClear.Enabled = false;
            this.bDelete.Enabled = false;
        }

        /// <summary>
        /// The selected message is deleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDelete_Click(object sender, EventArgs e)
        {
            //The selected message from the ListBox of messages is deleted
            this.lbMessages.Items.RemoveAt(this.lbMessages.SelectedIndex);
            //The button is disabled of Delete
            this.bDelete.Enabled = false;
            //If there is no message disables the button Clear
            if (this.lbMessages.Items.Count == 0)
                this.bClear.Enabled = false;
        }

        /// <summary>
        /// Hides the message from the result of sending a message to the simulated mOway after a while
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSendState_Tick(object sender, EventArgs e)
        {
            this.lSendState.Visible = false;
            //Timer is disabled
            this.tSendState.Enabled = false;
        }

        /// <summary>
        /// Occurs when an item in the message ListBox is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbMessages.SelectedIndex != -1)
                this.bDelete.Enabled = true;
            else
                this.bDelete.Enabled = false;
        }

        #endregion
    }
}
