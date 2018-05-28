using System;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public delegate void OperationEventHandler(object sender, OperationEventArgs e);

    public enum OperationState {Started, Finished, Canceled}

    public class OperationEventArgs : EventArgs
    {
        #region Atributos

        private OperationState state;

        #endregion

        #region Propiedades

        public OperationState State { get { return this.state; } }

        #endregion

        public OperationEventArgs(OperationState state)
        {
            this.state = state;
        }
    }
}
