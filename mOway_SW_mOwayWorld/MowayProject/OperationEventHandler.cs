using System;
using System.Drawing;

namespace Moway.Project
{
    /// <summary>
    /// Enumeration with the list of possible operations (depends on the type of project)
    /// </summary>
    public enum Operation { Nop, Insert, Select, SelectRectangle, Copy, Cut, Paste, Delete, InsertArrow, DragDrop, Settings, Connect, Undo, Redo, Reconnect, ModifyArrow }

    /// <summary>
    /// Delegate for events with operations
    /// </summary>
    /// <LastRevision>26.07.2012</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public delegate void OperationEventHandler(object sender, OperationEventArgs e);

    /// <summary>
    /// Arguments for the previous delegate
    /// </summary>
    public class OperationEventArgs : EventArgs
    {
        #region Attributes

        /// <summary>
        /// Affected operation
        /// </summary>
        private Operation operation;

        #endregion

        #region Properties

        /// <summary>
        /// Operation
        /// </summary>
        public Operation Operation { get { return this.operation; } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="operation">Operation</param>
        public OperationEventArgs(Operation operation)
        {
            this.operation = operation;
        }
    }
}
