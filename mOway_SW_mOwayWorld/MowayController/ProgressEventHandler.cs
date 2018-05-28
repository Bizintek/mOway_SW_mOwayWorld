using System;

namespace Moway.Controller
{
    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

    public class ProgressEventArgs : EventArgs
    {
        #region Attributes

        private int progress;

        #endregion

        #region Properties

        public int Progress { get { return this.progress; } }

        #endregion

        public ProgressEventArgs(int progress)
        {
            this.progress = progress;
        }
    }
}
