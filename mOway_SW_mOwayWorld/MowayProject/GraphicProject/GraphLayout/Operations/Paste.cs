using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Template;
using Moway.Project.GraphicProject.DiagramLayout;
using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Implementation of the paste operation.
    /// </summary>
    /// <LastRevision>01.08.2011</LastRevision>
    /// <Revisor>Jonathan Ruiz de Garibay</Revisor>
    public class Paste : IOperation
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
        /// Contextual menu for the operation
        /// </summary>
        private ContextMenu menu;
        /// <summary>
        /// Offset from source for paste operation
        /// </summary>
        private Point displacement;
        /// <summary>
        /// Previous location for events exiting and entering the workspace
        /// </summary>
        private Point prevLocation = new Point(-1, -1);
        /// <summary>
        /// Saves the initial positions of the items
        /// </summary>
        private Hashtable initLocations = new Hashtable();
        /// <summary>
        /// List of items to paste
        /// </summary>
        private List<GraphElement> graphElements = new List<GraphElement>();

        #endregion

        #region Properties

        /// <summary>
        /// Contextual menu for this operation
        /// </summary>
        public ContextMenu ContextMenu { get { return this.menu; } }
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
        public event EventHandler ElementSelectedChanged { add { } remove { } }


        #endregion

        /// <summary>
        /// Insert Operation Builder
        /// </summary>
        /// <param name="diagram">Logical diagram del GraphDrawing</param>
        /// <param name="diagramLayer">GraphDrawing diagram Layer</param>
        /// <param name="tempLayer">Temporal layer of the GraphDrawing</param>
        /// <param name="element">Elements to insert</param>
        public Paste(Diagram diagram, GraphLayer diagramLayer, GraphLayer tempLayer)
        {
            this.diagram = diagram;
            this.diagramLayer = diagramLayer;
            this.tempLayer = tempLayer;
            this.tempLayer.Visible = true;
            this.displacement = new Point(0, 0);
            //You get the items to paste
            this.graphElements.AddRange(GraphDiagram.CloneElements(GraphManager.Clipboard.GetElements()));
            //Add the item to the temporary layer from the Clipboard
            this.tempLayer.AddElements(this.graphElements);
            foreach (GraphElement element in this.tempLayer.Elements)
                if (!(element is GraphArrow))
                {
                    this.displacement = element.Center;
                    break;
                }
            this.tempLayer.UpdateSurface();
            //The initial positions of the items to be moved are saved
            foreach (GraphElement element in this.tempLayer.Elements)
                this.initLocations.Add(element, new Point(element.Center.X - this.displacement.X, element.Center.Y-displacement.Y));
            MenuItem miCancel = new MenuItem(PasteMessages.CANCEL);
            miCancel.Click += new EventHandler(MiCancel_Click);
            this.menu = new ContextMenu(new MenuItem[] { miCancel });
        }

        #region Contextual Menu Events

        /// <summary>
        /// Canceling the paste operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiCancel_Click(object sender, EventArgs e)
        {
            this.Cancel();
        }

        #endregion

        #region Methods to implement the IOperation interface

        /// <summary>
        /// This method is called when the mouse enters the workspace
        /// </summary>
        public void MouseEnter()
        {
            //The temporary layer is displayed, updated with the MouseMove
            this.tempLayer.Visible = true;
        }

        /// <summary>
        /// This method is called when the mouse exits the workspace
        /// </summary>
        public void MouseLeave()
        {
            //The temporary layer is hidden
            Cursor.Current = Cursors.No;
            this.prevLocation = new Point(-1, -1);
            this.tempLayer.Visible = false;
            this.tempLayer.UpdateSurface();
        }

        /// <summary>
        /// This method is called when the mouse moves into the workspace
        /// </summary>
        /// <param name="e"></param>
        public void MouseMove(MouseEventArgs e)
        {
            //You get the position within the grid (the roundings are for the effect to be better)
            int x = (int)(Math.Round((double)(e.X - 8) / 16) * 16) + 7;
            int y = (int)(Math.Round((double)(e.Y - 9) / 18) * 18) + 8;
            //Only updated if position has changed
            if ((this.prevLocation.X != x) || (this.prevLocation.Y != y))
            {
                this.prevLocation = new Point(x, y);
                //The position is updated
                foreach (GraphElement element in this.tempLayer.Elements)
                    element.Center = new Point(x + ((Point)this.initLocations[element]).X, y+((Point)this.initLocations[element]).Y);
                //It checks if the position is valid to make an insertion and the cursor is updated
                if (this.ValidateLocation())
                    Cursor.Current = Cursors.SizeAll;
                else
                    Cursor.Current = Cursors.No;
                //The temporal layer is updated
                this.tempLayer.UpdateSurface();
            }
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
            //If the button pressed is the left
            if (e.Button == MouseButtons.Left)
            {
                //You get the position within the grid (the roundings are for the effect to be better)
                int x = (int)(Math.Round((double)(e.X - 8) / 16) * 16) + 7;
                int y = (int)(Math.Round((double)(e.Y - 9) / 18) * 18) + 8;
                //Only updated if position has changed
                if ((this.prevLocation.X != x) || (this.prevLocation.Y != y))
                {
                    //The position is updated
                    foreach (GraphElement element in this.tempLayer.Elements)
                        element.Center = new Point(x + ((Point)this.initLocations[element]).X, y + ((Point)this.initLocations[element]).Y);
                }
                this.Do();
            }
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
                this.Cancel();
        }

        /// <summary>
        /// This method executes the paste operation once the paste position is set
        /// </summary>
        public void Do()
        {
            //If the operation is not precanceled and the mouse is within the workspace (when the temporary layer is visible)
            if (this.tempLayer.Visible)
            {
                //It is checked if the position is valid for insertion
                if (this.ValidateLocation())
                {
                    foreach (GraphElement element in this.tempLayer.Elements)
                    {
                        //The GraphElement is added to the diagram layer, and to the logical diagram
                        this.diagramLayer.AddElement(element);
                        this.diagram.AddElement(element.Element);
                    }
                    //The temporary layer is cleaned and hidden
                    this.tempLayer.ClearAndHide();
                    //The diagram layer is updated
                    this.diagramLayer.UpdateSurface();
                    if (this.DiagramChanged != null)
                        this.DiagramChanged(this, new EventArgs());
                    //The operation is terminated
                    if (this.OperationFinished != null)
                        this.OperationFinished(this, new OperationEventArgs(Operation.Paste));
                }
                else
                {
                    if (GraphSettings.Default.InsertWarning == true)
                    {
                        bool showAgain = true;
                        MowayMessageBox.Show(PasteMessages.PASTE_WARNING, PasteMessages.PASTE, MessageBoxButtons.OK, MessageBoxIcon.Error, ref showAgain);
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
            //The temporary layer is cleaned and hidden
            this.tempLayer.ClearAndHide();
            //The diagram layer is updated
            this.diagramLayer.UpdateSurface();
            //The cursor is updated
            Cursor.Current = Cursors.Default;
            //The operation is cancelled
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.Paste));
        }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus()
        {
            this.Cancel();
        }

        /// <summary>
        /// This method is called when the paste operation is enabled (for the context menu)
        /// </summary>
        public void EnablePaste() { }

        /// <summary>
        /// This method undos the operation
        /// </summary>
        public void Undo()
        {
            //se eliminan los GraphElements de la capa de diagrama y del Logical diagram
            GraphDiagram.DeleteElements(this.diagramLayer, this.diagram, this.graphElements);
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

        #region Private methods

        /// <summary>
        /// Validates the location of the GraphElement in the diagram layer
        /// </summary>
        /// <returns></returns>
        private bool ValidateLocation()
        {
            foreach (GraphElement graphElement in this.diagramLayer.Elements)
                if (this.tempLayer.IntersectsWith(graphElement))
                    return false;
            foreach (GraphElement graphElement in this.tempLayer.Elements)
                if ((graphElement.Left <= 0) || (graphElement.Right >= this.diagramLayer.Surface.Width) || (graphElement.Top <= 0) || (graphElement.Bottom >= this.diagramLayer.Surface.Height))
                    return false;
            return true;
        }

        #endregion
    }
}