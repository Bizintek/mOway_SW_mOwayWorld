using System;

namespace Moway.Controller
{
    public delegate void ProgressEventHandler(object sender, ProgressEventArgs e);

    public class ProgressEventArgs : EventArgs
    {
        #region Atributos

        private int progress;

        #endregion

        #region Propiedades

        public int Progress { get { return this.progress; } }

        #endregion

        public ProgressEventArgs(int progress)
        {
            this.progress = progress;
        }
    }
}
