using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.Actions;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Implementation of the insert operation. To launch the operation it is necessary to have the logical diagram
    /// as well as the element to be inserted.
    /// This implementation is a bit special because you can not launch the cancellation until it has occurred
    /// the Up event of the left mouse button. Therefore, there is an intermediate state of precancelation where it is cleaned
    /// the temporary layer but the Event of operation canceled is not launched.
    /// </summary>
    /// <LastRevision>01.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class InsertElement : IOperation
    {
        #region Attributes

        /// <summary>
        /// Logical diagram of GraphDrawing
        /// </summary>
        private Diagram diagram;
        /// <summary>
        /// Diagram of the GraphDrawing layer
        /// </summary>
        private GraphLayer diagramLayer;
        /// <summary>
        /// Temporal layer of the GraphDrawing
        /// </summary>
        private GraphLayer tempLayer;
        /// <summary>
        /// Graphic element to insert
        /// </summary>
        private GraphElement graphElement;
        /// <summary>
        /// Indicates whether the operation is precanceled
        /// </summary>
        private bool opPrecanceled = false;

        #endregion

        #region Properties

        /// <summary>
        /// Contextual menu for this operation
        /// </summary>
        public ContextMenu ContextMenu { get { return null; } }
        /// <summary>
        /// Initial Cursor for this operation
        /// </summary>
        public Cursor InitCursor { get { return Cursors.No; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the diagram changes
        /// </summary>
        public event EventHandler DiagramChanged;
        /// <summary>
        /// Occurs when the cursor changes
        /// </summary>
        public event CursorEventHandler CursorChanged;
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
        /// Insert Operation Builder
        /// </summary>
        /// <param name="diagram">Logical diagram of GraphDrawing</param>
        /// <param name="diagramLayer">GraphDrawing diagram Layer</param>
        /// <param name="tempLayer">Temporal layer of the GraphDrawing</param>
        /// <param name="element">Element to insert</param>
        public InsertElement(Diagram diagram, GraphLayer diagramLayer, GraphLayer tempLayer, GraphElement element)
        {
            this.diagram = diagram;
            this.diagramLayer = diagramLayer;
            this.tempLayer = tempLayer;
            this.tempLayer.Visible = false;
            this.graphElement = element;
            //Add the element to the temporal layer
            this.tempLayer.AddElement(this.graphElement);
        }

        #region Methods to implement the IOperation interface

        /// <summary>
        /// This method is called when the mouse enters the workspace
        /// </summary>
        public void MouseEnter()
        {
            //If the operation is not precanceled, the temporary layer is displayed (in the mouse move will be updated)
            if (!this.opPrecanceled)
            {
                this.tempLayer.Visible = true;
            }
        }

        /// <summary>
        /// This method is called when the mouse exits the workspace
        /// </summary>
        public void MouseLeave()
        {
            //If the operation is not precanceled, the temporary layer is hidden and updated
            if (!this.opPrecanceled)
            {
                Cursor.Current = Cursors.No;
                this.tempLayer.Visible = false;
                this.tempLayer.UpdateSurface();
                this.graphElement.Center = new Point(0, 0);  //necessary to be updated correctly when the mouse enter later
            }
        }

        /// <summary>
        /// This method is called when the mouse moves into the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseMove(MouseEventArgs e)
        {
            //As long as the operation is not precanceled
            if (!this.opPrecanceled)
            {
                //You get the position within the grid (the roundings are for the effect to be better)
                int x = (int)(Math.Round((double)(e.X - 8) / 16) * 16) + 7;
                int y = (int)(Math.Round((double)(e.Y - 9) / 18) * 18) + 8;
                //Only updated if position is changed
                if ((this.graphElement.Center.X != x) || (this.graphElement.Center.Y != y))
                {
                    //The position is updated
                    this.graphElement.Center = new Point(x, y);
                    //It checks if the position is valid to make an insertion and the cursor is updated
                    if (this.ValidateLocation())
                    {
                        if ((Cursor.Current != Cursors.SizeAll) && (this.CursorChanged != null))
                            this.CursorChanged(this, new CursorEventArgs(Cursors.SizeAll));
                    }
                    else
                    {
                        if ((Cursor.Current != Cursors.No) && (this.CursorChanged != null))
                            this.CursorChanged(this, new CursorEventArgs(Cursors.No));
                    }
                    //The temporal layer is updated
                    this.tempLayer.UpdateSurface();
                }
            }
            //If the right button is not pressed, the insert operation is cancelled
            else if (e.Button != MouseButtons.Left)
                this.Cancel();
        }

        /// <summary>
        /// This method is calling when you press any mouse button within the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseDown(MouseEventArgs e) { }

        /// <summary>
        /// This method is called when any mouse button is released within the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseUp(MouseEventArgs e)
        {
            //If this event occurs with another button than it is not the left one, the operation is cancelled (if insert has already occurred, this event does not jump)
            if (e.Button != MouseButtons.Right)
                this.Cancel();
        }

        /// <summary>
        /// This method is called when a key is pressed from the keyboard
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        public void KeyPress(Keys modifier, Keys key)
        {
            //Pressing escape will cancel the operation
            if ((modifier == Keys.None) && (key == Keys.Escape))
                this.PreCancel();
        }

        /// <summary>
        /// This method executes the insert operation after the insertion position has been set
        /// </summary>
        public void Do()
        {
            //If the operation is not precanceled and the mouse is within the workspace (when the temporary layer is visible)
            if ((!this.opPrecanceled) && (this.tempLayer.Visible))
            {
                //It is checked if the position is valid for insertion
                if (this.ValidateLocation())
                {
                    //It checks if the action needs Inicilización
                    if (this.graphElement.NeedInit)
                    {
                        ActionForm actionForm = ActionFactory.GetActionForm(this.graphElement.Element);
                        if (DialogResult.OK != actionForm.ShowDialog())
                        {
                            this.Cancel();
                            return;
                        }
                    }
                    //The GraphElement is added to the diagram layer, and to the logical diagram
                    this.diagramLayer.AddElement(this.graphElement);
                    this.diagram.AddElement(this.graphElement.Element);
                    //The temporary layer is cleaned and hidden
                    this.tempLayer.ClearAndHide();
                    //The diagram layer is updated
                    this.diagramLayer.UpdateSurface();
                    //It is indicated that the diagram has changed
                    if (this.DiagramChanged != null)
                        this.DiagramChanged(this, new EventArgs());
                    //The operation is terminated
                    if (this.OperationFinished != null)
                        this.OperationFinished(this, new OperationEventArgs(Operation.Insert));
                }
                else
                {
                    //If the position is invalid, it is precanceled to show notice to the user
                    this.PreCancel();
                    if (GraphSettings.Default.InsertWarning == true)
                    {
                        bool showAgain = true;
                        MowayMessageBox.Show(InsertElementMessages.DRAG_OBJECT, InsertElementMessages.INSERT_ELEMENT, MessageBoxButtons.OK, MessageBoxIcon.Error, ref showAgain);
                        GraphSettings.Default.InsertWarning = showAgain;
                        GraphSettings.Default.Save();
                    }
                    this.Cancel();
                }
            }
            else
                this.Cancel();
        }

        /// <summary>
        /// Cancels operation execution
        /// </summary>
        public void Cancel()
        {
            if (!this.opPrecanceled)
            {
                //The temporary layer is cleaned, hidden and updated
                this.tempLayer.ClearAndHide();
                this.tempLayer.UpdateSurface();
            }
            //The cursor is updated
            Cursor.Current = Cursors.Default;
            //The operation is cancelled
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.Insert));
        }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus() { }

        /// <summary>
        /// This method is called when the paste operation is enabled (for the context menu)
        /// </summary>
        public void EnablePaste() { }

        /// <summary>
        /// This method undos the operation
        /// </summary>
        public void Undo()
        {
            //The GraphElement of the diagram layer and the logical diagram is removed
            GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphElement);
            //The diagram layer is updated
            this.diagramLayer.UpdateSurface();
            //It is indicated that the diagram has changed
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
        }

        /// <summary>
        /// This method redoes the previously undone operation
        /// </summary>
        public void Redo() { }

        /// <summary>
        /// Makes a precancellation of the operation
        /// </summary>
        public void PreCancel()
        {
            this.opPrecanceled = true;
            //The temporary layer is cleaned, hidden and updated
            this.tempLayer.ClearAndHide();
            this.tempLayer.UpdateSurface();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Validates the position of the GraphElement to be inserted in the layer of the diagram
        /// </summary>
        /// <returns>True if the position is correct, false otherwise</returns>
        private bool ValidateLocation()
        {
            if ((this.graphElement.Left <= 0) || (this.graphElement.Right >= this.diagramLayer.Surface.Width) || (this.graphElement.Top <= 0) || (this.graphElement.Bottom >= this.diagramLayer.Surface.Height))
                return false;
            else if (this.diagramLayer.IntersectsWith(this.graphElement))
                return false;
            else
                return true;
        }

        #endregion
    }
}
