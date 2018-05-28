using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.Actions.Start;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Implementation of the copy operation.
    /// </summary>
    /// <LastRevision>01.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Copy : IOperation
    {
        #region Attributes

        /// <summary>
        /// Graphic Diagram Selection layer
        /// </summary>
        private GraphLayer selectLayer;

        #endregion

        #region Properties

        /// <summary>
        /// ContextMenu for Operation
        /// </summary>
        public ContextMenu ContextMenu { get { return null; } }
        /// <summary>
        /// Initial Cursor for this operation
        /// </summary>
        public Cursor InitCursor { get { return Cursors.SizeAll; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events


        /// <summary>
        /// Occurs when the diagram changes
        /// </summary>
        public event EventHandler DiagramChanged { add { } remove { } }
        /// <summary>
        /// Occurs when the cursor changes
        /// </summary>
        public event CursorEventHandler CursorChanged { add { } remove { } }
        /// <summary>
        /// Occurs when the insert operation ends
        /// </summary>
        public event OperationEventHandler OperationFinished;
        /// <summary>
        /// Occurs when the insert operation is cancelled
        /// </summary>
        public event OperationEventHandler OperationCanceled;
        /// <summary>
        /// Occurs when the execution of a new operation is launched (for the context menu)
        /// </summary>
        public event OperationEventHandler NewOperation { add { } remove { } }
        /// <summary>
        /// Occurs when a possible operation is enabled 
        /// </summary>
        public event OperationEventHandler OperationEnabled { add { } remove { } }
        /// <summary>
        /// Occurs when another operation is disabled
        /// </summary>
        public event OperationEventHandler OperationDisabled { add { } remove { } }
        /// <summary>
        /// Occurs when the selection of items in the diagram changes
        /// </summary>
        public event EventHandler ElementSelectedChanged { add { } remove { } }

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="selectLayer">Graphic Diagram Selection layer</param>
        public Copy(GraphLayer selectLayer)
        {
            this.selectLayer = selectLayer;
        }

        #region Methods to implement the IOperation interface

        /// <summary>
        /// This method is called when the mouse enters the workspace
        /// </summary>
        public void MouseEnter() { }

        /// <summary>
        /// This method is called when the mouse exits the workspace
        /// </summary>
        public void MouseLeave() { }

        /// <summary>
        /// This method is called when the mouse moves into the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseMove(MouseEventArgs e) { }

        /// <summary>
        /// This method is called when any mouse button is pressed within the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseDown(MouseEventArgs e) { }

        /// <summary>
        /// This method is called when any mouse button is released within the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseUp(MouseEventArgs e) { }

        /// <summary>
        /// This method is called when a key is pressed from the keyboard
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        public void KeyPress(Keys modifier, Keys key) { }

        /// <summary>
        /// This method executes the insert operation after the insertion position has been set
        /// </summary>
        public void Do()
        {
            if (!GraphDiagram.ValidateCopy(this.selectLayer.Elements))
            {
                MowayMessageBox.Show(CopyMessages.COPY_START, CopyMessages.COPY, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cancel();
                return;
            }
            //The items to be copied are loaded
            List<GraphElement> elementsToCopy = GraphDiagram.GetElementsToCopy(this.selectLayer);
            List<GraphElement> cloneElements = GraphDiagram.CloneElements(elementsToCopy);
            GraphManager.Clipboard.SetElements(cloneElements);
            //Launch Event of operation completed
            if (this.OperationFinished != null)
                this.OperationFinished(this, new OperationEventArgs(Operation.Copy));

        }

        /// <summary>
        /// Cancels operation execution
        /// </summary>
        public void Cancel()
        {
            //Launch cancelled Operation event
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.Delete));
        }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus() { }

        /// <summary>
        /// This method is called when the paste operation is enabled (for the contextual menu)
        /// </summary>
        public void EnablePaste() { }

        /// <summary>
        /// This method undos the operation
        /// </summary>
        public void Undo() { }

        /// <summary>
        /// This method redoes the previously undone operation
        /// </summary>
        public void Redo() { }

        #endregion
    }
}
