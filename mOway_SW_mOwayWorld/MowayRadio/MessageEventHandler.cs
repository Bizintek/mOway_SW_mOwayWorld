using System;

namespace Moway.Radio
{
    public delegate void MessageEventHandler(object sender, MessageEventArgs e);

    public class MessageEventArgs
    {
        #region Attributes

        private byte direction;
        private byte[] data;

        #endregion

        #region Properties

        public byte Direction { get { return this.direction; } }
        public byte[] Data { get { return this.data; } }

        #endregion

        public MessageEventArgs(byte direction, byte[] data)
        {
            this.direction = direction;
            this.data = data;
        }
    }
}
