using System;
using System.Collections.Generic;
using System.Text;

namespace Moway.Simulator.Communications
{
    /// <summary>
    /// It represents the communication module of the simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Communication
    {
        #region Attributes

        /// <summary>
        /// Communication module Status
        /// </summary>
        private bool running = false;
        /// <summary>
        /// Address of the MOway
        /// </summary>
        private byte direction;
        /// <summary>
        /// Communication channel
        /// </summary>
        private byte channel;
        /// <summary>
        /// Message Queue received
        /// </summary>
        private Queue<Message> messages = new Queue<Message>();

        #endregion

        #region Properties

        /// <summary>
        /// Communication channel
        /// </summary>
        public byte Channel { get { return this.channel; } }

        #endregion

        #region Events

        /// <summary>
        /// Message event sent by MOway communication module
        /// </summary>
        public event MessageEventHandler MessageSend;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        internal Communication() { }

        #region Public methods

        /// <summary>
        /// Start the MOway communication module
        /// </summary>
        /// <param name="direction">Address of the MOway</param>
        /// <param name="channel">Communication channel</param>
        public void Start(byte direction, byte channel)
        {
            this.direction = direction;
            this.channel = channel;
            this.running = true;
        }

        /// <summary>
        /// Stops the MOway communication module
        /// </summary>
        public void Stop()
        {
            this.running = false;
            this.messages.Clear();
        }

        /// <summary>
        /// Returns if the MOway has received a message
        /// </summary>
        /// <returns></returns>
        public bool MessageReceived()
        {
            //If the message queue is empty, no message has been received
            if (this.messages.Count != 0)
                return true;
            return false;
        }

        /// <summary>
        /// Returns the oldest message received
        /// </summary>
        /// <returns>Message received</returns>
        public Message GetMessage()
        {
            if (this.messages.Count != 0)
                return this.messages.Dequeue();
            return null;
        }

        /// <summary>
        /// Send a message through the communication module of the MOway
        /// </summary>
        /// <param name="direction">Receiver Address</param>
        /// <param name="data">Message data</param>
        /// <returns>Indicates whether the message was sent or not</returns>
        public bool SendMessage(byte direction, byte[] data)
        {
            if (this.running)
            {
                if (this.MessageSend != null)
                    this.MessageSend(this, new MessageEventArgs(new Message(direction, data)));
                return true;
            }
            else
                return false;
        }

        #endregion

        #region Internal methods

        /// <summary>
        /// Reset the Communications module
        /// </summary>
        internal void Reset()
        {
            this.running = false;
            //Message Queue is deleted
            this.messages.Clear();
        }

        /// <summary>
        /// The communications module receives a message from abroad (limited access to the simulation project to avoid confusion)
        /// </summary>
        /// <param name="channel">Message Channel</param>
        /// <param name="direction">Address of the Issuer</param>
        /// <param name="data">Message data</param>
        /// <returns>Shipment result</returns>
        internal int ReceiveMessage(byte channel, byte direction, byte[] data)
        {
            if (!this.running)
                return 1;
            else if (this.channel != channel)
                return 2;                
            else
            {
                this.messages.Enqueue(new Message(direction, data));
                return 0;
            }
        }

        #endregion
    }
}
