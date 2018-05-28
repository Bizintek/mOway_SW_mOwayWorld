using System;

namespace Moway.Simulator.Communications
{
    /// <summary>
    /// Communication message from and for the communications module of the simulated MOway
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Message
    {
        #region Attributes

        /// <summary>
        /// Receiver/Emitter Address
        /// </summary>
        private byte direction;
        /// <summary>
        /// Message data
        /// </summary>
        private byte[] data = new byte[8];

        #endregion

        #region Properties

        /// <summary>
        /// Receiver/Transmitter Address
        /// </summary>
        public byte Direction { get { return this.direction; } }
        /// <summary>
        /// Message data
        /// </summary>
        public byte[] Data { get { return this.data; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="direction">Receiver/Transmitter Address</param>
        /// <param name="data">Message data</param>
        public Message(byte direction, byte[] data)
        {
            this.direction = direction;
            this.data = data;
        }
    }
}
