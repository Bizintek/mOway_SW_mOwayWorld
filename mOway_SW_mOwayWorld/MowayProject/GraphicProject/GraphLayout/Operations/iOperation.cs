using System;
using System.Drawing;
using System.Windows.Forms;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Interface for graphic diagram operations
    /// </summary>
    /// <LastRevision>01.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public interface IOperation
    {
        #region Properties

        /// <summary>
        /// Operation context Menu
        /// </summary>
        ContextMenu ContextMenu { get; }
        /// <summary>
        /// Initial Cursor for this operation
        /// </summary>
        Cursor InitCursor { get; }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        Point InitMouseDownLocation { get; }

        #endregion

        #region Events
        
        /// <summary>
        /// Occurs when the diagram changes
        /// </summary>
        event EventHandler DiagramChanged;
        /// <summary>
        /// Occurs when the cursor changes
        /// </summary>
        event CursorEventHandler CursorChanged;
        /// <summary>
        /// Occurs when the insert operation ends
        /// </summary>
        event OperationEventHandler OperationFinished;
        /// <summary>
        /// Occurs when the insert operation is cancelled
        /// </summary>
        event OperationEventHandler OperationCanceled;
        /// <summary>
        /// Occurs when the execution of a new operation is launched (for the context menu)
        /// </summary>
        event OperationEventHandler NewOperation;
        /// <summary>
        /// Occurs when a possible operation is enabled 
        /// </summary>
        event OperationEventHandler OperationEnabled;
        /// <summary>
        /// Occurs when another operation is disabled
        /// </summary>
        event OperationEventHandler OperationDisabled;
        /// <summary>
        /// Occurs when the selection of items in the diagram changes
        /// </summary>
        event EventHandler ElementSelectedChanged;

        #endregion

        #region Methods to implement

        /// <summary>
        /// This method is called when the mouse enters the workspace
        /// </summary>
        void MouseEnter();

        /// <summary>
        /// This method is called when the mouse exits the workspace
        /// </summary>
        void MouseLeave();

        /// <summary>
        /// This method is called when the mouse moves into the workspace
        /// </summary>
        /// <param name="e"></param>
        void MouseMove(MouseEventArgs e);

        /// <summary>
        /// This method is calling when you press any mouse button within the workspace
        /// </summary>
        /// <param name="e"></param>
        void MouseDown(MouseEventArgs e);

        /// <summary>
        /// This method is called when any mouse button is released within the workspace
        /// </summary>
        /// <param name="e"></param>
        void MouseUp(MouseEventArgs e);

        /// <summary>
        /// This method is called when a key is pressed from the keyboard
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        void KeyPress(Keys modifier, Keys key);

        /// <summary>
        /// This method executes the insert operation after the insertion position has been set
        /// </summary>
        void Do();

        /// <summary>
        /// Cancels operation execution
        /// </summary>
        void Cancel();

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        void LostFocus();

        /// <summary>
        /// This method is called when the paste operation is enabled (for the context menu)
        /// </summary>
        void EnablePaste();

        /// <summary>
        /// This method undos the operation
        /// </summary>
        void Undo();

        /// <summary>
        /// This method redoes the previously undone operation
        /// </summary>
        void Redo();

        #endregion
    }
}
