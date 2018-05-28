using System;
using System.Windows.Forms;

using lib_nrf24lu1_RF;

namespace Moway.Radio
{
    public class Radio
    {        
        public static byte[] rxed_moway_data = new byte[128];
      
        public bool scratchOn = false;

        #region RF commands

        public byte CMD_CONFIGURACION = 0xC0;
        public byte CMD_ATTACHINFO = 0xAA;
        public byte CMD_SEND_RF = 0xFF;
        public byte CMD_DATA_RECEIVED = 0xCC;
        public byte CMD_WAIT_APP = 0xCF;

        #endregion

        #region Attributes

        /// <summary>
        /// Saves the channel with which the connection has been opened
        /// </summary>
        private byte chanel;
        /// <summary>
        /// Saves the address assigned to the item when the connection has been opened
        /// </summary>
        private byte direction;
        private Bzirf2Manager conection = new Bzirf2Manager();
        /// <summary>
        /// Variable to indicate whether the data has reached the Moway
        /// </summary>
        private byte datasent;


        #endregion

        #region Properties

        /// <summary>
        /// Saves the channel with which the connection has been opened
        /// </summary>
        public byte Chanel { get { return this.chanel; } }
        /// <summary>
        /// Saves the address assigned to the item when the connection has been opened
        /// </summary>
        public byte Direction { get { return this.direction; } }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when a new message is received
        /// </summary>
        public event MessageEventHandler MessageReceived;

        #endregion

        #region Singleton Pattern Implementation

        private static Radio instance = null;

        public static Radio GetRadio()
        {
            if (instance == null)
                    instance = new Radio();
            return instance;
        }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        private  Radio()
        {
            this.conection.Read += new NewBziRF2DataEventHandler(conection_Read);
        }

        void conection_Read(NewBziRF2DataEventArgs e)
        {
            byte[] moway_data = e.newdata;
         
            if (scratchOn == true)
            {
                try
                {
                    if (this.MessageReceived != null)                        
                        this.MessageReceived(this, new MessageEventArgs(e.newdata[0], moway_data));
                }
                catch { }
            }

            else
            {
                try
                {

                    //If the application has sent the CMD SEND RF command, check if it has received the ACK from the Moway
                    if (e.newdata.Length == 2 & e.newdata[0] == CMD_SEND_RF)
                    {
                        switch (e.newdata[1])
                        {
                            case 0:
                                //Message sent
                                datasent = 0;
                                return;

                            case 1:
                                //Can't send message
                                datasent = 1;
                                return;

                            default:
                                //Receiver is not reached
                                datasent = 2;
                                return;
                        }
                    }

                    if (this.MessageReceived != null)
                    {
                        this.MessageReceived(this, new MessageEventArgs(e.newdata[0], new byte[] { e.newdata[1], e.newdata[2], e.newdata[3], e.newdata[4], e.newdata[5], e.newdata[6], e.newdata[7], e.newdata[8] }));

                        // Save sensor reading in array accessible by other projects.
                        SaveSensorData(moway_data);



                    }
                }
                catch { }
            }
        }



        /// <summary>
        /// Opens the radio connection in a specific channel and with an address
        /// </summary>
        /// <param name="chanel">Channel for connection</param>
        /// <param name="direction">Address of the module used</param>
        /// <returns>Returns True if the connection is successfully opened, False otherwise</returns>
        public bool StartRadio(byte chanel, byte direction)
        {
            this.chanel = chanel;
            this.direction = direction;
            if (this.conection.USBdongleconected)
            {
                if (this.conection.Start(chanel, direction))
                {
                    //Send command to enable RFUSB 
                    byte[] Data;
                    Data = new byte[2];
                    Data[0] = CMD_WAIT_APP;
                    Data[1] = 0x00;
                    this.conection.Send(Data);
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Close the Radio connection
        /// </summary>
        /// <returns>Returns True if the connection is successfully closed, False otherwise</returns>
        public bool StopRadio()
        {
            System.Threading.Thread.Sleep(200);
            return this.conection.Stop();
        }

        /// <summary>
        /// Indicates whether the radio communication is open or not
        /// </summary>
        /// <returns>Returns True if it is open, False otherwise</returns>
        public bool RadioIsRunning()
        {
            return this.conection.RFIsRunning();
        }

        /// <summary>
        /// Send a radio message to a given address
        /// </summary>
        /// <param name="direction">Sent address</param>
        /// <param name="data">Data to send in the message </param>
        /// <returns>???</returns>
        public int SendMessage(byte direction, byte[] data)
        {
            if (this.conection.RFIsRunning())
            {
                byte[] msgData = new byte[10];
                msgData[0] = CMD_SEND_RF;
                try
                {
                    msgData[1] = direction;          // Moway direction
                    msgData[2] = data[0];            // LSB of data                 176
                    msgData[3] = data[1];                                       //speed
                    msgData[4] = data[2];
                    msgData[5] = data[3];
                    msgData[6] = data[4];
                    msgData[7] = data[5];
                    msgData[8] = data[6];
                    msgData[9] = data[7];             // MSB of data                                                          

                    this.conection.Send(msgData);
                    return datasent;
                }
                catch (Exception)
                {
                    // Can't send message
                    return (1);
                }
            }
            else
                // Can't send message
                return (1);


            //return this.conection.Send(new byte[] { CMD_SEND_RF, direction, data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7] });
        }


        /// <summary>
        /// Send a radio message to communicate with Scratch
        /// </summary>
        /// <param name="direction">Sent address</param>
        /// <param name="data">Data to send in the message</param>
        /// <returns>???</returns>
        public int SendScratchMessage(byte[] data)
        {            
            if (this.conection.RFIsRunning())
            {            
                try
                {             
                    this.conection.Send(data);
                    return datasent;
                }
                catch (Exception)
                {
                    // Can't send message
                    return (1);
                }
            }
            else
                // Can't send message
                return (1);


            //return this.conection.Send(new byte[] { CMD_SEND_RF, direction, data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7] });
        }


        #region Private functions       

        /// <summary>
        /// Saves sensor readings sent by Moway in a global array 
        /// To show data in the Radiocontrol window (RcBox.cs)
        /// </summary>        
        private void SaveSensorData(byte[] sensor_data)
        {
            int cont;

            for (cont = 0; cont < 9; cont++)
            {
                rxed_moway_data[cont] = sensor_data[cont];
            }       
        }
        #endregion
    }
}
