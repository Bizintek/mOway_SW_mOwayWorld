using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;
using Moway.Template;


namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class Reconnect : IOperation
    {
        #region Attributes

        /// <summary>
        /// Stores the position about the MouseButtonDown event has run
        /// </summary>
        private Diagram diagram;
        private GraphLayer diagramLayer;
        private GraphLayer tempLayer;
        private GraphArrow graphArrowToDelete;
        private GraphArrow graphArrow;
        private Connector fixedConnector;
        private Connector initialConnector;
        private bool nextEnable;
        private ConditionalOut conditionalOut;

        private TempGraphArrow tempGraphArrow = new TempGraphArrow();

        private GridPoint[,] gridStatus;
        private GraphElement presentElement = null;
        private Connector presentConnector = null;

        #endregion

        #region Properties

        public event EventHandler DiagramChanged;
        /// <summary>
        /// Contextual menu for the operation
        /// </summary>
        public ContextMenu ContextMenu { get { return null; } }
        public Cursor InitCursor { get { return Cursors.Hand; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events
        /// <summary>
        /// Event for cursor change
        /// </summary>
        public event CursorEventHandler CursorChanged { add { } remove { } }
        /// <summary>
        /// Event of operation completed
        /// </summary>
        public event OperationEventHandler OperationFinished;
        /// <summary>
        /// Event of operation cancelled
        /// </summary>
        public event OperationEventHandler OperationCanceled;
        /// <summary>
        /// Event of operation cancelledLaunches the execution of a new operation (for the context menu)
        /// </summary>
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
        public event EventHandler ElementSelectedChanged { add { } remove { } }

        #endregion

        public Reconnect(Diagram diagram, GraphLayer diagramLayer, GraphLayer tempLayer, Point initialPoint)
        {
            this.diagram = diagram;
            this.diagramLayer = diagramLayer;
            this.tempLayer = tempLayer;
            this.graphArrowToDelete = (GraphArrow)this.tempLayer.Elements[0];

            this.initialConnector = this.graphArrowToDelete.GetConnector(initialPoint);
            if (this.initialConnector == this.graphArrowToDelete.InitConnector)
            {
                this.fixedConnector = this.graphArrowToDelete.FinalConnector;
                this.nextEnable = true;
            }
            else
            {
                this.fixedConnector = this.graphArrowToDelete.InitConnector;
                this.nextEnable = false;
            }

            this.graphArrowToDelete.DisableModifiers();
            this.tempLayer.Clear();

            this.tempLayer.Add(this.tempGraphArrow);
            this.tempLayer.Visible = true;
            this.tempLayer.UpdateSurface();

            //You get the obstacles to avoid by the arrow of the diagram layer
            this.gridStatus = this.diagramLayer.GetGridPoints();
        }

        #region Methods to implement the IOperation interface

        public void MouseEnter()
        {
            this.tempGraphArrow.Visible = true;
            this.tempLayer.UpdateSurface();
        }

        public void MouseLeave()
        {
            this.tempGraphArrow.Visible = false;
            this.tempLayer.UpdateSurface();
        }

        public void MouseMove(MouseEventArgs e)
        {
            GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
            if (element != null)
            {
                if (this.presentElement != element)
                {
                    if (this.presentElement != null)
                    {
                        this.presentElement.DisableConnectors();
                        if (this.presentElement == this.fixedConnector.Parent)
                            this.presentElement.EnableConnector(this.fixedConnector);
                        else
                            this.tempLayer.RemoveElement(this.presentElement);
                        this.presentElement = null;
                    }
                    if (this.nextEnable)
                    {
                        if (element.EnableNextConnectors())
                        {
                            this.presentElement = element;
                            this.tempLayer.Add(this.presentElement);
                        }
                    }
                    else
                        if (element.EnablePrevConnectors())
                        {
                            this.presentElement = element;
                            this.tempLayer.Add(this.presentElement);
                        }
                }
                if (this.presentElement == null)
                {
                    this.presentConnector = null;
                    this.tempGraphArrow.UpdateArrow(this.fixedConnector.AbsCenter, e.Location);
                }
                else
                {
                    Connector connector = this.presentElement.GetConnector(e.Location);
                    if (connector == null)
                    {
                        this.presentConnector = null;
                        this.tempGraphArrow.UpdateArrow(this.fixedConnector.AbsCenter, e.Location);
                    }
                    else if (this.presentConnector != connector)
                    {
                        this.presentConnector = connector;
                        this.tempGraphArrow.UpdateArrow(this.fixedConnector.AbsCenter, this.presentConnector.AbsCenter);
                    }
                }
            }
            else
            {
                if (this.presentElement != null)
                {
                    this.presentElement.DisableConnectors();
                    if (this.presentElement == this.fixedConnector.Parent)
                        this.presentElement.EnableConnector(this.fixedConnector);
                    else
                        this.tempLayer.RemoveElement(this.presentElement);
                    this.presentElement = null;
                }
                this.tempGraphArrow.UpdateArrow(this.fixedConnector.AbsCenter, e.Location);
            }
            this.tempLayer.UpdateSurface();
        }

        public void MouseDown(MouseEventArgs e) { }

        public void MouseUp(MouseEventArgs e)
        {
            if (this.presentConnector != null)
                if (this.presentConnector == initialConnector)
                    this.Cancel();
                else
                    this.Do();
            else
                this.Cancel();
        }

        public void KeyPress(Keys modifier, Keys key)
        {
            if ((modifier == Keys.None) && (key == Keys.Escape))
                this.Cancel();
        }

        public void Do() 
        {
            //If you are modifying the next of an item...
            if (this.nextEnable)
            {
                if (this.presentConnector.Parent is GraphConditional)
                {
                    this.conditionalOut = ((GraphConditional)this.presentConnector.Parent).GetPredefOut(this.presentConnector);
                    if ((conditionalOut == ConditionalOut.True) && (((GraphConditional)this.presentConnector.Parent).NextTrue != null))
                        if (DialogResult.Yes != MowayMessageBox.Show(InsertArrowMessages.REPLACE_TRUE + "\r\n" + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            this.Cancel();
                            return;
                        }
                    else if ((conditionalOut == ConditionalOut.False) && (((GraphConditional)this.presentConnector.Parent).NextFalse != null))
                        if (DialogResult.Yes != MowayMessageBox.Show(InsertArrowMessages.REPLACE_FALSE + "\r\n" + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            this.Cancel();
                            return;
                        }
                }
                GraphDiagram.DeleteElement(diagramLayer, diagram, this.graphArrowToDelete);
                this.graphArrow = GraphDiagram.InsertArrow(this.diagram, this.diagramLayer, this.presentConnector, this.fixedConnector, this.conditionalOut, this.gridStatus);
            }
            else        //If you are modifying an item's prev
            {
                if (fixedConnector.Parent is GraphConditional)
                {
                    if (((GraphConditional)fixedConnector.Parent).NextTrue == this.graphArrowToDelete)
                        this.conditionalOut = ConditionalOut.True;
                    else
                        this.conditionalOut = ConditionalOut.False;
                }
                GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphArrowToDelete);
                this.graphArrow = GraphDiagram.InsertArrow(this.diagram, this.diagramLayer, this.fixedConnector, this.presentConnector, this.conditionalOut, this.gridStatus);
            }
            foreach (GraphElement element in this.tempLayer.Elements)
                element.DisableConnectors();
            this.tempLayer.ClearAndHide();
            this.diagramLayer.UpdateSurface();
            if (this.OperationFinished != null)
                this.OperationFinished(this, new OperationEventArgs(Operation.Reconnect));
        }

        public void Cancel()
        {
            foreach (GraphElement element in this.tempLayer.Elements)
                element.DisableConnectors();
            this.tempLayer.ClearAndHide();
            this.tempLayer.UpdateSurface();
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.Reconnect));
        }

        public void LostFocus()
        {
            this.Cancel();
        }

        public void EnablePaste() { }

        public void Undo()
        {
            //The entered arrow is removed
            GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphArrow);
            //Add the deleted arrow starting with the next element
            this.graphArrowToDelete.Next.AddPrevious(this.graphArrowToDelete.FinalConnector, this.graphArrowToDelete);
            foreach (GraphElement prevElement in this.graphArrowToDelete.Previous)
                if (prevElement is GraphConditional)
                    ((GraphConditional)prevElement).AddNext(this.graphArrowToDelete.InitConnector, this.graphArrowToDelete, this.conditionalOut);
                else
                    prevElement.AddNext(this.graphArrowToDelete.InitConnector, this.graphArrowToDelete);
            //The arrow is added to the diagram layer, and to the logical diagram
            this.diagramLayer.AddElement(this.graphArrowToDelete);
            this.diagram.AddElement(this.graphArrowToDelete.Element);
            //The diagram layer is updated
            this.diagramLayer.UpdateSurface();
            //It is indicated that the diagram has changed
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
        }

        public void Redo() { }

        #endregion
    }
}
