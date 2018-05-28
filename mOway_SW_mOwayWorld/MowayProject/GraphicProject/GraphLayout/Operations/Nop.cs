using System;
using System.Drawing;
using System.Windows.Forms;

using Moway.Project.GraphicProject.Actions.Start;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Operation Non-operation implementation
    /// </summary>
    /// <LastRevision>01.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Nop : IOperation
    {
        #region Attributes

        /// <summary>
        /// GrapgDrawing diagram Layer
        /// </summary>
        private GraphLayer diagramLayer;
        /// <summary>
        /// Temporal layer of the GraphDrawing
        /// </summary>
        private GraphLayer tempLayer;
        /// <summary>
        /// Contextual menu for the operation
        /// </summary>
        private ContextMenu menu;
        /// <summary>
        /// Item for the context menu for the paste operation
        /// </summary>
        MenuItem miPaste = new MenuItem(NopMessages.PASTE);
        /// <summary>
        /// Stores the position about the MouseButtonDown event has run
        /// </summary>
        private Point downInitialPoint;

        #endregion

        #region Properties

        /// <summary>
        /// Contextual menu for the operation
        /// </summary>
        public ContextMenu ContextMenu { get { return this.menu; } }
        /// <summary>
        /// Initial Cursor for this operation
        /// </summary>
        public Cursor InitCursor { get { return Cursors.Default; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return this.downInitialPoint; } }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the diagram changes
        /// </summary>
        public event EventHandler DiagramChanged { add { } remove { } }
        /// <summary>
        /// Occurs when the cursor changes
        /// </summary>
        public event CursorEventHandler CursorChanged;
        /// <summary>
        /// Occurs when the insert operation ends
        /// </summary>
        public event OperationEventHandler OperationFinished { add { } remove { } }
        /// <summary>
        /// Occurs when the insert operation is cancelled
        /// </summary>
        public event OperationEventHandler OperationCanceled { add { } remove { } }
        /// <summary>
        /// Occurs when the execution of a new operation is launched (for the context menu)
        /// </summary>
        public event OperationEventHandler NewOperation;
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
        /// Builder for the operation do nothing "Nop"
        /// </summary>
        /// <param name="diagramLayer">Diagram of the GraphDrawing layer</param>
        /// <param name="tempLayer">Temporal layer of the GraphDrawing</param>
        public Nop(GraphLayer diagramLayer, GraphLayer tempLayer)
        {
            this.diagramLayer = diagramLayer;
            this.tempLayer = tempLayer;
            try
            {
                this.miPaste.Enabled = !GraphManager.Clipboard.IsEmpty;
            }
            catch
            {
                this.miPaste.Enabled = false;
            }
            this.miPaste.Click += new EventHandler(MiPaste_Click);
            this.menu = new ContextMenu(new MenuItem[] { miPaste });
        }

        #region ContextMenu Events

        /// <summary>
        /// Launches the paste operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiPaste_Click(object sender, EventArgs e)
        {
            if (this.NewOperation != null)
                this.NewOperation(this, new OperationEventArgs(Operation.Paste));
        }

        #endregion

        #region Methods to implement the IOperation interface

        /// <summary>
        /// This method is called when the mouse enters the workspace
        /// </summary>
        public void MouseEnter() { }

        /// <summary>
        /// This method is called when the mouse exits the workspace
        /// </summary>
        public void MouseLeave()
        {
            //If there is any element in the temporal layer, it removes
            if (this.tempLayer.Elements.Count != 0)
            {
                this.ClearOperationContext();
                //The temporary layer is updated
                this.tempLayer.UpdateSurface();
            }
        }

        /// <summary>
        /// This method is called when the mouse moves into the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseMove(MouseEventArgs e)
        {
            if (this.tempLayer.Elements.Count != 0)
                if (this.tempLayer.Elements[0].IntersectsWith(e.Location))
                {
                    if (this.tempLayer.Elements[0] is GraphArrow)
                    {
                        ArrowModifier modifier = ((GraphArrow)this.tempLayer.Elements[0]).GetModifier(e.Location);
                        if (modifier is ConnectorModifier)
                        {
                            if ((Cursor.Current != Cursors.Hand) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.Hand));
                        }
                        else if (modifier is HorizontalModifier)
                        {
                            if ((Cursor.Current != Cursors.HSplit) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.HSplit));
                        }
                        else if (modifier is VerticalModifier)
                        {
                            if ((Cursor.Current != Cursors.VSplit) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.VSplit));
                        }
                        else
                        {
                            if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
                        }
                    }
                    else
                        if (this.tempLayer.Elements[0].IntersectsWithConnector(e.Location))
                        {
                            if ((Cursor.Current != Cursors.Hand) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.Hand));
                        }
                        else
                            if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                                this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
                    return;
                }
            //Looking for an item in the given position
            GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
            //If no items are found the operation is cancelled
            if (element == null)
            {
                //If there is any element in the temporal layer, it removes
                if (this.tempLayer.Elements.Count != 0)
                {
                    this.ClearOperationContext();
                    //The temporary layer is updated
                    this.tempLayer.UpdateSurface();
                    //The cursor is updated a default
                    if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                        this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
                }
                //If the left button is pressed, the zone selection operation starts
                if (e.Button == MouseButtons.Left)
                    throw new OperationException(Operation.Nop, "Change to SelectZone Operation");
            }
            else
            {
                if (this.tempLayer.Elements.Count == 0)
                    this.tempLayer.Visible = true;
                else
                {
                    //The temporary layer is cleaned
                    if (this.tempLayer.Elements[0] is GraphArrow)
                        //The arrow modifiers are disabled
                        ((GraphArrow)this.tempLayer.Elements[0]).DisableModifiers();
                    else
                        //Disables connectors
                        ((GraphElement)this.tempLayer.Elements[0]).DisableConnectors();
                    //Removes the element from the temporary layer
                    this.tempLayer.RemoveElement((GraphElement)this.tempLayer.Elements[0]);
                }
                if (element is GraphArrow)
                {
                    ((GraphArrow)element).EnableModifiers();
                    //Added to the temporary layer
                    this.tempLayer.AddElement(element);
                    this.tempLayer.UpdateSurface();
                    //Updates to the corresponding cursor
                    if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                        this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
                }
                else
                {
                    //The following connectors are enabled
                    if (element.EnableNextConnectors())
                    {
                        //Added to the temporary layer
                        this.tempLayer.AddElement(element);
                        this.tempLayer.UpdateSurface();
                        //Updates to the corresponding cursor
                        if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                            this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
                    }
                    else
                    {
                        this.tempLayer.ClearAndHide();
                        this.tempLayer.UpdateSurface();
                    }
                }
            }
        }

        /// <summary>
        /// This method is calling when you press any mouse button within the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseDown(MouseEventArgs e)
        {
            GraphElement element;
            //Looking for an item in the given position
            if ((this.tempLayer.Elements.Count != 0) && (this.tempLayer.Elements[0].IntersectsWith(e.Location)))
                element = this.tempLayer.Elements[0];
            else
                element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
            //Position is saved for future operations
            this.downInitialPoint = e.Location;
            //If an item exists, the mouse button is checked for a change of operation
            if (element != null)
            {
                //If the button pressed is the left...
                if (e.Button == MouseButtons.Left)
                    //If the press is on an arrow
                    if ((element is GraphArrow) && (this.tempLayer.Elements.Count == 1))
                    {
                            ArrowModifier modifier = ((GraphArrow)this.tempLayer.Elements[0]).GetModifier(e.Location);
                            if (modifier == null)
                            {
                                this.ClearOperationContext();
                                throw new OperationException(Operation.Nop, "Change to Select Operation");
                            }
                            else if (modifier is ConnectorModifier)
                                throw new OperationException(Operation.Nop, "Change to Reconnect Operation");
                            //If the press is on the element, it is passed to the selection operation
                            else
                                throw new OperationException(Operation.Nop, "Change to ModifyArrow Operation");
                    }
                    //If the pulsation is over a connector is passed to the arrow insert operation
                    else
                        if (element.IntersectsWithConnector(e.Location))
                            throw new OperationException(Operation.Nop, "Change to InsertArrow Operation");
                    //If the press is on the element, it is passed to the selection operation
                    else
                    {
                            this.ClearOperationContext();
                            throw new OperationException(Operation.Nop, "Change to Select Operation");
                        }
                //If the button pressed is the left one, it is passed to the selection operation
                else if (e.Button == MouseButtons.Right)
                {
                    this.ClearOperationContext();
                    throw new OperationException(Operation.Nop, "Change to Select Operation");
                }
            }
        }

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
        /// This operation does not run anything by itself
        /// </summary>
        public void Do() { }

        /// <summary>
        /// Cancels operation execution
        /// </summary>
        public void Cancel() { }

        /// <summary>
        /// This method is called when the paste operation is enabled (for the context menu)
        /// </summary>
        public void EnablePaste()
        {
            this.miPaste.Enabled = true;
        }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus()
        {
            if (this.tempLayer.Elements.Count != 0)
            {
                this.tempLayer.ClearAndHide();
                this.tempLayer.UpdateSurface();
            }
        }

        /// <summary>
        /// This method undos the operation
        /// </summary>
        public void Undo() { }

        /// <summary>
        /// This method redoes the previously undone operation
        /// </summary>
        public void Redo() { }

        #endregion

        #region Private methods

        /// <summary>
        /// Cleans the context of this operation
        /// </summary>
        private void ClearOperationContext()
        {
            //Removes elements from the temporary layer (removing the connectors)
            if (this.tempLayer.Elements.Count == 1)
            {
                if (this.tempLayer.Elements[0] is GraphArrow)
                    ((GraphArrow)this.tempLayer.Elements[0]).DisableModifiers();
                else
                    //Disables connectors
                    ((GraphElement)this.tempLayer.Elements[0]).DisableConnectors();
                //Removes the element from the temporary layer
                this.tempLayer.RemoveElement((GraphElement)this.tempLayer.Elements[0]);
            }
            //Hides the temporary layer
            this.tempLayer.Visible = false;
        }

        #endregion
    }
}
