using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.Actions.Start;
using Moway.Project.GraphicProject.DiagramLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Implementation of the cut operation.
    /// </summary>
    /// <LastRevision>01.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Cut:IOperation
    {
        #region Attributes

        /// <summary>
        /// Graphic diagram Layer
        /// </summary>
        private GraphLayer diagramLayer;
        /// <summary>
        /// Diagram Selection Layer
        /// </summary>
        private GraphLayer selectLayer;
        /// <summary>
        /// Logical diagram
        /// </summary>
        private Diagram diagram;
        /// <summary>
        /// List of items to delete
        /// </summary>
        private List<GraphElement> elementsToDelete;

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
        public event EventHandler DiagramChanged;
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
        public event EventHandler ElementSelectedChanged;

        #endregion

        /// <summary>
        /// Builder
        /// </summary>
        /// <param name="diagram">Logical diagram</param>
        /// <param name="diagramLayer">Graphic diagram Layer</param>
        /// <param name="selectLayer">Graphic Diagram Selection layer</param>
        public Cut(Diagram diagram, GraphLayer diagramLayer, GraphLayer selectLayer)
        {
            this.diagram = diagram;
            this.diagramLayer = diagramLayer;
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
        /// This method is calling when you press any mouse button within the workspace
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
                MowayMessageBox.Show(CutMessages.CUT_START, CutMessages.CUT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cancel();
                return;
            }
            //The items to be copied are loaded
            List<GraphElement> elementsToCut = GraphDiagram.GetElementsToCopy(this.selectLayer);
            List<GraphElement> cloneElements = GraphDiagram.CloneElements(elementsToCut);
            GraphManager.Clipboard.SetElements(cloneElements);

            this.elementsToDelete = GraphDiagram.GetElementsToDelete(this.selectLayer);
            GraphDiagram.DeleteElements(this.diagramLayer, this.diagram, this.elementsToDelete);
            //Cleans and hides the selection layer
            this.selectLayer.ClearAndHide();
            //Updates the diagram layer
            this.diagramLayer.UpdateSurface();
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
            if (this.ElementSelectedChanged != null)
                this.ElementSelectedChanged(this, new EventArgs());
            //Launch Event of operation completed
            if (this.OperationFinished != null)
                this.OperationFinished(this, new OperationEventArgs(Operation.Cut));

        }

        /// <summary>
        /// Cancels operation execution
        /// </summary>
        public void Cancel()
        {
            //Launch cancelled Operation event
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.Cut));
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
            //They reconnect the arrows that would have
            foreach (GraphElement graphElement in this.elementsToDelete)
            {
                graphElement.Selected = false;
                if (graphElement is GraphArrow)
                {
                    //The element Next is analyzed
                    if (!elementsToDelete.Contains(graphElement.Next))
                        graphElement.Next.AddPrevious(((GraphArrow)graphElement).FinalConnector, (GraphArrow)graphElement);
                    //The element Previous is analyzed (the arrow can only have 1)
                    foreach (GraphElement prevElement in graphElement.Previous)
                        if (!this.elementsToDelete.Contains(prevElement))
                            prevElement.AddNext(((GraphArrow)graphElement).InitConnector, (GraphArrow)graphElement);
                }
                //The GraphElement is added to the diagram layer, and to the logical diagram
                this.diagramLayer.AddElement(graphElement);
                this.diagram.AddElement(graphElement.Element);
            }
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

        #endregion
    }
}
