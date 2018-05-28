using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

using Moway.Template;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.DiagramLayout.Elements;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class Connect : IOperation
    {
        #region Attributes

        private Diagram diagram;
        private GraphLayer diagramLayer;
        private GraphLayer tempLayer;
        private Connector initialConnector = null;
        private ConditionalOut conditionalOut;
        private Connector finalConnector = null;
        private GraphArrow graphArrow;
        private GraphArrow graphArrowToDelete = null;

        private TempGraphArrow tempGraphArrow = new TempGraphArrow();
        private bool dragMode = true;

        private ContextMenu menu;
        private MenuItem miPaste = new MenuItem(ConnectMessages.PASTE);
        private MenuItem miCancel = new MenuItem(ConnectMessages.CANCEL);

        private Connector presentConnector;
        private GraphElement presentElement;
        private bool initFixed = false;

        #endregion

        #region Properties

        /// <summary>
        /// Context menu of the operation
        /// </summary>
        public ContextMenu ContextMenu { get { return this.menu; } }
        public Cursor InitCursor { get { return Cursors.Default; } }
        /// <summary>
        /// Initial position about the MouseButtonDown event was executed
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events

        public event EventHandler DiagramChanged;
        /// <summary>
        /// Event to change the cursor
        /// </summary>
        public event CursorEventHandler CursorChanged;
        /// <summary>
        /// Event of completed operation
        /// </summary>
        public event OperationEventHandler OperationFinished;
        /// <summary>
        /// Event of canceled operation
        /// </summary>
        public event OperationEventHandler OperationCanceled;
        /// <summary>
        /// Launches the execution of a new operation(for the context menu)
        /// </summary>
        public event OperationEventHandler NewOperation;
        /// <summary>
        /// Enables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationEnabled { add { } remove { } }
        /// <summary>
        /// Disables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationDisabled { add { } remove { } }
        /// <summary>
        /// Occurs when the selection of items in the diagram changes
        /// </summary>
        public event EventHandler ElementSelectedChanged { add { } remove { } }

        #endregion

        public Connect(Diagram diagram, GraphLayer diagramLayer, GraphLayer tempLayer)
        {
            this.diagram = diagram;
            this.diagramLayer = diagramLayer;
            this.tempLayer = tempLayer;
            this.miPaste.Click += new EventHandler(MiPaste_Click);
            this.miPaste.Enabled = !GraphManager.Clipboard.IsEmpty;
            this.miCancel.Click += new EventHandler(MiCancel_Click);
            this.menu = new ContextMenu(new MenuItem[] { this.miPaste, this.miCancel });

            this.tempLayer.Visible = true;
            this.tempLayer.Add(this.tempGraphArrow);
        }

        void MiPaste_Click(object sender, EventArgs e)
        {
            if (this.NewOperation != null)
                this.NewOperation(this, new OperationEventArgs(Operation.Paste));
        }

        void MiCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        #region Methods to implement

        /// <summary>
        /// Mouse entry in the GraphDrawing
        /// </summary>
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
        /// <summary>
        /// Mouse movement over the GraphDrawing
        /// </summary>
        /// <param name="e">Mouse Properties</param>
        public void MouseMove(MouseEventArgs e)
        {
            if (this.initialConnector == null)
            {
                GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
                if (element != null)
                {
                    if (element != this.presentElement)
                    {
                        if (this.presentElement != null)
                        {
                            this.presentElement.DisableConnectors();
                            this.tempLayer.RemoveElement(this.presentElement);
                            this.presentElement = null;
                        }
                        if (element.EnableNextConnectors())
                        {
                            this.presentElement = element;
                            this.tempLayer.Add(this.presentElement);
                            //The cursor is updated to default
                            if ((Cursor.Current != Cursors.Hand) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.Hand));
                        }
                        else
                            //The cursor is updated to default
                            if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.Default));

                        this.tempLayer.UpdateSurface();
                    }
                }
                else if (this.presentElement != null)
                {
                    this.presentElement.DisableConnectors();
                    this.tempLayer.RemoveElement(this.presentElement);
                    this.presentElement = null;
                    this.tempLayer.UpdateSurface();
                    //The cursor is updated to default
                    if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                        this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
                }
            }
            else
            {
                //The initial connector is updated if necessary
                if (!this.initFixed)
                {
                    Connector connector = this.GetConnector(this.initialConnector.Parent, e.Location);
                    if (this.initialConnector != connector)
                    {
                        this.initialConnector = connector;
                        this.initialConnector.Parent.DisableConnectors();
                        this.initialConnector.Parent.EnableConnector(this.initialConnector);
                        if (this.initialConnector.Parent is GraphConditional)
                            this.conditionalOut = ((GraphConditional)this.initialConnector.Parent).GetPredefOut(this.initialConnector);
                    }
                }
                //Looking for the final element
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
                        if (this.initialConnector.Parent == element)
                        {
                            if ((this.initFixed) && (element.EnablePrevConnectors()))
                            {
                                this.presentElement = element;
                                this.tempLayer.Add(this.presentElement);
                            }
                        }
                        else if (element.EnablePrevConnectors())
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
                            connector = this.GetPrevConnector(this.presentElement, e.Location);
                            if (connector != this.presentConnector)
                            {
                                this.presentConnector = connector;
                                this.tempGraphArrow.UpdateArrow(this.initialConnector.AbsCenter, this.presentConnector.AbsCenter);
                            }
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
            }
            this.tempLayer.UpdateSurface();
        }
        /// <summary>
        /// Press one of the mouse buttons (at the moment of pressing)
        /// </summary>
        /// <param name="e">Mouse Properties</param>
        public void MouseDown(MouseEventArgs e)
        {
            //If the initial connector is empty...
            if (this.initialConnector == null)
            {
                //You look for if you clicked on a different element of an arrow or a finish
                GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
                if ((element != null) && !((element is GraphArrow) || (element is GraphFinish)))
                {
                    Connector connector = element.GetConnector(e.Location);
                    if (connector != null)
                    {
                        this.initialConnector = connector;
                        this.initFixed = true;
                    }
                    else
                        this.initialConnector = this.GetConnector(element, e.Location);
                    if (this.initialConnector.Parent is GraphConditional)
                        this.conditionalOut = ((GraphConditional)this.initialConnector.Parent).GetPredefOut(this.initialConnector);
                    element.DisableConnectors();
                    element.EnableConnector(this.initialConnector);

                    this.tempGraphArrow.UpdateArrow(this.initialConnector.AbsCenter, e.Location);
                    this.tempLayer.UpdateSurface();
                }
            }
        }

        private Connector GetConnector(GraphElement element, Point location)
        {
            Connector connector = null;
            double minDistance = -1;
            foreach (Connector enableConnector in element.GetNextConnectors())
            {
                Point p = new Point(location.X - enableConnector.AbsCenter.X, location.Y - enableConnector.AbsCenter.Y);
                double distance = Math.Sqrt((p.X * p.X) + (p.Y * p.Y));
                if ((minDistance == -1) || (minDistance > distance))
                {
                    connector = enableConnector;
                    minDistance = distance;
                }
            }
            return connector;
        }

        private Connector GetPrevConnector(GraphElement element, Point location)
        {
            Connector connector = null;
            double minDistance = -1;
            foreach (Connector enableConnector in element.GetPrevConnectors())
            {
                Point p = new Point(location.X - enableConnector.AbsCenter.X, location.Y - enableConnector.AbsCenter.Y);
                double distance = Math.Sqrt((p.X * p.X) + (p.Y * p.Y));
                if ((minDistance == -1) || (minDistance > distance))
                {
                    connector = enableConnector;
                    minDistance = distance;
                }
            }
            return connector;
        }


        /// <summary>
        /// Press one of the mouse buttons (at the moment of release)
        /// </summary>
        /// <param name="e">Mouse Properties</param>
        public void MouseUp(MouseEventArgs e) 
        {
            if (this.initialConnector != null)
            {
                GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
                if ((element != null) && !(element is GraphArrow))
                    if (this.initialConnector.Parent == element)
                        if (this.initFixed)
                        {
                            Connector connector = element.GetConnector(e.Location);
                            if (this.initialConnector == connector)
                                this.dragMode = false;
                            else if (connector != null)
                            {
                                this.finalConnector = this.presentConnector;
                                this.Do();
                            }
                        }
                        else
                            this.dragMode = false;
                    else if (!(element is GraphStart))
                    {
                        this.finalConnector = this.presentConnector;
                        this.Do();
                    }
            }
        }
        /// <summary>
        /// One-key press event
        /// </summary>
        /// <param name="modifier"></param>
        /// <param name="key"></param>
        public void KeyPress(Keys modifier, Keys key) 
        {
            if (key == Keys.Escape)
                this.Cancel();
        }
        /// <summary>
        /// Execution of the operation
        /// </summary>
        public void Do() 
        {
            GraphElement initialElement = this.initialConnector.Parent;
            GraphElement finalElement = this.finalConnector.Parent;

            graphArrow = new GraphArrow(initialConnector, finalConnector, this.diagramLayer.GetGridPoints());
            if (initialElement is GraphConditional)
            {
                if ((this.conditionalOut == ConditionalOut.True) && (((GraphConditional)initialElement).NextTrue != null))
                    if (DialogResult.Yes == MowayMessageBox.Show(InsertArrowMessages.REPLACE_TRUE + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        this.graphArrowToDelete = (GraphArrow)((GraphConditional)initialElement).NextTrue;
                        GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphArrowToDelete);
                    }
                    else
                    {
                        this.Cancel();
                        return;
                    }
                else if ((this.conditionalOut == ConditionalOut.False) && (((GraphConditional)initialElement).NextFalse != null))
                    if (DialogResult.Yes == MowayMessageBox.Show(InsertArrowMessages.REPLACE_FALSE + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        this.graphArrowToDelete = (GraphArrow)((GraphConditional)initialElement).NextFalse;
                        GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphArrowToDelete);
                    }
                    else
                    {
                        this.Cancel();
                        return;
                    }
                ((GraphConditional)initialElement).AddNext(initialConnector, graphArrow, this.conditionalOut);
            }
            else
            {
                if (initialElement.Next != null)
                    if (DialogResult.Yes == MowayMessageBox.Show(InsertArrowMessages.REPLACE_OUT + InsertArrowMessages.CONTINUE, InsertArrowMessages.INSERT_ARROW, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        this.graphArrowToDelete = (GraphArrow)initialElement.Next;
                        GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphArrowToDelete);
                    }
                    else
                    {
                        this.Cancel();
                        return;
                    }
                initialElement.AddNext(initialConnector, graphArrow);
            }
            finalElement.AddPrevious(finalConnector, graphArrow);
            this.diagramLayer.AddElement(graphArrow);
            //Elements in the context of the operation are deleted
            foreach (GraphElement element in this.tempLayer.Elements)
                element.DisableConnectors();
            this.tempLayer.ClearAndHide();
            this.diagramLayer.UpdateSurface();
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
            if (this.OperationFinished != null)
                this.OperationFinished(this, new OperationEventArgs(Operation.Connect));
        }
        /// <summary>
        /// Cancellation of the operation
        /// </summary>
        public void Cancel() 
        {
            foreach (GraphElement element in this.tempLayer.Elements)
                element.DisableConnectors();
            this.tempLayer.ClearAndHide();
            this.tempLayer.UpdateSurface();
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.Connect));
        }
        /// <summary>
        /// You lose the input focus of the diagram on which the operation is
        /// </summary>
        public void LostFocus()
        {
            this.Cancel();
        }

        public void EnablePaste() {
            this.miPaste.Enabled = true;
        }

        /// <summary>
        /// Undo the operation
        /// </summary>
        public void Undo()
        {
            //The entered arrow is removed
            GraphDiagram.DeleteElement(this.diagramLayer, this.diagram, this.graphArrow);
            //Resets the eliminated arrow in the case that there was
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
            //it is indicated that the diagram has changed
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
        }
        /// <summary>
        /// Redo the operation
        /// </summary>
        public void Redo() { }

        #endregion
    }
}
