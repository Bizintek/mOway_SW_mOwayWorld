using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Implements the item selection operation (multiple selection is performed with the CONTROL key)
    /// </summary>
    /// <author>Jonathan Ruiz de Garibay</author>
    /// <version>3.0.0</version>
    /// <data>03/01/2011</data>
    public class Select : IOperation
    {
        #region Attributes

        /// <summary>
        /// Diagram of the GraphDrawing layer
        /// </summary>
        private GraphLayer diagramLayer;
        /// <summary>
        /// GraphDrawing selection Layer
        /// </summary>
        private GraphLayer selectLayer;
        /// <summary>
        /// Contextual menu for the operation
        /// </summary>
        private ContextMenu menu;
        /// <summary>
        /// Item for Contextual menu for the operation of Copy
        /// </summary>
        private MenuItem miCopy = new MenuItem(SelectMessages.COPY);
        /// <summary>
        /// Item for Contextual menu for the operation of Cut
        /// </summary>
        private MenuItem miCut = new MenuItem(SelectMessages.CUT);
        /// <summary>
        /// Item for Contextual menu for the operation of Paste
        /// </summary>
        private MenuItem miPaste = new MenuItem(SelectMessages.PASTE);
        /// <summary>
        /// Item for Contextual menu for the operation of Delete
        /// </summary>
        private MenuItem miRemove = new MenuItem(SelectMessages.DELETE);
        /// <summary>
        /// Item for Contextual menu for the operation to watch the properties.
        /// </summary>
        private MenuItem miSettings = new MenuItem(SelectMessages.SETTINGS);
        /// <summary>
        /// Stores the position about the MouseButtonDown event has run (necessary for a possible drag & drop)
        /// </summary>
        private Point downInitialpoint;

        #endregion

        #region Properties

        /// <summary>
        /// Contextual menu for the operation
        /// </summary>
        public ContextMenu ContextMenu { get { return this.menu; } }
        /// <summary>
        /// Initial Cursor for this operation
        /// </summary>
        public Cursor InitCursor { get { return Cursors.Hand; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return this.downInitialpoint; } }

        #endregion

        #region Events

        public event EventHandler DiagramChanged { add { } remove { } }
        /// <summary>
        /// Event for cursor change
        /// </summary>
        public event CursorEventHandler CursorChanged;
        /// <summary>
        /// Event of operation completed
        /// </summary>
        public event OperationEventHandler OperationFinished { add { } remove { } }
        /// <summary>
        /// Event of operation cancelled
        /// </summary>
        public event OperationEventHandler OperationCanceled;
        /// <summary>
        /// Event of operation cancelledLaunches the execution of a new operation (for the context menu)
        /// </summary>
        public event OperationEventHandler NewOperation;
        /// <summary>
        /// Enables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationEnabled { add { } remove { } }
        /// <summary>
        /// DesEnables an operation to be performed on the GraphDrawing
        /// </summary>
        public event OperationEventHandler OperationDisabled;
        /// <summary>
        /// Occurs when the selection of items in the diagram changes
        /// </summary>
        public event EventHandler ElementSelectedChanged;

        #endregion

        /// <summary>
        /// Builder for the Select operation
        /// </summary>
        /// <param name="diagramLayer">Diagram of the GraphDrawing layer</param>
        /// <param name="tempLayer">Temporal layer of the GraphDrawing</param>
        public Select(GraphLayer diagramLayer, GraphLayer selectLayer)
        {
            this.diagramLayer = diagramLayer;
            this.selectLayer = selectLayer;
            this.selectLayer.Visible = true;
            miSettings.Click += new EventHandler(MiShowProperties_Click);
            miCopy.Click += new EventHandler(MiCopy_Click);
            miCut.Click += new EventHandler(MiCut_Click);
            miPaste.Enabled = !GraphManager.Clipboard.IsEmpty;
            miPaste.Click += new EventHandler(MiPaste_Click);
            miRemove.Click += new EventHandler(MiRemove_Click);
            this.menu = new ContextMenu(new MenuItem[] { miSettings, new MenuItem("-"), miCopy, miCut, miPaste, miRemove });
            this.menu.Popup += new EventHandler(Menu_Popup);
        }

        #region ContextMenu Events

        /// <summary>
        /// Occurs when the context menu is opened: Selects the item if it is not in that state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Menu_Popup(object sender, EventArgs e)
        {
            GraphElement element = GraphDiagram.GetElement(this.diagramLayer, this.downInitialpoint);
            //You look at the selected state of the item
            if (!element.Selected)
            {
                //If the CONTROL key is not pressed the other elements are deselected
                if (Control.ModifierKeys != Keys.Control)
                    DeselectAll();
                SelectElement(element);
                //The temporary layer is updated
                this.selectLayer.UpdateSurface();
            }
        }

        void MiShowProperties_Click(object sender, EventArgs e)
        {
            //Shows the properties of an action
            if (this.NewOperation != null)
                this.NewOperation(this, new OperationEventArgs(Operation.Settings));
        }

        void MiCopy_Click(object sender, EventArgs e)
        {
            //Changes to the copy operation
            if (this.NewOperation != null)
                this.NewOperation(this, new OperationEventArgs(Operation.Copy));
        }

        void MiCut_Click(object sender, EventArgs e)
        {
            //Changes to the cut operation
            if (this.NewOperation != null)
                this.NewOperation(this, new OperationEventArgs(Operation.Cut));
        }

        void MiPaste_Click(object sender, EventArgs e)
        {
            //Changes to the paste operation
            if (this.NewOperation != null)
                this.NewOperation(this, new OperationEventArgs(Operation.Paste));
        }

        void MiRemove_Click(object sender, EventArgs e)
        {
            //Changes to the remove operation
            if (this.NewOperation != null)
                this.NewOperation(this, new OperationEventArgs(Operation.Delete));
        }

        #endregion

        #region Methods to implement the IOperation interface

        public void MouseEnter() { }

        public void MouseLeave() { }

        public void MouseMove(MouseEventArgs e)
        {
            GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
            //If you are right-clicking and no item found, you switch to Operation Nop
            if ((e.Button == MouseButtons.Right) && (element == null))
            {
                //The context of the Select operation is cleaned
                this.ClearOperationContext();
                throw new OperationException(Operation.Select, "Change to Nop operation");
            }
            //If you are pressing the left button, the selection is checked and Drag & Drop operation starts
            else if (e.Button == MouseButtons.Left)
            {
                if (element == null)
                    element = GraphDiagram.GetElement(this.diagramLayer, this.downInitialpoint);
                //If the item is not selected, it is selected before the drag & Drop operation is started
                if (!element.Selected)
                {
                    //If the CONTROL key is not pressed the other elements are deselected
                    if (Control.ModifierKeys != Keys.Control)
                        DeselectAll();
                    SelectElement(element);
                    //The temporary layer is updated
                    this.selectLayer.UpdateSurface();
                    if (this.ElementSelectedChanged != null)
                        this.ElementSelectedChanged(this, new EventArgs());
                }
                throw new OperationException(Operation.Select, "Change to Drag&Drop operation");
            }
            //The mouse cursor is updated as appropriate
            else
            {
                if (element == null)
                {
                    if ((Cursor.Current != Cursors.Hand) && (this.CursorChanged != null))
                        this.CursorChanged(this, new CursorEventArgs(Cursors.Hand));
                }
                else
                    if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                        this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
            }
        }

        public void MouseDown(MouseEventArgs e)
        {
            //This is for the right and left mouse buttons
            if ((e.Button == MouseButtons.Left) || (e.Button == MouseButtons.Right))
            {
                //The position of the Down event is saved for possible new operations
                this.downInitialpoint = e.Location;
                GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
                //If it is not pressed on any element, it is changed to the Nop operation
                if (element == null)
                {
                    //The context of the Select operation is cleaned
                    this.ClearOperationContext();
                    throw new OperationException(Operation.Select, "Change to Nop Operation");
                }
            }
        }

        public void MouseUp(MouseEventArgs e)
        {
            //Only checks for left mouse button
            if (e.Button == MouseButtons.Left)
            {
                //Looking for the affected element
                GraphElement element = GraphDiagram.GetElement(this.diagramLayer, e.Location);
                //If there is none, it is changed to Operation Nop
                if (element == null)
                {
                    //The context of the Select operation is cleaned
                    this.ClearOperationContext();
                    throw new OperationException(Operation.Select, "Change to Nop Operation");
                }
                else
                {
                    //If you are pressing the CONTROL key, a multiple selection is being made
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        //If the item is selected, it is deselected
                        if (element.Selected)
                        {
                            DeselectElement(element);
                            //If there is no item selected, it changes to the NOP operation
                            if (this.selectLayer.Elements.Count == 0)
                            {
                                //The context of the Select operation is cleaned
                                this.ClearOperationContext();
                                throw new OperationException(Operation.Select, "Change to Nop Operation");
                            }
                        }
                        //without, it selects
                        else
                            this.SelectElement(element);
                        this.selectLayer.UpdateSurface();
                        if (this.ElementSelectedChanged != null)
                            this.ElementSelectedChanged(this, new EventArgs());
                    }
                    //If the item is not selected, the others are deselected and the current is selected
                    else if (!element.Selected)
                    {
                        this.DeselectAll();
                        this.SelectElement(element);
                        //The temporary layer is updated
                        this.selectLayer.UpdateSurface();
                        if (this.ElementSelectedChanged != null)
                            this.ElementSelectedChanged(this, new EventArgs());
                    }
                }
            }
        }

        public void KeyPress(Keys modifier, Keys key)
        {
            if ((modifier == Keys.None) && (key == Keys.Escape))
                this.Cancel();
        }

        public void Do() { }

        public void Cancel()
        {
            this.ClearOperationContext();
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.Select));
        }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus() { }

        public void EnablePaste()
        {
            this.miPaste.Enabled = true;
        }

        public void Undo() { }

        public void Redo() { }

        #endregion

        #region Private methods

        /// <summary>
        /// Cleans the entire context of the operation before moving to a Nop
        /// </summary>
        private void ClearOperationContext()
        {
            //The items you have selected are deselected
            foreach (GraphElement selectedElement in this.selectLayer.Elements)
                selectedElement.Selected = false;
            //The temporary layer is cleaned, hidden and updated
            this.selectLayer.Clear();
            this.selectLayer.Visible = false;
            this.selectLayer.UpdateSurface();
            //The status of the affected operations is updated
            if (this.OperationDisabled != null)
            {
                this.OperationDisabled(this, new OperationEventArgs(Operation.Copy));
                this.OperationDisabled(this, new OperationEventArgs(Operation.Cut));
                this.OperationDisabled(this, new OperationEventArgs(Operation.Delete));
                this.OperationDisabled(this, new OperationEventArgs(Operation.Settings));
            }
            if (this.ElementSelectedChanged != null)
                this.ElementSelectedChanged(this, new EventArgs());
        }

        /// <summary>
        /// Selects the item sent as a parameter
        /// </summary>
        /// <param name="element">Item to select</param>
        private void SelectElement(GraphElement element)
        {
            //The item is selected
            element.Selected = true;
            //The element is loaded into the temporary layer
            this.selectLayer.AddElement(element);
            if (GraphDiagram.ValidateCopy(this.selectLayer.Elements))
            {
                this.miCopy.Enabled = true;
                this.miCut.Enabled = true;
            }
            else
            {
                if (this.OperationDisabled != null)
                {
                    this.OperationDisabled(this, new OperationEventArgs(Operation.Copy));
                    this.OperationDisabled(this, new OperationEventArgs(Operation.Cut));
                }
                this.miCopy.Enabled = false;
                this.miCut.Enabled = false;
            }
            if (GraphDiagram.ValidateDelete(this.selectLayer.Elements))
            {
                this.miRemove.Enabled = true;
            }
            else
            {
                if (this.OperationDisabled != null)
                    this.OperationDisabled(this, new OperationEventArgs(Operation.Delete));
                this.miRemove.Enabled = false;
            }
            if (GraphDiagram.ValidateSettings(this.selectLayer.Elements))
            {
                this.miSettings.Enabled = true;
            }
            else
            {
                if (this.OperationDisabled != null)
                    this.OperationDisabled(this, new OperationEventArgs(Operation.Settings));
                this.miSettings.Enabled = false;
            }
        }

        /// <summary>
        /// Deselects the item sent as a parameter
        /// </summary>
        /// <param name="element">Item to deselect</param>
        private void DeselectElement(GraphElement element)
        {
            //The item is deselected
            element.Selected = false;
            //Removed from the temporary layer
            this.selectLayer.RemoveElement(element);
            //If there is no element in the temporal layer...
        }

        /// <summary>
        /// Deselect all items
        /// </summary>
        private void DeselectAll()
        {
            //The rest of the items you have selected are deselected
            foreach (GraphElement selectedElement in this.selectLayer.Elements)
                selectedElement.Selected = false;
            //All elements of the temporary layer are cleared
            this.selectLayer.Clear();
        }

        #endregion
    }
}
