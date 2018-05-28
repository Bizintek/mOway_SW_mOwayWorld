using System;
using System.Drawing;
using System.Windows.Forms;

using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Graphics.Sprites;

using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    /// <summary>
    /// Selection operation through a selection box. It selects everything that does 
    /// intersection with the box (it does not necessarily have to be completely contained).    /// 
    /// </summary>
    public class SelectRectangle : IOperation
    {
        #region Attributes

        /// <summary>
        /// GarphDrawing diagram Layer
        /// </summary>
        private GraphLayer diagramLayer;
        /// <summary>
        /// GarphDrawing selection Layer
        /// </summary>
        private GraphLayer selectLayer;
        /// <summary>
        /// Temporal layer of the GarphDrawing
        /// </summary>
        private GraphLayer tempLayer;
        /// <summary>
        /// Initial position of the selection box (where the operation was started)
        /// </summary>
        private Point initialPoint;
        /// <summary>
        /// Graphic selection box for the operation
        /// </summary>
        private SelectionRectangle selectionRectangle = null;

        #endregion

        #region Properties

        /// <summary>
        /// Contextual menu for the operation (in this case it doesn't has)
        /// </summary>
        public ContextMenu ContextMenu { get { return null; } }
        public Cursor InitCursor { get { return Cursors.Default; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events

        public event EventHandler DiagramChanged { add { } remove { } }
        /// <summary>
        /// Event for cursor change
        /// </summary>
        public event CursorEventHandler CursorChanged { add { } remove { } }
        /// <summary>
        /// Event of operation completed
        /// </summary>
        public event OperationEventHandler OperationFinished { add { } remove { } }
        /// <summary>
        /// Event of operation cancelled
        /// </summary>
        public event OperationEventHandler OperationCanceled { add { } remove { } }
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
        public event OperationEventHandler OperationDisabled;
        /// <summary>
        /// Occurs when the selection of items in the diagram changes
        /// </summary>
        public event EventHandler ElementSelectedChanged;

        #endregion

        /// <summary>
        /// Builder for zone selection operation
        /// </summary>
        /// <param name="diagramLayer">Layer of the Diagram of the GraphDrawing</param>
        /// <param name="tempLayer">Temporal layer of the GraphDrawing</param>
        /// <param name="initialPoint">Initial position where the operation was started</param>
        public SelectRectangle(GraphLayer diagramLayer, GraphLayer selectLayer, GraphLayer tempLayer, Point initMouseLocation)
        {
            this.diagramLayer = diagramLayer;
            this.selectLayer = selectLayer;
            this.selectLayer.Visible = true;
            this.tempLayer = tempLayer;
            //Indicates that the temporary layer is visible but not updated (will be updated in the first MouseMove)
            this.tempLayer.Visible = true;
            this.initialPoint = initMouseLocation;
            //The graphic selection rectangle is created and loaded to the temporary layer
            this.selectionRectangle = new SelectionRectangle();
            this.tempLayer.Add(this.selectionRectangle);
        }

        #region Methods to implement the IOperation interface

        public void MouseEnter() { }

        public void MouseLeave() { }

        public void MouseMove(MouseEventArgs e)
        {
            //You get the upper left point of the selection box and the size 
            Point location = new Point(Math.Min(this.initialPoint.X, e.X), Math.Min(this.initialPoint.Y, e.Y));
            Size size = new Size(Math.Abs(e.X - this.initialPoint.X), Math.Abs(e.Y - this.initialPoint.Y));
            //A Rectangle object is created that contains the two informations
            Rectangle rectangle = new Rectangle(location, size);

            //It selects the items into the selection box and it gets the size and position of that box
            this.SelectElements(rectangle);
            //The selection box is updated
            this.selectionRectangle.UpdateRectangle(rectangle);
            //The temporary layer is updated
            this.tempLayer.UpdateSurface();
        }

        public void MouseDown(MouseEventArgs e) { }

        public void MouseUp(MouseEventArgs e)
        {
            //When the left mouse button is released...
            if (e.Button == MouseButtons.Left)
            {
                //You get the upper left point of the selection box and the size
                Point location = new Point(Math.Min(this.initialPoint.X, e.X), Math.Min(this.initialPoint.Y, e.Y));
                Size size = new Size(Math.Abs(e.X - this.initialPoint.X), Math.Abs(e.Y - this.initialPoint.Y));
                //A Rectangle object is created that contains the two informations
                Rectangle rectangle = new Rectangle(location, size);

                //The items inside the selection box are selected
                this.SelectElements(rectangle);
                //The chart selection box is deleted
                this.tempLayer.ClearAndHide();
                this.selectionRectangle.Dispose();
                //The temporary layer is updated
                this.tempLayer.UpdateSurface();
                if (GraphDiagram.ValidateCopy(this.selectLayer.Elements))
                {
                }
                else
                {
                    if (this.OperationDisabled != null)
                    {
                        this.OperationDisabled(this, new OperationEventArgs(Operation.Copy));
                        this.OperationDisabled(this, new OperationEventArgs(Operation.Cut));
                    }
                }
                if (GraphDiagram.ValidateDelete(this.selectLayer.Elements))
                {
                }
                else
                {
                    if (this.OperationDisabled != null)
                        this.OperationDisabled(this, new OperationEventArgs(Operation.Delete));
                }
                if (GraphDiagram.ValidateSettings(this.selectLayer.Elements))
                {
                }
                else
                {
                    if (this.OperationDisabled != null)
                        this.OperationDisabled(this, new OperationEventArgs(Operation.Settings));
                }
                //Exception is thrown for change of operation depending on whether there are selected items
                if (this.selectLayer.Elements.Count == 0)
                {
                    this.selectLayer.Visible = false;
                    throw new OperationException(Operation.SelectRectangle, "Change to Nop Operation");
                }
                else
                {
                    if (this.ElementSelectedChanged != null)
                        this.ElementSelectedChanged(this, new EventArgs());
                    throw new OperationException(Operation.SelectRectangle, "Change to Select Operation");
                }
            }
        }

        public void KeyPress(Keys modifier, Keys key) { }

        public void Do() { }

        public void Cancel() { }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus() { }

        public void EnablePaste() { }

        public void Undo() { }

        public void Redo() { }

        #endregion

        #region Private methods

        /// <summary>
        /// Selects the items contained within a selection box
        /// </summary>
        /// <param name="finalPoint">End point of the selection box</param>
        /// <returns>Size and position of the selection box</returns>
        private void SelectElements(Rectangle rectangle)
        {
            bool elementsChange = false;
            //Select and/or deselect those items that are inside/outside the rectangle
            foreach (GraphElement element in this.diagramLayer.Elements)
            {
                //If the intersects element with the selection box...
                if (element.ContainsIn(rectangle))
                    {
                    //If the item is not selected... (in the temporary layer are selected)
                    if (!this.selectLayer.Elements.Contains(element))
                    {
                        elementsChange = true;
                        //The item is selected
                        element.Selected = true;
                        //The element is loaded into the temporary layer
                        this.selectLayer.AddElement(element);
                    }
                }
                else
                    //If you do not intersects and are selected...
                    if (this.selectLayer.Elements.Contains(element))
                    {
                        elementsChange = true;
                        //The item is deselected
                        element.Selected = false;
                        //The element is removed in the temporary layer
                        this.selectLayer.RemoveElement(element);
                    }
            }
            if (elementsChange)
                this.selectLayer.UpdateSurface();
        }
       
        #endregion
    }

    /// <summary>
    /// It is a specific sprite that represents the graphic selection box
    /// </summary>
    public class SelectionRectangle : Sprite
    {
        /// <summary>
        /// Updates the position, size, and image of the selection box
        /// </summary>
        /// <param name="rectangle">Position and size of the selection box</param>
        public void UpdateRectangle(Rectangle rectangle)
        {
            this.Position = rectangle.Location;
            //The surface is created
            this.Surface = new Surface(rectangle.Size);
            this.Surface.Fill(GraphDiagram.TRASPARENT_COLOR);
            this.Surface.Draw(new Box(new Point(0, 0), new Size(rectangle.Width - 1, rectangle.Height - 1)), GraphDiagram.SELECTED_COLOR);
            //The color of transparency is indicated
            this.Transparent = true;
            this.TransparentColor = GraphDiagram.TRASPARENT_COLOR;
        }
    }
}
