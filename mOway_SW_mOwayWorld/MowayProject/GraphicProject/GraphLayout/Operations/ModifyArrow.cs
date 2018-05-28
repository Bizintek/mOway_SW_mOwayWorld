using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Moway.Project.GraphicProject.GraphLayout.Elements;

namespace Moway.Project.GraphicProject.GraphLayout.Operations
{
    public class ModifyArrow : IOperation
    {
        #region Enumerate

        private enum Movement { Horizontal, Vertical }

        #endregion

        #region Attributes

        private GraphLayer diagramLayer;
        private GraphLayer tempLayer;
        private GraphArrow graphArrow;
        private LineSegment segment;
        private Movement movement;
        private Cursor cursor;

        private TempGraphArrow tempGraphArrow = new TempGraphArrow();
        private GridPoint[,] gridStatus;
        private List<Point> points = new List<Point>();
        private List<Point> locations = new List<Point>();

        #endregion

        #region Properties

        public event EventHandler DiagramChanged { add { } remove { } }
        /// <summary>
        /// Contextual menu for the operation
        /// </summary>
        public ContextMenu ContextMenu { get { return null; } }
        public Cursor InitCursor { get { return this.cursor; } }
        /// <summary>
        /// The initial position about the MouseButtonDown event has run
        /// </summary>
        public Point InitMouseDownLocation { get { return new Point(-1, -1); } }

        #endregion

        #region Events

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

        public ModifyArrow(GraphLayer diagramLayer, GraphLayer tempLayer, Point initialLocation)
        {
            this.diagramLayer = diagramLayer;
            this.tempLayer = tempLayer;
            this.graphArrow = (GraphArrow)this.tempLayer.Elements[0];
            this.segment = (LineSegment)this.graphArrow.GetSegment(initialLocation);
            this.graphArrow.DisableModifiers();
            this.gridStatus = this.diagramLayer.GetGridPoints();

            if (this.segment.Modifier is VerticalModifier)
            {
                this.movement = Movement.Vertical;
                this.cursor = Cursors.VSplit;
            }
            else
            {
                this.movement = Movement.Horizontal;
                this.cursor = Cursors.HSplit;
            }

            this.tempLayer.Clear();
            this.tempLayer.Add(this.tempGraphArrow);
            this.tempLayer.Visible = true;
            this.tempLayer.UpdateSurface();
        }

        #region Methods to implement the IOperation interface

        public void MouseEnter()
        {
            this.tempLayer.Visible = true;
            this.tempLayer.UpdateSurface();
        }

        public void MouseLeave()
        {
            this.tempLayer.Visible = true;
            this.tempLayer.UpdateSurface();
        }

        public void MouseMove(MouseEventArgs e)
        {
            if (this.movement == Movement.Horizontal)
            {
                int yLocation = (int)(Math.Round((double)(e.Location.Y - 9) / 18) * 18) + 8;
                this.points = new List<Point>() { this.segment.StartPoint, new Point(this.segment.StartPoint.X, yLocation), new Point(this.segment.EndPoint.X, yLocation), this.segment.EndPoint };
            }
            else
            {
                int xLocation = (int)(Math.Round((double)(e.Location.X - 8) / 16) * 16) + 7;
                this.points = new List<Point>() { this.segment.StartPoint, new Point(xLocation, this.segment.StartPoint.Y), new Point(xLocation, this.segment.EndPoint.Y), this.segment.EndPoint };
            }
            this.tempGraphArrow.UpdateArrow(points, GraphDiagram.SELECTED_COLOR);
            if (this.ValidateTempSegments(points))
            {
                if ((Cursor.Current != this.cursor) && (this.CursorChanged!=null))
                    this.CursorChanged(this, new CursorEventArgs(this.cursor));
            }
            else
            {
                if ((Cursor.Current != Cursors.No) && (this.CursorChanged != null))
                    this.CursorChanged(this, new CursorEventArgs(Cursors.No));
            }
            this.tempLayer.UpdateSurface();
        }

        public void MouseDown(MouseEventArgs e) { }

        public void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.movement == Movement.Horizontal)
                {
                    int yLocation = (int)(Math.Round((double)(e.Location.Y - 9) / 18) * 18) + 8;
                    this.points = new List<Point>() { this.segment.StartPoint, new Point(this.segment.StartPoint.X, yLocation), new Point(this.segment.EndPoint.X, yLocation), this.segment.EndPoint };
                }
                else
                {
                    int xLocation = (int)(Math.Round((double)(e.Location.X - 8) / 16) * 16) + 7;
                    this.points = new List<Point>() { this.segment.StartPoint, new Point(xLocation, this.segment.StartPoint.Y), new Point(xLocation, this.segment.EndPoint.Y), this.segment.EndPoint };
                }
                this.Do();
            }
        }

        public void KeyPress(Keys modifier, Keys key)
        {
            if ((modifier == Keys.None) && (key == Keys.Escape))
                this.Cancel();
        }

        public void Do() 
        {
            if (this.ValidateTempSegments(this.points))
            {
                this.locations = this.graphArrow.Locations;
                this.graphArrow.ReplaceSegment(this.segment, this.points);
                this.tempLayer.ClearAndHide();
                this.diagramLayer.UpdateSurface();
                if (this.OperationFinished != null)
                    this.OperationFinished(this, new OperationEventArgs(Operation.ModifyArrow));
            }
            else
                this.Cancel();
        }

        public void Cancel() 
        {
            this.tempLayer.ClearAndHide();
            this.tempLayer.UpdateSurface();
            if (this.OperationCanceled != null)
                this.OperationCanceled(this, new OperationEventArgs(Operation.ModifyArrow));
        }

        public void LostFocus() { }

        public void EnablePaste() { }

        public void Undo()
        {
            this.graphArrow.UpdateArrow(this.locations);
            this.diagramLayer.UpdateSurface();
        }

        public void Redo() { }

        #endregion

        #region Private methods

        private bool ValidateTempSegments(List<Point> points)
        {
            //It is validated that the new path for the arrow is correct
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (points[i].X == points[i + 1].X)
                {
                    if (points[i].Y < points[i + 1].Y)
                    {
                        for (int j = points[i].Y; j <= points[i + 1].Y; j += GraphLayer.VERTICAL_STEP)
                            if (this.gridStatus[points[i].X / GraphLayer.HORIZONTAL_STEP, j / GraphLayer.VERTICAL_STEP].State != GridState.Free)
                                return false;
                    }
                    else
                    {
                        for (int j = points[i].Y; j >= points[i + 1].Y; j -= GraphLayer.VERTICAL_STEP)
                            if (this.gridStatus[points[i].X / GraphLayer.HORIZONTAL_STEP, j / GraphLayer.VERTICAL_STEP].State != GridState.Free)
                                return false;
                    }
                }
                else
                {
                    if (points[i].X < points[i + 1].X)
                    {
                        for (int j = points[i].X; j <= points[i + 1].X; j += GraphLayer.HORIZONTAL_STEP)
                            if (this.gridStatus[j / GraphLayer.HORIZONTAL_STEP, points[i].Y / GraphLayer.VERTICAL_STEP].State != GridState.Free)
                                return false;
                    }
                    else
                    {
                        for (int j = points[i].X; j >= points[i + 1].X; j -= GraphLayer.HORIZONTAL_STEP)
                            if (this.gridStatus[j / GraphLayer.HORIZONTAL_STEP, points[i].Y / GraphLayer.VERTICAL_STEP].State != GridState.Free)
                                return false;
                    }
                }
            }
            return true;
        }

        #endregion
    }
}
