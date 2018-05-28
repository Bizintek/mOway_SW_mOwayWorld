using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;
using Moway.Template.Controls;
using Moway.Radio;

namespace Moway.Panels
{
    /// <summary>
    /// Panel to the communications module
    /// </summary>
    /// <LastRevision>24.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public partial class CommunicationPanel : SharePanel
    {
        #region Attributes

        /// <summary>
        /// The object that represents the communication module. Implements the singleton pattern to avoid creating more than one instance.
        /// </summary>
        private Radio.Radio radio = Radio.Radio.GetRadio();

        #endregion

        #region Properties

        /// <summary>
        /// Title of the panel
        /// </summary>
        public override string Tittle { get { return CommunicationMessages.TITTLE; } }
        /// <summary>
        /// Short title of the panel
        /// </summary>
        public override string ShortTittle { get { return CommunicationMessages.SHORT_TITTLE; } }

        #endregion

        /// <summary>
        /// Builder of the panel
        /// </summary>
        public CommunicationPanel()
        {
            InitializeComponent();
            //This event is not included in the list of events in graphical mode so that it needs to be applied by hand
            this.tbData0.LostFocus += new EventHandler(TbData_LostFocus);
            this.tbData1.LostFocus += new EventHandler(TbData_LostFocus);
            this.tbData2.LostFocus += new EventHandler(TbData_LostFocus);
            this.tbData3.LostFocus += new EventHandler(TbData_LostFocus);
            this.tbData4.LostFocus += new EventHandler(TbData_LostFocus);
            this.tbData5.LostFocus += new EventHandler(TbData_LostFocus);
            this.tbData6.LostFocus += new EventHandler(TbData_LostFocus);
            this.tbData7.LostFocus += new EventHandler(TbData_LostFocus);
            //This event is logged to receive a new message
            this.radio.MessageReceived += new MessageEventHandler(Radio_MessageReceived);
        }

        #region Form Events

        /// <summary>
        /// Occurs when a key is pressed in any of the send data TextBox. It controls that only numbers can be written.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Includes the key pressed.</param>
        private void TbData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// It takes place when some of the TextBox of mailing information loses the focus, that is to say, when the edition of the same one is considered finished.
        /// Verifies the contents of the TextBox (byte-type value from 0 to 255)
        /// </summary>
        /// <param name="sender">The TextBox object that launches the event. It is used to know which one needs to be verified.</param>
        /// <param name="e"></param>
        void TbData_LostFocus(object sender, EventArgs e)
        {
            //It is first checked that it is not empty. In this case you put 0
            if (((TextBox)sender).Text == "")
                ((TextBox)sender).Text = "0";
            //It is a conversion to byte and if there are exception, is that it is not a valid value.
            try
            {
                System.Convert.ToByte(((TextBox)sender).Text);
            }
            catch
            {
                //As it is controlled that only numbers can be written, it can only be given the case that the writing value is greater than 255.
                ((TextBox)sender).Text = "255";
            }
        }

        /// <summary>
        /// Occurs when a certain amount of time has elapsed since a message was displayed on the result of sending a message
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
        /// Occurs when the Start button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BStart_Click(object sender, EventArgs e)
        {
            //necessary to update the NumericUpDown in text mode
            this.bStart.Focus();
            //The radio communication with the channel and address specified by the user is opened
            if (this.radio.StartRadio((byte)this.nudChannel.Value, (byte)this.nudDirection.Value))
            {
                //If opens correctly are enabled/disabled controls radio
                this.nudChannel.Enabled = false;
                this.nudDirection.Enabled = false;
                this.bStart.Enabled = false;
                this.bStop.Enabled = true;
                this.lReceptorDir.Enabled = true;
                this.nudReceptorDir.Enabled = true;
                this.l0.Enabled = true;
                this.l7.Enabled = true;
                this.tbData0.Enabled = true;
                this.tbData1.Enabled = true;
                this.tbData2.Enabled = true;
                this.tbData3.Enabled = true;
                this.tbData4.Enabled = true;
                this.tbData5.Enabled = true;
                this.tbData6.Enabled = true;
                this.tbData7.Enabled = true;
                this.bSend.Enabled = true;
                this.lTransmiterData.Enabled = true;
                this.lbMessages.Enabled = true;
            }
            else
                //if it is not opened correctly a message of explanatory error appears
                MowayMessageBox.Show(CommunicationMessages.START_ERROR, CommunicationMessages.COMMUNICATIONS, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Occurs when the Stop button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BStop_Click(object sender, EventArgs e)
        {
            this.Stop();
        }

        /// <summary>
        /// Occurs when the Send button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BSend_Click(object sender, EventArgs e)
        {
            this.tSendState.Enabled = true;
            //necessary to update the NumericUpDown in text mode
            this.bSend.Focus();
            //The default status of the message label is restarted and shown
            this.lSendState.Text = CommunicationMessages.SENDING_MESSAGE;
            this.lSendState.Location = new Point(this.bSend.Left - this.lSendState.Width - 6, this.lSendState.Location.Y);
            this.lSendState.Visible = true;
            //The shipment is made and the Condificado result is received.
            int response = this.radio.SendMessage((byte)this.nudReceptorDir.Value, new byte[] { System.Convert.ToByte(this.tbData0.Text), 
                System.Convert.ToByte(this.tbData1.Text), System.Convert.ToByte(this.tbData2.Text), System.Convert.ToByte(this.tbData3.Text), 
                System.Convert.ToByte(this.tbData4.Text), System.Convert.ToByte(this.tbData5.Text), System.Convert.ToByte(this.tbData6.Text), 
                System.Convert.ToByte(this.tbData7.Text) });
            //Depend of the result is displayed a message or other
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
            //The position is updated from the status message
            this.lSendState.Location = new Point(this.bSend.Left - this.lSendState.Width - 6, this.lSendState.Location.Y);
            //Timer is enabled which will make the message disappear after a certain time
            this.tSendState.Enabled = true;
        }

        /// <summary>
        /// Occurs when the Clear messages button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BClear_Click(object sender, EventArgs e)
        {
            //All messages in the message ListBox are cleared
            this.lbMessages.Items.Clear();
            //Clear button is disabled
            this.bClear.Enabled = false;
            this.bDelete.Enabled = false;
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

        /// <summary>
        /// Occurs when the Delete Message button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BDelete_Click(object sender, EventArgs e)
        {
            //The selected message from the ListBox of messages is deleted
            this.lbMessages.Items.RemoveAt(this.lbMessages.SelectedIndex);
            //Delete button is disabled
            this.bDelete.Enabled = false;
            //If there is no message disables the button Clear
            if (this.lbMessages.Items.Count == 0)
                this.bClear.Enabled = false;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Close panel warning before the communication is open
        /// </summary>
        /// <returns></returns>
        public override bool CloseBox()
        {
            if (this.radio.RadioIsRunning())
                if (DialogResult.Yes == MowayMessageBox.Show(CommunicationMessages.WARNING_CLOSE + "\r\n" + CommunicationMessages.CONTINUE, CommunicationMessages.COMMUNICATIONS, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    this.Stop();
                    return true;
                }
                else
                    return false;
            return true;
        }

        /// <summary>
        /// Force the panel to close
        /// </summary>
        public void ForceCloseBox()
        {
            this.Stop();
        }

        #endregion

        #region Events of the communication module

        /// <summary>
        /// Occurs every time a new radio message is received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">It includes the information relative to the message</param>
        void Radio_MessageReceived(object sender, MessageEventArgs e)
        {
            //A blank line is inserted between messages
            this.lbMessages.Items.Insert(0, "\r\n");

            //The message is formatted to display it by the ListBox. Format: (direction) Data7, Data6, Data5, Data4, Data3, Data2, Data1, Data0
            string message = "(" + e.Direction + ") " + e.Data[e.Data.Length - 1];
            for (int i = e.Data.Length - 2; i >= 0; i--)
                message += "," + e.Data[i];
            //it is loaded in the ListBox
            this.lbMessages.Items.Insert(0, message);

            //Insert the time the message was received
            string strTime = "time: " + DateTime.Now.Hour + "h:" + DateTime.Now.Minute + "m:" + DateTime.Now.Second + "s:" + DateTime.Now.Millisecond + "ms";
            this.lbMessages.Items.Insert(0, strTime);

            //Clear button is enabled
            this.bClear.Enabled = true;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Stops the communication system
        /// </summary>
        private void Stop()
        {
            //Radio communication is closed
            if (this.radio.RadioIsRunning())
                this.radio.StopRadio();
            //Close good or bad, radio controls are enabled/disabled
            this.nudChannel.Enabled = true;
            this.nudDirection.Enabled = true;
            this.bStart.Enabled = true;
            this.bStop.Enabled = false;
            this.lReceptorDir.Enabled = false;
            this.nudReceptorDir.Enabled = false;
            this.l0.Enabled = false;
            this.l7.Enabled = false;
            this.tbData0.Enabled = false;
            this.tbData1.Enabled = false;
            this.tbData2.Enabled = false;
            this.tbData3.Enabled = false;
            this.tbData4.Enabled = false;
            this.tbData5.Enabled = false;
            this.tbData6.Enabled = false;
            this.tbData7.Enabled = false;
            this.bSend.Enabled = false;
            this.lTransmiterData.Enabled = false;
            this.lbMessages.Enabled = false;
        }

        #endregion
    }
}
