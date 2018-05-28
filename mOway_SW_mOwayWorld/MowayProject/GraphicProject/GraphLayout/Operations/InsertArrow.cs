using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Graphics.Primitives;

using Moway.Template;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class InsertArrow : IOperation
    {
        #region Attributes

        private Diagram diagram;
        private GraphLayer diagramLayer;
        private GraphLayer tempLayer;
        private ContextMenu menu;
        private Connector initialConnector;
        private ConditionalOut conditionalOut;
        private Connector finalConnector = null;
        private GridPoint[,] gridStatus;
        /// <summary>
        /// Arrow included
        /// </summary>
        private GraphArrow graphArrow;
        private GraphArrow graphArrowToDelete = null;

        private TempGraphArrow tempGraphArrow = new TempGraphArrow();
        private bool preCanceled = false;
        private bool dragMode = true;
        private GraphElement presentElement = null;
        private Connector presentConnector = null;

        #endregion

        #region Properties

        public ContextMenu ContextMenu { get { return this.menu; } }
        public Cursor InitCursor { get { return Cursors.Hand; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events

        public event EventHandler DiagramChanged;
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

        public InsertArrow(Diagram diagram, GraphLayer diagramLayer, GraphLayer tempLayer, Point initialPoint)
        {
            this.diagram = diagram;
            this.diagramLayer = diagramLayer;
            this.tempLayer = tempLayer;
            MenuItem miCancel = new MenuItem("Cancelar");
            miCancel.Click += new EventHandler(MiCancel_Click);
            this.menu = new ContextMenu(new MenuItem[] { miCancel });
            //You get the starting element and the initial connector
            this.initialConnector = this.tempLayer.Elements[0].GetConnector(initialPoint);
            //Only the connector selected for that element is enabled
            this.initialConnector.Parent.EnableConnector(this.initialConnector);
            if (this.initialConnector.Parent is GraphConditional)
                this.conditionalOut = ((GraphConditional)this.initialConnector.Parent).GetPredefOut(this.initialConnector);
            //Add the temporary arrow
            this.tempLayer.Add(this.tempGraphArrow);
            this.tempLayer.Visible = true;
            this.tempLayer.UpdateSurface();

            //You get the obstacles to avoid by the arrow of the diagram layer
            this.gridStatus = this.diagramLayer.GetGridPoints();
        }
        
        void MiCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        public void MouseEnter()
        {
            if (!this.dragMode)
            {
                this.tempGraphArrow.Visible = true;
                this.tempLayer.UpdateSurface();
            }
        }

        public void MouseLeave()
        {
            if (!this.dragMode)
            {
                this.tempGraphArrow.Visible = false;
                this.tempLayer.UpdateSurface();
            }
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
                        if (this.presentElement == this.initialConnector.Parent)
                            this.presentElement.EnableConnector(this.initialConnector);
                        else
                            this.tempLayer.RemoveElement(this.presentElement);
                        this.presentElement = null;
                    }
                    if (element.EnablePrevConnectors())
                    {
                        this.presentElement = element;
                        this.tempLayer.Add(this.presentElement);
                    }
                }
                if (this.presentElement == null)
                {
                    this.presentConnector = null;
                    this.tempGraphArrow.UpdateArrow(this.initialConnector.AbsCenter, e.Location);
                }
                else
                {
                    Connector connector = this.presentElement.GetConnector(e.Location);
                    if (connector == null)
                    {
                        this.presentConnector = null;
                        this.tempGraphArrow.UpdateArrow(this.initialConnector.AbsCenter, e.Location);
                    }
                    else if (this.presentConnector != connector)
                    {
                        this.presentConnector = connector;
                        this.tempGraphArrow.UpdateArrow(this.initialConnector.AbsCenter, this.presentConnector.AbsCenter);
                    }
                }
            }
            else 
            {
                if (this.presentElement != null)
                {
                    this.presentElement.DisableConnectors();
                    if (this.presentElement == this.initialConnector.Parent)
                        this.presentElement.EnableConnector(this.initialConnector);
                    else
                        this.tempLayer.RemoveElement(this.presentElement);
                    this.presentElement = null;
                }
                this.tempGraphArrow.UpdateArrow(this.initialConnector.AbsCenter, e.Location);
            }
            this.tempLayer.UpdateSurface();
        }

        public void MouseDown(MouseEventArgs e) { }

        public void MouseUp(MouseEventArgs e)
        {
            if (!this.preCanceled)
            {
                this.finalConnector = GraphDiagram.GetConnector(this.tempLayer, e.Location);
                if (this.finalConnector == null)
                {
                    this.PreCancel();
                    throw new OperationException(Operation.InsertArrow, "Change to Nop Operation");
                }
                else if (this.finalConnector == this.initialConnector)
                {
                    this.finalConnector = null;
                    dragMode = false;
                }
                else
                {
                    this.Do();
                    throw new OperationException(Operation.InsertArrow, "Send a MouseMoveEvent");
                }
            }
            else
                this.Cancel();
        }

        public void KeyPress(Keys modifier, Keys key)
        {
            if ((modifier == Keys.None) && (key == Keys.Escape))
                if (this.dragMode)
                {
                    this.preCanceled = true;
                    this.PreCancel();
                }
                else
                    this.Cancel();
        }

        public void Do()
        {
            GraphElement initialElement = initialConnector.Parent;
            GraphElement finalElement = finalConnector.Parent;

            this.graphArrow = new GraphArrow(initialConnector, finalConnector, gridStatus);
            if (initialElement is GraphConditional)
            {
                if ((conditionalOut == ConditionalOut.True) && (((GraphConditional)initialElement).NextTrue != null))
                    if (DialogResult.Yes == MowayMessageBox.Show(InsertArrowMessages.REPLACE_TRUE + "\r\n" + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        this.graphArrowToDelete = (GraphArrow)((GraphConditional)initialElement).NextTrue;
                        GraphDiagram.DeleteElement(diagramLayer, diagram, this.graphArrowToDelete);
                    }
                    else
                    {
                        this.Cancel();
                        return;
                    }
                else if ((conditionalOut == ConditionalOut.False) && (((GraphConditional)initialElement).NextFalse != null))
                    if (DialogResult.Yes == MowayMessageBox.Show(InsertArrowMessages.REPLACE_FALSE + "\r\n" + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        this.graphArrowToDelete = (GraphArrow)((GraphConditional)initialElement).NextFalse;
                        GraphDiagram.DeleteElement(diagramLayer, diagram, this.graphArrowToDelete);
                    }
                    else
                    {
                        this.Cancel();
                        return;
                    }
                ((GraphConditional)initialElement).AddNext(initialConnector, this.graphArrow, conditionalOut);
            }
            else
            {
                if (initialElement.Next != null)
                    if (DialogResult.Yes == MowayMessageBox.Show(InsertArrowMessages.REPLACE_OUT + "\r\n" + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        this.graphArrowToDelete = (GraphArrow)initialElement.Next;
                        GraphDiagram.DeleteElement(diagramLayer, diagram, this.graphArrowToDelete);
                    }
                    else
                    {
                        this.Cancel();
                        return;
                    }
                initialElement.AddNext(initialConnector, this.graphArrow);
            }
            finalElement.AddPrevious(finalConnector, this.graphArrow);
            diagramLayer.AddElement(this.graphArrow);
            this.diagram.AddElement(this.graphArrow.Element);
            //Elements in the context of the operation are deleted
            this.PreCancel();
            this.diagramLayer.UpdateSurface();
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
            if (this.OperationFinished != null)
                this.OperationFinished(this, new OperationEventArgs(Operation.InsertArrow));
        }

        public void Cancel()
        {
            this.PreCancel();
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.InsertArrow));
        }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus()
        {
            this.Cancel();
        }

        public void EnablePaste() { }

        public void Undo() 
        {
            //The entered arrow is removed
            GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphArrow);
            //Resets the eliminated arrow in the event that there was
            if (this.graphArrowToDelete != null)
            {
                //Add the deleted arrow starting with the element next 
                this.graphArrowToDelete.Next.AddPrevious(this.graphArrowToDelete.FinalConnector, this.graphArrowToDelete);
                foreach (GraphElement prevElement in this.graphArrowToDelete.Previous)
                    prevElement.AddNext(this.graphArrowToDelete.InitConnector, this.graphArrowToDelete);
                //The arrow is added to the diagram layer, and to the logical diagram
                this.diagramLayer.AddElement(this.graphArrowToDelete);
                this.diagram.AddElement(this.graphArrowToDelete.Element);
            }
            //The diagram layer is updated
            this.diagramLayer.UpdateSurface();
            //It is indicated that the diagram has changed
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
        }

        public void Redo() { }

        #region Private methods

        private void PreCancel()
        {
            foreach (GraphElement element in this.tempLayer.Elements)
                element.DisableConnectors();
            this.tempLayer.ClearAndHide();
            this.tempLayer.UpdateSurface();
        }

        #endregion
    }

 
}