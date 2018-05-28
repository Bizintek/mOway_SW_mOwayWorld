using System;

namespace Moway.Simulator.Communications
{
    /// <summary>
    /// Message events of the simulated mOway communication module
    /// </summary>
    /// <LastRevision>08.06.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void MessageEventHandler (object sender, MessageEventArgs e);

    public class MessageEventArgs:EventArgs
    {
        #region Attributes

        /// <summary>
        /// Message
        /// </summary>
        private Message message;

        #endregion

        #region Properties

        /// <summary>
        /// Message
        /// </summary>
        public Message Message { get { return this.message; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="message">Menssage</param>
        public MessageEventArgs(Message message)
            : base()
        {
            this.message = message;
        }
    }
}
