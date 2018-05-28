using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using SdlDotNet.Graphics.Sprites;

using Moway.Template;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Project.GraphicProject.Actions.Start;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class Delete : IOperation
    {
        #region Attributes

        private Diagram diagram;
        private GraphLayer diagramLayer;
        private GraphLayer selectLayer;
        private List<GraphElement> elementsToDelete = new List<GraphElement>();

        #endregion

        #region Properties

        /// <summary>
        /// ContextMenu for Operation
        /// </summary>
        public ContextMenu ContextMenu { get { return null; } }
        public Cursor InitCursor { get { return Cursors.SizeAll; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events

        public event EventHandler DiagramChanged;
        public event CursorEventHandler CursorChanged { add { } remove { } }
        public event OperationEventHandler OperationFinished;
        public event OperationEventHandler OperationCanceled;
        public event OperationEventHandler NewOperation { add { } remove { } }
        /// <summary>
        /// Enables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationEnabled { add { } remove { } }
        /// <summary>
        /// DesEnables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationDisabled { add { } remove { } }
        /// <summary>
        /// Occurs when the selection of items in the diagram changes
        /// </summary>
        public event EventHandler ElementSelectedChanged;

        #endregion

        /// <summary>
        /// Builder for the delete operation
        /// </summary>
        /// <param name="diagram">Diagram of the GraphDrawing</param>
        /// <param name="diagramLayer">GraphDrawing diagram Layer</param>
        /// <param name="tempLayer">Temporal layer of the GraphDrawing</param>
        public Delete(Diagram diagram, GraphLayer diagramLayer, GraphLayer selectLayer)
        {
            this.diagram = diagram;
            this.diagramLayer = diagramLayer;
            this.selectLayer = selectLayer;
        }

        #region Methods to implement the IOperation interface

        public void MouseEnter() { }

        public void MouseLeave() { }

        public void MouseMove(MouseEventArgs e) { }

        public void MouseDown(MouseEventArgs e) { }

        public void MouseUp(MouseEventArgs e) { }

        public void KeyPress(Keys modifier, Keys key) { }

        public void Do()
        {
            if (!this.ValidateDelete())
            {
                MowayMessageBox.Show(DeleteMessages.DELETE_START, DeleteMessages.DELETE_OBJECT, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cancel();
                return;
            }

            if (GraphSettings.Default.DeleteWarning == true)
            {
                bool showAgain = true;
                if (DialogResult.No == MowayMessageBox.Show(DeleteMessages.WARNING_DELETE + "\r\n" + DeleteMessages.CONTINUE, DeleteMessages.DELETE_OBJECT, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, ref showAgain))
                {
                    this.Cancel();
                    GraphSettings.Default.DeleteWarning = showAgain;
                    GraphSettings.Default.Save();
                    return;
                }
                GraphSettings.Default.DeleteWarning = showAgain;
                GraphSettings.Default.Save();
            }
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
                this.OperationFinished(this, new OperationEventArgs(Operation.Delete));

        }

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

        public void EnablePaste() { }

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

        public void Redo() { }

        #endregion

        #region Private methods

        private bool ValidateDelete()
        {
            foreach (GraphElement element in this.selectLayer.Elements)
                if (element is GraphStart)
                    return false;
            return true;
        }

        #endregion
    }
}
