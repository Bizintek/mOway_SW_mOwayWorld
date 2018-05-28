using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class DragDrop : IOperation
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
        /// Temporal layer of the GraphDrawing
        /// </summary>
        private GraphLayer tempLayer;
        /// <summary>
        /// Initial mouse position
        /// </summary>
        private Point initMouseLocation;
        /// <summary>
        /// Saves the initial positions of the items
        /// </summary>
        private Hashtable initLocations = new Hashtable();
        /// <summary>
        /// Indicates whether the operation has been precanceled
        /// </summary>
        private bool opPrecanceled = false;
        /// <summary>
        /// Arrow List affected for Undo
        /// </summary>
        private Hashtable externalArrows = new Hashtable();

        #endregion

        #region Properties

        /// <summary>
        /// Contextual menu for this operation
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

        public event EventHandler DiagramChanged;
        /// <summary>
        /// Event for cursor change
        /// </summary>
        public event CursorEventHandler CursorChanged;
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

        public DragDrop(GraphLayer diagramLayer, GraphLayer selectLayer, GraphLayer tempLayer, Point initMouseLocation)
        {
            this.diagramLayer = diagramLayer;
            this.selectLayer = selectLayer; //The selection layer is already visible
            this.tempLayer = tempLayer;     //Temporary layer passes to visible but not yet updated
            this.tempLayer.Visible = true;
            this.initMouseLocation = initMouseLocation;
            //Includes all those elements affected by the drag & drop in the temporal layer (the selected and the interspersed arrows)
            this.LoadTempLayer();

            //The initial positions of the items to be moved are saved
            foreach (GraphElement element in this.tempLayer.Elements)
                this.initLocations.Add(element, element.Center);
        }

        #region Methods to implement the IOperation interface

        public void MouseEnter() { }

        public void MouseLeave() { }

        public void MouseMove(MouseEventArgs e)
        {
            if (!this.opPrecanceled)
            {
                this.RelocateElements(e.Location);
                this.tempLayer.UpdateSurface();
                if (this.ValidateLocation())
                {
                    //The cursor is updated
                    if ((Cursor.Current != Cursors.SizeAll) && (this.CursorChanged != null))
                        this.CursorChanged(this, new CursorEventArgs(Cursors.SizeAll));
                }
                else
                {
                    //The cursor is updated to indicate to the user that the position is invalid
                    if ((Cursor.Current != Cursors.No) && (this.CursorChanged != null))
                        this.CursorChanged(this, new CursorEventArgs(Cursors.No));
                }
            }
        }

        public void MouseDown(MouseEventArgs e) { }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((this.opPrecanceled) || (!this.ValidateLocation()))
                    this.Cancel();
                else
                {
                    this.RelocateElements(e.Location);
                    this.Do();
                }
            }
        }

        public void KeyPress(Keys modifier, Keys key)
        {
            if ((modifier == Keys.None) && (key == Keys.Escape))
                this.PreCancel();
        }

        public void Do()
        {
            //All arrows updated
            this.UpdateExternalArrows();
            //Cleans and hides the temporary layer
            this.tempLayer.ClearAndHide();
            //To be able to update the layer of the diagram, you need to deselect all the elements
            foreach (GraphElement element in this.selectLayer.Elements)
                element.Selected = false;
            //The diagram layer is updated
            this.diagramLayer.UpdateSurface();
            //All items are re-set as selected
            foreach (GraphElement element in this.selectLayer.Elements)
                element.Selected = true;
            //The selection layer is updated
            this.selectLayer.UpdateSurface();
            //The cursor is updated by default
            if ((Cursor.Current != Cursors.Hand) && (this.CursorChanged != null))
                this.CursorChanged(this, new CursorEventArgs(Cursors.Hand));
            if (this.DiagramChanged != null)
                this.DiagramChanged(this, new EventArgs());
            if (this.OperationFinished != null)
                this.OperationFinished(this, new OperationEventArgs(Operation.DragDrop));
        }

        public void PreCancel()
        {
            this.opPrecanceled = true;
            this.tempLayer.Visible = false;
            this.tempLayer.UpdateSurface();
            //The cursor is updated by default
            if (this.CursorChanged != null)
                this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
        }

        public void Cancel()
        {
            foreach (GraphElement element in this.tempLayer.Elements)
                element.Center = (Point)this.initLocations[element];
            this.tempLayer.ClearAndHide();
            this.tempLayer.UpdateSurface();
            //The cursor is updated by default
            if ((Cursor.Current != Cursors.Default) && (this.CursorChanged != null))
                this.CursorChanged(this, new CursorEventArgs(Cursors.Default));
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.DragDrop));
        }

        /// <summary>
        /// You lose the input focus of the diagram about the operation is
        /// </summary>
        public void LostFocus() { }

        public void EnablePaste() { }

        public void Undo()
        {
            foreach (GraphElement element in this.initLocations.Keys)
                element.Center = (Point)this.initLocations[element];
            foreach (GraphArrow arrow in this.externalArrows.Keys)
                arrow.UpdateArrow((List<Point>)this.externalArrows[arrow]);
            this.diagramLayer.UpdateSurface();
        }

        public void Redo() { }

        #endregion

        #region Private methods

        private void LoadTempLayer()
        {
            //The list of selected items is traversed to move the selected items and affected arrows to the temporal layer
            //You look only at the next element because you have to be selected the previous and the next element of the arrow
            foreach (GraphElement element in this.selectLayer.Elements)
            {
                if (element is GraphConditional)
                {
                    this.tempLayer.AddElement(element);
                    if (this.IsIntermediateArrow((GraphArrow)((GraphConditional)element).NextTrue))
                        this.tempLayer.AddElement(((GraphConditional)element).NextTrue);
                    if (this.IsIntermediateArrow((GraphArrow)((GraphConditional)element).NextFalse))
                        this.tempLayer.AddElement(((GraphConditional)element).NextFalse);
                }
                else if ((element is GraphModule) || (element is GraphStart))
                {
                    this.tempLayer.AddElement(element);
                    if (this.IsIntermediateArrow((GraphArrow)element.Next))
                        this.tempLayer.AddElement(element.Next);
                }
                else if (element is GraphFinish)
                    this.tempLayer.AddElement(element);
            }
        }

        private bool IsIntermediateArrow(GraphArrow arrow)
        {
            if ((arrow != null) && (arrow.Next != null) && (arrow.Next.Selected == true))
                return true;
            else
                return false;
        }

        private void RelocateElements(Point point)
        {
            //You get the displacement (the roundings are for the effect to be better)
            int xDisplacement = (int)(Math.Round((double)(point.X - this.initMouseLocation.X) / 16) * 16);
            int yDisplacement = (int)(Math.Round((double)(point.Y - this.initMouseLocation.Y) / 18) * 18);
            foreach (GraphElement element in this.tempLayer.Elements)
                element.Center = new Point(((Point)this.initLocations[element]).X + xDisplacement, ((Point)this.initLocations[element]).Y + yDisplacement);
        }

        /// <summary>
        /// Validates the location of the GraphElement in the diagram layer
        /// </summary>
        /// <returns></returns>
        private bool ValidateLocation()
        {
            foreach (GraphElement element in this.diagramLayer.Elements)
                if (!this.selectLayer.Elements.Contains(element))
                    if (this.selectLayer.IntersectsWith(element))
                        return false;
            foreach (GraphElement element in this.selectLayer.Elements)
                if ((element.Left <= 0) || (element.Right >= this.diagramLayer.Surface.Width) || (element.Top <= 0) || (element.Bottom >= this.diagramLayer.Surface.Height))
                    return false;
            return true;
        }

        private void UpdateExternalArrows()
        {
            GridPoint[,] gridPoints = this.diagramLayer.GetGridPoints();
            foreach (GraphElement element in this.tempLayer.Elements)
            {
                if (element is GraphConditional)
                {
                    if ((((GraphConditional)element).NextTrue != null) && (!this.tempLayer.Elements.Contains(((GraphConditional)element).NextTrue)))
                    {
                        this.externalArrows.Add((GraphArrow)((GraphConditional)element).NextTrue, ((GraphArrow)((GraphConditional)element).NextTrue).Locations);
                        ((GraphArrow)((GraphConditional)element).NextTrue).UpdateArrow(gridPoints);
                    }
                    if ((((GraphConditional)element).NextFalse != null) && (!this.tempLayer.Elements.Contains(((GraphConditional)element).NextFalse)))
                    {
                        this.externalArrows.Add((GraphArrow)((GraphConditional)element).NextFalse, ((GraphArrow)((GraphConditional)element).NextFalse).Locations);
                        ((GraphArrow)((GraphConditional)element).NextFalse).UpdateArrow(gridPoints);
                    }
                }
                else if ((element is GraphModule) || (element is GraphStart))
                {
                    if ((element.Next != null) && (!this.tempLayer.Elements.Contains(element.Next)))
                    {
                        this.externalArrows.Add((GraphArrow)element.Next, ((GraphArrow)element.Next).Locations);
                        ((GraphArrow)element.Next).UpdateArrow(gridPoints);
                    }
                }
                if ((element is GraphConditional) || (element is GraphModule) || (element is GraphFinish))
                {
                    foreach (GraphElement prev in element.Previous)
                        if (!this.tempLayer.Elements.Contains(prev))
                        {
                            this.externalArrows.Add((GraphArrow)prev, ((GraphArrow)prev).Locations);
                            ((GraphArrow)prev).UpdateArrow(gridPoints);
                        }
                }
            }
        }

        #endregion

    }
}
